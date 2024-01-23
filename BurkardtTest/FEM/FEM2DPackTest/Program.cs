using System;
using System.Globalization;
using Burkardt;
using Burkardt.FEM;
using Burkardt.Graph;
using Burkardt.MatrixNS;
using Burkardt.NavierStokesNS;
using Burkardt.Types;
using Burkardt.Uniform;
using Triangle = Burkardt.TriangleNS.Triangle;

namespace FEM2DPackTest;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for FEM2D_PACK_TEST.
        //
        //  Discussion:
        //
        //    FEM2D_PACK_TEST tests the FEM2D_PACK library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    11 January 2013
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("FEM2D_PACK_TEST:");
        Console.WriteLine("  Test the FEM2D_PACK library.");

        test01();
        test02();
        test03();
        test04();
        test05();
        test07();
        test08();
        test09();

        test10();
        test105();
        test11();
        test12();
        test13();
        test135();
        test14();
        test15();
        test16();
        test18();
        test19();

        test20();
        test21();
        test22();
        test23();
        test24();

        Console.WriteLine("");
        Console.WriteLine("FEM2D_PACK_TEST:");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}