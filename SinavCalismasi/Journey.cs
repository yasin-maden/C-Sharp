using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace SinavCalismasi
{
    internal class Journey
    {
        public Person Passanger { get; set; }
        public Stop BoardingStop { get; set; }
        public Stop AlightingStop { get; set; }
        public SubscriptionType Subscription { get; set; }
        public double Pay { get; set; }
        public bool isRefundable { get; set; }
        public DateTime Date { get; set; }
    }
}
