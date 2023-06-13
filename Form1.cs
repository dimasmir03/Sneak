using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Курсовая
{
    public partial class Form1 : Form
    {

        int direction = 2;
        static int len = 6;
        List<Point> sneak = new List<Point>();
        Point apple;
        int cell = 16;
        int speed = 20;

        public int W   { get => panel1.Width;   set { panel1.Width = value; } }

        public int H   { get => panel1.Height;  set { panel1.Height = value; } }

        public int X   { get => sneak[0].X;     set { sneak[0] = new Point(value, sneak[0].Y); } }

        public int Y   { get => sneak[0].Y;     set { sneak[0] = new Point(sneak[0].X, value); } }

        public Form1()
        {
            InitializeComponent();

            W = W / cell * cell;
            H = H / cell * cell;

            createApple();

            for (int i = 0; i < len; i++)
                sneak.Add(new Point(0, i * cell));

            timer1.Interval = speed;
            timer1.Start();
        }

        public void createApple()
        {
            apple.X = new Random().Next(0, W) / cell * cell;
            apple.Y = new Random().Next(0, H) / cell * cell;
            Console.WriteLine("Apple: " + apple.X + " " + apple.Y);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    if (direction != 3) direction = 1;
                    break;
                case Keys.Down:
                case Keys.S:
                    if (direction != 1) direction = 3;
                    break;
                case Keys.Left:
                case Keys.A:
                    if (direction != 2) direction = 0;
                    break;
                case Keys.Right:
                case Keys.D:
                    if (direction != 0) direction = 2;
                    break;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            for (var i = 0; i < H / cell; i++)
            {
                for (var j = 0; j < W / cell; j++)
                {
                    e.Graphics.DrawRectangle(new Pen(Color.Red, 1), j * cell, i * cell, cell, cell);
                }
            }

            for (int i = sneak.Count - 2; i >= 0; i--)
                sneak[i + 1] = new Point(sneak[i].X,sneak[i].Y);

            switch (direction)
            {
                case 0:
                    X -= cell;
                    break;
                case 1:
                    Y -= cell;
                    break;
                case 2:
                    X += cell;
                    break;
                case 3:
                    Y += cell;
                    break;
            }

            if (X < 0 || X >= W || Y < 0 || Y >= H)
            {
                gameOver();
                return;
            }

            if (X == apple.X && Y == apple.Y) { eatApple(); }

            for (int i = 0; i < sneak.Count; i++)
                e.Graphics.FillEllipse(Brushes.Green, sneak[i].X, sneak[i].Y, cell, cell);

            e.Graphics.FillEllipse(Brushes.Orange, apple.X, apple.Y, cell, cell);
        }

        public void gameOver()
        {
            timer1.Stop();
            timer1.Enabled = false;
            MessageBox.Show("Game Over!");
        }

        public void eatApple()
        {
            sneak.Add(new Point(sneak[sneak.Count - 1].X, sneak[sneak.Count - 1].Y));
            createApple();
            Console.WriteLine("Eat Fruit");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("timer");
            panel1.Invalidate();
        }
    }
}