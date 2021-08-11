using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureArea
{
    public class UnrealTriangleException: Exception
    {
        public override string Message => "The sum of the length of any two sides of a triangle must be greater than the length of the third side.";
    }
}
