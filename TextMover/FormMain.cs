using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextMover
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            MaximizeBox = false;
            txtBoxRecv.Enabled = false;
            txtBoxRecv.MaxLength = 5;
            txtBoxSend.MaxLength = 5;
            registEvent();
        }

        private void registEvent()
        {
            btnMoveTxt.Click += btnMoveTxt_Click;
        }

        private void btnMoveTxt_Click(object sender, EventArgs e)
        {
            sendTxt(txtBoxSend, txtBoxRecv);
        }

        private void sendTxt(TextBox txtboxSend, TextBox txtboxRecv)
        {
            txtboxRecv.Text = txtboxSend.Text;
            txtboxSend.Text = null;
        }
    }
}
