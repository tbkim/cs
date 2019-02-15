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
            numericUpDownTimeDelay.Minimum = 0;
            numericUpDownTimeDelay.Maximum = 60;
        }

        private void registEvent()
        {
            btnMoveTxt.Click += btnMoveTxt_Click;
            timerDelay.Tick += timer_tick;
        }

        private void btnMoveTxt_Click(object sender, EventArgs e)
        {
            enabledControl(false);

            int delay = (int)numericUpDownTimeDelay.Value * 1000;
            if (delay == 0)
            {
                sendTxt();
                return;
            }

            timerDelay.Interval = delay;
            timerDelay.Start();
        }

        private void enabledControl(bool state)
        {
            txtBoxSend.Enabled = state;
            btnMoveTxt.Enabled = state;
            numericUpDownTimeDelay.Enabled = state;
        }

        private void sendTxt()
        {    
            txtBoxRecv.Text = txtBoxSend.Text;
            txtBoxSend.Text = string.Empty;

            enabledControl(true);
        }

        private void timer_tick(object sender, EventArgs e)
        {
            sendTxt();
            timerDelay.Stop();
        }


    }
}
