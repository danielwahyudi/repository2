using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace XMLProcessWinForm
{
    /* Desktop application to read a collection of XML files and render them into HTML pages.
     * Created by Daniel Wahyudi
    */
    public partial class Form1 : Form
    {
        // XSLT file location. Defined in App.config settings file so the location can be changed without recompiling the application.
        string xsltFilePath = System.Configuration.ConfigurationManager.AppSettings.Get("xsltFilePath");

        static Queue queue = Queue.Synchronized(new Queue());

        private delegate void DisplayOutputDelegate(string message);
        private delegate void EnableButtonDelegate();

        private void DisplayOutput(string message)
        {
            tbOutput.Text += message;
        }

        private void EnableButton()
        {
            btnSubmit.Enabled = true;
        }

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Select a folder where the XML source files are located
        /// </summary>
        private void btnSelectXMLSource_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);                

                lblXMLSource.Text = folderBrowserDialog1.SelectedPath;
                lblXMLNumFiles.Text = files.Length.ToString() + " file(s) found.";

                btnSelectOutputFolder.Enabled = true;
            }
        }

        /// <summary>
        /// Set the folder where the HTML files will be generated.
        /// </summary>
        private void btnSelectOutputFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog2.ShowDialog();
            lblOutputFolder.Text = folderBrowserDialog2.SelectedPath;
            btnSubmit.Enabled = true;
        }

        /// <summary>
        /// Reads all the XML files in the "source" folder and put the XML contents in the queue.
        /// </summary>
        private void ReadXMLFile()
        {
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(lblXMLSource.Text);
                FileInfo[] xmlFiles = directoryInfo.GetFiles("*.xml");
                string tmpContents = string.Empty;

                // Put the XML files in a queue
                for (int i = 0; i < xmlFiles.Count(); i++)
                {
                    tbOutput.Invoke(new DisplayOutputDelegate(DisplayOutput), string.Format("Reading {0}...{1}", xmlFiles[i].Name, Environment.NewLine));                    

                    using (FileStream fileStream = File.OpenRead(xmlFiles[i].FullName))
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        memoryStream.SetLength(fileStream.Length);
                        // Read file contents to memory stream object
                        fileStream.Read(memoryStream.GetBuffer(), 0, (int)fileStream.Length);
                        queue.Enqueue(memoryStream);

                        tbOutput.Invoke(new DisplayOutputDelegate(DisplayOutput), "Reading XML completed." + Environment.NewLine);

                        Thread.Sleep(1000);
                    }
                }

                // Enable "Submit" button after process is completed
                btnSubmit.Invoke(new EnableButtonDelegate(EnableButton));

                MessageBox.Show("Process completed.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Gets all the XML files contents from the queue and creates the HTML file.
        /// </summary>
        private void GenerateHTMLFile()
        {            
            try
            {
                int i = 0;  // For HTML filename

                while (true)
                {
                    if (queue.Count > 0)
                    {
                        string htmlFullFileName = string.Format("{0}\\ComputerReport_{1}.html", lblOutputFolder.Text, i + 1);
                        tbOutput.Invoke(new DisplayOutputDelegate(DisplayOutput), string.Format("Generating {0}...{1}", htmlFullFileName, Environment.NewLine));

                        // Get the XSLT template
                        XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
                        xslCompiledTransform.Load(xsltFilePath);

                        // Use StringBuilder object to hold HTML data and creates TextWriter object to hold data from xslCompiledTransform
                        StringBuilder sbHtmlOutput = new StringBuilder();
                        TextWriter textWriter = new StringWriter(sbHtmlOutput);

                        // Create XmlReader object to read XML content                           
                        MemoryStream memoryStream = (MemoryStream)queue.Dequeue();
                        XmlReader reader = XmlReader.Create(memoryStream);

                        // Create HTML string and write in TextWriter object.    
                        xslCompiledTransform.Transform(reader, null, textWriter);

                        // Create HTML page
                        File.WriteAllText(htmlFullFileName, sbHtmlOutput.ToString());

                        tbOutput.Invoke(new DisplayOutputDelegate(DisplayOutput), "HTML page created." + Environment.NewLine);

                        Thread.Sleep(100);
                        i++;
                    }                                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            btnSubmit.Enabled = false;

            try
            {
                // The first thread. Read sequentially through the XML files and put their contents on the queue.
                Thread producer = new Thread(() =>
                {
                    ReadXMLFile();
                });

                // The second thread. Read from the queue and render the XML to HTML.
                Thread consumer = new Thread(() =>
                {
                    GenerateHTMLFile();
                });
                consumer.IsBackground = true;

                // Start the threads
                consumer.Start();
                producer.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
