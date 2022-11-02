using Microsoft.VisualBasic.FileIO;
using System.Net.Sockets;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System;

namespace Homework5
{
    public partial class Form1 : Form
    {
        public const int constTrialsCount = 20;
        public const int constNumTrajectories = 50;
        public Bitmap b;
        public Graphics g;

        public Bitmap b1;
        public Graphics g1;


        public Random r = new Random();
        public Pen penRed = new Pen(Color.OrangeRed, 1);
        public Pen penBlue = new Pen(Color.Blue, 1);
        public Pen penPurple = new Pen(Color.Purple, 1);
        readonly double successPr = 0.5;

        public Form1()
        {
            InitializeComponent();
        }
        private int fromYrealToYVirtual(double y, double minY, double maxY, int h)
        {
            if ((maxY - minY) == 0)
                return 0;

            return Convert.ToInt32(h - ((y - minY) * h) / (maxY - minY));
        }
        private int fromXrealToXVirtual(double x, double minX, double maxX, int w)
        {
            if ((maxX - minX) == 0)
            {
                return 0;
            }
            return Convert.ToInt32(((x - minX) * w) / (maxX - minX));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            Dictionary<int, int> finals = new Dictionary<int, int>();
            this.b = new Bitmap(this.pictureBox1.Width, this.PreferredSize.Height);
            this.g = Graphics.FromImage(b);

            int trialsCount = constTrialsCount;
            int numerOfTrajectories = constNumTrajectories;



            for (int i = 1; i <= numerOfTrajectories; i++)
            {
                List<Point> punti1 = new List<Point>();

                double Y = 0;
                for (int X = 1; X <= trialsCount; X++)
                {
                    double Uniform = r.NextDouble();
                    if (Uniform < successPr)
                        Y = Y + 1;
                    int xDevice = fromXrealToXVirtual(X, 0, trialsCount, pictureBox1.Width);
                    int yDevice = fromYrealToYVirtual(Y, 0, trialsCount, pictureBox1.Height);


                    punti1.Add(new Point(xDevice, yDevice));

                }
                Point p1 = punti1[trialsCount - 1];

                if (finals.ContainsKey(p1.Y))
                {
                    finals[p1.Y] += 1;
                }
                else
                {
                    finals.Add(p1.Y, 1);
                }


            }

            drawHorizontalChartRed(b, g, pictureBox1, finals);
            this.pictureBox1.Image = b;
        }

        private void drawHorizontalChartRed(Bitmap b, Graphics g, PictureBox pictureBox, Dictionary<int, int> points)
        {
            int j = 0;
            int step = pictureBox.Height / constTrialsCount;


            foreach (KeyValuePair<int, int> entry in points)
            {

                Rectangle r = new Rectangle(0, entry.Key, entry.Value * 30, step-3);
                g.DrawRectangle(Pens.OrangeRed, r);
                g.FillRectangle(new SolidBrush(Color.OrangeRed), r);
                j += step;
            }

            pictureBox.Image = b;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dictionary<int, int> finals = new Dictionary<int, int>();
            this.b = new Bitmap(this.pictureBox1.Width, this.PreferredSize.Height);
            this.g = Graphics.FromImage(b);

            int trialsCount = constTrialsCount;
            int numerOfTrajectories = constNumTrajectories;



            for (int i = 1; i <= numerOfTrajectories; i++)
            {
                List<Point> punti1 = new List<Point>();

                double Y = 0;
                for (int X = 1; X <= trialsCount; X++)
                {
                    double Uniform = r.NextDouble();
                    if (Uniform < successPr)
                        Y = Y + 1;
                    int xDevice = fromXrealToXVirtual(X, 0, trialsCount, pictureBox1.Width);
                    int yDevice = fromYrealToYVirtual(Y, 0, trialsCount, pictureBox1.Height);


                    punti1.Add(new Point(xDevice, yDevice));

                }
                Point p1 = punti1[trialsCount - 1];

                if (finals.ContainsKey(p1.Y))
                {
                    finals[p1.Y] += 1;
                }
                else
                {
                    finals.Add(p1.Y, 1);
                }


            }

            drawVerticalChartRed(b, g, pictureBox1, finals);
            this.pictureBox1.Image = b;
        }

        private void drawVerticalChartRed(Bitmap b, Graphics g, PictureBox pictureBox, Dictionary<int, int> points)
        {
            int j = 0;
            int step = pictureBox.Width / constNumTrajectories;


            foreach (KeyValuePair<int, int> entry in points)
            {
                double virtualX = fromRealToVirtualX(entry.Value, 0, constTrialsCount, pictureBox.Height);
                Rectangle r = new Rectangle(entry.Key, pictureBox.Height - (int)virtualX -1, step, (int)virtualX);
                g.DrawRectangle(Pens.Blue,r);
                g.FillRectangle(new SolidBrush(Color.Blue), r);
                j += step;
            }

            pictureBox.Image = b;
        }

        private double fromRealToVirtualX(double x, double minX, double maxX, double width)
        {
            return (x - minX) / (maxX - minX) * width;
        }
    }
}