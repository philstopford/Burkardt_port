﻿using System;
using Burkardt.Types;

namespace Burkardt.FullertonFnLib;

public static partial class FullertonLib
{
    public static double r8_rand(double r, ref int ix0, ref int ix1)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    R8_RAND is a portable pseudorandom number generator.
        //
        //  Discussion:
        //
        //    This pseudo-random number generator is portable amoung a wide
        //    variety of computers.  It is undoubtedly not as good as many
        //    readily available installation dependent versions, and so this
        //    routine is not recommended for widespread usage.  Its redeeming
        //    feature is that the exact same random numbers (to within final round-
        //    off error) can be generated from machine to machine.  Thus, programs
        //    that make use of random numbers can be easily transported to and
        //    checked in a new environment.
        //
        //    The random numbers are generated by the linear congruential
        //    method described by Knuth in seminumerical methods (p.9),
        //    addison-wesley, 1969.  Given the i-th number of a pseudo-random
        //    sequence, the i+1 -st number is generated from
        //      x(i+1) = (a*x(i) + c) mod m,
        //    where here m = 2^22 = 4194304, c = 1731 and several suitable values
        //    of the multiplier a are discussed below.  Both the multiplier a and
        //    random number x are represented in double precision as two 11-bit
        //    words.  The constants are chosen so that the period is the maximum
        //    possible, 4194304.
        //
        //    In order that the same numbers be generated from machine to
        //    machine, it is necessary that 23-bit ints be reducible modulo
        //    2^11 exactly, that 23-bit ints be added exactly, and that 11-bit
        //    ints be multiplied exactly.  Furthermore, if the restart option
        //    is used (where r is between 0 and 1), then the product r*2^22 =
        //    r*4194304 must be correct to the nearest int.
        //
        //    The first four random numbers should be 
        //
        //      0.0004127026,
        //      0.6750836372, 
        //      0.1614754200, 
        //      0.9086198807.
        //
        //    The tenth random number is 
        //
        //      0.5527787209.
        //
        //    The hundredth random number is 
        //
        //      0.3600893021.  
        //
        //    The thousandth number should be 
        //
        //      0.2176990509.
        //
        //    In order to generate several effectively independent sequences
        //    with the same generator, it is necessary to know the random number
        //    for several widely spaced calls.  The I-th random number times 2^22,
        //    where I=K*P/8 and P is the period of the sequence (P = 2^22), is
        //    still of the form L*P/8.  In particular we find the I-th random
        //    number multiplied by 2^22 is given by
        //      I   =  0  1*p/8  2*p/8  3*p/8  4*p/8  5*p/8  6*p/8  7*p/8  8*p/8
        //      RAND=  0  5*p/8  2*p/8  7*p/8  4*p/8  1*p/8  6*p/8  3*p/8  0
        //    thus the 4*P/8 = 2097152 random number is 2097152/2^22.
        //
        //    Several multipliers have been subjected to the spectral test
        //    (see Knuth, p. 82).  Four suitable multipliers roughly in order of
        //    goodness according to the spectral test are
        //      3146757 = 1536*2048 + 1029 = 2^21 + 2^20 + 2^10 + 5
        //      2098181 = 1024*2048 + 1029 = 2^21 + 2^10 + 5
        //      3146245 = 1536*2048 +  517 = 2^21 + 2^20 + 2^9 + 5
        //      2776669 = 1355*2048 + 1629 = 5^9 + 7^7 + 1
        //
        //    In the table below log10(NU(I)) gives roughly the number of
        //    random decimal digits in the random numbers considered I at a time.
        //    C is the primary measure of goodness.  In both cases bigger is better.
        //
        //                     log10 nu(i)              c(i)
        //         a       i=2  i=3  i=4  i=5    i=2  i=3  i=4  i=5
        //
        //      3146757    3.3  2.0  1.6  1.3    3.1  1.3  4.6  2.6
        //      2098181    3.3  2.0  1.6  1.2    3.2  1.3  4.6  1.7
        //      3146245    3.3  2.2  1.5  1.1    3.2  4.2  1.1  0.4
        //      2776669    3.3  2.1  1.6  1.3    2.5  2.0  1.9  2.6
        //     best
        //      possible   3.3  2.3  1.7  1.4    3.6  5.9  9.7  14.9
        //
        //    Note that the original version of this routine used local static
        //    variables IX0 and IX1.  In this revised version, IX0 and IX1 are
        //    routine arguments.  To duplicate the behavior of the original code,
        //    IX0 and IX1 should be set to zero before the first call.  
        //    JVB, 04 May 2016.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    05 May 2016
        //
        //  Author:
        //
        //    C++ version by John Burkardt.
        //
        //  Parameters:
        //
        //    Input, double R, determines the action.
        //    * R = 0.0, the next random number of the sequence is generated.
        //    * R < 0.0, the last generated number will be returned for
        //    possible use in a restart procedure.
        //    * R > 0.0, the sequence of random numbers will start with the
        //    seed ( R mod 1 ).  This seed is also returned as the value of
        //    R8_RAND provided the arithmetic is done exactly.
        //
        //    Input/output, int &IX0, &IX1, two parameters used
        //    as seeds for the random number generator.  On first call, these
        //    might both be set to 0.
        //
        //    Output, double R8_RAND, a pseudo-random number between 0.0 and 1.0.
        //
    {
        const int ia0 = 1029;
        const int ia1 = 1536;
        const int ia1ma0 = 507;
        const int ic = 1731;

        switch (r)
        {
            case 0.0E+00:
                int iy0 = ia0 * ix0;
                int iy1 = ia1 * ix1 + ia1ma0 * (ix0 - ix1) + iy0;
                iy0 += ic;
                ix0 = iy0 % 2048;
                iy1 += (iy0 - ix0) / 2048;
                ix1 = iy1 % 2048;
                break;
            case > 0.0:
                ix1 = (int) (r8_mod(r, 1.0E+00) * 4194304.0 + 0.5E+00);
                ix0 = ix1 % 2048;
                ix1 = (ix1 - ix0) / 2048;
                break;
        }

        double value = ix1 * 2048 + ix0;
        value /= 4194304.0E+00;

        return value;
    }

    public static double r8_randgs(double xmean, double sd, ref int seed)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    R8_RANDGS generates a normally distributed random number.
        //
        //  Discussion:
        //
        //    This function generate a normally distributed random number, that is, 
        //    it generates random numbers with a Gaussian distribution.  These 
        //    random numbers are not exceptionally good, especially in the tails 
        //    of the distribution, but this implementation is simple and suitable 
        //    for most applications.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    24 April 2016
        //
        //  Author:
        //
        //    C++ version by John Burkardt.
        //
        //  Reference:
        //
        //    Richard Hamming,
        //    Numerical Methods for Scientists and Engineers,
        //    Dover, 1986,
        //    ISBN: 0486652416,
        //    LC: QA297.H28.
        //
        //  Parameters:
        //
        //    Input, double XMEAN, the mean of the Gaussian distribution.
        //
        //    Input, double SD, the standard deviation of the Gaussian function.
        //
        //    Input/output, int &SEED, a seed for the random number generator.
        //
        //    Output, double R8_RANDGS, a normally distributed random number.
        //
    {
        int i;
        double value = 0;

        value = -6.0E+00;
        for (i = 1; i <= 12; i++)
        {
            value += r8_ren(ref seed);
        }

        value = xmean + sd * value;
        return value;
    }

    public static double r8_random(int n, ref double[] t, ref int ix0, ref int ix1)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    R8_RANDOM is a portable pseudorandom number generator.
        //
        //  Discussion:
        //
        //    This random number generator is portable amoung a wide variety of
        //    computers.  It generates a random number between 0.0 and 1.0 
        //    according to the algorithm presented by Bays and Durham.
        //
        //    The motivation for using this scheme, which resembles the
        //    Maclaren-Marsaglia method, is to greatly increase the period of the
        //    random sequence.  If the period of the basic generator is P,
        //    then the expected mean period of the sequence generated by this
        //    generator is given by
        //
        //      new mean P = sqrt ( Math.PI * factorial ( N ) / ( 8 * P ) ),
        //
        //    where factorial ( N ) must be much greater than P in this 
        //    asymptotic formula.  Generally, N should be 16 to maybe 32.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    09 May 2016
        //
        //  Author:
        //
        //    C++ version by John Burkardt.
        //
        //  Reference:
        //
        //    Carter Bays, Stephen Durham,
        //    Improving a Poor Random Number Generator,
        //    ACM Transactions on Mathematical Software,
        //    Volume 2, Number 1, March 1976, pages 59-64.
        //
        //  Parameters:
        //
        //    Input, int N, the number of random numbers in an auxiliary table.
        //
        //    Input/output, double T[N+1], an array of random numbers, initialized
        //    before first call by R8_RANDOM_INIT.
        //
        //    Input/output, int &IX0, &IX1, two parameters used
        //    as seeds for the random number generator.
        //
        //    Output, double R8_RANDOM, a random number between 0.0 and 1.0.
        //
    {
        //
        //  Pick J, a random index between 1 and N, and return T(J).
        //
        int j = (int) (t[n] * Math.Abs(n));
        t[n] = t[j];
        double value = t[j];
        //
        //  Put a new value into T(J).
        //
        const double r = 0.0;
        t[j] = r8_rand(r, ref ix0, ref ix1);

        return value;
    }

    public static void r8_random_init(int n, ref double[] t, ref int ix0, ref int ix1)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    R8_RANDOM_INIT initializes data for R8_RANDOM.
        //
        //  Discussion:
        //
        //    Before calling R8_RANDOM the first time, call R8_RANDOM_INIT
        //    in order to initialize the T array.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    09 May 2016
        //
        //  Author:
        //
        //    C++ version by John Burkardt.
        //
        //  Reference:
        //
        //    Carter Bays, Stephen Durham,
        //    Improving a Poor Random Number Generator,
        //    ACM Transactions on Mathematical Software,
        //    Volume 2, Number 1, March 1976, pages 59-64.
        //
        //  Parameters:
        //
        //    Input, int N, the number of random numbers in an 
        //    auxiliary table.
        //
        //    Output, double T[N+1], an array of random numbers. 
        //
        //    Input/output, int &IX0, &IX1, two parameters used
        //    as seeds for the random number generator.  These might both be set to 0.
        //
    {
        int i;

        const double r = 0.0;
        for (i = 0; i < n + 1; i++)
        {
            t[i] = r8_rand(r, ref ix0, ref ix1);
        }
    }

    public static double r8_ren(ref int seed)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    R8_REN is a simple random number generator.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    24 April 2016
        //
        //  Author:
        //
        //    C++ version by John Burkardt.
        //
        //  Reference:
        //
        //    Malcolm Pike, David Hill,
        //    Algorithm 266:
        //    Pseudo-Random Numbers,
        //    Communications of the ACM,
        //    Volume 8, Number 10, October 1965, page 605.
        //
        //  Parameters:
        //
        //    Input/output, int &SEED, a seed for the random number generator.
        //
        //    Output, double R8_REN, the random value.
        //
    {
        seed %= typeMethods.i4_huge() / 125;
        seed *= 125;
        seed -= seed / 2796203 * 2796203;
        double value = seed / 2796203.0;

        return value;
    }
}