using System;
using Burkardt.AppliedStatistics;

namespace ASA299Test;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for ASA299_TEST.
        //
        //  Discussion:
        //
        //    ASA299_TEST tests the ASA299 library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    10 January 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("ASA299_TEST");
        Console.WriteLine("  Test the ASA299 library.");

        test01 ( );

        Console.WriteLine("");
        Console.WriteLine("ASA299_TEST");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
            
    }

}