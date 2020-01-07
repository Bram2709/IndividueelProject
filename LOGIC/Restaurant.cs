using System;
using System.Collections.Generic;
using System.Text;

namespace LOGIC
{
    public class Restaurant
    {
        private int maxAmountOfPeaple { get; set; }
        private int currAmountOfPeaple { get; set; }

        public int GetAvaliblePlaces()
        {
            return maxAmountOfPeaple - currAmountOfPeaple;
        }

    }
}
