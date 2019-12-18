using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCompanyApp
{
    public class Delievery
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Weight{ get; set; }
        public string CityFrom { get; set; }
        public string CityTo { get; set; }
        public DelieveryType DelieveryType { get; set; }
        public int FinalSum { get; set; }
        public Sender Sender { get; set; }
        public Recipient Recipient { get; set; }
    }
}
