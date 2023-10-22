using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment
{
    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
    }

    public class CreditCard
    {
        public string CardNumber { get; set; }
        public BankAccount LinkedAccount { get; set; }
        public bool IsBlocked { get; set; }
    }

    public class PaymentSystem
    {
        private List<BankAccount> accounts = new List<BankAccount>();
        private List<CreditCard> creditCards = new List<CreditCard>();

        public void AddBankAccount(BankAccount account)
        {
            accounts.Add(account);
        }

        public void AddCreditCard(CreditCard card)
        {
            creditCards.Add(card);
        }

        public void MakePayment(string senderAccountNumber, string receiverAccountNumber, double amount)
        {
            BankAccount senderAccount = accounts.Find(account => account.AccountNumber == senderAccountNumber);
            BankAccount receiverAccount = accounts.Find(account => account.AccountNumber == receiverAccountNumber);

            if (senderAccount == null || receiverAccount == null)
            {
                throw new ArgumentException("Не удалось найти один или оба счета.");
            }

            if (senderAccount.Balance < amount)
            {
                throw new InvalidOperationException("Недостаточно средств на счете для совершения платежа.");
            }

            senderAccount.Balance -= amount;
            receiverAccount.Balance += amount;
        }

        public void BlockCreditCard(string cardNumber)
        {
            CreditCard card = creditCards.Find(c => c.CardNumber == cardNumber);

            if (card != null)
            {
                card.IsBlocked = true;
            }
        }
    }
}
