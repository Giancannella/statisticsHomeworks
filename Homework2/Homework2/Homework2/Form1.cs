namespace Homework2
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        int n;
        int tot=0;
        int i=1;
        int average=0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             this. n = random.Next(0,100);
            this.textBox1.Text = n.ToString();
            this.richTextBox1.AppendText(this.n.ToString()+", ");

            this.tot += n;
            this.average = this.tot / i;
            i++;
            this.textBox2.Text = average.ToString();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.timer1.Stop();
        }
    }
}