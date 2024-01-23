using System;
using System.Globalization;
using Burkardt.MinpackNS;
using Burkardt.SolveNS;
using Burkardt.Types;
using Burkardt.Uniform;

namespace MinPackTest;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MINPACK_TEST tests MINPACK.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    02 January 2018
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("MINPACK_TEST");
        Console.WriteLine("  Test minpack().");

        chkder_test();
        hybrd1_test();
        qform_test();
        Console.WriteLine("");
        Console.WriteLine("MINPACK_TEST");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}