using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NumberBlockSorting.Functions;

namespace NumberBlockSorting.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load logo
            string logoPath = "logo.png"; // Adjust path if necessary
            if (File.Exists(logoPath))
            {
                var logoImage = new Bitmap(logoPath);
                pictureBoxLogo.Image = new Bitmap(logoImage, new Size(250, 150));
            }

            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Text documents (.txt)|*.txt";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBoxFilePath.Text = openFileDialog.FileName;
                }
            }
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            string inputFileName = textBoxFilePath.Text;
            if (string.IsNullOrEmpty(inputFileName) || !File.Exists(inputFileName))
            {
                MessageBox.Show("Please select a valid file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FileSort fileSort = new ();
            var phoneNumbers = fileSort.ReadPhoneNumbersFromFile(inputFileName);
            var consecutiveSequences = fileSort.FindConsecutiveNumbers(phoneNumbers);
            MessageBox.Show(string.Join(Environment.NewLine, consecutiveSequences), "Consecutive Numbers", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}