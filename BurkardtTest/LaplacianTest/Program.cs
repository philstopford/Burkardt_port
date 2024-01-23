using System;
using Burkardt.CholeskyNS;
using Burkardt.Error;
using Burkardt.Laplacian;
using Burkardt.Types;

namespace LaplacianTest;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for LAPLACIAN_TEST.
        //
        //  Discussion:
        //
        //    LAPLACIAN_TEST tests the LAPLACIAN library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    02 November 2013
        //
        //  Author:
        //
        //   John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("LAPLACIAN_TEST");
        Console.WriteLine("  Test the LAPLACIAN library.");

        test01();
        test02();
        test03();
        test04();
        test05();
        test06();

        Console.WriteLine("");
        Console.WriteLine("LAPLACIAN_TEST");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}