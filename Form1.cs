using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 下落的小球
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent(); }        

        ball ball = new ball();
        board board = new board();
               
        SolidBrush white = new SolidBrush(Color.White);
        SolidBrush blue = new SolidBrush(Color.Blue);
        SolidBrush red = new SolidBrush(Color.Red);
        SolidBrush green = new SolidBrush(Color.Green);

        Random Position = new Random();
        bool draw = false;        
        int i = 0;
        int time = 1;
        int number = 0;
        int position;        

        void set() { position = Position.Next(0, pictureBox1.Width - 2 * ball.radius); }

        void reset()
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.FillRectangle(blue, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            g.FillRectangle(white, board.location, pictureBox1.Height - board.height, board.length, board.height);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            board.length = pictureBox1.Width / 5;
            board.location = pictureBox1.Width / 2 - board.length / 2;
            g.FillRectangle(white, board.location, pictureBox1.Height - board.height, board.length, board.height);
            if (draw)
            {                
                timer1.Start();
                timer2.Interval = timer2.Interval = ((pictureBox1.Height - 2 * ball.radius) / Convert.ToInt32(ball.speed)) * timer1.Interval + 1000;
                timer2.Start();
            }
            if (draw == false)
            {
                timer1.Stop();
                time = 1;
                reset();
            }            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.FillRectangle(blue, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height - board.height));            
            g.FillEllipse(white, position, time * ball.speed, 2 * ball.radius, 2 * ball.radius);
            time = time + 1;
            if (time * ball.speed >= pictureBox1.Height - 2 * ball.radius) 
            {
                if (position + ball.radius > board.location && position + ball.radius < board.location + board.length)
                { 
                    g.FillEllipse(green, position, (time - 1) * ball.speed, 2 * ball.radius, 2 * ball.radius);                    
                    number++;
                    label3.Text = number.ToString();
                }
                else 
                {
                    label1.Text = "Restart";
                    g.FillEllipse(red, position, (time - 1) * ball.speed, 2 * ball.radius, 2 * ball.radius);                    
                    timer2.Stop();
                }
                timer1.Stop();                
            }
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (label1.Text == "Restart")
                {                    
                    label1.Text = "End";
                    time = 1;
                    Invalidate(new Rectangle(pictureBox1.Location, pictureBox1.Size));
                }
                else
                {
                    if (label1.Text != "Restart")
                    {
                        if (i % 2 == 0)
                        {
                            draw = true;
                            label1.Text = "End";
                            Invalidate(new Rectangle(pictureBox1.Location, pictureBox1.Size));
                        }
                        else
                        {
                            draw = false;
                            label1.Text = "Start";
                            Invalidate(new Rectangle(pictureBox1.Location, pictureBox1.Size));
                        }
                        i++;
                    }
                }
            }
        }       

        private void Form1_SizeChanged(object sender, EventArgs e)
        {           
            Graphics g = pictureBox1.CreateGraphics();            
            g.FillRectangle(blue, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height - board.height));                       
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            reset();
            set();
            timer1.Start();            
            time = 1;                 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            if ((Keys)e.KeyCode == Keys.Right)
            {
                if (board.location < pictureBox1.Width - board.length)
                {
                    board.location = board.location + 10;
                    g.FillRectangle(blue, 0, pictureBox1.Height - board.height, pictureBox1.Width, board.height);
                    g.FillRectangle(white, board.location, pictureBox1.Height - board.height, board.length, board.height);
                }             
            }
            if((Keys)e.KeyCode == Keys.Left)
            {
                if(board.location > 0)
                {
                    board.location = board.location - 10;
                    g.FillRectangle(blue, 0, pictureBox1.Height - board.height, pictureBox1.Width, board.height);
                    g.FillRectangle(white, board.location, pictureBox1.Height - board.height, board.length, board.height);
                }                
            }
        }
    }
}
