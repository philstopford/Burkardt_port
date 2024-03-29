using System.Globalization;
using Burkardt.MonomialNS;
using Burkardt.SphereNS;
using Burkardt.Types;
using Burkardt.Uniform;

namespace Burkardt_Tests.TestSphere;

public class IntegralsTest
{
        [Test]
    public static void test01()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 uses SPHERE01_SAMPLE to estimate monomial integrands.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    06 January 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        const int m = 3;
        int test;
        const int test_num = 20;

        Console.WriteLine("");
        Console.WriteLine("TEST01");
        Console.WriteLine("  Estimate monomial integrands using Monte Carlo");
        Console.WriteLine("  over the surface of the unit sphere in 3D.");
        //
        //  Get sample points.
        //
        const int n = 8192;
        int seed = 123456789;
        double[] x = Integrals.sphere01_sample(n, ref seed);
        Console.WriteLine("");
        Console.WriteLine("  Number of sample points used is " + n + "");
        //
        //  Randomly choose X,Y,Z exponents between (0,0,0) and (9,9,9).
        //
        Console.WriteLine("");
        Console.WriteLine("  If any exponent is odd, the integral is zero.");
        Console.WriteLine("  We will restrict this test to randomly chosen even exponents.");
        Console.WriteLine("");
        Console.WriteLine("  Ex  Ey  Ez     MC-Estimate           Exact      Error");
        Console.WriteLine("");
        for (test = 1; test <= test_num; test++)
        {
            int[] e = UniformRNG.i4vec_uniform_ab_new(m, 0, 4, ref seed);
            int i;
            for (i = 0; i < m; i++)
            {
                e[i] *= 2;
            }

            double[] value = Monomial.monomial_value(m, n, e, x);

            double result = Integrals.sphere01_area() * typeMethods.r8vec_sum(n, value) / n;
            double exact = Integrals.sphere01_monomial_integral(e);
            double error = Math.Abs(result - exact);

            Console.WriteLine("  " + e[0].ToString().PadLeft(2)
                                   + "  " + e[1].ToString().PadLeft(2)
                                   + "  " + e[2].ToString().PadLeft(2)
                                   + "  " + result.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + exact.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + error.ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
        }
    }

}