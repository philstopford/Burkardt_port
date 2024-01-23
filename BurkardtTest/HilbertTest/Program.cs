using System;
using Burkardt.Function;

namespace HilbertTest;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for HILBERT_CURVE_TEST.
        //
        //  Discussion:
        //
        //    HILBERT_CURVE_TEST tests HILBERT_CURVE.
        //
        //  Modified:
        //
        //    02 January 2016
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("HILBERT_CURVE_TEST:");
        Console.WriteLine("  Test the HILBERT_CURVE library.");

        d2xy_test();
        rot_test();
        xy2d_test();

        Console.WriteLine("");
        Console.WriteLine("HILBERT_CURVE_TEST");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}