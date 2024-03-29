﻿using System;

namespace Burkardt.AppliedStatistics;

public static partial class Algorithms
{
    public static double digamma(double x, ref int ifault)
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    DIGAMMA calculates DIGAMMA ( X ) = d ( LOG ( GAMMA ( X ) ) ) / dX
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    20 March 2016
        //
        //  Author:
        //
        //    Original FORTRAN77 version by Jose Bernardo.
        //    C++ version by John Burkardt.
        //
        //  Reference:
        //
        //    Jose Bernardo,
        //    Algorithm AS 103:
        //    Psi ( Digamma ) Function,
        //    Applied Statistics,
        //    Volume 25, Number 3, 1976, pages 315-317.
        //
        //  Parameters:
        //
        //    Input, double X, the argument of the digamma function.
        //    0 < X.
        //
        //    Output, int *IFAULT, error flag.
        //    0, no error.
        //    1, X <= 0.
        //
        //    Output, double DIGAMMA, the value of the digamma function at X.
        //
    {
        const double c = 8.5;
        const double euler_mascheroni = 0.57721566490153286060;
        double value;
        switch (x)
        {
            //
            //  Check the input.
            //
            case <= 0.0:
                value = 0.0;
                ifault = 1;
                return value;
        }

        //
        //  Initialize.
        //
        ifault = 0;
        switch (x)
        {
            //
            //  Use approximation for small argument.
            //
            case <= 0.000001:
                value = -euler_mascheroni - 1.0 / x + 1.6449340668482264365 * x;
                return value;
        }

        //
        //  Reduce to DIGAMA(X + N).
        //
        value = 0.0;
        double x2 = x;
        while (x2 < c)
        {
            value -= 1.0 / x2;
            x2 += 1.0;
        }

        //
        //  Use Stirling's (actually de Moivre's) expansion.
        //
        double r = 1.0 / x2;
        value = value + Math.Log(x2) - 0.5 * r;

        r *= r;

        value -= r * (1.0 / 12.0
                      - r * (1.0 / 120.0
                             - r * (1.0 / 252.0
                                    - r * (1.0 / 240.0
                                           - r * (1.0 / 132.0)))));

        return value;
    }

    public static void psi_values(ref int n_data, ref double x, ref double fx)
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    PSI_VALUES returns some values of the Psi or Digamma function.
        //
        //  Discussion:
        //
        //    In Mathematica, the function can be evaluated by:
        //
        //      PolyGamma[x]
        //
        //    or
        //
        //      Polygamma[0,x]
        //
        //    PSI(X) = d ln ( Gamma ( X ) ) / d X = Gamma'(X) / Gamma(X)
        //
        //    PSI(1) = - Euler's constant.
        //
        //    PSI(X+1) = PSI(X) + 1 / X.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    17 August 2004
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Reference:
        //
        //    Milton Abramowitz, Irene Stegun,
        //    Handbook of Mathematical Functions,
        //    National Bureau of Standards, 1964,
        //    ISBN: 0-486-61272-4,
        //    LC: QA47.A34.
        //
        //    Stephen Wolfram,
        //    The Mathematica Book,
        //    Fourth Edition,
        //    Cambridge University Press, 1999,
        //    ISBN: 0-521-64314-7,
        //    LC: QA76.95.W65.
        //
        //  Parameters:
        //
        //    Input/output, int *N_DATA.  The user sets N_DATA to 0 before the
        //    first call.  On each call, the routine increments N_DATA by 1, and
        //    returns the corresponding data; when there is no more data, the
        //    output value of N_DATA will be 0 again.
        //
        //    Output, double *X, the argument of the function.
        //
        //    Output, double *FX, the value of the function.
        //
    {
        const int N_MAX = 11;

        double[] fx_vec =  {
                -0.5772156649015329E+00,
                -0.4237549404110768E+00,
                -0.2890398965921883E+00,
                -0.1691908888667997E+00,
                -0.6138454458511615E-01,
                0.3648997397857652E-01,
                0.1260474527734763E+00,
                0.2085478748734940E+00,
                0.2849914332938615E+00,
                0.3561841611640597E+00,
                0.4227843350984671E+00
            }
            ;

        double[] x_vec =  {
                1.0E+00,
                1.1E+00,
                1.2E+00,
                1.3E+00,
                1.4E+00,
                1.5E+00,
                1.6E+00,
                1.7E+00,
                1.8E+00,
                1.9E+00,
                2.0E+00
            }
            ;

        n_data = n_data switch
        {
            < 0 => 0,
            _ => n_data
        };

        n_data += 1;

        if (N_MAX < n_data)
        {
            n_data = 0;
            x = 0.0;
            fx = 0.0;
        }
        else
        {
            x = x_vec[n_data - 1];
            fx = fx_vec[n_data - 1];
        }

    }
}