using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountClassLibrary
{
    public class Bank : AutomatedTellerMachine
    {
        public string BankName { get; private set; }
        private string listBankomats;
        public string ListBankomats { get { return listBankomats; } private set { listBankomats = Address;} }
        public Bank()
        {
            BankName = "NewNameBank";
            ListBankomats = listBankomats;
        }
    }
}
