using Microsoft.VisualBasic.FileIO;
using System.Net.Sockets;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System;
using static System.Windows.Forms.DataFormats;
using System.Text.RegularExpressions;
using App_NormalDistributions_C;

namespace Homework8
{
    public partial class Form1 : Form
    {
        
       

        int numbersamples = 10000;
       

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

       

        
        private void button2_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Text = "";

            List<int> numbers = new List<int>();

            Dictionary<int, int> finals = new Dictionary<int, int>();
            Bitmap b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            Graphics g = Graphics.FromImage(b);


            NormalRVGenerator RVgen = new NormalRVGenerator();



            for (int i = 0; i < numbersamples; i++)
            {

                (double X, double Y) = RVgen.getNewPair();
                numbers.Add((int)(X*10));
                this.richTextBox1.AppendText(((int)(X*10)).ToString()+"\n");
                
              
            }


            for (int i = 0; i < numbers.Count; i++)
            {
                if (finals.ContainsKey(numbers[i]))
                {
                    finals[numbers[i]] += 1;
                }
                else
                {
                    finals.Add(numbers[i], 1);
                }
            }


            int lenght = finals.Count;
                        
          

            drawVerticalChartBlue(b, g, pictureBox1, finals, lenght);
            this.pictureBox1.Image = b;
        }

        private void drawVerticalChartBlue(Bitmap b, Graphics g, PictureBox pictureBox, Dictionary<int, int> finals, int lenght)
        {
            int j = 0;
            int step = pictureBox.Width / lenght;
            

            foreach (KeyValuePair<int, int> entry in finals)
            {
                double virtualX = fromRealToVirtualX(entry.Key, 0, lenght, pictureBox.Width);
                
                Rectangle r = new Rectangle((int)virtualX+ 450, pictureBox.Height - entry.Value - 1, step-2, entry.Value);
                g.DrawRectangle(Pens.Blue, r);
                g.FillRectangle(new SolidBrush(Color.Blue), r);
                j += step;
            }

            pictureBox.Image = b;
        }

        private void drawVerticalChartRed(Bitmap b, Graphics g, PictureBox pictureBox, Dictionary<int, int> finals, int lenght)
        {
            int j = 0;
            int step = pictureBox.Width / lenght;

            foreach (KeyValuePair<int, int> entry in finals)
            {
                double virtualX = fromRealToVirtualX(entry.Key, 0, lenght, pictureBox.Width);
                Rectangle r = new Rectangle((int)virtualX+450, pictureBox.Height - entry.Value - 1, step - 2, entry.Value);
                g.DrawRectangle(Pens.Red, r);
                g.FillRectangle(new SolidBrush(Color.Red), r);
                j += step;
            }

            pictureBox.Image = b;
        }

        private void drawVerticalChartGreen(Bitmap b, Graphics g, PictureBox pictureBox, Dictionary<int, int> finals, int lenght)
        {
            int j = 0;
            int step = pictureBox.Width / lenght;

            foreach (KeyValuePair<int, int> entry in finals)
            {
                double virtualX = fromRealToVirtualX(entry.Key, 0, lenght, pictureBox.Width);
                Rectangle r = new Rectangle((int)virtualX + 450, pictureBox.Height - entry.Value - 1, step - 2, entry.Value);
                g.DrawRectangle(Pens.Green, r);
                g.FillRectangle(new SolidBrush(Color.Green), r);
                j += step;
            }

            pictureBox.Image = b;
        }

        private void drawVerticalChartPurple(Bitmap b, Graphics g, PictureBox pictureBox, Dictionary<int, int> finals, int lenght)
        {
            int j = 0;
            int step = pictureBox.Width / lenght;

            foreach (KeyValuePair<int, int> entry in finals)
            {
                double virtualX = fromRealToVirtualX(entry.Key, 0, lenght, pictureBox.Width);
                Rectangle r = new Rectangle((int)virtualX + 450, pictureBox.Height - entry.Value - 1, step - 2, entry.Value);
                g.DrawRectangle(Pens.Purple, r);
                g.FillRectangle(new SolidBrush(Color.Purple), r);
                j += step;
            }

            pictureBox.Image = b;
        }

        private void drawVerticalChartYellow(Bitmap b, Graphics g, PictureBox pictureBox, Dictionary<int, int> finals, int lenght)
        {
            int j = 0;
            int step = pictureBox.Width / lenght;

            foreach (KeyValuePair<int, int> entry in finals)
            {
                double virtualX = fromRealToVirtualX(entry.Key, 0, lenght, pictureBox.Width);
                Rectangle r = new Rectangle((int)virtualX + 450, pictureBox.Height - entry.Value - 1, step - 2, entry.Value);
                g.DrawRectangle(Pens.Yellow, r);
                g.FillRectangle(new SolidBrush(Color.Yellow), r);
                j += step;
            }

            pictureBox.Image = b;
        }

        private double fromRealToVirtualX(double x, double minX, double maxX, double width)
        {
            return (x - minX) / (maxX - minX) * width;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<int> numbers = new List<int>();
            this.richTextBox1.Text = "";
            Dictionary<int, int> finals = new Dictionary<int, int>();
            Bitmap b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            Graphics g = Graphics.FromImage(b);



            NormalRVGenerator RVgen = new NormalRVGenerator();



            for (int i = 0; i < numbersamples; i++)
            {

                (double X, double Y) = RVgen.getNewPair();
                numbers.Add((int)(X*X*10));
                this.richTextBox1.AppendText(((int)(X*X*10)).ToString() + "\n");


            }


            for (int i = 0; i < numbers.Count; i++)
            {
                if (finals.ContainsKey(numbers[i]))
                {
                    finals[numbers[i]] += 1;
                }
                else
                {
                    finals.Add(numbers[i], 1);
                }
            }


            int lenght = finals.Count;


            drawVerticalChartRed(b, g, pictureBox1, finals, lenght);
            this.pictureBox1.Image = b;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> numbers = new List<int>();
            this.richTextBox1.Text = "";
            Dictionary<int, int> finals = new Dictionary<int, int>();
            Bitmap b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            Graphics g = Graphics.FromImage(b);



            NormalRVGenerator RVgen = new NormalRVGenerator();



            for (int i = 0; i < numbersamples; i++)
            {

                (double X, double Y) = RVgen.getNewPair();

                if ((int)(X / Math.Sqrt((Y * Y))) < 400 && (int)(X / Math.Sqrt((Y * Y))) > -400)
                {
                    numbers.Add((int)(X / Math.Sqrt((Y * Y))));
                    this.richTextBox1.AppendText(((int)(X / Math.Sqrt((Y * Y)))).ToString() + "\n");
                }


            }


            for (int i = 0; i < numbers.Count; i++)
            {
                if (finals.ContainsKey(numbers[i]))
                {
                    finals[numbers[i]] += 1;
                }
                else
                {
                    finals.Add(numbers[i], 1);
                }
            }


            int lenght = finals.Count;


            drawVerticalChartGreen(b, g, pictureBox1, finals, lenght);
            this.pictureBox1.Image = b;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<int> numbers = new List<int>();
            this.richTextBox1.Text = "";
            Dictionary<int, int> finals = new Dictionary<int, int>();
            Bitmap b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            Graphics g = Graphics.FromImage(b);



            NormalRVGenerator RVgen = new NormalRVGenerator();



            for (int i = 0; i < numbersamples; i++)
            {

                (double X, double Y) = RVgen.getNewPair();
                
                if ((int)((X * X) / (Y * Y))<400 && (int)((X * X) / (Y * Y)) > -400)
                {
                    numbers.Add((int)((X * X) / (Y * Y)));
                    this.richTextBox1.AppendText(((int)((X * X) / (Y * Y))).ToString() + "\n");
                }


            }


            for (int i = 0; i < numbers.Count; i++)
            {
                if (finals.ContainsKey(numbers[i]))
                {
                    finals[numbers[i]] += 1;
                }
                else
                {
                    finals.Add(numbers[i], 1);
                }
            }


            int lenght = finals.Count;


            drawVerticalChartPurple(b, g, pictureBox1, finals, lenght);
            this.pictureBox1.Image = b;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<int> numbers = new List<int>();
            this.richTextBox1.Text = "";
            Dictionary<int, int> finals = new Dictionary<int, int>();
            Bitmap b = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            Graphics g = Graphics.FromImage(b);



            NormalRVGenerator RVgen = new NormalRVGenerator();



            for (int i = 0; i < numbersamples; i++)
            {

                (double X, double Y) = RVgen.getNewPair();
                if (((int)(X / Y)) > -500 && ((int)(X / Y)) < 500)
                {
                    numbers.Add((int)(X / Y));
                    this.richTextBox1.AppendText(((int)(X / Y)).ToString() + "\n");
                }

            }


            for (int i = 0; i < numbers.Count; i++)
            {
                if (finals.ContainsKey(numbers[i]))
                {
                    finals[numbers[i]] += 1;
                }
                else
                {
                    finals.Add(numbers[i], 1);
                }
            }


            int lenght = finals.Count;


            drawVerticalChartYellow(b, g, pictureBox1, finals, lenght);
            this.pictureBox1.Image = b;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}