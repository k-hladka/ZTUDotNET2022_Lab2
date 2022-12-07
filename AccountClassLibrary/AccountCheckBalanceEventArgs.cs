using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountClassLibrary
{
    public class AccountCheckBalanceEventArgs : EventArgs
    {
        public string Mess { get; }
        public int Balance { get; private set; }
        public string Name { get; private set; }
        public AccountCheckBalanceEventArgs(string Mess, int Balance, string Name)
        {
            this.Mess = Mess;
            this.Balance = Balance;
            this.Name = Name;
        }
    }
}
