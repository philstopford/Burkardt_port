using System.Globalization;
using Burkardt.MonomialNS;
using Burkardt.Types;
using Burkardt.Wedge;

namespace Burkhardt_Tests.Wedge;

public class MonteCarloTest
{
    private static void test01()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 uses WEDGE01_SAMPLE with an increasing number of points.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    18 August 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int[] e = new int[3];
        int[] e_test =  {
                0, 0, 0,
                1, 0, 0,
                0, 1, 0,
                0, 0, 1,
                2, 0, 0,
                1, 1, 0,
                0, 0, 2,
                3, 0, 0
            }
            ;
        int i;
        int j;
        const int m = 3;
        double result;

        Console.WriteLine("");
        Console.WriteLine("TEST01");
        Console.WriteLine("  Use WEDGE01_SAMPLE for a Monte Carlo estimate of an");
        Console.WriteLine("  integral over the interior of the unit wedge in 3D.");

        int seed = 123456789;

        Console.WriteLine("");
        Console.WriteLine("         N        1               X               Y " + 
                          "              Z                X^2            XY              Z^2    " + 
                          "        X^3");
        Console.WriteLine("");

        int n = 1;

        while (n <= 65536)
        {
            double[] x = MonteCarlo.wedge01_sample(n, ref seed);

            string cout = "  " + n.ToString().PadLeft(8);

            for (j = 0; j < 8; j++)
            {
                for (i = 0; i < m; i++)
                {
                    e[i] = e_test[i + j * m];
                }

                double[] value = Monomial.monomial_value(m, n, e, x);

                result = MonteCarlo.wedge01_volume() * typeMethods.r8vec_sum(n, value) / n;
                cout += "  " + result.ToString(CultureInfo.InvariantCulture).PadLeft(14);
            }

            Console.WriteLine(cout);
                
            n = 2 * n;
        }

        string cout2 = "     Exact";

        for (j = 0; j < 8; j++)
        {
            for (i = 0; i < m; i++)
            {
                e[i] = e_test[i + j * m];
            }

            result = MonteCarlo.wedge01_integral(e);
            cout2 += "  " + result.ToString(CultureInfo.InvariantCulture).PadLeft(14);
        }

        Console.WriteLine(cout2);
    }
    
}