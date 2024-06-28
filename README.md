# Number Block Sorting Software

## Description

This is a simple code intended for sorting a listing of numbers and finding which block they belong to, if they are part of a order block.

For those who aren't around the VoIP business, thats fine, I will give you a brief explenation. When you get a number from a provider, you basically order a number from them. _This number gets determined by the governing body_ (In Germany the BNA) and when verified you receive it. In that same way, busineeses can order multiple "blocks" of numbers. A block basically just means that that the last digits follow. So a 10 block would have a traling 90 - 99.

## Usage

- \_ -

## Notes

If you want to edit it to accept different file types, got to the __buttonBrowse_Click__ method:

```c#
    openFileDialog.Filter = "Text documents (.txt)|*.txt";
    if (openFileDialog.ShowDialog() == DialogResult.OK)
    {
        textBoxFilePath.Text = openFileDialog.FileName;
    }
```


The software has the function t have your logo be displayed. You can edit it here in the __MainForm_Load__ method:

```c#
        string logoPath = "logo.png";
            if (File.Exists(logoPath))
            {
                var logoImage = new Bitmap(logoPath);
                pictureBoxLogo.Image = new Bitmap(logoImage, new Size(250, 150));
            }
```

## Style

Any style changes can be made in the __MainForm.Designer.cs__ file. 