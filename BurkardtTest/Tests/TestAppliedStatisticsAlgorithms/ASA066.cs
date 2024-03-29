using Burkardt.AppliedStatistics;

namespace Burkardt_Tests.TestAppliedStatisticsAlgorithms;

public class ASA066
{
        [Test]
        public static void test01 ( )
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 compares ALNORM against tabulated values.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    16 January 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double fx = 0;
        const bool upper = false;
        double x = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST01:");
        Console.WriteLine("  Compare tabulated values of the normal");
        Console.WriteLine("  Cumulative Density Function against values");
        Console.WriteLine("  computed by ALNORM.");
        Console.WriteLine("");
        Console.WriteLine("         X        CDF                       CDF"
                          + "                    DIFF");
        Console.WriteLine("               (tabulated)                 (ALNORM)");
        Console.WriteLine("");

        int n_data = 0;

        for ( ; ; )
        {
            Algorithms.normal_01_cdf_values ( ref n_data, ref x, ref fx );

            if ( n_data == 0 )
            {
                break;
            }

            double fx2 = Algorithms.alnorm ( x, upper );

            Console.WriteLine("  " + x.ToString("0.####").PadLeft(10)
                                   + "  " + fx.ToString("0.################").PadLeft(24)
                                   + "  " + fx2.ToString("0.################").PadLeft(24)
                                   + "  " + Math.Abs( fx - fx2 ).ToString("0.####").PadLeft(10) + "");
        }
    }


    [Test]
    public static void test02()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST02 compares NORMP against tabulated values.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    16 January 2008
        //
        //  Author:
        //
        //    John Burkardt
    {
        double fx = 0;
        double p = 0;
        double pdf = 0;
        double q = 0;
        double x = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST02:");
        Console.WriteLine("  Compare tabulated values of the normal");
        Console.WriteLine("  Cumulative Density Function against values");
        Console.WriteLine("  computed by NORMP.");
        Console.WriteLine("");
        Console.WriteLine("         X        CDF                       CDF"
                          + "                    DIFF");
        Console.WriteLine("               (tabulated)                 (NORMP)");
        Console.WriteLine("");

        int n_data = 0;

        for (;;)
        {
            Algorithms.normal_01_cdf_values ( ref n_data, ref x, ref fx );

            if (n_data == 0)
            {
                break;
            }

            Algorithms.normp(x, ref p, ref q, ref pdf);
            double fx2 = p;

            Console.WriteLine("  " + x.ToString("0.####").PadLeft(10)
                                   + "  " + fx.ToString("0.################").PadLeft(24)
                                   + "  " + fx2.ToString("0.################").PadLeft(24)
                                   + "  " + Math.Abs( fx - fx2 ).ToString("0.####").PadLeft(10) + "");
        }
    }

    [Test]
    public static void test03()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST03 compares NPROB against tabulated values.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    16 January 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double fx = 0;
        double p = 0;
        double pdf = 0;
        double q = 0;
        double x = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST03");
        Console.WriteLine("  Compare tabulated values of the normal");
        Console.WriteLine("  Cumulative Density Function against values");
        Console.WriteLine("  computed by NPROBP.");
        Console.WriteLine("");
        Console.WriteLine("         X        CDF                       CDF"
                          + "                    DIFF");
        Console.WriteLine("               (tabulated)                 (NPROB)");
        Console.WriteLine("");

        int n_data = 0;

        for (;;)
        {
            Algorithms.normal_01_cdf_values ( ref n_data, ref x, ref fx );

            if (n_data == 0)
            {
                break;
            }

            Algorithms.nprob(x, ref p, ref q, ref pdf);
            double fx2 = p;

            Console.WriteLine("  " + x.ToString("0.####").PadLeft(10)
                                   + "  " + fx.ToString("0.################").PadLeft(24)
                                   + "  " + fx2.ToString("0.################").PadLeft(24)
                                   + "  " + Math.Abs( fx - fx2 ).ToString("0.####").PadLeft(10) + "");
        }
    }

}