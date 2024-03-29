﻿namespace Burkardt.Values;

public static class Cot
{
    public static void cot_values(ref int n_data, ref double x, ref double fx)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    COT_VALUES returns some values of the cotangent function.
        //
        //  Discussion:
        //
        //    In Mathematica, the function can be evaluated by:
        //
        //      Cot[x]
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    17 March 2010
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
        //    Input/output, ref int N_DATA.  The user sets N_DATA to 0
        //    before the first call.  On each call, the routine increments N_DATA by 1,
        //    and returns the corresponding data; when there is no more data, the
        //    output value of N_DATA will be 0 again.
        //
        //    Output, ref double X, the argument of the function.
        //
        //    Output, ref double FX, the value of the function.
        //
    {
        const int N_MAX = 15;

        double[] fx_vec =
        {
            11.972209353628661620,
            3.7320508075688772935,
            1.8304877217124519193,
            1.7320508075688772935,
            1.0000000000000000000,
            0.64209261593433070301,
            0.57735026918962576451,
            0.26794919243112270647,
            0.00000000000000000000,
            0.13165249758739585347,
            0.065543462815238228565,
            -0.45765755436028576375,
            -7.0152525514345334694,
            0.86369115445061661395,
            -0.29581291553274554043
        };

        double[] x_vec =
        {
            0.083333333333333333333,
            0.26179938779914943654,
            0.50000000000000000000,
            0.52359877559829887308,
            0.78539816339744830962,
            1.0000000000000000000,
            1.0471975511965977462,
            1.3089969389957471827,
            1.5707963267948966192,
            1.4398966328953219010,
            1.5053464798451092601,
            2.0000000000000000000,
            3.0000000000000000000,
            4.0000000000000000000,
            5.0000000000000000000
        };

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