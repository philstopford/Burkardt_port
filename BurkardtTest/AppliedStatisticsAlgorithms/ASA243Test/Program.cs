using System;
using Burkardt.AppliedStatistics;

namespace ASA241Test;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for ASA243_TEST.
        //
        //  Discussion:
        //
        //    ASA243_TEST tests the ASA243 library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    25 January 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("ASA243_TEST:");
        Console.WriteLine("  Test the ASA243 library.");

        test01 ( );

        Console.WriteLine("");
        Console.WriteLine("ASA243_TEST:");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
            
    }

}