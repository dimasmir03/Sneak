using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class Form1 : Form
    {
        Graphics g;
        int w, h;
        public Form1()
        {
            InitializeComponent();

            Width = 600;
            Height = 480;

            Height = (Height / 20) * 20;
            Width = (Width / 20 * 20);
            
            g = CreateGraphics();
            w=Width; h=Height;
        }

        public void drawGrid()
        {
            Console.WriteLine(Width);
            Height = (Height / 20) * 20;
            Width = (Width / 20) * 20;
            g = CreateGraphics();
            for (var i = 0; i < Height/20; i++)
            {
                for (var j = 0; j < Width/20; j++)
                {
                    //fillRect(i, j, CELL_SIZE, CELL_SIZE)
                    g.DrawRectangle(new Pen(Color.Red,1), j*20, i*20, 20, 20);
                }
            }
            //g.FillRectangle(new SolidBrush(Color.Red),0,0,w,h);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {

            //this.OnPaint(null);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawGrid();
        }
    }
}
