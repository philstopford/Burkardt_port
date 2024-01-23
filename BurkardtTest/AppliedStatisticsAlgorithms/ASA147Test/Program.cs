using System;
using Burkardt.AppliedStatistics;

namespace ASA147Test;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for ASA147_TEST.
        //
        //  Discussion:
        //
        //    ASA147_TEST tests the ASA147 library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    22 January 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("ASA147_TEST:");
        Console.WriteLine("  Test the ASA147 library.");

        test01 ( );

        Console.WriteLine("");
        Console.WriteLine("ASA147_TEST:");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

        
}