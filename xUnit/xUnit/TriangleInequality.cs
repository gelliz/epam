using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnit
{
    public class triangle
    {
        public static bool IsTriangle(double a, double b, double c)
        {
            if (a > 0 || b > 0 || c > 0 || a + b > c || a + c > b || b + c > a)
                return true;
            return false;
        }
    }
}
