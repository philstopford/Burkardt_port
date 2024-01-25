using System.Globalization;
using Burkardt.MonomialNS;
using Burkardt.Types;
using MonteCarlo = Burkardt.LineNS.MonteCarlo;

namespace Burkardt_Tests.TestLine;

public class MonteCarloTest
{
    [Test]
    public static void line01_sample_random_test()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    LINE01_SAMPLE_RANDOM_TEST compares exact and estimated monomial integrals.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    07 June 2017
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        const int n = 4192;
        int test;
        const int test_num = 11;

        Console.WriteLine("");
        Console.WriteLine("LINE01_SAMPLE_RANDOM_TEST");
        Console.WriteLine("  LINE01_SAMPLE_RANDOM randomly samples the unit line segment.");
        Console.WriteLine("  Use it to estimate integrals.");
        //
        //  Get sample points.
        //
        int seed = 123456789;
        double[] x = MonteCarlo.line01_sample_random(n, ref seed);

        Console.WriteLine("");
        Console.WriteLine("  Number of sample points used is " + n + "");
        Console.WriteLine("");
        Console.WriteLine("   E     MC-Estimate      Exact           Error");
        Console.WriteLine("");

        for (test = 1; test <= test_num; test++)
        {
            int e = test - 1;

            double[] value = Monomial.monomial_value_1d(n, e, x);

            double result = MonteCarlo.line01_length() * typeMethods.r8vec_sum(n, value) / n;
            double exact = MonteCarlo.line01_monomial_integral(e);
            double error = Math.Abs(result - exact);

            Console.WriteLine("  " + e.ToString(CultureInfo.InvariantCulture).PadLeft(2)
                                   + "  " + result.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + exact.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + error.ToString(CultureInfo.InvariantCulture).PadLeft(10) + "");
        }

    }

    [Test]
    public static void line01_sample_ergodic_test()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    LINE01_SAMPLE_ERGODIC_TEST compares exact and estimated monomial integrals.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    07 June 2017
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        const int n = 4192;
        int test;
        const int test_num = 11;

        Console.WriteLine("");
        Console.WriteLine("LINE01_SAMPLE_ERGODIC_TEST");
        Console.WriteLine("  LINE01_SAMPLE_ERGODIC ergodically samples the unit line segment.");
        Console.WriteLine("  Use it to estimate integrals.");
        //
        //  Get sample points.
        //
        double shift = 0.0;
        double[] x = MonteCarlo.line01_sample_ergodic(n, ref shift);

        Console.WriteLine("");
        Console.WriteLine("  Number of sample points used is " + n + "");
        Console.WriteLine("");
        Console.WriteLine("   E     MC-Estimate      Exact           Error");
        Console.WriteLine("");

        for (test = 1; test <= test_num; test++)
        {
            int e = test - 1;

            double[] value = Monomial.monomial_value_1d(n, e, x);

            double result = MonteCarlo.line01_length() * typeMethods.r8vec_sum(n, value) / n;
            double exact = MonteCarlo.line01_monomial_integral(e);
            double error = Math.Abs(result - exact);

            Console.WriteLine("  " + e.ToString(CultureInfo.InvariantCulture).PadLeft(2)
                                   + "  " + result.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + exact.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + error.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "");

        }

    }
    
}