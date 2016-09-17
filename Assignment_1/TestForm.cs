using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using Assignment_1.IO;

namespace Assignment_1
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }

        private void TestForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            var filterString = "";
            if (Xml.Checked)
                filterString = @"XML files (*.xml)|*.xml";
            else
                filterString = @"Json files (*.json)|*.json";

            OpenFileDialog dlg = new OpenFileDialog
            {
                DefaultExt = "txt",
                Filter = filterString,
                Multiselect = false
            };
            DialogResult result = dlg.ShowDialog();

            if (result == DialogResult.OK)
                inputFilename.Text = dlg.FileName;
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputFilename.Text))
            {
                MessageBox.Show(@"Input filename cannot be empty");
                return;
            }

            if (!File.Exists(inputFilename.Text))
            {
                MessageBox.Show(@"Input file must exist");
                return;
            }

            LoadSaveStrategy storageStrategy = null;
            if (Xml.Checked)
                storageStrategy = new XmlLoadSave();
            else
                storageStrategy = new JsonLoadSave();

            // Run the analyzer
            string stringPath = Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
            using(System.IO.StreamWriter file = new System.IO.StreamWriter(stringPath + @"\matchAssignment.txt"))
            {
                file.WriteLine("Matched pairs");
            }
            Console.WriteLine("Matched pairs");
            MatchAlgorithms m1 = new MatchingStrategy1();
            MatchAlgorithms m2 = new MatchingStrategy2();
            MatchAlgorithms m3 = new MatchingStrategy3();
            MatchAlgorithms m4 = new MatchingStrategy4();
            MatchAlgorithms m5 = new MatchingStrategy5();
            m1.Storage = storageStrategy;
            m1.InputFile = inputFilename.Text;
            Console.WriteLine("Matches using first algorithm: ");
            m1.isAMatch();

            m2.Storage = storageStrategy;
            m2.InputFile = inputFilename.Text;
            Console.WriteLine("\nMatches using second algorithm: ");
            m2.isAMatch();

            m3.Storage = storageStrategy;
            m3.InputFile = inputFilename.Text;
            Console.WriteLine("\nMatches using third algorithm: ");
            m3.isAMatch();

            m4.Storage = storageStrategy;
            m4.InputFile = inputFilename.Text;
            Console.WriteLine("\nMatches using fourth algorithm: ");
            m4.isAMatch();

            m5.Storage = storageStrategy;
            m5.InputFile = inputFilename.Text;
            Console.WriteLine("\nMatches using fifth algorithm: ");
            m5.isAMatch();
        }
    }
}