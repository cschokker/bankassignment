using CharlesBank.Presentation;

/*

Customers: 
            - Edit Customer, 
            - Delete Customer
Accounts: 
            - New Account, 
            - Edit Account, 
            - View Accounts, 
            - Delete Account
Funds Transfer: 
            - Transfer amount from one bank account to another bank account
Funds Transfer Statement: 
            View list of funds transfers between dates
Account Statement: 
            View list of debit and credit transactions between specified dates

 */
class Program
{
    static void Main()
    {
        //Display Title
        System.Console.WriteLine("\t\t----------------------------------------");
        System.Console.WriteLine("\t\t~~~~~~~~~~~~~ Charles Bank ~~~~~~~~~~~~~");
        System.Console.WriteLine("\t\t----------------------------------------");

        System.Console.WriteLine("\n\t\t::: Login Page :::");
        System.Console.WriteLine("\t\t==================");
        System.Console.WriteLine("\t\tPress enter to exit.");

        //Declarations
        string userName = null;
        string password = null;

        //Read userName from Keyboard
        System.Console.Write("\t\tUsername: ");
        userName = System.Console.ReadLine();

        //Read password from Keyboard only if username is entered
        if (userName != "")
        {
            System.Console.Write("\t\tPassword: ");
            password = System.Console.ReadLine();
        }

        //Check userName and password
        if (userName == "system" && password == "manager")
        {
            //Declarations
            int mainMenuChoice = -1;

            do
            {
                //Show Main Menu
                System.Console.WriteLine("\n\t\t::: Main Menu :::");
                System.Console.WriteLine("\t\t=================");
                System.Console.WriteLine("\t\t1. Customers");
                System.Console.WriteLine("\t\t2. Accounts");
                System.Console.WriteLine("\t\t3. Funds Transfer");
                System.Console.WriteLine("\t\t4. Funds Transfer Statement");
                System.Console.WriteLine("\t\t5. Account Statement");
                System.Console.WriteLine("\t\t0. Exit");

                // Accept user choice from keyboard
                System.Console.Write("\n\t\tEnter Choice: ");
                mainMenuChoice = int.Parse(System.Console.ReadLine());

                // Check selection
                switch (mainMenuChoice)
                {
                    case 1: CustomersMenu(); break;
                    case 2: AccountsMenu(); break;
                    case 3: TransactionsPresentation.TransferFunds(); break;
                    case 4: TransactionsPresentation.DisplayTransferStatement(); break;
                    case 5: TransactionsPresentation.ViewTransactionsStatement(); break;
                }
            } while (mainMenuChoice != 0);
        }
        else
        {
            System.Console.WriteLine("Invalid username or password");
        }

        //About to exit
        System.Console.WriteLine("\n\t\tThank you! Visit again.");
        System.Console.ReadKey();
    }

    static void CustomersMenu()
    {
        //Declarations
        int customerMenuChoice = -1;

        do
        {
            //Show Menu
            System.Console.WriteLine("\n\t\t::: Customers Menu :::");
            System.Console.WriteLine("\t\t======================");
            System.Console.WriteLine("\t\t1. Add Customer");
            System.Console.WriteLine("\t\t2. Delete Customer");
            System.Console.WriteLine("\t\t3. Update Customer");
            System.Console.WriteLine("\t\t4. Search Customers");
            System.Console.WriteLine("\t\t5. View Customers");
            System.Console.WriteLine("\t\t0. Back to Main Menu");

            // Accept user choice from keyboard
            System.Console.Write("\n\t\tEnter Choice: ");
            customerMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());

            // Check selection
            switch (customerMenuChoice)
            {
                case 1: CustomersPresentation.AddCustomer(); break;
                case 2: CustomersPresentation.DeleteCustomer(); break;
                case 3: CustomersPresentation.UpdateCustomer(); break;
                case 4: CustomersPresentation.SearchCustomer(); break;
                case 5: CustomersPresentation.ViewCustomers(); break;
            }
        } while (customerMenuChoice != 0);
    }

    static void AccountsMenu()
    {
        //Declarations
        int accountsMenuChoice = -1;

        do
        {
            //Show Menu
            System.Console.WriteLine("\n\t\t::: Accounts Menu :::");
            System.Console.WriteLine("\t\t=====================");
            System.Console.WriteLine("\t\t1. Add Account");
            System.Console.WriteLine("\t\t2. Delete Account");
            System.Console.WriteLine("\t\t3. Update Account");
            System.Console.WriteLine("\t\t4. View Accounts");
            System.Console.WriteLine("\t\t0. Back to Main Menu");

            // Accept user choice from keyboard
            System.Console.Write("\n\t\tEnter Choice: ");
            accountsMenuChoice = System.Convert.ToInt32(System.Console.ReadLine());

            // Check selection
            switch (accountsMenuChoice)
            {
                case 1: AccountsPresentation.AddAccount(); break;
                case 2: AccountsPresentation.DeleteAccount(); break;
                case 3: AccountsPresentation.UpdateAccount(); break;
                case 4: AccountsPresentation.ViewAccounts(); break;
            }
        } while (accountsMenuChoice != 0);
    }
}