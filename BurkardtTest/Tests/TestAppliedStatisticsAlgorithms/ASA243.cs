using Burkardt.AppliedStatistics;

namespace Burkardt_Tests.TestAppliedStatisticsAlgorithms;

public class ASA243
{
        [Test]
        public static void test01 ( )
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 demonstrates the use of TNC.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    25 January 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double delta = 0;
        int df = 0;
        double fx = 0;
        int ifault = 0;
        double x = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST01:");
        Console.WriteLine("  TNC computes the noncentral Student T");
        Console.WriteLine("  Cumulative Density Function.");
        Console.WriteLine("  Compare with tabulated values.");
        Console.WriteLine("");
        Console.WriteLine("        X         LAMBDA        DF     "
                          + " CDF             CDF           DIFF");
        Console.WriteLine("                                       "
                          + " Tabulated       PRNCST");
        Console.WriteLine("");

        int n_data = 0;

        for ( ; ; )
        {
            Algorithms.student_noncentral_cdf_values ( ref n_data, ref df, ref delta, ref x, ref fx );

            if ( n_data == 0 )
            {
                break;
            }

            double df_real = df;

            double fx2 = Algorithms.tnc ( x, df_real, delta, ref ifault );

            Console.WriteLine("  " + x.ToString("0.####").PadLeft(10)
                                   + "  " + delta.ToString("0.####").PadLeft(10)
                                   + "  " +                      df.ToString().PadLeft(8)
                                   + "  " + fx.ToString("0.################").PadLeft(24)
                                   + "  " + fx2.ToString("0.################").PadLeft(24)
                                   + "  " + Math.Abs ( fx - fx2 ).ToString("0.####").PadLeft(10) + "");
        }
    }

}