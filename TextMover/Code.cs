using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextMover
{
    //! comboBox 아이템이면서 타이머의 종류를 나타냄
    public enum TimerType
    {
        WindowsForms = 0, //!< System.Windows.Forms.Timer
        Threading = 1, //!< System.Threading.Timer
        Timers = 2, //!< System.Timer
    }
}
