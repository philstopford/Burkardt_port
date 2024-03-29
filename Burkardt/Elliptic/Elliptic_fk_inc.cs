﻿using System;

namespace Burkardt.Elliptic;

public static class FK_inc
{
    public static double evaluate(double phi, double k)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    ELLIPTIC_INC_FK evaluates the incomplete elliptic integral F(PHI,K).
        //
        //  Discussion:
        //
        //    The value is computed using Carlson elliptic integrals:
        //
        //      F(phi,k) = sin(phi) * RF ( cos^2 ( phi ), 1-k^2 sin^2 ( phi ), 1 )
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
        //    Input, double PHI, K, the arguments.
        //    0 <= PHI <= PI/2.
        //    0 <= K^2 * sin^2(PHI) <= 1.
        //
        //    Output, double ELLIPTIC_INC_FK, the function value.
        //
    {
        int ierr = 0;

        double cp = Math.Cos(phi);
        double sp = Math.Sin(phi);
        double x = cp * cp;
        double y = (1.0 - k * sp) * (1.0 + k * sp);
        const double z = 1.0;
        const double errtol = 1.0E-03;

        double value = Integral.rf(x, y, z, errtol, ref ierr);

        if (ierr != 0)
        {
            Console.WriteLine("");
            Console.WriteLine("ELLIPTIC_INC_FK - Fatal error!");
            Console.WriteLine("  RF returned IERR = " + ierr + "");
            return 1;
        }

        value = sp * value;

        return value;
    }

    public static void values(ref int n_data, ref double phi, ref double k, ref double fk )

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    ELLIPTIC_INC_FK_VALUES: values of the incomplete elliptic integral F(PHI,K).
        //
        //  Discussion:
        //
        //    This is the incomplete elliptic integral of the first kind.
        //
        //      F(PHI,K) = integral ( 0 <= T <= PHI ) 
        //        dT / sqrt ( 1 - K^2 * sin ( T )^2 )
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
        //    Output, double &PHI, &K, the arguments.
        //
        //    Output, double &FK, the value of the function.
        //
    {
        const int N_MAX = 20;

        double[] fk_vec =
            {
                0.4340870330108736,
                1.307312511398114,
                0.8005154258533936,
                0.4656721451084328,
                0.06969849613441773,
                0.09712646708750489,
                0.6632598061016007,
                2.2308677858579,
                1.439846282888019,
                0.2043389243773096,
                1.537183574881771,
                0.2749229901565622,
                0.4828388342828284,
                0.1812848567886627,
                1.360729522341841,
                1.09039680912027,
                1.355363051581808,
                1.445462819732441,
                0.3125355489354676,
                0.6775731623807174
            }
            ;

        double[] k_vec =
            {
                2.712952582080266,
                0.1279518954120547,
                -1.429437513650137,
                -1.981659235625333,
                3.894801879555818,
                -1.042486024983672,
                0.8641142168759754,
                -1.049058412826877,
                -0.3024062128402472,
                -6.574288841527263,
                0.6987397421988888,
                -5.12558591600033,
                2.074947853793764,
                -1.670886158426681,
                -0.4843595000931672,
                0.1393061679635559,
                -0.0946527302537008,
                0.1977207111754007,
                1.788159919089993,
                -1.077780624681256
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
            fk = 0.0;
            k = 0.0;
            phi = 0.0;
        }
        else
        {
            fk = fk_vec[n_data];
            k = k_vec[n_data];
            phi = phi_vec[n_data];
            n_data += 1;
        }
    }
}