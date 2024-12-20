﻿using System;

namespace LibraryApp
{
    /// <summary>Class <c>Cli</c> Displays the libraries user interface and handles user input
    /// </summary>
    public class Cli
    {
        /// <summary>
        /// The choice of the book category according the user input.
        /// </summary>
        private BookCategory choice;

        /// <summary>
        /// The date on which a book has been rented according to user input.
        /// </summary>
        private DateTime rentDate;

        /// <summary>
        /// The date on which a book has been returned according to user input.
        /// </summary>
        private DateTime returnDate;

        /// <summary> The method used to start the console user interface. No further configuration
        /// needed
        /// </summary>
        public void Start()
        {
            this.WelcomeText();
            this.ReceiveCategoryInputValidationLoop();

            Console.Clear();
            this.RentDateText();
            this.rentDate = this.ReceiveDateInputValidationLoop();

            Console.Clear();
            this.ReturnDateText();
            this.returnDate = this.ReceiveDateInputValidationLoop();

            Console.Clear();
            this.PrintPaymentInformation();
        }
        
        /// <summary>
        /// Prints the debt of the library client to the console. The method assumes the variables 
        /// rentDate and return date are not empty. If return date is earlier then the rent day then
        /// no borrower fee is printed.
        /// </summary>
        private void PrintPaymentInformation()
        {
            int debt = Library.UserDebt(this.rentDate, this.returnDate, this.choice);
            if (debt > 0)
            {
                Console.WriteLine("Borrower penalty fee is {0}PLN", debt);
                return;
            }

            Console.WriteLine("Borrower has no fee to pay");
        }

        private void WelcomeText()
        {
            Console.WriteLine("Welcome to the library!");
        }
        
        private void CategoryText()
        {
            Console.WriteLine("Please Choose a book from one of the following categories:");
            
            int i = 0;
            foreach (BookCategory bt in (BookCategory[])Enum.GetValues(typeof(BookCategory)))
            {
                Console.WriteLine("{0}. {1}", ++i, bt);
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

        /// <summary>
        /// Takes user input and assigns it to the <c>choice</c> variable. Input must be numeric
        /// and must be defined in the BookCategory enum, otherwise an exception will be thrown
        /// </summary>
        private void ReceiveCategoryInput()
        {
            int inputNumber = Convert.ToInt32(Console.ReadLine()) - 1;
            if (Enum.IsDefined(typeof(BookCategory), inputNumber))
            {
                this.choice = (BookCategory)inputNumber;
                return;
            }

            throw new ArithmeticException("Invalid user input"); 
        }
        
        /// <summary>
        /// Calls the <c>ReceiveCategoryInput</c> method until no exception is thrown. In short: 
        /// Makes sure the user category input is valid
        /// </summary>
        private void ReceiveCategoryInputValidationLoop()
        {
            bool inputValid;
            do
            {
                try
                {
                    this.CategoryText();
                    this.ReceiveCategoryInput();
                    inputValid = true;
                }
                catch
                {
                    inputValid = false;
                    Console.WriteLine("Please input the correct value");
                }
            } 
            while (!inputValid);
        }

        /// <summary>
        /// Prompts the user to enter the day, month and year and returns the input as an object of class <c>DateTime</c>
        /// </summary>
        /// /// <returns>The correctly inputted date as <c>DateTime</c></returns>
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
        
        /// <summary>
        /// Calls the <c>ReceiveDateInput</c> method until no exception is thrown. In short: 
        /// Makes sure the user day, month, year input is a valid date.
        /// </summary>
        /// <returns>The correctly inputted date as <c>DateTime</c></returns>
        private DateTime ReceiveDateInputValidationLoop()
        {
            bool inputValid;
            DateTime ret = new DateTime();
            do
            {
                try
                {
                    ret = this.ReceiveDateInput();
                    inputValid = true;
                }
                catch
                {
                    Console.WriteLine("The date you entered is not valid! Please try again!");
                    inputValid = false;
                }
            } 
            while (!inputValid);
            return ret;
        }
    }
}
