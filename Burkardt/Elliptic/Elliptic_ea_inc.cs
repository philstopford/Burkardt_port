﻿using System;

namespace Burkardt.Elliptic;

public static class EA_inc
{
    public static double evaluate(double phi, double a)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    ELLIPTIC_INC_EA evaluates the incomplete elliptic integral E(PHI,A).
        //
        //  Discussion:
        //
        //    The value is computed using Carlson elliptic integrals:
        //
        //      k = sin ( a * Math.PI / 180 )
        //      E(phi,a) = 
        //                  sin ( phi )   RF ( cos^2 ( phi ), 1-k^2 sin^2 ( phi ), 1 ) 
        //        - 1/3 k^2 sin^3 ( phi ) RD ( cos^2 ( phi ), 1-k^2 sin^2 ( phi ), 1 ).
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    25 June 2018
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, double PHI, A, the arguments.
        //    0 <= PHI <= PI/2.
        //    0 <= sin^2 ( A * Math.PI / 180 ) * sin^2(PHI) <= 1.
        //
        //    Output, double ELLIPTIC_INC_EA, the function value.
        //
    {
        int ierr = 0;

        double k = Math.Sin(a * Math.PI / 180.0);

        double cp = Math.Cos(phi);
        double sp = Math.Sin(phi);
        double x = cp * cp;
        double y = (1.0 - k * sp) * (1.0 + k * sp);
        const double z = 1.0;
        const double errtol = 1.0E-03;

        double value1 = Integral.rf(x, y, z, errtol, ref ierr);

        if (ierr != 0)
        {
            Console.WriteLine("");
            Console.WriteLine("ELLIPTIC_INC_EA - Fatal error!");
            Console.WriteLine("  RF returned IERR = " + ierr + "");
            return 1;
        }

        double value2 = Integral.rd(x, y, z, errtol, ref ierr);

        if (ierr != 0)
        {
            Console.WriteLine("");
            Console.WriteLine("ELLIPTIC_INC_EA - Fatal error!");
            Console.WriteLine("  RD returned IERR = " + ierr + "");
            return 1;
        }

        double value = sp * value1 - k * k * sp * sp * sp * value2 / 3.0;

        return value;
    }

    public static void values(ref int n_data, ref double phi, ref double a, ref double ea )

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    ELLIPTIC_INC_EA_VALUES: values of the incomplete elliptic integral E(PHI,A).
        //
        //  Discussion:
        //
        //    This is one form of the incomplete elliptic integral of the second kind.
        //
        //      E(PHI,A) = integral ( 0 <= T <= PHI ) 
        //        sqrt ( 1 - sin^2 ( A ) * sin^2 ( T ) ) dT
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    24 June 2018
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Reference:
        //
        //    Milton Abramowitz, Irene Stegun,
        //    Handbook of Mathematical Functions,
        //    US Department of Commerce, 1964.
        //
        //    Stephen Wolfram,
        //    The Mathematica Book,
        //    Fourth Edition,
        //    Wolfram Media / Cambridge University Press, 1999.
        //
        //  Parameters:
        //
        //    Input/output, int &N_DATA.  The user sets N_DATA to 0 
        //    before the first call.  On each call, the routine increments N_DATA by 1, 
        //    and returns the corresponding data when there is no more data, the
        //    output value of N_DATA will be 0 again.
        //
        //    Output, double &PHI, &A, the arguments of the function.
        //
        //    Output, double &EA, the value of the function.
        //
    {
        const int N_MAX = 20;

        double[] a_vec =
            {
                123.0821233267548,
                11.26931745051486,
                -94.88806452075445,
                -99.71407853545323,
                57.05881039324191,
                -19.71363287074183,
                56.31230299738043,
                -91.55605346417718,
                -27.00654574696468,
                -169.2293728595904,
                61.96859564803047,
                -158.7324398933148,
                105.0883958999383,
                -48.95883872360177,
                -42.58568835110901,
                11.65603284687828,
                -8.398113719173338,
                17.69362213019626,
                73.8803420626852,
                -69.82492339645128
            }
            ;

        double[] ea_vec =
            {
                0.3384181367348019,
                1.292924624509506,
                0.6074183768796306,
                0.3939726730783567,
                0.06880814097089803,
                0.0969436473376824,
                0.6025937791452033,
                0.9500549494837583,
                1.342783372140486,
                0.1484915631401388,
                1.085432887050926,
                0.1932136916085597,
                0.3983689593057807,
                0.1780054133336934,
                1.164525270273536,
                1.080167047541845,
                1.346684963830312,
                1.402100272685504,
                0.2928091845544553,
                0.5889342583405707
            }
            ;

        double[] phi_vec =
            {
                0.3430906586047127,
                1.302990057703935,
                0.6523628380743488,
                0.4046022501376546,
                0.06884642871852312,
                0.0969609046794745,
                0.630370432896175,
                1.252375418911598,
                1.409796082144801,
                0.1485105463502483,
                1.349466184634646,
                0.1933711786970301,
                0.4088829927466769,
                0.1785430666405224,
                1.292588374416351,
                1.087095515757691,
                1.352794600489329,
                1.432530166308616,
                0.2968093345769761,
                0.6235880396594726
            }
            ;

        n_data = n_data switch
        {
            < 0 => 0,
            _ => n_data
        };

        if (N_MAX <= n_data)
        {
            n_data = 0;
            a = 0.0;
            ea = 0.0;
            phi = 0.0;
        }
        else
        {
            a = a_vec[n_data];
            ea = ea_vec[n_data];
            phi = phi_vec[n_data];
            n_data += 1;
        }
    }
}