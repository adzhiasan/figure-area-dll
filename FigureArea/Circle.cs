using System;

namespace FigureArea
{
    public class Circle: Figure
    {
        private double _radius;

        public double Radius {
            get => _radius; 
            set 
            {
                if (value < 0)
                    throw new Exception("Radius must be greater than zero.");
                _radius = value;
            }
        }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double CalculateArea() => Math.PI * Radius * Radius;
    }
}
