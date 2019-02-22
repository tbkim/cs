using System;
using System.Windows.Forms;
using System.Diagnostics;

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
            btnClearView.Click += BtnClearView_Click;
        }

        private void BtnClearView_Click(object sender, EventArgs e)
        {
            listViewInfo.Clear();
            listViewInfo.View = View.Details;
            listViewInfo.Columns.Add("보낸문자", 60, HorizontalAlignment.Left);
            listViewInfo.Columns.Add("지연시간", 60, HorizontalAlignment.Left);
            writeLog(new Log(DateTime.Now, "리스트 지우기"));
        }

        private void btnMoveTxt_Click(object sender, EventArgs e)
        {
            if (listViewInfo.Items.Count >= 50)
            {
                MessageBox.Show("문자는 50번까지만 옮길 수 있습니다.", "알림");
                return;
            }

            enabledControl(false);
            
            int delay = (int)numericUpDownTimeDelay.Value * 1000; //!< 1000ms = 1s

            //! 즉시(0ms) 보내는 것과 1ms 후 보내는 것의 체감 상 차이가 없어 코드 단순화
            if (delay == 0) delay = 1;

            timerDelay.Interval = delay;
            timerDelay.Start();
        }

        //! UI 콘트롤 수정 여부 변경
        private void enabledControl(bool enabled)
        {
            txtBoxSend.Enabled = enabled;
            btnMoveTxt.Enabled = enabled;
            numericUpDownTimeDelay.Enabled = enabled;
        }

        //! 문자 옮기기(보내기)
        private void sendTxt()
        {
            this.txtBoxRecv.Text = this.txtBoxSend.Text;
        }

        //! listView에 정보를 추가하고 갱신
        private void addInfo2View(Info info)
        {
            //! 리스트뷰 아이템을 업데이트 하기 시작, 끝날 때까지 UI갱신 중지
            listViewInfo.BeginUpdate();

            //! textSend별로 ListViewItem객체 하나씩 만듦. textSend 항목 값 추가
            ListViewItem lvi = new ListViewItem(info.textSend);
             
            lvi.SubItems.Add(info.delay.ToString());//!< 지연시간 항목 값 추가
            listViewInfo.Items.Add(lvi);

            listViewInfo.EndUpdate();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            Info info = new Info();
            try
            {
                sendTxt(); //!< text 옮기기(보내기)
                writeLog(new Log(DateTime.Now, "send text"));

                info.textSend = this.txtBoxSend.Text; //!< 정보 기록
                info.delay = numericUpDownTimeDelay.Value; //!< 정보 기록
                writeLog(new Log(DateTime.Now, "정보기록"));

                addInfo2View(info); //!< 정보를 listView에 추가하고, 표시
                writeLog(new Log(DateTime.Now, "정보를 VIEW에 갱신"));

                txtBoxSend.Text = string.Empty; //!< 보내기 텍스트박스 초기화
                writeLog(new Log(DateTime.Now, "보내기 텍스트박스 초기화"));

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

        //! 로그 쓰기
        private void writeLog(Log log)
        {   
            Trace.Listeners.Clear();
            using (TextWriterTraceListener twtl = new TextWriterTraceListener("Logs.txt"))
            {
                Trace.Listeners.Add(twtl); //!< 스트림을 파일에 쓰도록 리스너 추가
                Trace.AutoFlush = false; //!< flush(버퍼에서 스트림으로 쓰기 작업)을 수동으로
                Trace.Write(log.time.ToString());
                Trace.Write(" "); //!< 날짜와 msg 구분자를 한칸(" ")으로 
                Trace.WriteLine(log.msg); //!< 로그를 하나를 쓰면 다음 줄로
                Trace.Flush(); //!< 버퍼에 있는 것을 스트림으로 쓰기
            }
        }

        //! 정보 클래스
        private class Info
        {
            public string textSend { get; set; } //!< 옮긴(보낸) 문자
            public decimal delay { get; set; } //!< 문자를 옮길(보낼) 때 지연시간
        }

        //! 로그 클래스
        private class Log
        {
            public DateTime time;
            public string msg;

            public Log(DateTime time, string msg)
            {
                this.time = time;
                this.msg = msg;
            }
        }
    }
}
