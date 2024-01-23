using System;
using Burkardt.AppliedStatistics;

namespace ASA310Test;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for ASA310_PRB.
        //
        //  Discussion:
        //
        //    ASA310_PRB tests the ASA310 library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    03 February 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("ASA310_PRB:");
        Console.WriteLine("  Test the ASA310 library.");

        test01 ( );

        Console.WriteLine("");
        Console.WriteLine("ASA310_PRB:");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
            
    }

        
}