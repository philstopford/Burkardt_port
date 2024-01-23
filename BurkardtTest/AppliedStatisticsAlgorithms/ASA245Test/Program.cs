using System;
using Burkardt;
using Burkardt.AppliedStatistics;

namespace ASA245Test;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for ASA245_TEST.
        //
        //  Discussion:
        //
        //    ASA245_TEST tests the ASA245 library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    25 September 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("ASA245_TEST:");
        Console.WriteLine("  Test the ASA245 library.");

        test01();
        test02();
        test03();

        Console.WriteLine("");
        Console.WriteLine("ASA245_TEST:");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");

    }

}