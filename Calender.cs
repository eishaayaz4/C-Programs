using System;
public class Calender
{
    public static void PrintCalender()
    {
        // Take input for year
        Console.Write("Enter Year between 2005-2014: ");
        int year = int.Parse(Console.ReadLine());
        if (year < 2005 || year > 2014)
        {
            Console.WriteLine("Enter a valid year (2005-2014)");
            return;
        }

        // Take input for month
        Console.Write("Enter month (1-12): ");
        int month = int.Parse(Console.ReadLine());
        if (month > 12 || month < 1)
        {
            Console.WriteLine("Enter a valid month (between 1-12)");
            return;
        }

        // Get first day of the month
        DateTime firstDayOfMonth = new DateTime(year, month, 1);
        int startDay = (int)firstDayOfMonth.DayOfWeek; // Sunday = 0, Monday = 1, etc.
        startDay = (startDay == 0) ? 6 : startDay - 1;

        // Get days in month
        int daysInMonth = DateTime.DaysInMonth(year, month);

        // Get name of the month
        var monthName = new DateTime(1, month, 1).ToString("MMMM");

        // Print header
        Console.WriteLine($"\n{monthName} - {year}");
        Console.WriteLine("Mo Tu We Th Fr Sa Su");

        // Print leading spaces for the first week
        for (int i = 0; i < startDay; i++)
        {
            Console.Write("   "); // Print 3 spaces to align the first day correctly
        }

        // Print all days of the month
        int currentDay = 1;

        // Print the first week
        for (int i = startDay; i < 7 && currentDay <= daysInMonth; i++)
        {
            Console.Write($"{currentDay,2:D2} "); // Print day with leading zero and 2-character width
            currentDay++;
        }

        Console.WriteLine(); // Move to next line after the first week

        // Print the remaining weeks
        while (currentDay <= daysInMonth)
        {
            for (int i = 0; i < 7 && currentDay <= daysInMonth; i++)
            {
                Console.Write($"{currentDay,2:D2} "); // Print day with leading zero and 2-character width
                currentDay++;
            }
            Console.WriteLine(); // Move to next line after each week
        }
    }

}
