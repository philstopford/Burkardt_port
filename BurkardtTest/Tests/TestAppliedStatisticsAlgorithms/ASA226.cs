using Burkardt.AppliedStatistics;

namespace Burkardt_Tests.TestAppliedStatisticsAlgorithms;

public class ASA226
{
        [Test]
        public static void test01 ( )
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 demonstrates the use of BETANC.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    24 January 2008
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
        double lambda = 0;
        double x = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST01:");
        Console.WriteLine("  BETANC computes the noncentral incomplete Beta function.");
        Console.WriteLine("  Compare to tabulated values.");
        Console.WriteLine("");
        Console.WriteLine("      A        B     LAMBDA        X      "
                          + "    FX                        FX2");
        Console.WriteLine("                                          "
                          + "    (Tabulated)               (BETANC)            DIFF");
        Console.WriteLine("");

        int n_data = 0;

        for ( ; ; )
        {
            Algorithms.beta_noncentral_cdf_values ( ref n_data, ref a, ref b, ref lambda, ref x, ref fx );

            if ( n_data == 0 )
            {
                break;
            }

            double fx2 = Algorithms.betanc ( x, a, b, lambda, ref ifault );

            Console.WriteLine("  " + a.ToString("0.##").PadLeft(7)
                                   + "  " + b.ToString("0.##").PadLeft(7)
                                   + "  " + lambda.ToString("0.###").PadLeft(7)
                                   + "  " + x.ToString("0.####").PadLeft(10)
                                   + "  " + fx.ToString("0.################").PadLeft(24)
                                   + "  " + fx2.ToString("0.################").PadLeft(24)
                                   + "  " + Math.Abs ( fx - fx2 ).ToString("0.####").PadLeft(10) + "");
        }
    }

}