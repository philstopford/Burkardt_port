namespace Burkardt_Tests.TestSquare;
using Burkardt.IntegralNS;
using Burkardt.Quadrature;

public class ExactnessTest
{
    [Test]
    public static void test01()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 tests product Gauss-Legendre rules for the Legendre 2D integral.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    31 May 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double[] a = new double[2];
        double[] b = new double[2];
        int l;

        a[0] = -1.0;
        a[1] = -1.0;
        b[0] = +1.0;
        b[1] = +1.0;

        Console.WriteLine("");
        Console.WriteLine("TEST01");
        Console.WriteLine("  Product Gauss-Legendre rules for the 2D Legendre integral.");
        Console.WriteLine("  Density function rho(x) = 1.");
        Console.WriteLine("  Region: -1 <= x <= +1.");
        Console.WriteLine("  Region: -1 <= y <= +1.");
        Console.WriteLine("  Level: L");
        Console.WriteLine("  Exactness: 2*L+1");
        Console.WriteLine("  Order: N = (L+1)*(L+1)");

        for (l = 0; l <= 5; l++)
        {
            int n_1d = l + 1;
            int n = n_1d * n_1d;
            int t = 2 * l + 1;

            double[] w = new double[n];
            double[] x = new double[n];
            double[] y = new double[n];

            LegendreQuadrature.legendre_2d_set(a, b, n_1d, n_1d, ref x, ref y, ref w);

            int p_max = t + 1;
            Integral.legendre_2d_exactness(a, b, n, ref x, ref y, ref w, p_max);
        }

    }

    [Test]
    public static void test02()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST02 tests Padua rules for the Legendre 2D integral.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    31 May 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double[] a = new double[2];
        double[] b = new double[2];
        int l;

        a[0] = -1.0;
        a[1] = -1.0;
        b[0] = +1.0;
        b[1] = +1.0;

        Console.WriteLine("");
        Console.WriteLine("TEST02");
        Console.WriteLine("  Padua rule for the 2D Legendre integral.");
        Console.WriteLine("  Density function rho(x) = 1.");
        Console.WriteLine("  Region: -1 <= x <= +1.");
        Console.WriteLine("  Region: -1 <= y <= +1.");
        Console.WriteLine("  Level: L");
        Console.WriteLine("  Exactness: L+1 when L is 0,");
        Console.WriteLine("             L   otherwise.");
        Console.WriteLine("  Order: N = (L+1)*(L+2)/2");

        for (l = 0; l <= 5; l++)
        {
            int n = (l + 1) * (l + 2) / 2;

            double[] w = new double[n];
            double[] x = new double[n];
            double[] y = new double[n];

            Burkardt.Values.Padua.padua_point_set(l, ref x, ref y);
            Burkardt.Values.Padua.padua_weight_set(l, ref w);

            int p_max = l switch
            {
                0 => l + 2,
                _ => l + 1
            };

            Integral.legendre_2d_exactness(a, b, n, ref x, ref y, ref w, p_max);

        }

    }
    
}