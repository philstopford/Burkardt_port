using System;
using System.Globalization;
using Burkardt.AppliedStatistics;
using Burkardt.Types;
using Burkardt.Uniform;

namespace ASA266Test;

internal static class Program
{
    private static void Main()
//****************************************************************************80
//
//  Purpose:
//
//    MAIN is the main program for ASA266_TEST.
//
//  Discussion:
//
//    ASA266_TEST tests the ASA266 library.
//
//  Licensing:
//
//    This code is distributed under the GNU LGPL license. 
//
//  Modified:
//
//    05 June 2013
//
//  Author:
//
//    John Burkardt
//
    {
        Console.WriteLine("");
        Console.WriteLine("ASA266_TEST:");
        Console.WriteLine("  Test the ASA266 library.");

        test01();
        test02();
        test03();
        test04();
        test05();
        test06();
        test07();
        test08();
        test085();
        test09();
        test10();

        Console.WriteLine("");
        Console.WriteLine("ASA266_TEST:");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");

    }



}