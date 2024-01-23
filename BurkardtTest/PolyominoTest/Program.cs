using System;
using Burkardt.PolyominoNS;
using Burkardt.Types;

namespace PolyominoTest;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for polyominoes_test.
        //
        //  Discussion:
        //
        //    polyominoes_test tests polyominoes.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    02 April 2020
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("polyominoes_test");
        Console.WriteLine("  Test polyominoes.");

        pentomino_matrix_test();
        pentomino_plot_test();
        polyomino_condense_test();
        polyomino_embed_number_test();
        polyomino_embed_list_test();
        polyomino_enumerate_test();
        polyomino_index_test();
        polyomino_lp_write_test();
        polyomino_transform_test();
        Console.WriteLine("");
        Console.WriteLine("polyominoes_test");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}