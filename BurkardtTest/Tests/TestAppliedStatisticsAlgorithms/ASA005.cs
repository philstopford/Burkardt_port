using Burkardt.AppliedStatistics;

namespace Burkardt_Tests.TestAppliedStatisticsAlgorithms;

public class ASA005
{
    [Test]
    public static void test1()
    {
            //****************************************************************************80
            //
            //  Purpose:
            //
            //    TEST01 demonstrates the use of PRNCST.
            //
            //  Licensing:
            //
            //    This code is distributed under the GNU LGPL license. 
            //
            //  Modified:
            //
            //    26 January 2008
            //
            //  Author:
            //
            //    John Burkardt
            //
        {
                
            // Outputs.
            int df = 0;
            int ifault = 0;
            double lambda = 0;
            double x = 0;

            Console.WriteLine();
            Console.WriteLine("TEST01:");
            Console.WriteLine("  PRNCST computes the noncentral Student's");
            Console.WriteLine("  Cumulative Density Function.");
            Console.WriteLine("  Compare to tabulated values.");
            Console.WriteLine();
            Console.WriteLine("      X   LAMBDA  DF     "
                              + " CDF                       CDF                     DIFF");
            Console.WriteLine("                         "
                              + " Tabulated                 PRNCST");
            Console.WriteLine();

            int n_data = 0;

            for (;;)
            {
                double fx = Algorithms.student_noncentral_cdf_values(ref n_data, ref df, ref lambda, ref x);

                if (n_data == 0)
                {
                    break;
                }

                double fx2 = Algorithms.prncst(x, df, lambda, ref ifault);

                string cout = "  " + x.ToString("0.##").PadLeft(6);
                cout += "  " + lambda.ToString("0.##").PadLeft(6);
                cout += "  " + df.ToString().PadLeft(2);
                cout += "  " + fx.ToString("0.################").PadLeft(24);
                cout += "  " + fx2.ToString("0.################").PadLeft(24);
                cout += "  " + Math.Abs(fx - fx2).ToString("0.####").PadLeft(10);
                Console.WriteLine(cout);
            }
        }
    }
}