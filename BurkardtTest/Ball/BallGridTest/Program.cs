using System;
using Burkardt.Ball;
using Burkardt.Types;

namespace BallGridTest;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for BALL_GRID_TEST.
        //
        //  Discussion:
        //
        //    BALL_GRID_TEST tests the BALL_GRID library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    11 November 2011
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("BALL_GRID_TEST:");
        Console.WriteLine("  Test the BALL_GRID library.");

        ball_grid_test01();

        Console.WriteLine("");
        Console.WriteLine("BALL_GRID_TEST:");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}