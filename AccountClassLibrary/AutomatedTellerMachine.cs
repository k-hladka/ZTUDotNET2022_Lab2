using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountClassLibrary
{
    public class AutomatedTellerMachine
    {
        public int MoneyBank { get; set; }
        public int Id { get; private set; }
        private string address;
        public string Address { get { return address; } private set { address = "вул. Червона 2г"; } }
        public AutomatedTellerMachine()
        {
            Id = 1;
            Address = address;
        }
    }
}
