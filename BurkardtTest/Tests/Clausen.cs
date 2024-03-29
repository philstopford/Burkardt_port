using Burkardt.IntegralNS;

namespace Burkardt_Tests;

public class ClausenTest
{
    private static void clausen_test()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    CLAUSEN_TEST compares the CLAUSEN function to some tabulated values.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    12 December 2016
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double fx1 = 0;
        double x = 0;
        //
        //  Save the current precision.
        //

        Console.WriteLine("");
        Console.WriteLine("CLAUSEN_TEST:");
        Console.WriteLine("  CLAUSEN evaluates the Clausen function.");
        Console.WriteLine("  Compare its results to tabulated data.");
        Console.WriteLine("");
        Console.WriteLine("                               Tabulated               Computed");
        Console.WriteLine("           X                          FX                     FX        Diff");
        Console.WriteLine("");

        int n_data = 0;

        for (;;)
        {
            Clausen.clausen_values(ref n_data, ref x, ref fx1);

            if (n_data == 0)
            {
                break;
            }

            double fx2 = Clausen.clausen(x);

            double diff = Math.Abs(fx1 - fx2);

            Console.WriteLine("  " + x.ToString("0.######").PadLeft(12)
                                   + "  " + fx1.ToString("0.################").PadLeft(24)
                                   + "  " + fx2.ToString("0.################").PadLeft(24)
                                   + "  " + diff.ToString("0.#").PadLeft(24) + "");
        }
    }

}