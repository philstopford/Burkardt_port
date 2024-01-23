using System;
using System.Globalization;
using Burkardt;
using Burkardt.AppliedStatistics;

namespace ASA136Test;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for ASA136_TEST.
        //
        //  Discussion:
        //
        //    ASA136_TEST tests the ASA136 library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    15 February 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("ASA136_TEST:");
        Console.WriteLine("  Test the ASA136 library.");

        test01();

        Console.WriteLine("");
        Console.WriteLine("ASA136_TEST:");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }


}