using Burkardt.AppliedStatistics;

namespace Burkhardt_Tests.AppliedStatisticsAlgorithms;

public class ASA147
{
    [Test]
    public static void test01 ( )
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 demonstrates the use of GAMMDS.
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
        double a = 0;
        double fx = 0;
        int ifault = 0;
        double x = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST01:");
        Console.WriteLine("  GAMMDS computes the incomplete Gamma function.");
        Console.WriteLine("  Compare to tabulated values.");
        Console.WriteLine("");
        Console.WriteLine("             A             X      "
                          + "    FX                        FX2");
        Console.WriteLine("                                  "
                          + "    (Tabulated)               (GAMMDS)            DIFF");
        Console.WriteLine("");

        int n_data = 0;

        for ( ; ; )
        {
            Burkardt.Values.Gamma.gamma_inc_valuesASA032 ( ref n_data, ref a, ref x, ref fx );

            if ( n_data == 0 )
            {
                break;
            }

            double fx2 = Algorithms.gammds ( x, a, ref ifault );

            Console.WriteLine("  " + a.ToString("0.####").PadLeft(12)
                                   + "  " + x.ToString("0.####").PadLeft(12)
                                   + "  " + fx.ToString("0.################").PadLeft(24)
                                   + "  " + fx2.ToString("0.################").PadLeft(24)
                                   + "  " + Math.Abs ( fx - fx2 ).ToString("0.####").PadLeft(10) + "");
        }
    }

}