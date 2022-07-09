using AccountMicroservice.DB;
using AccountMicroservice.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AccountMicroservice.Repository
{
    public class AccountRep : IAccountRep
    {
        static int acid = 203;
        AccountDbContext _context;
        public AccountRep(AccountDbContext context)
        {
            _context = context;
        }

        public List<AccountMsg> getCustomerAccounts(string id)
        {
            var a = _context.customerAccounts.Where(c => c.CustomerId == id).FirstOrDefault<CustomerAccount>();
            var ca = _context.accounts.Where(cac => cac.Id == a.CurrentAccountId).FirstOrDefault<Account>();
            var sa = _context.accounts.Where(sac => sac.Id == a.SavingsAccountId).FirstOrDefault<Account>();
            var ac = new List<AccountMsg>
            {
                new AccountMsg{AccId=ca.Id,AccType="Current Account",AccBal=ca.Balance},
                new AccountMsg{AccId=sa.Id,AccType="Savings Account",AccBal=sa.Balance}
            };
            return ac;
        }
        public CustomerAccount createAccount(string id)
        {
            CustomerAccount a = new CustomerAccount
            {
                CustomerId = id,
                CurrentAccountId = acid,
                SavingsAccountId = (acid + 1)
            };
            _context.customerAccounts.Add(a);
            Account ca = new Account
            {
                Id = a.CurrentAccountId,
                Balance = 0.00
            };
            _context.accounts.Add(ca);
            _context.accountStatements.Add(
                    new AccountStatement
                    {
                        AccountId = ca.Id,
                        Statements = new List<Statement>() { }
                    }
                );
            Account sa = new Account
            {
                Id = a.SavingsAccountId,
                Balance = 0.00
            };
            _context.accounts.Add(sa);
            acid += 2;
            _context.accountStatements.Add(
                    new AccountStatement
                    {
                        AccountId = sa.Id,
                        Statements = new List<Statement>() { }
                    }
                );
            _context.SaveChanges();
            return a;
        }
        public AccountMsg getAccount(int id)
        {
            var acc = _context.accounts.Where(a => a.Id == id).FirstOrDefault<Account>();
            if(id % 2 != 0)
            {
                var accMsg = new AccountMsg
                {
                    AccId = acc.Id,
                    AccType = "Current Account",
                    AccBal = acc.Balance
                };
                return accMsg;
            }
            else
            {
                var accMsg = new AccountMsg
                {
                    AccId = acc.Id,
                    AccType = "Savings Account",
                    AccBal = acc.Balance
                };
                return accMsg;
            }
        }
        public TransactionMsg deposit(Transaction t)
        {
            var acc = _context.accounts.Where(a => a.Id == t.AccountId).FirstOrDefault<Account>();
            acc.Balance = acc.Balance + t.Amount;
            TransactionMsg accMsg = new TransactionMsg
            {
                AccountId = t.AccountId,
                Message = "Sucessfully Deposited Amount",
                Balance = acc.Balance
            };
            var accStatement = _context.accountStatements.Where(a => a.AccountId == t.AccountId).FirstOrDefault<AccountStatement>();
            if(accStatement.Statements == null)
            {
                accStatement.Statements = new List<Statement>();
            }
            accStatement.Statements.Add(
                    new Statement { Date = DateTime.Today, Narration = "Deposited", Withdrawal = 0.00,Deposit = t.Amount, ClosingBalance = acc.Balance }
                );

            _context.SaveChanges();
            return accMsg;
        }

        public TransactionMsg withdraw(Transaction t)
        {
            var acc = _context.accounts.Where(a => a.Id == t.AccountId).FirstOrDefault<Account>();
            if (acc.Balance >= t.Amount)
            {
                acc.Balance = acc.Balance - t.Amount;
                TransactionMsg accMsg = new TransactionMsg
                {
                    AccountId = t.AccountId,
                    Message = "Sucessfully Withdrawn Amount",
                    Balance = acc.Balance
                };
                var accStatement = _context.accountStatements.Where(a => a.AccountId == t.AccountId).FirstOrDefault<AccountStatement>();
                if (accStatement.Statements == null)
                {
                    accStatement.Statements = new List<Statement>();
                }
                accStatement.Statements.Add(
                        new Statement { Date = DateTime.Today, Narration = "Withdrawn", Withdrawal = t.Amount, Deposit = 0.0, ClosingBalance = acc.Balance }
                    );

                _context.SaveChanges();
                return accMsg;
            }
            else
            {
                TransactionMsg accMsg = new TransactionMsg
                {
                    AccountId = t.AccountId,
                    Message = "Inscufficient Balance",
                    Balance = acc.Balance
                };
                return accMsg;
            }            
        }
        public List<Statement> getAccountStatement(int AccountId, string from_date, string to_date)
        {
            var accs = _context.accountStatements.Where(a => a.AccountId == AccountId).FirstOrDefault<AccountStatement>();
            var s = accs.Statements;
            DateTime from = DateTime.ParseExact(from_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime to = DateTime.ParseExact(to_date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            List<Statement> res = new List<Statement>();
            foreach (var n in s)
            {
            if (n.Date >= from && n.Date <= to)
                {
                    res.Add(n);
                }
            }
            return res;
        }

    }
}
