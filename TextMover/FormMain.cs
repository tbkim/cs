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

        ~FormMain()
        {
            Trace.Close(); //!< Flush(버퍼에 있는 것을 스트림으로 쓰기) 후 Listeners를 닫음
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
            btnClearView.Click += btnClearView_Click;
            timerDelay.Tick += timer_tick;
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

        private void btnClearView_Click(object sender, EventArgs e)
        {
            listViewInfo.Clear();
            listViewInfo.View = View.Details;
            listViewInfo.Columns.Add("보낸문자", 60, HorizontalAlignment.Left);
            listViewInfo.Columns.Add("지연시간", 60, HorizontalAlignment.Left);
            writeLog(new Log(DateTime.Now, "리스트 지우기"));
        }

        private void timer_tick(object sender, EventArgs e)
        {
            Info info = new Info();
            try
            {
                sendTxt(); //!< text 옮기기(보내기)
                writeLog(new Log(DateTime.Now, "send text"));

                info.setTextSend(this.txtBoxSend.Text); //!< 정보 기록
                info.setDelay(numericUpDownTimeDelay.Value); //!< 정보 기록
                string logMsg = "정보기록 "
                    + "보낸문자 : " + info.getTextSend()
                    + " 지연시간 : " + info.getDelay().ToString();
                writeLog(new Log(DateTime.Now, logMsg));

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
            ListViewItem lvi = new ListViewItem(info.getTextSend());
             
            lvi.SubItems.Add(info.getDelay().ToString());//!< 지연시간 항목 값 추가
            listViewInfo.Items.Add(lvi);

            listViewInfo.EndUpdate();
        }

        //! 로그 쓰기
        private void writeLog(Log log)
        {
            TextWriterTraceListener twtl = null;
            try
            {
                twtl = new TextWriterTraceListener("Logs.txt");

                Trace.Listeners.Clear();
                Trace.Listeners.Add(twtl); //!< 스트림을 파일에 쓰도록 리스너 추가
                Trace.AutoFlush = true; //!< flush(버퍼에서 스트림으로 쓰기 작업)을 자동으로
                Trace.Write(log.getTime().ToString());
                Trace.Write(" "); //!< 날짜와 msg 구분자를 한칸(" ")으로 
                Trace.WriteLine(log.getMsg()); //!< 로그를 하나를 쓰면 다음 줄로
                Trace.Flush(); //!< 버퍼에서 스트림으로 쓰기 작업
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "오류");
            }
            finally
            {
                twtl?.Dispose();
            }          
        }

        //! 정보 클래스
        private class Info
        {
            private string textSend = string.Empty; //!< 옮긴(보낸) 문자
            private decimal delay = 0; //!< 문자를 옮길(보낼) 때 지연시간

            public void setTextSend(string textSend)
            {
                this.textSend = textSend;
            }

            public string getTextSend()
            {
                return textSend;
            }

            public void setDelay(decimal delay)
            {
                this.delay = delay;
            }

            public decimal getDelay()
            {
                return delay;
            }
        }

        //! 로그 클래스
        private class Log
        {
            private DateTime time = DateTime.Now;
            private string msg = string.Empty;

            public Log(DateTime time, string msg)
            {
                this.time = time;
                this.msg = msg;
            }

            public DateTime getTime()
            {
                return time;
            }

            public string getMsg()
            {
                return msg;
            }
        }
    }
}
