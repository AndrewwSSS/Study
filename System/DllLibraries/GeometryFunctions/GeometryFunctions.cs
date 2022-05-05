
using System;

namespace Geometry_Functions
{
    public static class GeometryFunctions
    {
        public static double CountAreaOfTriangelBy3Sides(double side1, double side2, double side3)
        {
            double p = (side1 + side2 + side3)/2;
            return Math.Sqrt(p * (p - side1) * (p - side2) * (p - side3));
        }


        public static double CountAreaOfRectangle(double height, double width)
        {
            return width * height;
        }


        public static double CountAreaOfSquare(double side)
        {
            return side*side;
        }

    }
}
