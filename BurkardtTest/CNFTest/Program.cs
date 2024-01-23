using System;
using Burkardt.IO;
using Burkardt.Types;

namespace CNFTest;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for CNF_IO_TEST.
        //
        //  Discussion:
        //
        //    CNF_IO_TEST tests the CNF_IO library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    09 June 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("CNF_IO_TEST");

        Console.WriteLine("  Test the CNF_IO library.");

        test01();
        test02();
        test03();
        test04();
        test05();
        test06();
        test07();

        Console.WriteLine("");
        Console.WriteLine("CNF_IO_TEST");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}