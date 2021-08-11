using System;

namespace FigureArea
{
    public class Triangle : Figure
    {
        private double _firstSide;
        private double _secondSide;
        private double _thirdSide;

        private double[] sortedSides;
        public double FirstSide
        {
            get { return _firstSide; }
            private set
            {
                GreaterThanZeroCheck(value);
                _firstSide = value;
            }
        }

        public double SecondSide
        {
            get { return _secondSide; }
            private set
            {
                GreaterThanZeroCheck(value);
                _secondSide = value;
            }
        }

        public double ThirdSide
        {
            get { return _thirdSide; }
            private set
            {
                GreaterThanZeroCheck(value);
                _thirdSide = value;
            }
        }

        private void GreaterThanZeroCheck(double value)
        {
            if (value < 0)
                throw new Exception("Side must be greater than zero.");
        }

        public Triangle(double firstSide, double secondSide, double thirdSide)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;

            if (!IsTriangle())
                throw new UnrealTriangleException();

            sortedSides = new double[]{ FirstSide, SecondSide, ThirdSide };
            Array.Sort(sortedSides);
        }

        private bool IsTriangle()
        {
            bool isFirstSideCorrect = SecondSide + ThirdSide > FirstSide;
            bool isSecondSideCorrect = FirstSide + ThirdSide > SecondSide;
            bool isThirdSideCorrect = FirstSide + SecondSide > ThirdSide;

            if (isFirstSideCorrect && isSecondSideCorrect && isThirdSideCorrect)
                return true;
            return false;
        }

        public override double CalculateArea()
        {
            if (IsRightTriangle())
                return sortedSides[0] * sortedSides[1] / 2;
            return HeronsFormula();
        }


        private double HeronsFormula()
        {
            double semiPerimeter = (FirstSide + SecondSide + ThirdSide) / 2;
            double resultSquare = semiPerimeter * (semiPerimeter - FirstSide) * (semiPerimeter - SecondSide) * (semiPerimeter - ThirdSide);

            return Math.Sqrt(resultSquare);
        }

        public bool IsRightTriangle()
        {
            double firstLegSquare = sortedSides[0] * sortedSides[0];
            double secondLegSquare = sortedSides[1] * sortedSides[1];
            double hypotenuseSquare = sortedSides[2] * sortedSides[2];

            if (hypotenuseSquare == firstLegSquare + secondLegSquare)
                return true;
            return false;
        }
    }
}
