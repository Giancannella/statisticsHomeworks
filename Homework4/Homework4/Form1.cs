using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System;

namespace Homework4

{
    public partial class Form1 : Form
    {
        public const int constTrialsCount = 250;
        public const int constNumTrajectories = 50;
        public Bitmap b;
        public Graphics g;

        public Bitmap b1;
        public Graphics g1;


        public Random r= new Random();
        public Pen penRed = new Pen(Color.OrangeRed, 1);
        public Pen penBlue = new Pen(Color.Blue, 1);
        public Pen penPurple = new Pen(Color.Purple, 1);
        readonly double successPr = 0.5;
        

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            pictureBox5.Visible = false;
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
        private int fromXrealToXVirtual(double x, double minX, double maxX,  int w)
        {
            if ((maxX - minX) == 0)
            {
                return 0;
            }
            return Convert.ToInt32(((x - minX) * w) / (maxX - minX));
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.b1 = new Bitmap(this.pictureBox5.Width, this.pictureBox5.Height);
            pictureBox5.Image = b1;
            pictureBox5.Visible = false;

            this.richTextBox1.Text = "";
            this.richTextBox1.AppendText("|Fr abs | Fr rel | Fr norm \n");
            this.b = new Bitmap(this.pictureBox1.Width, this.PreferredSize.Height);
            this.g = Graphics.FromImage(b);
            

            
            int trialsCount = constTrialsCount;
            int numerOfTrajectories = constNumTrajectories;

         

            for (int i = 1; i <= numerOfTrajectories; i++)
            {
                List<Point> punti1 = new List<Point>();
                List<Point> punti2 = new List<Point>();
                List<Point> punti3 = new List<Point>();

                double Y = 0;
                for (int X = 1; X <= trialsCount; X++)
                {
                    double Uniform = r.NextDouble();
                    if (Uniform < successPr)
                        Y = Y + 1;
                    int xDevice = fromXrealToXVirtual(X, 0, trialsCount, pictureBox1.Width );
                    int yDevice = fromYrealToYVirtual(Y, 0, trialsCount, pictureBox1.Height );
                    
                    int x2Device = fromXrealToXVirtual(X, 0, trialsCount, pictureBox1.Width);
                    int y2Device = fromYrealToYVirtual(Y * trialsCount / (X + 1), 0, trialsCount, pictureBox1.Height);

                    int x3Device = fromXrealToXVirtual(X, 0, trialsCount, pictureBox1.Width);
                    int y3Device = fromYrealToYVirtual(Y * (Math.Sqrt(trialsCount)) / (Math.Sqrt(X + 1)), 0, trialsCount * successPr, pictureBox1.Height);

                    punti1.Add(new Point(xDevice, yDevice));
                    punti2.Add(new Point(x2Device, y2Device));
                    punti3.Add(new Point(x3Device, y3Device+60));
                }
                Point p1 = punti1[trialsCount-1];
                Point p2 = punti2[trialsCount-1];
                Point p3 = punti3[trialsCount-1];

                this.richTextBox1.AppendText("|  "+ p1.Y.ToString() +"   |  "+ p2.Y.ToString() +"   |    "+ p3.Y.ToString()+"  \n");

                
                this.g.DrawLines(penRed, punti1.ToArray());
                this.g.DrawLines(penBlue, punti2.ToArray());
                this.g.DrawLines(penPurple, punti3.ToArray());
                
            }
            this.pictureBox1.Image = b;
            
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
            b1 = new Bitmap(pictureBox5.Width, pictureBox5.Height);
            g1 = Graphics.FromImage(b1);
            
            Dictionary<int, int> finals = new Dictionary<int, int>();

            this.richTextBox1.Text = "";
            this.richTextBox1.AppendText("|Fr abs|\n");
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

                this.richTextBox1.AppendText("|  " + p1.Y.ToString() +  " |\n");
                this.g.DrawLines(penRed, punti1.ToArray());
                

            }

            drawHorizontalChartRed(b1, g1, pictureBox5, finals);
            this.pictureBox1.Image = b;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
            b1 = new Bitmap(pictureBox5.Width, pictureBox5.Height);
            g1 = Graphics.FromImage(b1);

            Dictionary<int, int> finals = new Dictionary<int, int>();

            this.richTextBox1.Text = "";
            this.richTextBox1.AppendText("| Fr rel |\n");
            this.b = new Bitmap(this.pictureBox1.Width, this.PreferredSize.Height);
            this.g = Graphics.FromImage(b);


            int trialsCount = constTrialsCount;
            int numerOfTrajectories = constNumTrajectories;



            for (int i = 1; i <= numerOfTrajectories; i++)
            {
                
                List<Point> punti2 = new List<Point>();
                

                double Y = 0;
                for (int X = 1; X <= trialsCount; X++)
                {
                    double Uniform = r.NextDouble();
                    if (Uniform < successPr)
                        Y = Y + 1;
                    

                    int x2Device = fromXrealToXVirtual(X, 0, trialsCount, pictureBox1.Width);
                    int y2Device = fromYrealToYVirtual(Y * trialsCount / (X + 1), 0, trialsCount, pictureBox1.Height);

                   

                   
                    punti2.Add(new Point(x2Device, y2Device));
                    
                }
                
                Point p2 = punti2[trialsCount - 1];

                if (finals.ContainsKey(p2.Y))
                {
                    finals[p2.Y] += 1;
                }
                else
                {
                    finals.Add(p2.Y, 1);
                }

                this.richTextBox1.AppendText("|  " + p2.Y.ToString() + "   |    "+ " \n");
                this.g.DrawLines(penBlue, punti2.ToArray());
                

            }
            drawHorizontalChartBlue(b1, g1, pictureBox5, finals);
            this.pictureBox1.Image = b;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
            b1 = new Bitmap(pictureBox5.Width, pictureBox5.Height);
            g1 = Graphics.FromImage(b1);

            Dictionary<int, int> finals = new Dictionary<int, int>();

            this.richTextBox1.Text = "";
            this.richTextBox1.AppendText("| Fr norm|\n");
            this.b = new Bitmap(this.pictureBox1.Width, this.PreferredSize.Height);
            this.g = Graphics.FromImage(b);


            int trialsCount = constTrialsCount;
            int numerOfTrajectories = constNumTrajectories;



            for (int i = 1; i <= numerOfTrajectories; i++)
            {
                
                List<Point> punti3 = new List<Point>();

                double Y = 0;
                for (int X = 1; X <= trialsCount; X++)
                {
                    double Uniform = r.NextDouble();
                    if (Uniform < successPr)
                        Y = Y + 1;
                    

                    int x3Device = fromXrealToXVirtual(X, 0, trialsCount, pictureBox1.Width);
                    int y3Device = fromYrealToYVirtual(Y * (Math.Sqrt(trialsCount)) / (Math.Sqrt(X + 1)), 0, trialsCount * successPr, pictureBox1.Height);

                   
                    punti3.Add(new Point(x3Device, y3Device+60));
                }
               
                Point p3 = punti3[trialsCount - 1];
                if (finals.ContainsKey(p3.Y))
                {
                    finals[p3.Y] += 1;
                }
                else
                {
                    finals.Add(p3.Y, 1);
                }
                this.richTextBox1.AppendText("|" + p3.Y.ToString() + "          |\n");


                
                this.g.DrawLines(penPurple, punti3.ToArray());

            }
            drawHorizontalChartPurple(b1, g1, pictureBox5, finals);
            this.pictureBox1.Image = b;
        }

        private void drawHorizontalChartRed(Bitmap b, Graphics g, PictureBox pictureBox, Dictionary<int,int> points)
        {
            int j = 0;
            int step = pictureBox.Height/ 250;
            

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
    }
}