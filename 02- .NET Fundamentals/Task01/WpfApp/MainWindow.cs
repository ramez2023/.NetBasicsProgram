﻿using HelperClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfApp
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            string title = "Welcome";
            string name = nameTextBox.Text;
            string erroressage = string.Concat(Helper.GetErrorMessage(), ".");

            if (string.IsNullOrWhiteSpace(name))
                MessageBox.Show(erroressage, title);
            else
                MessageBox.Show(Helper.GetRichName(name), title);
        }

    }
}
