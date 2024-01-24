using Burkardt.CircleNS;
using Burkardt.Types;

namespace Burkardt_Tests.TestCircle;

public class ArcTest
{
    [Test]
    public static void test01()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 demonstrates the use of CIRCLE_ARC_GRID.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    13 November 2011
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double[] a = new double[2];
        double[] c = new double[2];
        const string filename = "arc.txt";

        Console.WriteLine("");
        Console.WriteLine("TEST01");
        Console.WriteLine("  Compute points along a 90 degree arc");

        const double r = 2.0;
        c[0] = 5.0;
        c[1] = 5.0;
        a[0] = 0.0;
        a[1] = 90.0;
        const int n = 10;
        //
        //  Echo the input.
        //
        Console.WriteLine("");
        Console.WriteLine("  Radius =           " + r + "");
        Console.WriteLine("  Center =           " + c[0] + "  " + c[1] + "");
        Console.WriteLine("  Angle 1 =          " + a[0] + "");
        Console.WriteLine("  Angle 2 =          " + a[1] + "");
        Console.WriteLine("  Number of points = " + n + "");
        //
        //  Compute the data.
        //
        double[] xy = Circle.circle_arc_grid(r, c, a, n);
        //
        //  Print a little of the data.
        //
        typeMethods.r82vec_print_part(n, xy, 5, "  A few of the points:");
        //
        //  Write the data.
        //
        typeMethods.r8mat_write(filename, 2, n, xy);
        Console.WriteLine("");
        Console.WriteLine("  Data written to \"" + filename + "\".");
    }
    
}