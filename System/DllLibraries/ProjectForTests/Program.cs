using Geometry_Functions;
using System;
using String_Functions;
using Contact_Info;
using File_Manager;
using System.Collections.Generic;

namespace ProjectForTests
{
    public class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Area of triangel with sides 5 9 10: " + GeometryFunctions.CountAreaOfTriangelBy3Sides(5, 9, 10));
            Console.WriteLine("Area or rectangle with sides 5 and 10: " + GeometryFunctions.CountAreaOfRectangle(10, 5));
            Console.WriteLine("Area of square with side 5: " + GeometryFunctions.CountAreaOfSquare(5));
            Console.WriteLine();


            Console.WriteLine("-taco cat is palindrome ? - " + StringFunctions.StringIsPalindrome("taco cat"));
            Console.WriteLine("taco cat reverse - " + StringFunctions.ReversString("taco cat"));
            Console.WriteLine("Hi! My name is tacocat. Sentences in this string - " + StringFunctions.CountSentences("Hi! My name is tacocat."));
            Console.WriteLine();


            Console.WriteLine("Andreww Fedorov, Dmit - is it correct? - " + ContactInfo.isRightFullName("Andreww", "Fedorov", "Dmit"));
            Console.WriteLine("And2eww Fed5rov, Dmit - is it correct? - " + ContactInfo.isRightFullName("And2eww", "Fed5rov", "Dmit"));
            Console.WriteLine("+3804329423 with format +380 is it correct? - " + ContactInfo.isRightTelephoneByFormat("+3804329423", "+380"));
            Console.WriteLine("+3204329423 with format +380 is it correct? - " + ContactInfo.isRightTelephoneByFormat("+3204329423", "+380"));
            Console.WriteLine("Aboba@gmail.com with format @gmail.com is it correct? - " + ContactInfo.isRightEmailByFormat("Aboba@gmail.com", "@gmail.com"));
            Console.WriteLine("Aboba@mg41.mk.ua with format @gmail.com is it correct? - " + ContactInfo.isRightEmailByFormat("Aboba@mg41.mk.ua", "@gmail.com"));



            Console.ReadKey();
        }
    }
}
