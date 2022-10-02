namespace Homework1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.groupBox1.Text = "Russian forces retreat from strategic city. Pressure appears to be growing on Putin to use nuclear weapons";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.groupBox1.Text = "Bolsonaro or Lula? As Brazil prepares to vote, here's what to know";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.groupBox1.Text = "Hurricane Orlene strengthens into Category 4 storm as it heads toward western Mexico";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Text = "Now you can close the application form";
        }

     
       

        
    }
}