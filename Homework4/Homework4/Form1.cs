namespace Homework4

{
    public partial class Form1 : Form
    {
        
        public Bitmap b;
        public Graphics g;
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
            this.richTextBox1.Text = "";
            this.richTextBox1.AppendText("|Fr abs | Fr rel | Fr norm \n");
            this.b = new Bitmap(this.pictureBox1.Width, this.PreferredSize.Height);
            this.g = Graphics.FromImage(b);

            
            int trialsCount = 500;
            int numerOfTrajectories = 50;

         

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
                    punti3.Add(new Point(x3Device, y3Device));
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
    }
}