using System.Globalization;
using Burkardt.ODENS;

namespace Burkardt_Tests.TestOrdinaryDifferentialEquation;

public class HermitePolyChaosExpansionTest
{
        [Test]
    public static void pce_ode_hermite_test01()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    PCE_ODE_HERMITE_TEST01 runs a test problem with PCE_ODE_HERMITE.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    17 March 2012
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int i;
        const int np = 4;
        const int nt = 200;

        double[] t = new double[nt + 1];
        double[] u = new double[(nt + 1) * (np + 1)];
        double[] uex = new double[nt + 1];

        Console.WriteLine("");
        Console.WriteLine("PCE_ODE_HERMITE_TEST01:");
        Console.WriteLine("  Call PCE_ODE_HERMITE to compute a polynomial chaos expansion");
        Console.WriteLine("  for the ODE:");
        Console.WriteLine("");
        Console.WriteLine("    u' = - alpha * u,");
        Console.WriteLine("    u(0) = 1.");

        const double ti = 0.0;
        const double tf = 2.0;
        const double ui = 1.0;
        const double alpha_mu = 0.0;
        const double alpha_sigma = 1.0;

        Console.WriteLine("");
        Console.WriteLine("  Initial time         TI = " + ti + "");
        Console.WriteLine("  Final time           TF = " + tf + "");
        Console.WriteLine("  Number of time steps NT = " + nt + "");
        Console.WriteLine("  Initial condition    UI = " + ui + "");
        Console.WriteLine("  Expansion degree     NP = " + np + "");
        Console.WriteLine("  E(ALPHA)       ALPHA_MU = " + alpha_mu + "");
        Console.WriteLine("  STD(ALPHA)  ALPHA_SIGMA = " + alpha_sigma + "");

        HermitePolyChaosExpansion.pce_ode_hermite(ti, tf, nt, ui, np, alpha_mu, alpha_sigma, ref t, ref u);
        //
        //  Evaluate the exact expected value function.
        //
        for (i = 0; i <= nt; i++)
        {
            uex[i] = ui * Math.Exp(t[i] * t[i] / 2.0);
        }

        //
        //  Compare the first computed component against the exact expected value.
        //
        Console.WriteLine("");
        Console.WriteLine(" i  T(i)  E(U(T(i)))    U(T(i),0)");
        Console.WriteLine("");
        for (i = 0; i <= nt; i += 10)
        {
            Console.WriteLine("  " + i.ToString(CultureInfo.InvariantCulture).PadLeft(4)
                                   + "  " + t[i].ToString(CultureInfo.InvariantCulture).PadLeft(6)
                                   + "  " + uex[i].ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + u[i + 0 * (nt + 1)].ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + Math.Abs(uex[i] - u[i + 0 * (nt + 1)]).ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
        }
    }

    [Test]
    public static void pce_ode_hermite_test02()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    PCE_ODE_HERMITE_TEST02 looks at convergence behavior for a fixed time.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    18 March 2012
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double[] ep = new double[6];
        int np;
        const int nt = 2000;

        double[] t = new double[nt + 1];

        Console.WriteLine("");
        Console.WriteLine("PCE_ODE_HERMITE_TEST02:");
        Console.WriteLine("  Examine convergence behavior as the PCE degree increases:");
        Console.WriteLine("");
        Console.WriteLine("    u' = - alpha * u,");
        Console.WriteLine("    u(0) = 1.");

        const double ti = 0.0;
        const double tf = 2.0;
        const double ui = 1.0;
        const double alpha_mu = 0.0;
        const double alpha_sigma = 1.0;

        Console.WriteLine("");
        Console.WriteLine("  Initial time         TI = " + ti + "");
        Console.WriteLine("  Final time           TF = " + tf + "");
        Console.WriteLine("  Number of time steps NT = " + nt + "");
        Console.WriteLine("  Initial condition    UI = " + ui + "");
        Console.WriteLine("  E(ALPHA)       ALPHA_MU = " + alpha_mu + "");
        Console.WriteLine("  STD(ALPHA)  ALPHA_SIGMA = " + alpha_sigma + "");

        double uexf = ui * Math.Exp(tf * tf / 2.0);

        for (np = 0; np <= 5; np++)
        {
            double[] u = new double[(nt + 1) * (np + 1)];

            HermitePolyChaosExpansion.pce_ode_hermite(ti, tf, nt, ui, np, alpha_mu, alpha_sigma, ref t, ref u);

            ep[np] = Math.Abs(uexf - u[nt + 0 * (nt + 1)]);

        }

        //
        //  Plot error in expected value as a function of the PCE degree.
        //
        Console.WriteLine("");
        Console.WriteLine("    NP     Error(NP)     Log(Error(NP))");
        Console.WriteLine("");
        for (np = 0; np <= 5; np++)
        {
            Console.WriteLine("  " + np.ToString(CultureInfo.InvariantCulture).PadLeft(4)
                                   + "  " + ep[np].ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + Math.Log(ep[np]).ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
        }
    }

}