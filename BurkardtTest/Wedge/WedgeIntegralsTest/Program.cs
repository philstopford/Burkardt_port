using System;
using System.Globalization;
using Burkardt.MonomialNS;
using Burkardt.Types;
using Integrals = Burkardt.Wedge.Integrals;

namespace WedgeIntegralsTest;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for WEDGE_INTEGRALS_TEST.
        //
        //  Discussion:
        //
        //    WEDGE_INTEGRALS_TEST tests the WEDGE_INTEGRALS library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    21 August 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("WEDGE_INTEGRALS_TEST");
            
        Console.WriteLine("  Test the WEDGE_INTEGRALS library.");

        test01();

        Console.WriteLine("");
        Console.WriteLine("WEDGE_INTEGRALS_TEST");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}