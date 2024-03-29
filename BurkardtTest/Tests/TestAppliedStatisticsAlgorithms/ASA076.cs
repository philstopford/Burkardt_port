using Burkardt.AppliedStatistics;

namespace Burkardt_Tests.TestAppliedStatisticsAlgorithms;

public class ASA076
{
        [Test]
        public static void test01()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 demonstrates the use of TFN.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    20 January 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double a = 0;
        double h = 0;
        int n_data = 0;
        double t1 = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST01:");
        Console.WriteLine("  TFN computes Owen's T function.");
        Console.WriteLine("  Compare to tabulated values.");
        Console.WriteLine("");
        Console.WriteLine("             H             A      "
                          + "    T                         T  ");
        Console.WriteLine("                                  "
                          + "    (Tabulated)               (TFN)               DIFF");
        Console.WriteLine("");

        for (;;)
        {
            Algorithms.owen_values(ref n_data, ref h, ref a, ref t1);

            if (n_data == 0)
            {
                break;
            }

            double t2 = Algorithms.tfn(h, a);

            Console.WriteLine("  " + h.ToString("0.####").PadLeft(12)
                                   + "  " + a.ToString("0.####").PadLeft(12)
                                   + "  " + t1.ToString("0.################").PadLeft(24)
                                   + "  " + t2.ToString("0.################").PadLeft(24)
                                   + "  " + Math.Abs(t1 - t2).ToString("0.####").PadLeft(10) + "");
        }
    }

    [Test]
    public static void test02()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST02 demonstrates the use of THA.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    20 January 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double a = 0;
        double h = 0;
        int n_data = 0;
        const double one = 1.0;
        double t1 = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST02:");
        Console.WriteLine("  THA computes Owen's T function.");
        Console.WriteLine("  Compare to tabulated values.");
        Console.WriteLine("");
        Console.WriteLine("             H             A      "
                          + "    T                         T  ");
        Console.WriteLine("                                  "
                          + "    (Tabulated)               (THA)               DIFF");
        Console.WriteLine("");
            
        for (;;)
        {
            Algorithms.owen_values(ref n_data, ref h, ref a, ref t1);

            if (n_data == 0)
            {
                break;
            }

            double t2 = Algorithms.tha(h, one, a, one);

            Console.WriteLine("  " + h.ToString("0.####").PadLeft(12)
                                   + "  " + a.ToString("0.####").PadLeft(12)
                                   + "  " + t1.ToString("0.################").PadLeft(24)
                                   + "  " + t2.ToString("0.################").PadLeft(24)
                                   + "  " + Math.Abs(t1 - t2).ToString("0.####").PadLeft(10) + "");
        }
    }

}