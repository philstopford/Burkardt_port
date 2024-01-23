using System;
using Burkardt.AppliedStatistics;

namespace ASA172Test;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for ASA172_TEST.
        //
        //  Discussion:
        //
        //    ASA172_TEST tests the ASA172 library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    27 July 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("ASA172_TEST:");
        Console.WriteLine("  Test the ASA172 library.");

        test01();
        test02();

        Console.WriteLine("");
        Console.WriteLine("ASA172_TEST:");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }



}