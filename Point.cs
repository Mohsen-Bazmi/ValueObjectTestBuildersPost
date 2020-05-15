using System;

namespace ValueObjectTestBuildersPost
{
    public class Point
    {
        public Point(double x, double y, double z = 0)
        {
            if (x > 90)
                throw new ArgumentOutOfRangeException();
            X = x;
        }
        public Point ButWithX(double alternativeX)
        {
            return new Point(alternativeX, this.Y, this.Z);
        }
        public double X { get; }
        public double Y { get; }
        public double Z { get; }
    }
}