using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bitfinex
{
    public class OrderBook
    {
        public List<Informations> Asks { get; set; }
        public List<Informations> Bids { get; set; }

    }
}
