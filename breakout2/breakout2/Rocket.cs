using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace breakout2
{
    class Rocket
    {
        public Point position; // 板子的位置
        public Size clientSize; // 視窗寬高
        public Size rocketSize; // 板子的大小
        SolidBrush myBrush = new SolidBrush(Color.Blue);

        public Rocket(Point position, Size rocketSize, Size ClientSize, SolidBrush mBrush)
        {
            this.position = position;
            this.rocketSize = rocketSize;
            this.clientSize = ClientSize;
            this.myBrush = mBrush;
        }

        public void move(int X)
        {
            position.X = X;
            if (position.X < 0)
            {
                position.X = 0;
            }
            else if (position.X > clientSize.Width - rocketSize.Width)
            {
                position.X = clientSize.Width - rocketSize.Width;
            }
        }

        public void Draw(Graphics G)
        {
            G.FillRectangle(myBrush, position.X, position.Y, rocketSize.Width, rocketSize.Height);
            G.DrawRectangle(Pens.Black, position.X, position.Y, rocketSize.Width, rocketSize.Height);
        }

        public bool Collides(classball Ball)
        {
            if (position.X + rocketSize.Width > Ball.position.X - Ball.Ball_Width &&
                position.X - rocketSize.Width < Ball.position.X + Ball.Ball_Width &&
                position.Y + rocketSize.Height > Ball.position.Y - Ball.Ball_Width &&
                position.Y - rocketSize.Height < Ball.position.Y + Ball.Ball_Width)
                return true;
            else
                return false;
        }
    }
}
