using Burkardt;
using Burkardt.AppliedStatistics;

namespace Burkardt_Tests.TestAppliedStatisticsAlgorithms;

public class ASA109
{
    [Test]
    public static void test01()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 demonstrates the use of XINBTA.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    28 April 2013
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double a = 0;
        double b = 0;
        double fx = 0;
        int ifault = 0;
        double x = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST01:");
        Console.WriteLine("  XINBTA inverts the incomplete Beta function.");
        Console.WriteLine("  Given CDF, it computes an X.");
        Console.WriteLine("");
        Console.WriteLine("           A           B           CDF    "
                          + "    X                         X");
        Console.WriteLine("                                          "
                          + "    (Tabulated)               (XINBTA)            DIFF");
        Console.WriteLine("");

        int n_data = 0;

        for (;;)
        {
            Algorithms.beta_inc_values(ref n_data, ref a, ref b, ref x, ref fx);

            if (n_data == 0)
            {
                break;
            }

            double beta_log = Helpers.LogGamma(a)
                              + Helpers.LogGamma(b)
                              - Helpers.LogGamma(a + b);

            double x2 = Algorithms.xinbta(a, b, beta_log, fx, ref ifault);

            Console.WriteLine("  " + a.ToString("0.####").PadLeft(10)
                                   + "  " + b.ToString("0.####").PadLeft(10)
                                   + "  " + fx.ToString("0.####").PadLeft(10)
                                   + "  " + x.ToString("0.################").PadLeft(24)
                                   + "  " + x2.ToString("0.################").PadLeft(24)
                                   + "  " + Math.Abs(x - x2).ToString("0.####").PadLeft(10) + "");
        }
    }

    [Test]
    public static void test02()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST02 tests BETA_INC_VALUES.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    25 September 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double a = 0;
        double b = 0;
        double fx = 0;
        double x = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST02:");
        Console.WriteLine("  BETA_INC_VALUES stores values of");
        Console.WriteLine("  the incomplete Beta function.");
        Console.WriteLine("");
        Console.WriteLine("      A            B            X            BETA_INC(A,B)(X)");
        Console.WriteLine("");

        int n_data = 0;

        for (;;)
        {
            Algorithms.beta_inc_values(ref n_data, ref a, ref b, ref x, ref fx);

            if (n_data == 0)
            {
                break;
            }

            double beta_log = Helpers.LogGamma(a)
                              + Helpers.LogGamma(b)
                              - Helpers.LogGamma(a + b);

            int ifault = 0;
            double fx2 = Algorithms.betain(x, a, b, beta_log, ref ifault);

            Console.WriteLine("  " + a.ToString("0.####").PadLeft(10)
                                   + "  " + b.ToString("0.####").PadLeft(10)
                                   + "  " + x.ToString("0.####").PadLeft(10)
                                   + "  " + fx.ToString("0.################").PadLeft(24)
                                   + "  " + fx2.ToString("0.################").PadLeft(24)
                                   + "  " + Math.Abs(fx - fx2).ToString("0.####").PadLeft(10) + "");
        }
    }

}