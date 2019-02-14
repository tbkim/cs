using System;
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
            registEvent();

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            txtBoxRecv.Enabled = false;
            txtBoxRecv.MaxLength = 5;
            txtBoxSend.MaxLength = 5;
            txtBoxSend.TabIndex = 0;
            btnMoveTxt.TabIndex = 1;
        }

        private void registEvent()
        {
            btnMoveTxt.Click += btnMoveTxt_Click;
        }

        private void btnMoveTxt_Click(object sender, EventArgs e)
        {
            sendTxt();
        }

        private void sendTxt()
        {
            txtBoxRecv.Text = txtBoxSend.Text;
            txtBoxSend.Text = string.Empty;
        }
    }
}
