using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myBanking {
    public class Account {
        private static int NextAccountNumber { get; set; } = 1;
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
        public string Description { get; set; }

        public bool Deposit(Decimal Amount) {
            if (Amount <= 0) {
                throw new Exception("Amount must be positive.");
            }
            Balance = Balance + Amount;
            return true;
        }
        public bool Withdrawal(Decimal Amount) {
            if (Amount <= 0) {
                throw new Exception("Amount must be positive.");
            }
            if (Amount > Balance) {
                throw new Exception("Insufficient Funds.");
            }
            Balance = Balance - Amount;
            return true;
        }

        public bool Transfer(Decimal Amount, Account ToAccount) {
            try {
                Withdrawal(Amount);
            } catch (Exception) {
                throw new Exception("Withdrawal Failed in Transfer.");
            }
            ToAccount.Deposit(Amount);
            return true;
        }
        public void Debug() {
            Console.WriteLine($"{AccountNumber}|{Description}|{Balance:c}");
        }
        public Account() {
            AccountNumber = NextAccountNumber;
            NextAccountNumber++;
            Description = "New Account";
            Balance = 0;

        }



    }

}
    
