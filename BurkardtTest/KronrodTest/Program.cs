using System;
using System.Globalization;
using Burkardt.Kronrod;

namespace KronrodTest;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for KRONROD_TEST.
        //
        //  Discussion:
        //
        //    KRONROD_TEST tests KRONROD.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    03 August 2010
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("KRONROD_TEST:");
        Console.WriteLine("  Test the KRONROD library.");

        test01();
        test02();
        test03();

        Console.WriteLine("");
        Console.WriteLine("KRONROD_TEST:");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}