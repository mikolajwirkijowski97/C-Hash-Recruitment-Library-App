using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryApp
{
    public enum BookCategory
    {
        It,
        History,
        Classics,
        Law,
        Medical,
        Philosophy

    }
    class Library
    {

        public int BookCostPerDay(BookCategory b)
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
        public int UserDebt(DateTime rentDay, DateTime returnDay, BookCategory b)
        {
            return DaysBetween(rentDay,returnDay) * BookCostPerDay(b);
        }
        private int DaysBetween(DateTime d1, DateTime d2)
        {
            TimeSpan span = d2.Subtract(d1);
            return (int)span.TotalDays;
        }


    }
}
