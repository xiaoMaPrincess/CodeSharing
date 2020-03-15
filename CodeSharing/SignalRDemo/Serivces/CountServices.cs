using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo.Serivces
{
    public class CountServices
    {
        private int _count;
        public int GetLatestCount()
        {
            return ++_count;
        }
    }
}
