using AccountClassLibrary;
namespace AccountClass{
   public class Program
{
    static void Main(string[] args)
    {
            AutomatedTellerMachine machine = new ();
            Show_Console_Message($"ID банкомату = {machine.Id}");
            Bank bankInfo = new ();
            Show_Console_Message($"Назва банку = {bankInfo.BankName}");
            Show_Console_Message($"Адреса банкомату = {bankInfo.ListBankomats}");

            Account ivan = new Account("5123333322224444", "1111", "Ivan", "Ivanov");
            ivan.PutMessage += Show_Console_Message;
            ivan.PutMessage += Show_MessageBox_Message;
            ivan.Put(100);

            ivan.WithdrawalMessage += Show_Console_Message;
            ivan.WithdrawalMessage += Show_MessageBox_Message;
            ivan.Withdrawal(50);

            ivan.CheckBalance += Show_Console_Balance;
            ivan.CheckBalance += Show_MessageBox_Balance;
            ivan.ShowBalance("5123333322224444", "1111");

            ivan.EnterPassword += Show_Console_Message;
            ivan.EnterPassword += Show_MessageBox_Message;
            ivan.ErrorPassword += Show_Console_Message;
            ivan.ErrorPassword += Show_MessageBox_Message;
            ivan.ChangePassword("1111", "2222");
            ivan.ChangePassword("1111", "2222");

            Account petro = new Account("5123333322226666", "5555", "Petro", "Ivanov");
            petro.CheckBalance += Show_Console_Balance;
            petro.CheckBalance += Show_MessageBox_Balance;

            Console.ForegroundColor = ConsoleColor.Blue;
            Show_Console_Message("Баланс до перерахування кошту");
            Console.ResetColor();
            petro.ShowBalance("5123333322226666", "5555");
            ivan.ShowBalance("5123333322224444", "2222");

            ivan.TransferMoney(ivan, petro, 20);

            Console.ForegroundColor = ConsoleColor.Blue;
            Show_Console_Message("Баланс пiсля перерахування кошту");
            Console.ResetColor();
            petro.ShowBalance("5123333322226666", "5555");
            ivan.ShowBalance("5123333322224444", "2222");

            AutomatedTellerMachine infoBank = new();
        }
        private static void Show_Console_Message(string str)
        {
            Console.WriteLine(str);
        }
        private static void Show_MessageBox_Message(string str)
        {
            System.Windows.Forms.MessageBox.Show(str);
        }
        private static void Show_Console_Balance(object sender, AccountCheckBalanceEventArgs e)
        {
            Console.WriteLine(e.Mess);
        }
        private static void Show_MessageBox_Balance(object sender, AccountCheckBalanceEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(e.Mess);
        }
    }
}


