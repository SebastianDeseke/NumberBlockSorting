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
            try
            {
                if (string.IsNullOrEmpty(inputFileName) || !File.Exists(inputFileName))
                {
                    MessageBox.Show("Please select a valid file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                FileSort fileSort = new();
                var phoneNumbers = FileSort.ReadPhoneNumbersFromFile(inputFileName);
                var consecutiveSequences = FileSort.FindConsecutiveNumbers(phoneNumbers);
                FileSort.outputConsecutiveSequences(consecutiveSequences, "output.txt");
                MessageBox.Show(string.Join(Environment.NewLine, consecutiveSequences), "Consecutive Numbers", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // MessageBox.Show("What would you like to name the save file?", "Save File", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Prompt user to save the file
                SaveFileDialog saveFileDialog = new()
                {
                    Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                    FileName = "output.txt"
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy("output.txt", saveFileDialog.FileName, true);
                    MessageBox.Show("File downloaded successfully.", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}