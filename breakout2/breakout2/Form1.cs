using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace breakout2
{
    public partial class Form1 : Form
    {
        classball ball;
        Rocket rocket;
        List<Stone> stone=new List<Stone>();
        int con = 3;
        public Form1()
        {
            InitializeComponent();
            //////////////////////////////////////////
            Point pt = new Point(300, 480);
            Point velocity = new Point(20, -20);
            Size clientSize = this.ClientSize;
            ball = new classball(pt, velocity, clientSize, 5, Color.AliceBlue);
            //////////////////////////////////////////球跑的方向及位置
            pt.X=280;
            pt.Y=500;
            Size rsize=new Size(50,10);
            SolidBrush mBrush = new SolidBrush(Color.Cyan);
            rocket = new Rocket(pt, rsize, ClientSize, mBrush);
            /////////////////////////////////////////下面移動的方塊
            SolidBrush sBrush = new SolidBrush(Color.Red);
            SolidBrush ssBrush = new SolidBrush(Color.Blue);
            SolidBrush sssBrush = new SolidBrush(Color.Green);
            Size ssize = new Size(32, 10);
            for (int i = 0; i < 15; i++)
            {
                pt.X=60+i*33;
                pt.Y=90;
                Stone s = new Stone(pt, ssize, sBrush);
                pt.Y = 120;
                Stone t = new Stone(pt, ssize, ssBrush);
                pt.Y = 140;
                Stone u = new Stone(pt, ssize, sssBrush);
                stone.Add(s);
                stone.Add(t);
                stone.Add(u);
            }
            /////////////////////////////////////////做出要打的磚塊
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int score = 0, live = 0;
            live=ball.Move();
            if (live == -1 && con == 1)///////////////失敗
            {
                con--;
                score = con;
                label4.Text = score.ToString();
                Form2 a = new Form2();
                a.Show();
                this.Enabled = false;
                a.FormClosed += new FormClosedEventHandler(Form2_FormClosed);

            }
            else if (live == -1 && con > 1)
            {
                Point pt = new Point(300, 480);
                Point velocity = new Point(-20, -20);
                Size clientSize = this.ClientSize;
                ball = new classball(pt, velocity, clientSize, 5, Color.AliceBlue);
                //////////////////////////////////////////球跑的方向及位置
                con--;
                score = con;
                label4.Text = score.ToString();
                
            }
            if (rocket.Collides(ball))//碰到下面移動磚塊
            {
                ball.velocity.Y *= -1;
            }
            else
            {
                for (int i = 0; i < stone.Count; i++)
                {
                    if (stone[i].isVisible && stone[i].Collides(ball))//碰到磚塊
                    {
                        ball.velocity.Y *= -1;
                        stone[i].isVisible = false;

                        score=Convert.ToInt32(label2.Text);
                        score = score + 500;
                        label2.Text = score.ToString();

                        break;
                    }
                }
            }
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            rocket.Draw(e.Graphics);//畫出下面移動磚塊
            ball.Draw(e.Graphics);//畫出球
            for (int i = 0; i < stone.Count; i++)
            {
                if (stone[i].isVisible) stone[i].Draw(e.Graphics);//畫出磚塊
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            rocket.move(e.X);//滑鼠移動跟著下面移動磚塊一起移動
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Text = "0";
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
