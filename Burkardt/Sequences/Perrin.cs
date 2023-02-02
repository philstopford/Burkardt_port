﻿namespace Burkardt.Sequence;

public static class Perrin
{
    public static void perrin ( int n, ref int[] p )

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    PERRIN returns the first N values of the Perrin sequence.
        //
        //  Discussion:
        //
        //    The Perrin sequence has the initial values:
        //
        //      P(0) = 3
        //      P(1) = 0
        //      P(2) = 2
        //
        //    and subsequent entries are generated by the recurrence
        //
        //      P(I+1) = P(I-1) + P(I-2)
        //
        //    Note that if N is a prime, then N must evenly divide P(N).
        //
        //  Example:
        //
        //    0   3
        //    1   0
        //    2   2
        //    3   3
        //    4   2
        //    5   5
        //    6   5
        //    7   7
        //    8  10
        //    9  12
        //   10  17
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    11 August 2004
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Reference:
        //
        //    Ian Stewart,
        //    "A Neglected Number",
        //    Scientific American, Volume 274, pages 102-102, June 1996.
        //
        //    Ian Stewart,
        //    Math Hysteria,
        //    Oxford, 2004.
        //
        //    Eric Weisstein,
        //    CRC Concise Encyclopedia of Mathematics,
        //    CRC Press, 1999.
        //
        //  Parameters:
        //
        //    Input, int N, the number of terms.
        //
        //    Output, int P(N), the terms 0 through N-1 of the sequence.
        //
    {
        int i;

        switch (n)
        {
            case < 1:
                return;
        }

        p[0] = 3;

        switch (n)
        {
            case < 2:
                return;
        }

        p[1] = 0;

        switch (n)
        {
            case < 3:
                return;
        }
 
        p[2] = 2;

        for ( i = 4; i <= n; i++ )
        {
            p[i-1] = p[i-3] + p[i-4];
        }
    }
}