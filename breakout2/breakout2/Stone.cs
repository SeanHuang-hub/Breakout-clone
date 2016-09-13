using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace breakout2
{
    class Stone
    {
        public Point position; // 磚塊的位置
        public Size stoneSize; // 磚塊的大小
        public bool isVisible = true;
        SolidBrush myBrush = new SolidBrush(Color.Blue);

        public Stone(Point position, Size stoneSize, SolidBrush mBrush)
        {
            this.position = position;
            this.stoneSize = stoneSize;
            this.myBrush = mBrush;
        }

        public void Draw(Graphics G)
        {
            if (isVisible)
            {
                G.FillRectangle(myBrush, position.X, position.Y, stoneSize.Width, stoneSize.Height);
                G.DrawRectangle(Pens.Black, position.X, position.Y, stoneSize.Width, stoneSize.Height);
            }
        }

        public bool Collides(classball Ball)
        {
            if (position.X + stoneSize.Width > Ball.position.X - Ball.Ball_Width &&
                position.X - stoneSize.Width < Ball.position.X + Ball.Ball_Width &&
                position.Y + stoneSize.Height > Ball.position.Y - Ball.Ball_Width &&
                position.Y - stoneSize.Height < Ball.position.Y + Ball.Ball_Width)
                return true;
            else
                return false;
        }

    }
}
