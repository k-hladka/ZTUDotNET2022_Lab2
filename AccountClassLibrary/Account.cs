namespace AccountClassLibrary
{
    public delegate void AccountMessage(string message);
    public class Account : AutomatedTellerMachine
    {

        public event AccountMessage PutMessage;
        public event AccountMessage WithdrawalMessage;
        public event EventHandler<AccountCheckBalanceEventArgs> CheckBalance;
        public event AccountMessage EnterPassword;
        public event AccountMessage ErrorPassword;
        private  string numberCard;
        public string NumberCard {
            private set
            {
                if (value.Length == 16)
                    numberCard = value;
            }
            get
            {
                return numberCard; 
            }
        }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        private string password;
        public string Password { 
            private get
            {
                return password;
            }
            set
            {
                if (value.Length >= 4)
                    password = value;
            }
        }
        public int Balance { get; private set; }
        public Account(string numberCard,  string password, string name, string surname)
        {
            NumberCard = numberCard;
            Password = password;
            Name = name;
            Surname = surname;
        }
        public void Put(int sum)
        {
            Balance += sum;
            MoneyBank += sum;
            if (PutMessage != null)
                PutMessage($"На карту користувача {Name} зараховано {sum} грн");

        }
        public void Withdrawal(int sum)
        {
            if (Balance >= sum)
            {
                Balance -= sum;
                MoneyBank -= sum;
            }
            if (WithdrawalMessage != null)
                WithdrawalMessage($"З карти користувача {Name} знято {sum} грн");
        }
        public void ShowBalance(string numberCard, string password)
        {
            if(Password == password && NumberCard == numberCard)
            if (CheckBalance != null)
                CheckBalance(this, new AccountCheckBalanceEventArgs($"Баланс карти користувача {Name}: {Balance}", Balance, Name));
        }
        public void ChangePassword(string oldPassword, string newPassword)
        {
            if (Password == oldPassword)
            {
                Password = newPassword;
                if (EnterPassword != null)
                    EnterPassword("Пароль змiнено успiшно");
            }
            else
                if(ErrorPassword!=null)
                    ErrorPassword("Неправильний пароль");
        }
        public void TransferMoney(Account account, Account account2, int money)
        {
            if (NumberCard == account.NumberCard && account.Balance >= money)
            {
                account.Balance -= money;
                account2.Balance += money;
            }
        }
    }
}