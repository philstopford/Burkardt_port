using Burkardt.AppliedStatistics;

namespace Burkardt_Tests.TestAppliedStatisticsAlgorithms;

public class ASA152
{
        [Test]
        public static void test01()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 demonstrates CHYPER for cumulative probabilities.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    27 January 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double fx = 0;
        int ifault = 0;
        int pop = 0;
        int sam = 0;
        int suc = 0;
        int x = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST01:");
        Console.WriteLine("  CHYPER computes cumulative probablities");
        Console.WriteLine("  of the hypergeometric PDF.");
        Console.WriteLine("  Compare to tabulated values.");
        Console.WriteLine("");
        Console.WriteLine("   SAM   SUC   POP     X    "
                          + "  CDF                       CDF                     DIFF");
        Console.WriteLine("                            "
                          + " (tabulated)               (CHYPER)");
        Console.WriteLine("");

        int n_data = 0;

        for (;;)
        {
            Algorithms.hypergeometric_cdf_values(ref n_data, ref sam, ref suc, ref pop, ref x, ref fx);

            if (n_data == 0)
            {
                break;
            }

            const bool point = false;

            double fx2 = Algorithms.chyper(point, sam, x, pop, suc, ref ifault);

            Console.WriteLine("  " + sam.ToString().PadLeft(4)
                                   + "  " + suc.ToString().PadLeft(4)
                                   + "  " + pop.ToString().PadLeft(4)
                                   + "  " + x.ToString().PadLeft(4)
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
        //    TEST02 demonstrates CHYPER for point probabilities.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    27 January 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double fx = 0;
        int ifault = 0;
        int pop = 0;
        int sam = 0;
        int suc = 0;
        int x = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST02:");
        Console.WriteLine("  CHYPER computes point probablities");
        Console.WriteLine("  of the hypergeometric PDF.");
        Console.WriteLine("  Compare to tabulated values.");
        Console.WriteLine("");
        Console.WriteLine("   SAM   SUC   POP     X    "
                          + "  PDF                       PDF                     DIFF");
        Console.WriteLine("                            "
                          + " (tabulated)               (CHYPER)");
        Console.WriteLine("");

        int n_data = 0;

        for (;;)
        {
            Algorithms.hypergeometric_pdf_values(ref n_data, ref sam, ref suc, ref pop, ref x, ref fx);

            if (n_data == 0)
            {
                break;
            }

            const bool point = true;

            double fx2 = Algorithms.chyper(point, sam, x, pop, suc, ref ifault);

            Console.WriteLine("  " + sam.ToString().PadLeft(4)
                                   + "  " + suc.ToString().PadLeft(4)
                                   + "  " + pop.ToString().PadLeft(4)
                                   + "  " + x.ToString().PadLeft(4)
                                   + "  " + fx.ToString("0.################").PadLeft(24)
                                   + "  " + fx2.ToString("0.################").PadLeft(24)
                                   + "  " + Math.Abs(fx - fx2).ToString("0.####").PadLeft(10) + "");
        }
    }

}