using System;
using System.Windows.Forms;

namespace TextMover
{
    public partial class FormMain : Form
    {
        Log log = new Log();

        public FormMain()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            registEvent();

            listViewLog.View = View.Details;
            listViewLog.Columns.Add("보낸문자", 60, HorizontalAlignment.Left);
            listViewLog.Columns.Add("지연시간", 60, HorizontalAlignment.Left);
            listViewLog.Columns.Add("실행시간", 120, HorizontalAlignment.Left);
            listViewLog.Columns.Add("완료시간", 120, HorizontalAlignment.Left);
            listViewLog.Columns.Add("에러여부", 60, HorizontalAlignment.Left);
        }

        private void registEvent()
        {
            btnMoveTxt.Click += btnMoveTxt_Click;
            timerDelay.Tick += timer_tick;
        }

        private void btnMoveTxt_Click(object sender, EventArgs e)
        {
            log.timeExcute = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            enabledControl(false);
            
            int delay = (int)numericUpDownTimeDelay.Value * 1000;
            if (delay == 0) delay = 1;

            log.delay = (numericUpDownTimeDelay.Value).ToString();

            timerDelay.Interval = delay;
            timerDelay.Start();
        }

        private void enabledControl(bool enabled)
        {
            txtBoxSend.Enabled = enabled;
            btnMoveTxt.Enabled = enabled;
            numericUpDownTimeDelay.Enabled = enabled;
        }

        private void sendTxt()
        {
            txtBoxRecv.Text = txtBoxSend.Text;
            log.txtSend = txtBoxSend.Text;
            txtBoxSend.Text = string.Empty;
        }

        private void addLog()
        {
            listViewLog.BeginUpdate();

            ListViewItem lvi = new ListViewItem(log.txtSend);
            lvi.SubItems.Add(log.delay);
            lvi.SubItems.Add(log.timeExcute);
            lvi.SubItems.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lvi.SubItems.Add(log.err);
            listViewLog.Items.Add(lvi);

            listViewLog.EndUpdate();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            try
            {
                sendTxt();
            }
            catch (Exception ex)
            {
                log.err = "에러";
                MessageBox.Show(ex.Message, "에러");
            }
            finally
            {
                addLog();
                timerDelay.Stop();
                enabledControl(true);
            }
        }
    }

    public struct Log
    {
        public string txtSend;
        public string delay;
        public string timeExcute;
        public string err;
    }
}
