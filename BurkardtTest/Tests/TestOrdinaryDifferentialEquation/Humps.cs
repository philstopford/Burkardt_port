using Burkardt.ODENS;

namespace Burkardt_Tests.TestOrdinaryDifferentialEquation;

public class HumpsTest
{
    [Test]
    public static void humps_antideriv_test()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    humps_antideriv_test tests humps_antideriv.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    05 August 2019
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int i;

        Console.WriteLine("");
        Console.WriteLine("humps_antideriv_test");
        Console.WriteLine("  Test humps_antideriv.");

        const double a = 0.0;
        const double b = 2.0;
        const int n = 101;
        double[] x = new double[n];
        double[] y = new double[n];
        for (i = 0; i < n; i++)
        {
            x[i] = ((n - i) * a + i * b) / (n - 1);
            y[i] = Humps.humps_antideriv(x[i]);
        }

        Humps.plot_xy(n, x, y, "humps_antideriv");
    }

    [Test]
    public static void humps_fun_test()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    humps_fun_test tests humps_fun.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    05 August 2019
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int i;

        Console.WriteLine("");
        Console.WriteLine("humps_fun_test");
        Console.WriteLine("  Test humps_fun.");

        const double a = 0.0;
        const double b = 2.0;
        const int n = 101;
        double[] x = new double[n];
        double[] y = new double[n];
        for (i = 0; i < n; i++)
        {
            x[i] = ((n - i) * a + i * b) / (n - 1);
            y[i] = Humps.humps_fun(x[i]);
        }

        Humps.plot_xy(n, x, y, "humps_fun");
    }

    [Test]
    public static void humps_deriv_test()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    humps_deriv_test tests humps_deriv.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    05 August 2019
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int i;

        Console.WriteLine("");
        Console.WriteLine("humps_deriv_test");
        Console.WriteLine("  Test humps_deriv.");

        const double a = 0.0;
        const double b = 2.0;
        const int n = 101;
        double[] x = new double[n];
        double[] y = new double[n];
        for (i = 0; i < n; i++)
        {
            x[i] = ((n - i) * a + i * b) / (n - 1);
            y[i] = Humps.humps_deriv(x[i]);
        }

        Humps.plot_xy(n, x, y, "humps_deriv");
    }

    [Test]
    public static void humps_deriv2_test()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    humps_deriv2_test tests humps_deriv2.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    05 August 2019
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int i;

        Console.WriteLine("");
        Console.WriteLine("humps_deriv2_test");
        Console.WriteLine("  Test humps_deriv2.");

        const double a = 0.0;
        const double b = 2.0;
        const int n = 101;
        double[] x = new double[n];
        double[] y = new double[n];
        for (i = 0; i < n; i++)
        {
            x[i] = ((n - i) * a + i * b) / (n - 1);
            y[i] = Humps.humps_deriv2(x[i]);
        }

        Humps.plot_xy(n, x, y, "humps_deriv2");
    }
    
}