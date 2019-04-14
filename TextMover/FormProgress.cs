using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace TextMover
{
    public partial class FormProgress : Form
    {
        Info info = null;
        public Controller controller = new Controller();
        Queue<string> qStr = new Queue<string>();

        DateTime dateTime = DateTime.Now; 
        public FormProgress(Info info)
        {
            InitializeComponent();
            init();
            this.info = info;
            setProgressBar();
            timer1.Interval = calculrateInterval();
            dateTime = DateTime.Now; //!< FormProgress 생성 시간
            makeQTextSend(info);
            timer1.Start();
        }

        private void init()
        {
            registEvent();
        }

        private void registEvent()
        {
            timer1.Tick += timerWinform_tick;
        }

        private void timerWinform_tick(object sender, EventArgs e)
        {
            work();
        }

        private void work()
        {
            //! 더이상 옮길 문자가 없으면 타이머를 멈추고 리턴
            if (qStr.Count == 0)
            {
                timer1.Stop();
                return;
            }
            //! 프로그레스바 진행을 스탭만큼 증가
            progressBar1.PerformStep(); 
            //! 진행 퍼센트 계산
            decimal percent = ((decimal)(progressBar1.Value) / (decimal)(progressBar1.Maximum)) * 100;
            //! 소수점 버림
            percent = Math.Truncate(percent);

            label2.Text = percent.ToString() + "%";

            //! 현재시간 - 폼생성시간 = 시간간격
            info.Diff = DateTime.Now - dateTime;

            //! 큐에서 한글자씩 빼서 textBox에 표시
            try
            {
                textBox1.Text = textBox1.Text + qStr.Dequeue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "에러");
            }

            //! 시간간격이 딜레이시간보다 같거나 작으면 return
            if ((decimal)info.Diff.Seconds < info.Delay) { return; }

            timer1.Stop();
        }

        private void setProgressBar()
        {
            controller.initProgressBar(progressBar1);
            progressBar1.Maximum = info.TextSend.Length;
        }

        private int calculrateInterval()
        {
            decimal interval = 0;
            if (info.TextSend.Length != 0)
            {
                interval = info.Delay / (decimal)info.TextSend.Length;
                //! 즉시 실행일 경우
                if (interval == 0) 
                {
                    interval = 1;
                    progressBar1.Maximum = 1;
                }
            }
            interval = interval * 1000;
            return (int)interval;
        }

        //! 보낸문자 큐 생성
        private void makeQTextSend(Info info)
        {
            foreach (char ch in info.TextSend)
            {
                qStr.Enqueue(ch.ToString());
            }
        }

        //! 프로그레스바 진행을 스탭만큼 증가
        public void runPerformStep()
        {
            progressBar1.PerformStep();
        }
    }
}
