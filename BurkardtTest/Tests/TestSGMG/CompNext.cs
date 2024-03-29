using Burkardt.Composition;

namespace Burkardt_Tests.TestSGMG;

public class CompNextTest
{
    static int[] dim_num_array =
    {
        2, 2, 2, 2, 2,
        3, 3, 3, 3, 3,
        4, 4
    };
    static int[] level_max_array =
    {
        0, 1, 2, 3, 4,
        0, 1, 2, 3, 4,
        2, 3
    };
    const int test_num = 12;

    [Test]
    public static void test()
    {
        for (int test = 0; test < test_num; test++)
        {
            int dim_num = dim_num_array[test];
            int level_max = level_max_array[test];
            comp_next_test(dim_num, level_max);
        }
        
    }
    
    private static void comp_next_test(int dim_num, int level_max)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    COMP_NEXT_TEST tests COMP_NEXT, which computes 1D level vectors.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    23 August 2009
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int DIM_NUM, the spatial dimension.
        //
        //    Input, int LEVEL_MAX, the maximum level.
        //
    {
        int level;

        int[] level_1d = new int[dim_num];
        int level_min = Math.Max(0, level_max + 1 - dim_num);

        Console.WriteLine("");
        Console.WriteLine("COMP_NEXT_TEST");
        Console.WriteLine("  COMP_NEXT generates, one at a time, vectors");
        Console.WriteLine("  LEVEL_1D(1:DIM_NUM) whose components add up to LEVEL.");
        Console.WriteLine("");
        Console.WriteLine("  We call with:");
        Console.WriteLine("  DIM_NUM = " + dim_num + "");
        Console.WriteLine("  " + level_min + " = LEVEL_MIN <= LEVEL <= LEVEL_MAX = "
                          + level_max + "");
        Console.WriteLine("");
        Console.WriteLine("     LEVEL     INDEX  LEVEL_1D Vector");
        //
        //  The outer loop generates values of LEVEL from LEVEL_MIN to LEVEL_MAX.
        //
        for (level = level_min; level <= level_max; level++)
        {
            Console.WriteLine("");
            //
            //  The inner loop generates vectors LEVEL_1D(1:DIM_NUM) whose components 
            //  add up to LEVEL.
            //
            bool more_grids = false;
            int h = 0;
            int t = 0;
            int i = 0;

            for (;;)
            {
                Comp.comp_next(level, dim_num, ref level_1d, ref more_grids, ref h, ref t);

                i += 1;
                string cout = "  " + level.ToString().PadLeft(8)
                                   + "  " + i.ToString().PadLeft(8);
                int dim;
                for (dim = 0; dim < dim_num; dim++)
                {
                    cout += "  " + level_1d[dim].ToString().PadLeft(8);
                }

                Console.WriteLine(cout);

                if (!more_grids)
                {
                    break;
                }
            }
        }
    }
}