using System;
using System.Globalization;
using Burkardt.Ball;
using Burkardt.MonomialNS;
using Burkardt.Types;
using Burkardt.Uniform;

namespace BallIntegralsTest;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for BALL_INTEGRALS_TEST.
        //
        //  Discussion:
        //
        //    BALL_INTEGRALS_TEST tests the BALL_INTEGRALS library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    10 January 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("BALL_INTEGRALS_TEST");
        Console.WriteLine("  Test the BALL_INTEGRALS library.");

        test01();

        Console.WriteLine("");
        Console.WriteLine("BALL_INTEGRALS_TEST");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}