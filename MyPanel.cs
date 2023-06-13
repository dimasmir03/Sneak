using System.Windows.Forms;

namespace Курсовая
{
    internal class MyPanel : Panel
    {
        public MyPanel() {

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }
    }
}