using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp
{
    class Cli
    {
        BookCategory Choice;
        DateTime RentDate;
        DateTime ReturnDate;
        readonly Library LibraryInstance;
        public Cli()
        {
            LibraryInstance = new Library();
        }
        public void Start()
        {
            WelcomeText();
            ReceiveCategoryInputValidationLoop();
            
            RentDateText();
            RentDate = ReceiveDateInputValidationLoop();

            ReturnDateText();
            ReturnDate = ReceiveDateInputValidationLoop();

            PrintPaymentInformation();


        }

        private void PrintPaymentInformation()
        {
            int debt = LibraryInstance.UserDebt(RentDate, ReturnDate, Choice);
            if(debt > 0)
            {
                Console.WriteLine("Borrower penalty fee is {0}PLN", debt);
                return;
            }

            Console.WriteLine("Borrower has no fee to pay");
        }
        private void WelcomeText()
        {
            Console.WriteLine("Welcome to the library!"); ;
        }
        private void CategoryText()
        {
            Console.WriteLine("Please Choose a book from one of the following categories:");
            
            int i = 0;
            foreach(BookCategory bt in (BookCategory[])Enum.GetValues(typeof(BookCategory)))
            {
                Console.WriteLine("{0}. {1}",++i,bt);
            }
            
        }
        
        private void RentDateText()
        {
            Console.WriteLine("Please input the date of the book rental. Input must be numerical.");
        }
        
        private void ReturnDateText()
        {
            Console.WriteLine("Please input the date of the book returnal. Input must be numerical.");
        }


        private void ReceiveCategoryInput()
        {
            int InputNumber = Convert.ToInt32(Console.ReadLine())-1;
            if (Enum.IsDefined(typeof(BookCategory), InputNumber))
            {
                Choice = (BookCategory)InputNumber;
                return;
            }
            throw new ArithmeticException("Invalid user input"); 
        }

        private void ReceiveCategoryInputValidationLoop()
        {
            bool inputValid;
            do
            {
                try
                {
                    CategoryText();
                    ReceiveCategoryInput();
                    inputValid = true;
                }
                catch
                {
                    inputValid = false;
                    Console.WriteLine("Please input the correct value");
                }
            } while (!inputValid);
        }

        private DateTime ReceiveDateInput()
        {
            
            Console.Write("Enter a day: ");
            int day = int.Parse(Console.ReadLine());

            Console.Write("Enter a month: ");
            int month = int.Parse(Console.ReadLine());

            Console.Write("Enter a year: ");
            int year = int.Parse(Console.ReadLine());

            return new DateTime(year, month, day);
        }

        private DateTime ReceiveDateInputValidationLoop()
        {
            bool inputValid;
            DateTime ret = new DateTime();
            do
            {
                try
                {
                    ret = ReceiveDateInput();
                    inputValid = true;
                }
                catch
                {
                    Console.WriteLine("The date you entered is not valid! Please try again!");
                    inputValid = false;
                }
            } while (!inputValid);
            
            return ret;

        }



    }
}
