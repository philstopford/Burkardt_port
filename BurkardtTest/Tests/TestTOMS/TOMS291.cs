using Burkardt.AppliedStatistics;

namespace Burkardt_Tests.TestTOMS;

public class TOMS291
{
    [Test] 
    public static void test01()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 demonstrates the use of ALOGAM.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    22 January 2008
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
        Console.WriteLine("  ALOGAM computes the logarithm of the ");
        Console.WriteLine("  Gamma function.  We compare the result");
        Console.WriteLine("  to tabulated values.");
        Console.WriteLine("");
        Console.WriteLine("          X                     "
                          + "FX                        FX2");
        Console.WriteLine("                                "
                          + "(Tabulated)               (ALOGAM)                DIFF");
        Console.WriteLine("");

        int n_data = 0;

        for (;;)
        {
            Burkardt.Values.Gamma.gamma_log_values(ref n_data, ref x, ref fx);

            if (n_data == 0)
            {
                break;
            }

            double fx2 = Algorithms.alogam(x, ref ifault);

            Console.WriteLine("  " + x.ToString("0.################").PadLeft(24)
                                   + "  " + fx.ToString("0.################").PadLeft(24)
                                   + "  " + fx2.ToString("0.################").PadLeft(24)
                                   + "  " + Math.Abs(fx - fx2).ToString("0.####").PadLeft(10) + "");
        }

    }

}