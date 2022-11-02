namespace Homework5_MouseEvents
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap b;
        Graphics g;


        int x_down;
        int y_down;

        int x_mouse;
        int y_mouse;

        int r_width;
        int r_height;

        Rectangle r;

        bool drag = false;
        bool resizing = false;


        private void button1_Click(object sender, EventArgs e)
        {
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);

            g.Clear(Color.White);

            r = new Rectangle(150, 70, 500, 300);

            g.DrawRectangle(Pens.Purple, r);
            pictureBox1.Image = b;
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (r.Contains(e.X, e.Y))
            {
                if (r.Height > 100 && r.Width > 100)
                {
                    double delta_wheel = e.Delta;
                    double newHeight = r.Height + (delta_wheel / 10);
                    double newWidth = r.Width + (delta_wheel / 10);

                    double deltaY = (newHeight - r.Height) * 0.5;
                    double deltaX = (newWidth - r.Width) * 0.5;

                    r.Width = (int)newWidth;
                    r.Height = (int)newHeight;

                    r.Y = (int)(r.Location.Y - deltaY);
                    r.X = (int)(r.Location.X - deltaX);


                    redraw(r, g);
                }
                
            }


        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (r.Contains(e.X, e.Y))
            {
                x_mouse = e.X;
                y_mouse = e.Y;

                x_down = r.X;
                y_down = r.Y;

                r_width = r.Width;
                r_height = r.Height;

                if (e.Button == MouseButtons.Left)
                {
                    drag = true;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    resizing = true;
                }
            }

        }



        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            resizing = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            int delta_x = e.X - x_mouse;
            int delta_y = e.Y - y_mouse;



            if (drag)
            {

                r.X = x_down + delta_x;
                r.Y = y_down + delta_y;

                redraw(r, g);
            }
            else if (resizing)
            {
                r.Width = r_width + delta_x;
                r.Height = r_height + delta_y;

                redraw(r, g);
            }

        }

        private void redraw(Rectangle r, Graphics g)
        {
            g.Clear(Color.White);

            g.DrawRectangle(Pens.Purple, r);
            pictureBox1.Image = b;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}