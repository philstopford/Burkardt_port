using System;

namespace IndexTest;

using Index = Burkardt.IndexNS.Index;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for INDEX_TEST.
        //
        //  Discussion:
        //
        //    INDEX_TEST tests the INDEX library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    28 November 2012
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("INDEX_TEST:");
        Console.WriteLine("  Test the INDEX library.");

        test01();
        test02();
        test03();
        test04();
        test05();

        Console.WriteLine("");
        Console.WriteLine("INDEX_TEST:");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}