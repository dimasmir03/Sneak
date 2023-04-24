using System;
using System.Drawing;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class Form1 : Form
    {

        int d = 2;
        static int len = 6;
        Point[] sneak = new Point[len];
        Point apple;
        int cell = 16;
        int l = 16;

        public int W
        {
            get { return panel1.Width; }
            set { panel1.Width = value; }
        }

        public int H
        {
            get { return panel1.Height; }
            set { panel1.Height = value; }
        }

        public int X
        {
            get { return sneak[0].X; }
            set { sneak[0].X = value; }
        }

        public int Y
        {
            get { return sneak[0].Y; }
            set { sneak[0].Y = value; }
        }

        Bitmap map;

        public Form1()
        {
            InitializeComponent();

            map = new Bitmap(W, H);
            Graphics gm = Graphics.FromImage(map);

            createApple();
            for (var i = 0; i < H / cell; i++)
            {
                for (var j = 0; j < W / cell; j++)
                {
                    gm.DrawRectangle(new Pen(Color.Red, 1), j * cell, i * cell, cell, cell);
                }
            }

            for (int i = 0; i < len; i++)
            {
                //sneak[i] = new Point();
                //sneak[i].Y = i * cell;
            }

            timer1.Start();
        }

        public void createApple()
        {
            apple.X = new Random().Next(0, W / cell * cell) / cell * cell;
            apple.Y = new Random().Next(0, H / cell * cell) / cell * cell;
            Console.WriteLine("Apple: " + apple.X + " " + apple.Y);

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    if (d != 3) d = 1;
                    //if ((Y -= cell) < 0) Y = H-cell;
                    //Console.WriteLine("Key Up");
                    break;
                case Keys.Down:
                case Keys.S:
                    if (d != 1) d = 3;
                    //if ((Y += cell) >= H) Y = 0;
                   // Console.WriteLine("Key Down");
                    break;
                case Keys.Left:
                case Keys.A:
                    if (d != 2) d = 0;
                    //if ((X -= cell) < 0) X = W-cell;
                    //Console.WriteLine("Key Left");
                    break;
                case Keys.Right:
                case Keys.D:
                    if (d != 0) d = 2;
                    //if ((X += cell) >= W) X = 0;
                   // Console.WriteLine("Key Right");
                    break;
            }
            //Console.WriteLine(Y + " " + X);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawImage(map, e.ClipRectangle);


            for (int i = sneak.Length - 2; i >= 0; i--)
            {
                sneak[i + 1].X = sneak[i].X;
                sneak[i + 1].Y = sneak[i].Y;
            }
            switch (d)
            {
                case 0:
                    //if ((X -= l) < 0) X = W - cell;
                    X -= l;
                    break;
                case 1:
                    //if ((Y -= l) < 0) Y = H - cell;
                    Y -= l;
                    break;
                case 2:
                    //if ((X += l) >= W) X = 0;
                    X += l;
                    break;
                case 3:
                    //if ((Y += l) >= H) Y = 0;
                    Y += l;
                    break;
            }

            //if (X == apple.X && Y == apple.Y) { eatApple(); }

            if (X < 0 || X > W || Y < 0 || Y > H)
            {
                gameOver();
                
            }

            for (int i = 0; i < sneak.Length; i++)
            {
                /*for (int j = 0; j < W; j+=cell)
                {
                    e.Graphics.FillEllipse(Brushes.Green, j, i, cell, cell);
                }*/
                e.Graphics.FillEllipse(Brushes.Green, sneak[i].X, sneak[i].Y, cell, cell);
            }
            e.Graphics.FillEllipse(Brushes.Orange, apple.X, apple.Y, cell, cell);
        }

        public void gameOver()
        {
            Console.WriteLine("123");
            MessageBox.Show("Game Over!");
            timer1.Interval = 10000;
            timer1.Stop();
        }

        public void eatApple()
        {
            Console.WriteLine("Eat Fruit");
            Array.Resize(ref sneak, sneak.Length + 1);
            sneak[sneak.Length-1] = new Point(sneak[sneak.Length-2].X, sneak[sneak.Length-2].Y);
            //Console.WriteLine("Length sneak: "+sneak.Length);
            createApple();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("timer");
            panel1.Invalidate();
        }
    }
}
