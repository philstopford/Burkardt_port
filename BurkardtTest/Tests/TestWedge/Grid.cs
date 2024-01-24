using System.Globalization;
using Burkardt.Wedge;

namespace Burkardt_Tests.TestWedge;

public class GridTest
{
    [Test]
    public static void test01()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 tests WEDGE_GRID.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    22 August 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int j;
        const int n = 5;
        List<string> output_unit = new();

        Console.WriteLine("");
        Console.WriteLine("TEST01");
        Console.WriteLine("  WEDGE_GRID can define a grid of points");
        Console.WriteLine("  with N+1 points on a side");
        Console.WriteLine("  over the interior of the unit wedge in 3D.");

        Console.WriteLine("");
        Console.WriteLine("  Grid order N = " + n + "");

        int ng = Grid.wedge_grid_size(n);

        Console.WriteLine("  Grid count NG = " + ng + "");

        double[] g = Grid.wedge_grid(n, ng);

        Console.WriteLine("");
        Console.WriteLine("     J      X                Y               Z");
        Console.WriteLine("");
        for (j = 0; j < ng; j++)
        {
            Console.WriteLine(j.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  "
                                                      + g[0 + j * 3].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "  "
                                                      + g[1 + j * 3].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "  "
                                                      + g[2 + j * 3].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
        }

        string output_filename = "wedge_grid.xy";

        for (j = 0; j < ng; j++)
        {
            output_unit.Add(g[0 + j * 3] + "  "
                                         + g[1 + j * 3] + "  "
                                         + g[2 + j * 3] + "");
        }
            
        File.WriteAllLines(output_filename, output_unit);

        Console.WriteLine("");
        Console.WriteLine("  Data written to '" + output_filename + "'");
    }

    [Test]
    public static void test02()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST02 tests WEDGE_GRID_PLOT.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    22 August 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        const int n = 5;

        Console.WriteLine("");
        Console.WriteLine("TEST02");
        Console.WriteLine("  WEDGE_GRID_PLOT can create GNUPLOT data files");
        Console.WriteLine("  for displaying a wedge grid.");

        Console.WriteLine("");
        Console.WriteLine("  Grid order N = " + n + "");

        int ng = Grid.wedge_grid_size(n);

        Console.WriteLine("  Grid count NG = " + ng + "");

        double[] g = Grid.wedge_grid(n, ng);

        string header = "wedge";

        Grid.wedge_grid_plot(n, ng, g, header);
    }
    
}