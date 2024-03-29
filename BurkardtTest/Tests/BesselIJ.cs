using System.Globalization;
using Burkardt.Function;

namespace Burkardt_Tests;

public class BesselIJTest
{
    [Test]
    public static void rjbesl_test()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    RJBESL_TEST tests RJBESL.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    15 January 2016
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double fx = 0;
        int ncalc = 0;
        double order = 0;
        double x = 0;

        Console.WriteLine("");
        Console.WriteLine("RJBESL_TEST:");
        Console.WriteLine("  RJBESL computes the Bessel Jn function for NONINTEGER order.");
        Console.WriteLine("");
        Console.WriteLine("         ORDER             X                       FX                         FX");
        Console.WriteLine("                                                 exact                  computed");
        Console.WriteLine("");

        int n_data = 0;

        for (;;)
        {
            BesselJ.bessel_jx_values(ref n_data, ref order, ref x, ref fx);

            if (n_data == 0)
            {
                break;
            }

            int n = (int) order;
            double alpha = order - n;
            int nb = n + 1;
            double[] b = new double[nb];
            BesselJ.rjbesl(x, alpha, nb, ref b, ref ncalc);
            Console.WriteLine("  " + order.ToString(CultureInfo.InvariantCulture).PadLeft(12)
                                   + "  " + x.ToString(CultureInfo.InvariantCulture).PadLeft(12)
                                   + "  " + fx.ToString("0.################").PadLeft(12)
                                   + "  " + b[n].ToString("0.################").PadLeft(12) + "");
        }
    }
}