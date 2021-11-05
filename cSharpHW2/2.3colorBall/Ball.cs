using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrahw2._3
{
    public class Ball : Color
    {
        private int Size;
        private int ThrowCount;
        public Ball(int red, int green, int blue, int alpha, int size, int tc)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
            Size = size;
            ThrowCount = tc;
        }
        public Ball(int red, int green, int blue, int alpha)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
            Size = 1;
            ThrowCount = 0;
        }
        public Ball()
        {
            this.red = 0;
            this.green = 0;
            this.blue = 0;
            this.alpha = 255;
            Size = 1;
            ThrowCount = 0;
        }
        public void Pop()
        {
            Size = 0;
        }
        public void Throw()
        {
            if (Size != 0)
            {
                ThrowCount++;
            }
        }
        public int GetThrowCount()
        {
            return (ThrowCount);
        }


    }
}
