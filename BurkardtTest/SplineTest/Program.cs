using System;
using System.Globalization;
using Burkardt.Function;
using Burkardt.MatrixNS;
using Burkardt.Types;
using Burkardt.Uniform;

namespace SplineTest;


internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for SPLINE_TEST.
        //
        //  Discussion:
        //
        //    SPLINE_TEST tests SPLINE.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    29 January 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("SPLINE_TEST");
        Console.WriteLine("  Test SPLINE.");

        parabola_val2_test();
        test002();
        test003();
        test004();
        test005();
        test006();

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
        test115();
        test116();
        test12();
        test125();
        test126();
        test127();
        test13();
        test14();
        test145();
        test15();
        test16();
        test17();
        test18();
        test19();

        test20();
        test205();
        test21();
        test215();
        test22();
        test225();
        test23();
        test235();
        test24();
        Console.WriteLine("");
        Console.WriteLine("SPLINE_TEST");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}