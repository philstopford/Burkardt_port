using Burkardt.MonomialNS;
using Burkardt.SphereNS;
using Burkardt.Types;

namespace Burkardt_Tests.TestSphere;

public class MonteCarloTest
{
    [Test]
    public static void test01()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 uses SPHERE01_SAMPLE with an increasing number of points.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    02 January 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int[] e = new int[3];
        int[] e_test =
        {
            0, 0, 0,
            2, 0, 0,
            0, 2, 0,
            0, 0, 2,
            4, 0, 0,
            2, 2, 0,
            0, 0, 4
        };
        int i;
        int j;
        string cout;

        Console.WriteLine("");
        Console.WriteLine("TEST01");
        Console.WriteLine("  Use SPHERE01_SAMPLE to estimate integrals on the unit sphere surface.");

        int seed = 123456789;

        Console.WriteLine("");
        Console.WriteLine("         N        1              X^2             Y^2" +
                          "             Z^2             X^4            X^2Y^2          Z^4");
        Console.WriteLine("");

        int n = 1;

        while (n <= 65536)
        {
            double[] x = MonteCarlo.sphere01_sample(n, ref seed);
            cout = "  " + n.ToString().PadLeft(8);
            for (j = 0; j < 7; j++)
            {
                for (i = 0; i < 3; i++)
                {
                    e[i] = e_test[i + j * 3];
                }

                double[] value = Monomial.monomial_value(3, n, e, x);

                double result = MonteCarlo.sphere01_area() * typeMethods.r8vec_sum(n, value) / n;
                cout += "  " + result.ToString("0.##########").PadLeft(14);

            }

            Console.WriteLine(cout);

            n = 2 * n;
        }

        Console.WriteLine("");
        cout = "  " + "   Exact";
        for (j = 0; j < 7; j++)
        {
            for (i = 0; i < 3; i++)
            {
                e[i] = e_test[i + j * 3];
            }

            double exact = MonteCarlo.sphere01_monomial_integral(e);
            cout += "  " + exact.ToString("0.##########").PadLeft(14);
        }

        Console.WriteLine(cout);

    }
    
}