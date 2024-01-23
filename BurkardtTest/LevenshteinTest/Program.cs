using System;
using Burkardt.MatrixNS;

namespace LevenshteinTest;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //   MAIN is the main program for LEVENSHTEIN_TEST.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    19 March 2018
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("LEVENSHTEIN_TEST");
        Console.WriteLine("  Test the LEVENSHTEIN library.");

        levenshtein_distance_test();
        levenshtein_matrix_test();
        //
        //  Terminate.
        //
        Console.WriteLine("");
        Console.WriteLine("LEVENSHTEIN_TEST");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}