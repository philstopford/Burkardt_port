using Burkardt;
using Burkardt.AppliedStatistics;

namespace Burkardt_Tests.TestAppliedStatisticsAlgorithms;

public class ASA245
{
    [Test]
    public static void test01()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 demonstrates the use of ALNGAM.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    15 January 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double fx = 0;
        int ifault = 0;
        double x = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST01:");
        Console.WriteLine("  ALNGAM computes the logarithm of the ");
        Console.WriteLine("  Gamma function.  We compare the result");
        Console.WriteLine("  to tabulated values.");
        Console.WriteLine("");
        Console.WriteLine("          X                     "
                          + "FX                        FX2");
        Console.WriteLine("                                "
                          + "(Tabulated)               (ALNGAM)                DIFF");
        Console.WriteLine("");

        int n_data = 0;

        for (;;)
        {
            Burkardt.Values.Gamma.gamma_log_values(ref n_data, ref x, ref fx);

            if (n_data == 0)
            {
                break;
            }

            double fx2 = Algorithms.alngam(x, ref ifault);

            Console.WriteLine("  " + x.ToString("0.################").PadLeft(24)
                                   + "  " + fx.ToString("0.################").PadLeft(24)
                                   + "  " + fx2.ToString("0.################").PadLeft(24)
                                   + "  " + Math.Abs(fx - fx2).ToString("0.####").PadLeft(10) + "");
        }
    }

    [Test]
    public static void test02()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST02 demonstrates the use of LNGAMMA.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    15 January 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double fx = 0;
        int ier = 0;
        double x = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST02:");
        Console.WriteLine("  LNGAMMA computes the logarithm of the ");
        Console.WriteLine("  Gamma function.  We compare the result");
        Console.WriteLine("  to tabulated values.");
        Console.WriteLine("");
        Console.WriteLine("          X                     "
                          + "FX                        FX2");
        Console.WriteLine("                                "
                          + "(Tabulated)               (LNGAMMA)                DIFF");
        Console.WriteLine("");

        int n_data = 0;

        for (;;)
        {
            Burkardt.Values.Gamma.gamma_log_values(ref n_data, ref x, ref fx);

            if (n_data == 0)
            {
                break;
            }

            double fx2 = Algorithms.lngamma(x, ref ier);

            Console.WriteLine("  " + x.ToString("0.################").PadLeft(24)
                                   + "  " + fx.ToString("0.################").PadLeft(24)
                                   + "  " + fx2.ToString("0.################").PadLeft(24)
                                   + "  " + Math.Abs(fx - fx2).ToString("0.####").PadLeft(10) + "");
        }
    }

    [Test]
    public static void test03()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST03 demonstrates the use of LGAMMA.
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
        double fx = 0;
        double x = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST03");
        Console.WriteLine("  LGAMMA computes the logarithm of the ");
        Console.WriteLine("  Gamma function.");
        Console.WriteLine("  LGAMMA is available with the G++ compiler.");
        Console.WriteLine("  Compare the result to tabulated values.");
        Console.WriteLine("");
        Console.WriteLine("          X                     "
                          + "FX                        FX2");
        Console.WriteLine("                                "
                          + "(Tabulated)               (LNGAMMA)                DIFF");
        Console.WriteLine("");

        int n_data = 0;

        for (;;)
        {
            Burkardt.Values.Gamma.gamma_log_values(ref n_data, ref x, ref fx);

            if (n_data == 0)
            {
                break;
            }

            double fx2 = Helpers.LogGamma(x);

            Console.WriteLine("  " + x.ToString("0.################").PadLeft(24)
                                   + "  " + fx.ToString("0.################").PadLeft(24)
                                   + "  " + fx2.ToString("0.################").PadLeft(24)
                                   + "  " + Math.Abs(fx - fx2).ToString("0.####").PadLeft(10) + "");
        }
    }

}