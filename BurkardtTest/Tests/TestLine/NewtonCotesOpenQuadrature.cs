using System.Globalization;
using Burkardt.LineNS;

namespace Burkardt_Tests.TestLine;

public class NewtonCotesOpenQuadratureTest
{
    [Test]
    public static void test01()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 computes and prints NCO rules.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    28 July 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int n;

        const double a = -1.0;
        const double b = +1.0;

        Console.WriteLine("");
        Console.WriteLine("TEST01");
        Console.WriteLine("  LINE_NCO_RULE computes the Newton-Cotes Open (NCO) rule");
        Console.WriteLine("  using N equally spaced points for an interval [A,B].");

        for (n = 1; n <= 12; n++)
        {
            double[] x = new double[n];
            double[] w = new double[n];

            NewtonCotesQuadrature.line_nco_rule(n, a, b, x, ref w);
            Console.WriteLine("");
            Console.WriteLine("  Newton-Cotes Open (NCO) Rule #" + n + "");
            Console.WriteLine("   I       X(I)            W(I)");
            Console.WriteLine("");
            double w_sum = 0.0;
            int i;
            for (i = 0; i < n; i++)
            {
                Console.WriteLine("  " + i.ToString(CultureInfo.InvariantCulture).PadLeft(2)
                                       + "  " + x[i].ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                       + "  " + w[i].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
                w_sum += Math.Abs(w[i]);
            }

            Console.WriteLine("        Sum(|W)|) =  " + w_sum.ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
        }
    }

    [Test]
    public static void test02()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST02 uses NCO rules to estimate the integral of exp(x) from 0 to 1.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    28 July 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int n;

        const double a = 0.0;
        const double b = +1.0;
        double exact = Math.Exp(b) - Math.Exp(a);

        Console.WriteLine("");
        Console.WriteLine("TEST02");
        Console.WriteLine("  Use a sequence of NCO rules to compute an estimate Q");
        Console.WriteLine("  of the integral:");
        Console.WriteLine("    I = integral ( 0 <= x <= 1 ) exp(x) dx.");
        Console.WriteLine("  The exact value is:");
        Console.WriteLine("    I = " + exact + "");

        Console.WriteLine("");
        Console.WriteLine("   N       Q             |Q-I|");
        Console.WriteLine("");

        for (n = 1; n <= 22; n++)
        {
            double[] x = new double[n];
            double[] w = new double[n];

            NewtonCotesQuadrature.line_nco_rule(n, a, b, x, ref w);

            double q = 0.0;
            int i;
            for (i = 0; i < n; i++)
            {
                q += w[i] * Math.Exp(x[i]);
            }

            double error = Math.Abs(exact - q);
            Console.WriteLine("  " + n.ToString(CultureInfo.InvariantCulture).PadLeft(2)
                                   + "  " + q.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + error.ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
        }
    }
    
}