using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextMover
{
    //! 정보 클래스
    public class Info
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

        private TimeSpan diff = TimeSpan.Zero;
        public TimeSpan Diff
        {
            get { return diff; }
            set { diff = value; }
        }
    }
}
