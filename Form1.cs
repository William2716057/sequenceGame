using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace sequenceGame
{
    public partial class Form1 : Form
    {
        private List<Circle> circles;
        private const int CircleRadius = 30;
        private const int CircleCount = 5;

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.BackColor = Color.Black;
            this.ClientSize = new Size(800, 600);
            //this.Text = "Random White Circles";

            GenerateRandomCircles();
        }

        private void GenerateRandomCircles()
        {
            Random rand = new Random();
            circles = new List<Circle>();

            for (int i = 0; i < CircleCount; i++)
            {
                int x = rand.Next(CircleRadius, this.ClientSize.Width - CircleRadius);
                int y = rand.Next(CircleRadius, this.ClientSize.Height - CircleRadius);
                circles.Add(new Circle(x, y, CircleRadius));
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            using (Brush brush = new SolidBrush(Color.White))
            {
                foreach (var circle in circles)
                {
                    g.FillEllipse(brush, circle.X - circle.Radius, circle.Y - circle.Radius, circle.Radius * 2, circle.Radius * 2);
                }
            }
        }
    }

    public class Circle
    {
        public int X { get; }
        public int Y { get; }
        public int Radius { get; }

        public Circle(int x, int y, int radius)
        {
            X = x;
            Y = y;
            Radius = radius;
        }
    }
}