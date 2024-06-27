using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using NumberBlockSorting.Functions;
using NumberBlockSorting.Views;

namespace NumberBlockSorting
{
    class Program
    {
        //necessary for using Windows Forms in cosole application
            [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Views.MainForm());
        }
        }
}