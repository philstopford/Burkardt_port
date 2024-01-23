using Burkardt.AppliedStatistics;

namespace Burkhardt_Tests.AppliedStatisticsAlgorithms;

public class ASA111
{
    [Test]
    public static void test01 ( )
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 compares PPND against tabulated values.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    21 January 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double fx = 0;
        int ifault = 0;
        int n_data = 0;
        double x = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST01:");
        Console.WriteLine("  PPND computes percentage points of the normal distribution.");
        Console.WriteLine("  Compare against tabulated values.");
        Console.WriteLine("");
        Console.WriteLine("         CDF        X                           X  "
                          + "                  DIFF");
        Console.WriteLine("                 (tabulated)                   (PPND)");
        Console.WriteLine("");


        for ( ; ; )
        {
            Algorithms.normal_01_cdf_values ( ref n_data, ref x, ref fx );

            if ( n_data == 0 )
            {
                break;
            }

            double x2 = Algorithms.ppnd ( fx, ref ifault );

            Console.WriteLine("  "  + fx.ToString("0.####").PadLeft(10)
                                    + "  " + x.ToString("0.################").PadLeft(24)
                                    + "  " + x2.ToString("0.################").PadLeft(24)
                                    + "  " + Math.Abs (x - x2).ToString("0.####").PadLeft(10) + "");
        }
    }

}