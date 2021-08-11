using System;
using System.Collections.Generic;
using Xunit;

namespace FigureArea.Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(1, -1, -2)]
        [InlineData(-1, -3.5, -1)]
        [InlineData(0, -3.5, -1)]
        [InlineData(0, 0, -1)]
        public void NegativeSidesTest(double firstSide, double secondSide, double thirdSide)
        {
            var caughtException = Assert.Throws<Exception>(() => new Triangle(firstSide, secondSide, thirdSide));

            Assert.Equal("Side must be greater than zero.", caughtException.Message);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-10)]
        public void NegativeRadiusTest(double radius)
        {
            var caughtException = Assert.Throws<Exception>(() => new Circle(radius));

            Assert.Equal("Radius must be greater than zero.", caughtException.Message);
        }

        [Theory]
        [InlineData(7, 2, 9)]
        [InlineData(5, 7, 12)]
        [InlineData(29, 7, 12)]
        public void UnrealTriangleTest(double firstSide, double secondSide, double thirdSide)
        {
            Assert.Throws<UnrealTriangleException>(() => new Triangle(firstSide, secondSide, thirdSide));
        }

        [Theory]
        [InlineData(3, 4, 5)]
        [InlineData(16, 63, 65)]
        [InlineData(33, 56, 65)]
        [InlineData(65, 72, 97)]
        public void RightTriangleTest(double firstSide, double secondSide, double thirdSide)
        {
            Triangle triangle = new(firstSide, secondSide, thirdSide);

            Assert.True(triangle.IsRightTriangle());
        }

        [Theory]
        [InlineData(2, 4, 5)]
        [InlineData(16, 64, 65)]
        [InlineData(11, 6, 13)]
        [InlineData(5, 8, 12)]
        public void NotRightTriangleTest(double firstSide, double secondSide, double thirdSide)
        {
            Triangle triangle = new(firstSide, secondSide, thirdSide);

            Assert.False(triangle.IsRightTriangle());
        }

        [Theory]
        [MemberData(nameof(DataForAreaCalculating))]
        public void AnyFigureCalculateArea(Figure figure, double expectedArea)
        {
            Assert.Equal(expectedArea, figure.CalculateArea());
        }

        public static IEnumerable<object[]> DataForAreaCalculating =>
            new List<object[]>
            {
                new object[] { new Triangle(5, 8, 12), 14.523687548277813 },
                new object[] { new Triangle(16, 63, 65), 504.0 },
                new object[] { new Circle(0), 0 },
                new object[] { new Circle(10), 314.1592653589793 },
            };
    }
}
