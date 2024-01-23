using System;
using Burkardt.AppliedStatistics;
using Burkardt.Types;

namespace ASA144Test;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for ASA144_TEST.
        //
        //  Discussion:
        //
        //    ASA144_TEST tests the ASA144 library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    28 January 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("ASA144_TEST");
        Console.WriteLine("  Test the ASA144 library.");

        test01();

        Console.WriteLine("");
        Console.WriteLine("ASA144_TEST");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}