using System;

namespace LibraryApp
{
    static class Library
    {
        /// <summary>
        /// Returns the daily cost of returning a book late.
        /// </summary>
        /// <param name="b">Category of the book as defined in the <c>BookCategory</c> enum</param>
        /// <returns>The value of debt in PLN as an <c>int</c></returns>
        static public int BookCostPerDay(BookCategory b)
        {
            return b switch
            {
                BookCategory.It => 5,
                BookCategory.History => 3,
                BookCategory.Classics => 2,
                BookCategory.Law => 2,
                BookCategory.Medical => 2,
                BookCategory.Philosophy => 2,
                _ => 0
            };
        }
        /// <summary>
        /// Returns the calculated debt of the borrower. One day of rental is at no cost.
        /// </summary>
        /// <param name="rentDay">The day the book was rented</param>
        /// <param name="returnDay">The day the book was returned</param>
        /// <param name="b">The category of the book</param>
        /// <returns>The user debt in PLN as an integer</returns>
        static public int UserDebt(DateTime rentDay, DateTime returnDay, BookCategory b)
        {
            int daysAllowed = 1;
            return (DaysBetween(rentDay,returnDay) - daysAllowed) * BookCostPerDay(b);
        }
        /// <summary>
        /// Calculates the number of days between two dates.
        /// </summary>
        /// <param name="d1">The day from which counting starts</param>
        /// <param name="d2">The day on which the counting ends</param>
        /// <returns>The number of whole days between two dates</returns>
        static private int DaysBetween(DateTime d1, DateTime d2)
        {
            TimeSpan span = d2.Subtract(d1);
            return (int)span.TotalDays;
        }
    }
}
