using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace antrahw2._3
{
    public class Color
    {
        private int Red;
        private int Green;
        private int Blue;
        private int Alpha;
        public Color(int red, int green, int blue, int alpha)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }
        public Color(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = 255;
        }
        public Color()
        {
            Red = 0;
            Green = 0;
            Blue = 0;
            Alpha = 255;
        }
        public int red 
        {
            get
            {
                return this.Red;
            }
            set
            {
                if(this.Red < 0 | this.Red > 225)
                {
                    throw new ArgumentOutOfRangeException("value out of range");
                }
            }
        }
        public int green
        {
            get
            {
                return this.Green;
            }
            set
            {
                if (this.Green < 0 | this.Green > 225)
                {
                    throw new ArgumentOutOfRangeException("value out of range");
                }
            }
        }
        public int blue
        {
            get
            {
                return this.Blue;
            }
            set
            {
                if (this.Blue < 0 | this.Blue > 225)
                {
                    throw new ArgumentOutOfRangeException("value out of range");
                }
            }
        }
        public int alpha { get; set; }

        public int grayscale() 
        {
            return ((this.Red + this.Green + this.Blue) / 3);
        }

    } 

}
