using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lottoFeladat
{
    internal class data
    {
        public int week;
        public int numOne;
        public int numTwo;
        public int numThree;
        public int numFour;
        public int numFive;

        public data(int week, int numOne, int numTwo, int numThree, int numFour, int numFive)
        {
            this.week = week;
            this.numOne = numOne;
            this.numTwo = numTwo;
            this.numThree = numThree;
            this.numFour = numFour;
            this.numFive = numFive;
        }
    }
}
