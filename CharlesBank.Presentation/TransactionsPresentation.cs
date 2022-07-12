using CharlesBank.BusinessLogicLayer;
using CharlesBank.BusinessLogicLayer.BALContracts;
using CharlesBank.Entities;
using System;

namespace CharlesBank.Presentation
{
    static class TransactionsPresentation
    {
        internal static void TransferFunds()
        {
            try
            {
                // Create BL object
                IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
                ITransactionsBusinessLogicLayer transactionsBusinessLogicLayer = new TransactionsBusinessLogicLayer();

                //Get account code from user
                Console.WriteLine("\n**********ACCOUNT STATEMENT**********");

                System.Console.Write("\nFrom Account Code: ");
                var fromAccountCode = System.Convert.ToInt64(System.Console.ReadLine());
                var matchingFromAccounts = accountsBusinessLogicLayer.GetAccountsByCondition(item => item.AccountCode == fromAccountCode);

                if (matchingFromAccounts.Count >= 1)
                {
                    System.Console.Write("\nTo Account Code: ");
                    var toAccountCode = System.Convert.ToInt64(System.Console.ReadLine());
                    var matchingToAccounts = accountsBusinessLogicLayer.GetAccountsByCondition(item => item.AccountCode == toAccountCode);

                    if (matchingToAccounts.Count >= 1)
                    {
                        System.Console.Write("\nDate of Transaction: ");
                        var transactionDate = System.Convert.ToDateTime(System.Console.ReadLine());

                        System.Console.Write("\nAmount $: ");
                        var amount = System.Convert.ToInt64(System.Console.ReadLine());

                        transactionsBusinessLogicLayer.PerformTransferBetweenAccounts(matchingFromAccounts[0].AccountId,
                            matchingToAccounts[0].AccountId,
                            transactionDate,
                            amount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid account number.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid account number.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void DisplayTransferStatement()
        {
            try
            {
                // Create BL object
                ITransactionsBusinessLogicLayer transactionsBusinessLogicLayer = new TransactionsBusinessLogicLayer();

                //Get account code from user
                Console.WriteLine("\n**********FUNDS TRANSFER STATEMENT**********");
                Console.Write("\nEnter Start Date Range:");
                DateTime startFrom = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter End Date Range: ");
                DateTime endAt = DateTime.Parse(Console.ReadLine());

                var matchingTransactions = transactionsBusinessLogicLayer.GetTransactionsByCondition(item => item.TransactionDate >= startFrom
                    && item.TransactionDate <= endAt);

                Console.WriteLine($"\nTransaction History for Range {startFrom} to {endAt}:");
                Console.WriteLine("-------------------------------------");
                foreach (var transaction in matchingTransactions)
                {
                    PrintTransaction(transaction);
                }
                Console.WriteLine("-------------------------------------");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void ViewTransactionsStatement()
        {
            try
            {
                // Create BL object
                IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
                ITransactionsBusinessLogicLayer transactionsBusinessLogicLayer = new TransactionsBusinessLogicLayer();

                //Get account code from user
                Console.WriteLine("\n**********ACCOUNT STATEMENT**********");
                System.Console.Write("\nAccount Code: ");
                var accountCode = System.Convert.ToInt64(System.Console.ReadLine());

                var matchingAccounts = accountsBusinessLogicLayer.GetAccountsByCondition(item => item.AccountCode == accountCode);

                if (matchingAccounts.Count >= 1)
                {
                    Account account = matchingAccounts[0];
                    //Get account transactions between the specified dates

                    var transactionList = transactionsBusinessLogicLayer.GetTransactionsByCondition(item => item.AccountId == account.AccountId);
                    Console.WriteLine($"Transaction History for Account {account.AccountCode}:");
                    Console.WriteLine("-------------------------------------");
                    foreach (Transaction trans in transactionList)
                    {
                        Console.WriteLine($"{trans.TransactionDate.ToShortDateString()}  |  Amount: {trans.TransactionAmount.ToString("C2")} ({trans.TransactionType})");
                    }
                    Console.WriteLine("-------------------------------------");
                }
                else
                {
                    Console.WriteLine("Invalid account number.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        internal static void PrintTransaction(Transaction transaction)
        {
            try
            {
                Console.WriteLine($"Transfer Date: {transaction.TransactionDate.ToShortDateString()}    | Transaction ID: {transaction.TransactionId}");
                // display customer of account
                AccountsPresentation.PrintAccountHeader(transaction.AccountId);

                Console.WriteLine($"Transfer Amount: {transaction.TransactionAmount.ToString("C2")}  | ({transaction.TransactionType}) ");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }
    }
}
