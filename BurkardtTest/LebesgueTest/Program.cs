using System;
using Burkardt.Function;
using Burkardt.PointsNS;
using Burkardt.Types;

namespace LebesgueTest;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for LEBESGUE_TEST.
        //
        //  Discussion:
        //
        //    LEBESGUE_TEST tests the LEBESGUE library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    04 March 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("LEBESGUE_TEST");
        Console.WriteLine("  Test the LEBESGUE library.");

        test01();
        test02();
        test03();
        test04();
        test05();
        test06();
        test07();
        test08();
        test09();

        Console.WriteLine("");
        Console.WriteLine("LEBESGUE_TEST");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}