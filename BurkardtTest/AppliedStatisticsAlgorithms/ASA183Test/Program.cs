using System;
using System.Globalization;
using Burkardt.AppliedStatistics;

namespace ASA183Test;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for ASA183_TEST.
        //
        //  Discussion:
        //
        //    ASA183_TEST tests the ASA183 library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    08 July 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("ASA183_TEST");
        Console.WriteLine("  Test the ASA183 library.");

        test01();
        test02();
        test03();

        test04();
        test05();
        test06();

        test07();
        test08();
        test09();

        test10();
        test11();
        test12();

        Console.WriteLine("");
        Console.WriteLine("ASA183_TEST");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");

    }



}