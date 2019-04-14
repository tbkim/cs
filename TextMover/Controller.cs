using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TextMover
{
    public class Controller
    {
        public void setProgressBarMaximum(Info info, ProgressBar progressBar)
        {
            if (info.Delay == 0)
            {
                progressBar.Maximum = 1; //!< delay가 0일 때, 프로그레스바 최대 값을 1로
            }
            else
            {
                progressBar.Maximum = (int)info.Delay; //!< 프로그레스바 최대 값을 delay 값으로
            }
        }

        public void initProgressBar(ProgressBar progressBar)
        {
            progressBar.Style = ProgressBarStyle.Continuous; //!< 프로그레스바 스타일을 연속막대로
            progressBar.Step = 1; //!< 스탭마다 증가시킬 값
        }
    }
}
