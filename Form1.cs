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
        public Form1()
        {
            InitializeComponent();

            Width = 600;
            Height = 480;

            Height = (Height / 20) * 20;
            Width = Width / 20 * 20 + 50;
            
            g = CreateGraphics();
        }

        public void drawGrid()
        {
            Console.WriteLine(Width);
            //Height = (Height / 20) * 20;
            //Width = (Width / 20) * 20;
            g = CreateGraphics();
            for (var i = 0; i < Height/20; i++)
            {
                for (var j = 0; j < Width/20; j++)
                {
                    g.DrawRectangle(new Pen(Color.Red,1), j*20, i*20, 20, 20);
                }
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawGrid();
        }
    }
}
