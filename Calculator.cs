using System;
public class Calculator
{

    public static void Start()
    {
        bool continueProgram = true;
        while (continueProgram)
        {
            Console.WriteLine("Select the desired geometrical figure:");
            Console.WriteLine("1 - Circle");
            Console.WriteLine("2 - Rectangle");
            Console.WriteLine("3 - Square");
            Console.WriteLine("4 - Triangle");
            Console.WriteLine("5 - Exit");
            Console.Write("Enter the number corresponding to your choice: ");

            try
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        CalculateCircle();
                        break;
                    case 2:
                        CalculateRectangle();
                        break;
                    case 3:
                        CalculateSquare();
                        break;
                    case 4:
                        CalculateTriangle();
                        break;
                    case 5:
                        continueProgram = false;
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please select a valid option.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter a number between 1 and 5.");
            }

            if (continueProgram)
            {
                Console.WriteLine("\nDo you want to perform another calculation? (yes/no)");
                string continueChoice = Console.ReadLine().ToLower();
                switch (continueChoice)
                {
                    case "yes":
                        continueProgram = true;
                        break;
                    case "no":
                        continueProgram = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please select a valid option.");
                        break;
                }
            }
        }
    }

    static void CalculateCircle()
    {
        Console.WriteLine("Enter radius of the circle");
        double radius = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("What you want to calculate");
        Console.WriteLine("1- Circumference");
        Console.WriteLine("2- Diameter");
        Console.WriteLine("3- Area");
        Console.WriteLine("Enter number corresponding to your choice...");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                double Circumference = 2 * Math.PI * radius;
                Console.WriteLine("Circumference of circle is :" + Circumference);
                break;
            case 2:
                double Diameter = 2 * radius;
                Console.WriteLine("Diameter of circle is :" + Diameter);
                break;
            case 3:
                double Area = Math.PI * radius * radius;
                Console.WriteLine("Area of circle is :" + Area);
                break;
            default:
                Console.WriteLine("Invalid choice! Please select a valid option.");
                break;
        }
    }

    static void CalculateRectangle()
    {
        Console.WriteLine("Enter length of the Rectangle");
        int length = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter width of the Rectangle");
        int width = int.Parse(Console.ReadLine());

        Console.WriteLine("What you want to calculate");
        Console.WriteLine("1- Area");
        Console.WriteLine("2- Parimeter");
        Console.WriteLine("Enter number corresponding to your choice...");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                double Area = length * width;
                Console.WriteLine("Area of rectangle is :" + Area);
                break;
            case 2:
                double parimeter = (length + width) * 2;
                Console.WriteLine("Parimeter of rectangle is :" + parimeter);
                break;
            default:
                Console.WriteLine("Invalid choice! Please select a valid option.");
                break;

        }
    }

    static void CalculateSquare()
    {
        Console.WriteLine("Enter length of the side");
        int length = int.Parse(Console.ReadLine());

        Console.WriteLine("What you want to calculate");
        Console.WriteLine("1- Area");
        Console.WriteLine("2- Parimeter");
        Console.WriteLine("Enter number corresponding to your choice...");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                double Area = length * length;
                Console.WriteLine("Area of square is :" + Area);
                break;
            case 2:
                double parimeter = 4 * length;
                Console.WriteLine("Parimeter of Square is :" + parimeter);
                break;
            default:
                Console.WriteLine("Invalid choice! Please select a valid option.");
                break;

        }
    }

    static void CalculateTriangle()
    {

        Console.WriteLine("Select mode");
        Console.WriteLine("1- Enquiry mode");
        Console.WriteLine("2- Length mode");
        Console.WriteLine("3- Angle mode");
        Console.WriteLine("4- Area mode");
        Console.WriteLine("Enter number corresponding to your choice...");
        int choice = int.Parse(Console.ReadLine());
        switch (choice)
        {
            case 1:
                EnquiryMode();
                break;
            case 2:
                LengthMode();
                break;
            case 3:
                AngleMode();
                break;
            case 4:
                AreaMode();
                break;
            default:
                Console.WriteLine("Invalid choice! Please select a valid option.");
                break;
        }
    }
    static void EnquiryMode()
    {
        Console.Write("Enter three sides of triangle: ");
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());
        double c = Convert.ToDouble(Console.ReadLine());
        if (IsRightAngle(a, b, c))
        {
            Console.WriteLine("Triangle is a right angle triangle");
        }
        else if (IsAcute(a, b, c))
        {
            Console.WriteLine("Triangle is a acute angle triangle");
        }
        else
        {
            Console.WriteLine("Triangle is a obtuse angle triangle");
        }
    }
    static void AngleMode()
    {
        Console.Write("Enter three sides of triangle: ");
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());
        double c = Convert.ToDouble(Console.ReadLine());
        if (IsTriangle(a, b, c))
        {
            double angleA = CalculateAngle(b, c, a);
            double angleB = CalculateAngle(a, c, b);
            double angleC = CalculateAngle(a, b, c);

            // Output the angles in degrees
            Console.WriteLine($"The first angle is: {angleA:F2} degrees");
            Console.WriteLine($"The second angle is: {angleB:F2} degrees");
            Console.WriteLine($"The third angle is: {angleC:F2} degrees");
        }
        else
        {
            Console.WriteLine("The given sides do not form a valid triangle.");
        }
    }
    static void LengthMode()
    {
        Console.Write("Enter two angles of triangle: ");
        double angle1 = Convert.ToDouble(Console.ReadLine());
        double angle2 = Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter a side of triangle: ");
        double side1 = Convert.ToDouble(Console.ReadLine());
        double angle3 = 180 - angle1 - angle2;
        double angle1Rad = angle1 * Math.PI / 180;
        double angle2Rad = angle2 * Math.PI / 180;
        double angle3Rad = angle3 * Math.PI / 180;

        // Use the Law of Sines to calculate the other two sides
        double side2 = (side1 * Math.Sin(angle2Rad)) / Math.Sin(angle3Rad);
        double side3 = (side1 * Math.Sin(angle1Rad)) / Math.Sin(angle3Rad);
        Console.WriteLine($"angle1 :{angle1:F2} angle2{angle2:F2} angle3 {angle3:F2}");
        Console.WriteLine("side1 :" + side1 + " side2 :" + side2 + " side3 :" + side3);

    }

    static void AreaMode()
    {
        Console.Write("Enter three sides of triangle: ");
        double a = Convert.ToDouble(Console.ReadLine());
        double b = Convert.ToDouble(Console.ReadLine());
        double c = Convert.ToDouble(Console.ReadLine());
        if (IsTriangle(a, b, c))
        {
            double perimeter = a + b + c;
            double semiPerimeter = perimeter / 2;
            // Calculate the area using Heron's formula
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
            Console.WriteLine($"The perimeter of the triangle is: {perimeter:F2}");
            Console.WriteLine($"The area of the triangle is: {area:F2}");

        }
        else
        {
            Console.WriteLine("Sides doesn't make a triangle");
        }
    }
    static bool IsRightAngle(double a, double b, double c)
    {
        double[] arr = { a, b, c };
        Array.Sort(arr);
        return Math.Pow(arr[2], 2) == Math.Pow(arr[0], 2) + Math.Pow(arr[1], 2);
    }
    static bool IsAcute(double a, double b, double c)
    {
        double[] arr = { a, b, c };
        Array.Sort(arr);
        return Math.Pow(arr[2], 2) < Math.Pow(arr[0], 2) + Math.Pow(arr[1], 2);
    }

    //validating if given sides make a triangle
    static bool IsTriangle(double a, double b, double c)
    {
        return a + b > c && b + c > a && c + a > b;
    }

    // Calculate the angle using the Law of Cosines
    static double CalculateAngle(double side1, double side2, double oppositeSide)
    {
        // Law of Cosines: cos(angle) = (side1^2 + side2^2 - oppositeSide^2) / (2 * side1 * side2)
        double cosAngle = (Math.Pow(side1, 2) + Math.Pow(side2, 2) - Math.Pow(oppositeSide, 2)) / (2 * side1 * side2);
        // Convert the cosine value to an angle in degrees
        double angleInRadians = Math.Acos(cosAngle); // Math.Acos returns the angle in radians
        return angleInRadians * (180 / Math.PI); // Convert radians to degrees
    }
}
