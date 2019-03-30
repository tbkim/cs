using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace TextMover
{
    public partial class FormMain : Form
    {
        private System.Threading.Timer threadingTimer = null;
        private System.Timers.Timer timer = null;
        private Info info = new Info(); //!< 정보 인스턴스
        private DateTime dateTime = DateTime.Now; //!< 문자 옮기기 버튼 클릭 시간
        private const int count = 50; //!< 문자를 옮길 수 있는 최대 횟수

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
            initListView();
            initComboBox();
            initProgressBar();
            timerWinform.Interval = 1000;
            deleteLogFile();
        }

        private void registEvent()
        {
            btnMoveTxt.Click += btnMoveTxt_Click;
            btnClearView.Click += btnClearView_Click;
            timerWinform.Tick += timerWinform_tick;
        }

        private void initListView()
        {
            listViewInfo.View = View.Details;
            listViewInfo.Columns.Add("보낸문자", 60, HorizontalAlignment.Left);
            listViewInfo.Columns.Add("지연시간", 60, HorizontalAlignment.Left);
            listViewInfo.Columns.Add("타이머타입", 100, HorizontalAlignment.Left);
        }

        private void initComboBox()
        {
            //! 타이머 타입 enum을 순회하여 comboBox에 추가
            foreach (TimerType timerType in (TimerType[])Enum.GetValues(typeof(TimerType)))
            {
                comboBoxThreadType.Items.Add(timerType);
            }
            comboBoxThreadType.SelectedIndex = (int)TimerType.WindowsForms; //!< 선택 값을 "WindowsForms"으로 
        }

        private void initProgressBar()
        {
            progressBar1.Style = ProgressBarStyle.Continuous; //!< 프로그레스바 스타일을 연속막대로
            progressBar1.Step = 1; //!< 스탭마다 증가시킬 값
        }

        private void deleteLogFile()
        {
            try
            {
                string logFilePath = Application.StartupPath + "\\Logs.txt";
                System.IO.FileInfo fi = new System.IO.FileInfo(logFilePath);
                if (fi.Exists)
                {
                    fi.Delete();
                }
            }
            catch (System.IO.IOException e)
            {
                MessageBox.Show(e.Message, "에러");
            }
        }

        private void btnMoveTxt_Click(object sender, EventArgs e)
        {
            if (listViewInfo.Items.Count >= count)
            {
                MessageBox.Show("문자는 " + count + "번까지만 옮길 수 있습니다.", "알림");
                return;
            }

            progressBar1.Value = 0; //!< 프로그레스바 현재 값 초기화(=빈 값으로)
            enabledControl(false);

            info.TextSend = this.txtBoxSend.Text; //!< 정보 인스턴스에 옮길 문자 set
            info.Delay = numericUpDownTimeDelay.Value; //!< 정보 인스턴스에 딜레이 값 set
            
            //! 정보 인스턴스에 타이머 타입 값 set
            info.TimerType = ((TimerType)comboBoxThreadType.SelectedIndex);

            if (info.Delay == 0) { progressBar1.Maximum = 1; } //!< delay가 0일 때, 프로그레스바 최대 값을 1로
            else { progressBar1.Maximum = (int)info.Delay; } //!< 프로그레스바 최대 값을 delay 값으로

            //! 지연시간 기능을 실행할 때 사용할 Timer를 선택하여 실행
            dateTime = DateTime.Now;
            switch ((TimerType)comboBoxThreadType.SelectedItem)
            {
                case TimerType.WindowsForms:
                    moveTextWinFormsTimer(); //!< 윈폼 타이머를 이용하여 문자 옮기기 기능 실행
                    break;
                case TimerType.Threading:
                    moveTextThreadingTimer(); //!< 쓰레딩 타이머를 이용하여 문자 옮기기 기능 실행
                    break;
                case TimerType.Timers:
                    moveTextTimer(); //!< 시스템 타이머를 이용하여 문자 옮기기 기능 실행
                    break;
            }
        }

        private void btnClearView_Click(object sender, EventArgs e)
        {
            listViewInfo.Items.Clear();
            writeLog("리스트 지우기");
        }

        private void timerWinform_tick(object sender, EventArgs e)
        {
            work();
        }

        private void work()
        {
            progressBar1.PerformStep(); //!< 프로그레스바 진행을 스탭만큼 증가

            TimeSpan diff = DateTime.Now - dateTime; //!< 현재시간 - 버튼클릭시간 = 시간간격
            
            //! 시간간격이 딜레이시간보다 같거나 작으면 return
            if ((decimal)diff.Seconds <= info.Delay) { return; } 

            try
            {
                sendTxt(info); //!< text 옮기기(보내기)
                addInfo2View(info); //!< 정보를 listView에 추가하고, 표시
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "에러");
            }
            finally
            {
                switch (info.TimerType)
                {
                    case TimerType.WindowsForms:
                        timerWinform?.Stop(); //!< 윈폼타이머 중지
                        break;
                    case TimerType.Threading:
                        threadingTimer?.Dispose(); //!< 타이머 리소스 해제
                        break;
                    case TimerType.Timers:
                        timer?.Stop();
                        timer?.Dispose();
                        break;
                    default:
                        break;
                }
                enabledControl(true);
            }
        }

        private void moveTextWinFormsTimer()
        {
            timerWinform.Start();
        }

        private void moveTextThreadingTimer()
        {
            const int delayStart = 1000; //!< delayStart는 시작 지연시간, 밀리세컨드
            const int period = 1000; //!< period는 callback 호출 시간 간격, 밀리세컨드
            threadingTimer = new System.Threading.Timer(timerCallback, null, delayStart, period); 
        }

        private delegate void TimerEventDelegate();

        private void timerCallback(Object state)
        {
            //! 컨트롤의 내부 핸들이 작성된 스레드에서 지정된 대리자를 비동기식으로 실행
            BeginInvoke(new TimerEventDelegate(work));
        }

        //! 쓰레드풀의 작업쓰레드가 지정된 시간 간격으로 아래 이벤트 핸들러 실행
        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            BeginInvoke(new TimerEventDelegate(work));
        }
        
        //! System.Timer를 이용하여 문자 옮기기 기능 실행
        private void moveTextTimer()
        {
            timer = new System.Timers.Timer();
            timer.Elapsed -= timer_Elapsed; //!< 이벤트 등록 해제
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed); //!< 이벤트 등록
            timer.Interval = 1000;
            timer.Start();
        }

        //! UI 콘트롤 수정 여부 변경
        private void enabledControl(bool enabled)
        {
            txtBoxSend.Enabled = enabled;
            btnMoveTxt.Enabled = enabled;
            numericUpDownTimeDelay.Enabled = enabled;
            comboBoxThreadType.Enabled = enabled;
        }

        //! 문자 옮기기(보내기)
        private void sendTxt(Info info)
        {
            this.txtBoxRecv.Text = info.TextSend;
            writeLog("send text");

            txtBoxSend.Text = string.Empty; //!< 보내기 텍스트박스 초기화
            writeLog("보내기 텍스트박스 초기화");
        }

        //! listView에 정보를 추가하고 갱신
        private void addInfo2View(Info info)
        {
            //! 리스트뷰 아이템을 업데이트 하기 시작, 끝날 때까지 UI갱신 중지
            listViewInfo.BeginUpdate();

            //! textSend별로 ListViewItem객체 하나씩 만듦. textSend 항목 값 추가
            ListViewItem lvi = new ListViewItem(info.TextSend);
             
            lvi.SubItems.Add(info.Delay.ToString());//!< 지연시간 항목 값 추가
            lvi.SubItems.Add(info.TimerType.ToString());
            listViewInfo.Items.Add(lvi);

            listViewInfo.EndUpdate();
            writeLog("정보를 VIEW에 갱신");

            //! 리스트뷰 마지막 아이템 자동스크롤
            listViewInfo.EnsureVisible(listViewInfo.Items.Count - 1);

            string logMsg = "정보기록 "
                + "보낸문자 : " + info.TextSend
                + " 지연시간 : " + info.Delay.ToString()
                + " 타이머타입 : " + info.TimerType;
            writeLog(logMsg);
        }

        //! 로그 쓰기
        private void writeLog(string msg)
        {
            TextWriterTraceListener twtl = null;
            try
            {
                twtl = new TextWriterTraceListener("Logs.txt");

                Trace.Listeners.Clear();
                Trace.Listeners.Add(twtl); //!< 스트림을 파일에 쓰도록 리스너 추가
                Trace.AutoFlush = true; //!< flush(버퍼에서 스트림으로 쓰기 작업)을 자동으로
                Trace.Write(DateTime.Now);
                Trace.Write(" "); //!< 날짜와 msg 구분자를 한칸(" ")으로 
                Trace.WriteLine(msg); //!< 로그를 하나를 쓰면 다음 줄로
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
            public string TextSend
            {
                get { return textSend; }
                set { textSend = value; }
            }

            private decimal delay = 0; //!< 문자를 옮길(보낼) 때 지연시간
            public decimal Delay
            {
                get { return delay; }
                set { delay = value; }
            } 

            private TimerType timerType = TimerType.WindowsForms; //<! 콤보박스로 선택한 타이머의 타입
            public TimerType TimerType
            {
                get { return timerType; }
                set { timerType = value; }
            }
        }
        
        //! comboBox 아이템이면서 타이머의 종류를 나타냄
        public enum TimerType
        {
            WindowsForms = 0, //!< System.Windows.Forms.Timer
            Threading = 1, //!< System.Threading.Timer
            Timers = 2, //!< System.Timer
        }
    }
}
