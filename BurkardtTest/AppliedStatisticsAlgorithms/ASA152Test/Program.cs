using System;
using Burkardt.AppliedStatistics;

namespace ASA152Test;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for ASA152_TEST.
        //
        //  Discussion:
        //
        //    ASA152_TEST tests the ASA152 library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    27 January 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("ASA152_TEST:");
        Console.WriteLine("  Test the ASA152 library.");

        test01();
        test02();

        Console.WriteLine("");
        Console.WriteLine("ASA152_TEST:");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");

    }


}