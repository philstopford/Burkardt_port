using System.Globalization;
using Burkardt.Polygon;

namespace Burkardt_Tests.TestPolygon;

public class IntegralsTest
{
    [Test]
    public static void test01()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 carries out a test on a rectangle.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    03 October 2012
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double[] alpha_exact =
        {
            1.0,
            5.0, 4.0,
            30.66666666666667, 22.0, 18.66666666666666
        };
        double[] mu_exact =
        {
            1.0,
            0.0, 0.0,
            5.666666666666667, 2.0, 2.666666666666667
        };
        const int n = 4;
        double[] nu_exact =
        {
            40.0,
            200.0, 160.0,
            1226.66666666666667, 880.0, 746.66666666666666
        };
        int p;
        int q;
        int s;
        double[] x =
        {
            2.0, 10.0, 8.0, 0.0
        };
        double[] y =
        {
            0.0, 4.0, 8.0, 4.0
        };

        Console.WriteLine("");
        Console.WriteLine("TEST01");
        Console.WriteLine("  Check normalized moments of a rectangle.");
        Console.WriteLine("");
        Console.WriteLine("   P   Q             Nu(P,Q)");
        Console.WriteLine("            Computed         Exact");
        Console.WriteLine("");
        int k = 0;
        for (s = 0; s <= 2; s++)
        {
            for (p = s; 0 <= p; p--)
            {
                q = s - p;
                double nu_pq = Integrals.moment(n, x, y, p, q);
                Console.WriteLine("  " + p.ToString(CultureInfo.InvariantCulture).PadLeft(2)
                                       + "  " + q.ToString(CultureInfo.InvariantCulture).PadLeft(2)
                                       + "  " + nu_pq.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                       + "  " + nu_exact[k].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
                k += 1;
            }
        }

        Console.WriteLine("");
        Console.WriteLine("   P   Q           Alpha(P,Q)");
        Console.WriteLine("            Computed         Exact");
        Console.WriteLine("");
        k = 0;
        for (s = 0; s <= 2; s++)
        {
            for (p = s; 0 <= p; p--)
            {
                q = s - p;
                double alpha_pq = Integrals.moment_normalized(n, x, y, p, q);
                Console.WriteLine("  " + p.ToString(CultureInfo.InvariantCulture).PadLeft(2)
                                       + "  " + q.ToString(CultureInfo.InvariantCulture).PadLeft(2)
                                       + "  " + alpha_pq.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                       + "  " + alpha_exact[k].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
                k += 1;
            }
        }

        Console.WriteLine("");
        Console.WriteLine("   P   Q             Mu(P,Q)");
        Console.WriteLine("            Computed         Exact");
        Console.WriteLine("");
        k = 0;
        for (s = 0; s <= 2; s++)
        {
            for (p = s; 0 <= p; p--)
            {
                q = s - p;
                double mu_pq = Integrals.moment_central(n, x, y, p, q);
                Console.WriteLine("  " + p.ToString(CultureInfo.InvariantCulture).PadLeft(2)
                                       + "  " + q.ToString(CultureInfo.InvariantCulture).PadLeft(2)
                                       + "  " + mu_pq.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                       + "  " + mu_exact[k].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
                k += 1;
            }
        }
    }
    
}