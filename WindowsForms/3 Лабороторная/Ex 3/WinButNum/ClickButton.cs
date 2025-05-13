using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinButNum
{
    public class ClickButton : System.Windows.Forms.Button
    {
        int mClicks;
        public int Clicks //создание свва клика
        {
            get { return mClicks; }
        }
        protected override void OnClick(EventArgs e)//обр каждого клика
        {
            mClicks++;
            base.OnClick(e);
        }
        protected override void
        OnPaint(System.Windows.Forms.PaintEventArgs pevent)//отображение клва щелчков
        {
            base.OnPaint(pevent);
            System.Drawing.Graphics g = pevent.Graphics;
            System.Drawing.SizeF stringsize;
            stringsize = g.MeasureString(Clicks.ToString(),
            this.Font, this.Width);
            g.DrawString(Clicks.ToString(), this.Font,
            System.Drawing.SystemBrushes.ControlText,
            this.Width - stringsize.Width - 3, this.Height -
            stringsize.Height - 3);
        }
    }
}
