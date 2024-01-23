using System;
using Burkardt.Means;
using Burkardt.SolveNS;
using Burkardt.Table;
using Burkardt.Types;

namespace KMeansTest;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for KMEANS_TEST.
        //
        //  Discussion:
        //
        //    KMEANS_TEST tests the KMEANS library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    13 October 2011
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("KMEANS_TEST");
        Console.WriteLine("  Test the KMEANS library.");

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
        test13();
        test14();
        test15();
        test16();

        Console.WriteLine("");
        Console.WriteLine("KMEANS_TEST");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}