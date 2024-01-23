using System;
using Burkardt.BoxBehnkenNS;
using Burkardt.Types;

namespace BoxBehnkenTest;

internal static class Program
{
    private static void Main()
    {
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for BOX_BEHNKEN_TEST.
        //
        //  Discussion:
        //
        //    BOX_BEHNKEN_TEST tests the BOX_BEHNKEN library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    23 October 2006
        //
        //  Author:
        //
        //    John Burkardt
        //
        {
            Console.WriteLine();
            Console.WriteLine("BOX_BEHNKEN_TEST");
            Console.WriteLine("  Test the BOX_BEHNKEN library.");

            test01();
            test02();

            Console.WriteLine();
            Console.WriteLine("BOX_BEHNKEN_TEST");
            Console.WriteLine("  Normal end of execution.");
            Console.WriteLine();
        }
            
            
}