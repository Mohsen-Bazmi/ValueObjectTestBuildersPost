using System;
using AutoFixture;
using FluentAssertions;
using Xunit;

namespace ValueObjectTestBuildersPost
{
    public static class A
    {
        public static Point Point
        => new Point(32, -9);
    }
    public class PointTests
    {
        [Fact]
        public void Point_Does_Not_Accept_X_If_It_Is_Greater_Than_90_Using_Default_Constructor()
        {
            Action createPoint = () => new Point(x: 92, y: -9);
            createPoint.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void Point_Accepts_X_When_It_Is_In_The_Right_Range_Using_General_A_Class()
        {
            var expected = new Random().Next(-90, 90);
            var point = A.Point.ButWithX(expected);
            point.X.Should().Be(expected);
        }

        [Fact]
        public void Point_Accepts_X_When_It_Is_In_The_Right_Range_Using_Local_Factory_Method()
        {
            var expected = new Random().Next(-90, 90);
            var point = CreateAPoint().ButWithX(expected);
            point.X.Should().Be(expected);
        }

        static Point CreateAPoint()
        {
            var rnd = new Random();
            return new Point(x: rnd.Next(-90, 90)
                            , y: rnd.Next(-180, 180));
        }
    }
}
