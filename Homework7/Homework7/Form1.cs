using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System;
using System.Windows.Forms;

namespace Homework7

{
    public partial class Form1 : Form
    {
        public const int constTrialsCount = 90;
        public const int constNumTrajectories = 50;
        public Bitmap b;
        public Graphics g;

        


        public Random r = new Random();
        public Pen penRed = new Pen(Color.OrangeRed, 1);
        public Pen penBlue = new Pen(Color.Blue, 1);
        public Pen penPurple = new Pen(Color.Purple, 1);
        public Pen penYellow = new Pen(Color.Yellow, 1);




        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
            List<Point> punti = new List<Point>();
            punti.Add(new Point(0, 0));
            punti.Add(new Point(40, 0));

            Pen penRed = new Pen(Color.OrangeRed, 6);
            Pen penBlue = new Pen(Color.Blue, 6);
            Pen penPurple = new Pen(Color.Purple, 6);

            Bitmap colorRed = new Bitmap(this.pictureBox2.Width, this.pictureBox2.Height);
            Graphics gr1 = Graphics.FromImage(colorRed);

            gr1.DrawLines(penRed, punti.ToArray());
            this.pictureBox2.Image = colorRed;

            Bitmap colorBlue = new Bitmap(this.pictureBox3.Width, this.pictureBox3.Height);
            Graphics gr2 = Graphics.FromImage(colorBlue);

            gr2.DrawLines(penBlue, punti.ToArray());
            this.pictureBox3.Image = colorBlue;

            Bitmap colorPurple = new Bitmap(this.pictureBox4.Width, this.pictureBox4.Height);
            Graphics gr3 = Graphics.FromImage(colorPurple);

            gr3.DrawLines(penPurple, punti.ToArray());
            this.pictureBox4.Image = colorPurple;




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

        int successPr = 50;

        private void button1_Click(object sender, EventArgs e)
        {
            
            

            Bitmap b1 = new Bitmap(pictureBox5.Width, pictureBox5.Height);
            Graphics g1 = Graphics.FromImage(b1);

            Bitmap bmp3 = new Bitmap(pictureBox6.Width, pictureBox6.Height);
            Graphics g3 = Graphics.FromImage(bmp3);


            int lambda = (int)numericUpDown1.Value;
            successPr = (int)lambda / constTrialsCount;

            
 
            this.richTextBox1.Text = "";
            this.richTextBox1.AppendText("|Fr abs | Fr rel | Fr norm \n");

            this.b = new Bitmap(this.pictureBox1.Width, this.PreferredSize.Height);
            this.g = Graphics.FromImage(b);



            int trialsCount = constTrialsCount;
            int numerOfTrajectories = constNumTrajectories;

            Dictionary<int, int> interrarivalDistribution = new Dictionary<int, int>();
            Dictionary<int, int> finals1 = new Dictionary<int, int>();
            Dictionary<int, int> finals2 = new Dictionary<int, int>();
            Dictionary<int, int> finals3 = new Dictionary<int, int>();

            int interrarival = 0;

            for (int i = 1; i <= numerOfTrajectories; i++)
            {
                List<Point> punti1 = new List<Point>();
                List<Point> punti2 = new List<Point>();
                List<Point> punti3 = new List<Point>();



                double Y = 0;
                for (int X = 1; X <= trialsCount; X++)
                {
                    int uniform = r.Next(100);
                    if (uniform <= successPr)
                    {
                        Y++;
                        if (interrarival != 0)
                        {
                            if (!interrarivalDistribution.ContainsKey(interrarival)) 
                                interrarivalDistribution.Add(interrarival, 1);
                            else interrarivalDistribution[interrarival]++;
                            interrarival = 0;
                        }

                    }
                    else interrarival++;

                    int xDevice = fromXrealToXVirtual(X, 0, trialsCount, pictureBox1.Width);
                    int yDevice = fromYrealToYVirtual(Y, 0, trialsCount, pictureBox1.Height);

                    int x2Device = fromXrealToXVirtual(X, 0, trialsCount, pictureBox1.Width);
                    int y2Device = fromYrealToYVirtual(Y * trialsCount / (X + 1), 0, trialsCount, pictureBox1.Height);

                    int x3Device = fromXrealToXVirtual(X, 0, trialsCount, pictureBox1.Width);
                    int y3Device = fromYrealToYVirtual(Y * (Math.Sqrt(trialsCount)) / (Math.Sqrt(X + 1)), 0, trialsCount * successPr, pictureBox1.Height);

                    punti1.Add(new Point(xDevice, yDevice));
                    punti2.Add(new Point(x2Device, y2Device));
                    punti3.Add(new Point(x3Device, y3Device + 60));
                }
                Point p1 = punti1[trialsCount - 1];
                Point p2 = punti2[trialsCount - 1];
                Point p3 = punti3[trialsCount - 1];

                if (finals1.ContainsKey(p1.Y))
                {
                    finals1[p1.Y] += 1;
                }
                else
                {
                    finals1.Add(p1.Y, 1);
                }

                if (finals2.ContainsKey(p2.Y))
                {
                    finals2[p2.Y] += 1;
                }
                else
                {
                    finals2.Add(p2.Y, 1);
                }

                if (finals3.ContainsKey(p3.Y))
                {
                    finals3[p3.Y] += 1;
                }
                else
                {
                    finals3.Add(p3.Y, 1);
                }

                this.richTextBox1.AppendText("|  " + p1.Y.ToString() + "   |  " + p2.Y.ToString() + "   |    " + p3.Y.ToString() + "  \n");


                this.g.DrawLines(penRed, punti1.ToArray());
                this.g.DrawLines(penBlue, punti2.ToArray());
                this.g.DrawLines(penPurple, punti3.ToArray());

            }

            
            lambdaHistogram(bmp3, g3, pictureBox6, interrarivalDistribution, trialsCount);
            this.pictureBox6.Image = bmp3;

            drawHorizontalChartRed(b1, g1, pictureBox5, finals1);
            drawHorizontalChartBlue(b1, g1, pictureBox5, finals2);
            drawHorizontalChartPurple(b1, g1, pictureBox5, finals3);

            this.pictureBox1.Image = b;

        }



       

        private void drawHorizontalChartRed(Bitmap b, Graphics g, PictureBox pictureBox, Dictionary<int, int> points)
        {
            int j = 0;
            int step = pictureBox.Height / 250;


            foreach (KeyValuePair<int, int> entry in points)
            {

                Rectangle r = new Rectangle(0, entry.Key, entry.Value * 30, step);
                g.DrawRectangle(Pens.OrangeRed, 0, entry.Key, entry.Value * 30, step);
                g.FillRectangle(new SolidBrush(Color.OrangeRed), r);
                j += step;
            }

            pictureBox.Image = b;
        }

        private void drawHorizontalChartBlue(Bitmap b, Graphics g, PictureBox pictureBox, Dictionary<int, int> points)
        {
            int j = 0;
            int step = pictureBox.Height / 250;


            foreach (KeyValuePair<int, int> entry in points)
            {

                Rectangle r = new Rectangle(0, entry.Key, entry.Value * 30, step);
                g.DrawRectangle(Pens.Blue, 0, entry.Key, entry.Value * 30, step);
                g.FillRectangle(new SolidBrush(Color.Blue), r);
                j += step;
            }
            
            pictureBox.Image = b;

        }

        private void drawHorizontalChartPurple(Bitmap b, Graphics g, PictureBox pictureBox, Dictionary<int, int> points)
        {
            int j = 0;
            int step = pictureBox.Height / 250;


            foreach (KeyValuePair<int, int> entry in points)
            {

                Rectangle r = new Rectangle(0, entry.Key, entry.Value * 30, step);
                g.DrawRectangle(Pens.Purple, 0, entry.Key, entry.Value * 30, step);
                g.FillRectangle(new SolidBrush(Color.Purple), r);
                j += step;
            }

            pictureBox.Image = b;
        }

        private void lambdaHistogram(Bitmap bitmap, Graphics g, PictureBox pictureBox, Dictionary<int, int> distribution, int numElement)
        {
            int j = 0;
            int step = pictureBox.Width / distribution.Count;


            foreach (var item in distribution)
            {
                double virtualX = fromXrealToXVirtual(item.Value * 20, 0, numElement, pictureBox.Height);
                g.DrawRectangle(penYellow, j + 1, pictureBox.Height - (int)virtualX, step, (int)virtualX);
                j += step;
            }

            pictureBox.Image = bitmap;
        }

    }
}