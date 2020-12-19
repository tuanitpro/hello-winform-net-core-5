﻿using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmOption : Form
    {
        public FrmOption()
        {
            InitializeComponent();
        }

        private Form1 _parentForm;

        public FrmOption(Form1 parentForm)
        {
            InitializeComponent();
            _parentForm = parentForm;
        }

        private void FrmSetup_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 31; i++)
            {
                cbbSecond.Items.Add(i.ToString());
            }

            cbbTypeOfNumber.SelectedIndex = _parentForm.TypeOfNumber;
            cbbSecond.Text = _parentForm.AutoStopSecond.ToString();
            txtFilePath.Text = _parentForm.ExcelFile;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _parentForm.TypeOfNumber = cbbTypeOfNumber.SelectedIndex;
            _parentForm.ExcelFile = txtFilePath.Text;
            _parentForm.AutoStopSecond = Convert.ToInt32(cbbSecond.Text);
            this.Close();
        }

        private void txtFilePath_MouseDown(object sender, MouseEventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog1.FileName;
            }
        }
    }
}