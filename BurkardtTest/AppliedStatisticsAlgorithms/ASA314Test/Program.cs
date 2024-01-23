using System;
using Burkardt.AppliedStatistics;
using Burkardt.Types;

namespace ASA314Test;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for ASA314_TEST.
        //
        //  Discussion:
        //
        //    ASA314_TEST tests ASA314.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    09 December 2013
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Reference:
        //
        //    Roger Payne,
        //    Inversion of matrices with contents subject to modulo arithmetic,
        //    Applied Statistics,
        //    Volume 46, Number 2, 1997, pages 295-298.
        //
    {
        Console.WriteLine("");
        Console.WriteLine("ASA314_TEST:");
        Console.WriteLine("  Test the ASA314 library.");

        test01 ( );

        Console.WriteLine("");
        Console.WriteLine("ASA314_TEST:");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
            
    }

        
}