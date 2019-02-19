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

            listViewInfo.View = View.Details;
            listViewInfo.Columns.Add("보낸문자", 60, HorizontalAlignment.Left);
            listViewInfo.Columns.Add("지연시간", 60, HorizontalAlignment.Left);            
        }

        private void registEvent()
        {
            btnMoveTxt.Click += btnMoveTxt_Click;
            timerDelay.Tick += timer_tick;
        }

        private void btnMoveTxt_Click(object sender, EventArgs e)
        {
            enabledControl(false);
            
            int delay = (int)numericUpDownTimeDelay.Value * 1000; //!< 1000ms = 1s

            //! 즉시(0ms) 보내는 것과 1ms 후 보내는 것의 체감 상 차이가 없어 코드 단순화
            if (delay == 0) delay = 1;

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
            this.txtBoxRecv.Text = this.txtBoxSend.Text;
        }

        private void addInfo(Info info)
        {
            listViewInfo.BeginUpdate();

            ListViewItem lvi = new ListViewItem(info.textSend);
            lvi.SubItems.Add(info.delay.ToString());
            listViewInfo.Items.Add(lvi);

            listViewInfo.EndUpdate();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            Info info = new Info();
            try
            {
                sendTxt();
                info.textSend = this.txtBoxSend.Text;
                info.delay = numericUpDownTimeDelay.Value;
                addInfo(info);
                txtBoxSend.Text = string.Empty;

                //! 리스트뷰 마지막 아이템 자동스크롤
                listViewInfo.EnsureVisible(listViewInfo.Items.Count - 1); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "에러");
            }
            finally
            {
                timerDelay.Stop();
                enabledControl(true);
            }
        }

        private class Info
        {
            public string textSend { get; set; }
            public decimal delay { get; set; }
        }
    }
}
