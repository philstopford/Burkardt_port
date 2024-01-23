using System;
using Burkardt.IntegralNS;

namespace ClausenTest;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for CLAUSEN_TEST.
        //
        //  Discussion:
        //
        //    CLAUSEN_TEST tests the CLAUSEN library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    12 December 2016
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("CLAUSEN_TEST:");
        Console.WriteLine("  Test the CLAUSEN library.");

        clausen_test();
        //
        //  Terminate.
        //
        Console.WriteLine("");
        Console.WriteLine("CLAUSEN_TEST:");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}