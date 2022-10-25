namespace Homework4

{
    public partial class Form1 : Form
    {
        public Bitmap b;
        public Graphics g;
        public Random r= new Random();
        public PointF p = new Point(2,2);
        public Point punti;        
        public Form1()
        {
            InitializeComponent();
            this.punti= new PointF[1];
            punti.add
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private int fromXtoXVirtual(double x,double minx, double maxx,int left, int w)
        {
            return w = (int)((x - minx) / (maxx - minx))- left;
        }

        private int fromYtoYVirtual(double y, double miny, double maxy, int top, int h)
        {
            return h = (int)((y - miny) / (maxy - miny)) + top;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            
            this.b = new Bitmap(this.pictureBox1.Width, this.PreferredSize.Height);
            this.g = Graphics.FromImage(b);
            this.g.DrawRectangle(Pens.Khaki, 20,20,100,100);
            this.pictureBox1.Image = b;

            double y = 0;
            double successPr = 0.5;
            int trialsCount = 10;

            for(int x = 0; x < trialsCount; x++)
            {
                double random = r.NextDouble();
                if (random >= successPr)
                {
                    y =+ 1;
                }

                this.richTextBox1.AppendText("X:" + x + "Y:"+ y+"N:"+random+ "\n");
            }
            this.g.DrawLines(Pens.Gray, punti);
        }
    }
}