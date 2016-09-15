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
            MatchAlgorithms m1 = new MatchingStrategy1();
            m1.Storage = storageStrategy; // storageStrategy;
            m1.InputFile = inputFilename.Text;
            Console.WriteLine(m1.isAMatch());

            //// Display the result;
            //beginningBalance.Text = FormatToDollars(analyzer.BeginningTotal);
            //endingBalance.Text = FormatToDollars(analyzer.EndingTotal);
            //interestPaid.Text = FormatToDollars(analyzer.InterestPaid);
            //feesCollected.Text = FormatToDollars(analyzer.FeesCollected);
        }
    }
}