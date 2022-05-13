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
        public void Start()
        {
            WelcomeText();
            ReceiveCategoryInputValidationLoop();
            
            RentDateText();
            RentDate = ReceiveDateInputValidationLoop();

            ReturnDateText();
            ReturnDate = ReceiveDateInputValidationLoop();


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
            Console.WriteLine("Please input the date of the book rental");
        }
        
        private void ReturnDateText()
        {
            Console.WriteLine("Please input the date of the book returnal");
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
            Console.Write("Enter a month: ");
            int month = int.Parse(Console.ReadLine());
            Console.Write("Enter a day: ");
            int day = int.Parse(Console.ReadLine());
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
