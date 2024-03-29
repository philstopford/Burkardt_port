using System.Globalization;
using Burkardt.Quadrature;
using Burkardt.Sparse;
using Burkardt.Types;

namespace Burkardt_Tests.TestSparse;

public class GridOpenTest
{
        [Test]
    public static void test()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for SPARSE_GRID_OPEN_TEST.
        //
        //  Discussion:
        //
        //    SPARSE_GRID_OPEN_TEST tests the SPARSE_GRID_OPEN library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    12 January 2010
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Reference:
        //
        //    Fabio Nobile, Raul Tempone, Clayton Webster,
        //    A Sparse Grid Stochastic Collocation Method for Partial Differential
        //    Equations with Random Input Data,
        //    SIAM Journal on Numerical Analysis,
        //    Volume 46, Number 5, 2008, pages 2309-2345.
        //
    {
        Console.WriteLine("");
        Console.WriteLine("SPARSE_GRID_OPEN_TEST");
        Console.WriteLine("  Test the SPARSE_GRID_OPEN library.");
        //
        //  Point counts for Open Fully Nested "OFN" rules.
        //
        int dim_min = 1;
        int dim_max = 5;
        int level_max_min = 0;
        int level_max_max = 10;
        test01(dim_min, dim_max, level_max_min, level_max_max);

        dim_min = 6;
        dim_max = 10;
        level_max_min = 0;
        level_max_max = 10;
        test01(dim_min, dim_max, level_max_min, level_max_max);
        //
        //  Point counts for Open Non Nested "ONN" rules.
        //
        dim_min = 1;
        dim_max = 5;
        level_max_min = 0;
        level_max_max = 10;
        test011(dim_min, dim_max, level_max_min, level_max_max);

        dim_min = 6;
        dim_max = 10;
        level_max_min = 0;
        level_max_max = 10;
        test011(dim_min, dim_max, level_max_min, level_max_max);
        //
        //  Point counts for Open Weakly Nested "OWN" rules.
        //
        dim_min = 1;
        dim_max = 5;
        level_max_min = 0;
        level_max_max = 10;
        test012(dim_min, dim_max, level_max_min, level_max_max);

        dim_min = 6;
        dim_max = 10;
        level_max_min = 0;
        level_max_max = 10;
        test012(dim_min, dim_max, level_max_min, level_max_max);
        //
        //  Point counts for Fejer Type 2 Slow rules.
        //
        dim_min = 1;
        dim_max = 5;
        level_max_min = 0;
        level_max_max = 10;
        test013(dim_min, dim_max, level_max_min, level_max_max);

        dim_min = 6;
        dim_max = 10;
        level_max_min = 0;
        level_max_max = 10;
        test013(dim_min, dim_max, level_max_min, level_max_max);
        //
        //  Point counts for Gauss-Patterson-Slow rules.
        //
        dim_min = 1;
        dim_max = 5;
        level_max_min = 0;
        level_max_max = 10;
        test015(dim_min, dim_max, level_max_min, level_max_max);

        dim_min = 6;
        dim_max = 10;
        level_max_min = 0;
        level_max_max = 10;
        test015(dim_min, dim_max, level_max_min, level_max_max);

        test02(2, 2);
        test02(2, 3);
        test02(2, 4);
        test02(3, 2);
        test02(6, 2);

        test04(2, 3);

        test05(2, 3);

        test06(2, 4);

        test08(2, 4);
        //
        //  Terminate.
        //
        Console.WriteLine("");
        Console.WriteLine("SPARSE_GRID_OPEN_TEST");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

    private static void test01(int dim_min, int dim_max, int level_max_min, int level_max_max)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 tests SPARSE_GRID_OFN_SIZE.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    23 December 2009
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int DIM_MIN, the minimum spatial dimension to consider.
        //
        //    Input, int DIM_MAX, the maximum spatial dimension to consider.
        //
        //    Input, int LEVEL_MAX_MIN, the minimum value of LEVEL_MAX to consider.
        //
        //    Input, int LEVEL_MAX_MAX, the maximum value of LEVEL_MAX to consider.
        //
    {
        int dim_num;
        int level_max;

        Console.WriteLine("");
        Console.WriteLine("TEST01");
        Console.WriteLine("  SPARSE_GRID_OFN_SIZE returns the number of ");
        Console.WriteLine("  distinct points in a sparse grid made up of all ");
        Console.WriteLine("  product grids formed from open fully nested");
        Console.WriteLine("  quadrature rules.");
        Console.WriteLine("");
        Console.WriteLine("  The sparse grid is the sum of all product grids");
        Console.WriteLine("  of order LEVEL, with");
        Console.WriteLine("    0 <= LEVEL <= LEVEL_MAX.");
        Console.WriteLine("");
        Console.WriteLine("  LEVEL is the sum of the levels of the 1D rules,");
        Console.WriteLine("  the order of the 1D rule is 2^(LEVEL+1) - 1,");
        Console.WriteLine("  the region is [-1,1]^DIM_NUM.");
        Console.WriteLine("");
        Console.WriteLine("  For this kind of rule, there is complete nesting,");
        Console.WriteLine("  that is, a sparse grid of a given level includes");
        Console.WriteLine("  ALL the points on grids of lower levels.");
        Console.WriteLine("");
        string cout = "   DIM: ";
        for (dim_num = dim_min; dim_num <= dim_max; dim_num++)
        {
            cout += "  " + dim_num.ToString(CultureInfo.InvariantCulture).PadLeft(10);
        }

        Console.WriteLine(cout);
        Console.WriteLine("");
        Console.WriteLine("   LEVEL_MAX");
        Console.WriteLine("");

        for (level_max = level_max_min; level_max <= level_max_max; level_max++)
        {
            cout = "    " + level_max.ToString(CultureInfo.InvariantCulture).PadLeft(4);
            for (dim_num = dim_min; dim_num <= dim_max; dim_num++)
            {
                int point_num = Grid.sparse_grid_ofn_size(dim_num, level_max);
                cout += "  " + point_num.ToString(CultureInfo.InvariantCulture).PadLeft(10);
            }

            Console.WriteLine(cout);
        }
    }

    private static void test011(int dim_min, int dim_max, int level_max_min, int level_max_max)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST011 tests SPARSE_GRID_ONN_SIZE.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    12 January 2010
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int DIM_MIN, the minimum spatial dimension to consider.
        //
        //    Input, int DIM_MAX, the maximum spatial dimension to consider.
        //
        //    Input, int LEVEL_MAX_MIN, the minimum value of LEVEL_MAX to consider.
        //
        //    Input, int LEVEL_MAX_MAX, the maximum value of LEVEL_MAX to consider.
        //
    {
        int dim_num;
        int level_max;

        Console.WriteLine("");
        Console.WriteLine("TEST011");
        Console.WriteLine("  SPARSE_GRID_ONN_SIZE returns the number of ");
        Console.WriteLine("  distinct points in a sparse grid made up of all ");
        Console.WriteLine("  product grids formed from open non nested ");
        Console.WriteLine("  quadrature rules.");
        Console.WriteLine("");
        Console.WriteLine("  The sparse grid is the sum of all product grids");
        Console.WriteLine("  of order LEVEL, with");
        Console.WriteLine("    0 <= LEVEL <= LEVEL_MAX.");
        Console.WriteLine("");
        Console.WriteLine("  LEVEL is the sum of the levels of the 1D rules,");
        Console.WriteLine("  the order of the 1D rule is 2^(LEVEL+1) - 1,");
        Console.WriteLine("  the region is [-1,1]^DIM_NUM.");
        Console.WriteLine("");
        Console.WriteLine("  For this kind of rule, there is no nesting.");
        Console.WriteLine("");
        string cout = "   DIM: ";
        for (dim_num = dim_min; dim_num <= dim_max; dim_num++)
        {
            cout += "  " + dim_num.ToString(CultureInfo.InvariantCulture).PadLeft(10);
        }

        Console.WriteLine(cout);
        Console.WriteLine("");
        Console.WriteLine("   LEVEL_MAX");
        Console.WriteLine("");

        for (level_max = level_max_min; level_max <= level_max_max; level_max++)
        {
            cout = "    " + level_max.ToString(CultureInfo.InvariantCulture).PadLeft(4);
            for (dim_num = dim_min; dim_num <= dim_max; dim_num++)
            {
                int point_num = Grid.sparse_grid_onn_size(dim_num, level_max);
                cout += "  " + point_num.ToString(CultureInfo.InvariantCulture).PadLeft(10);
            }

            Console.WriteLine(cout);
        }
    }

    private static void test012(int dim_min, int dim_max, int level_max_min, int level_max_max)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST012 tests SPARSE_GRID_OWN_SIZE.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    12 January 2010
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int DIM_MIN, the minimum spatial dimension to consider.
        //
        //    Input, int DIM_MAX, the maximum spatial dimension to consider.
        //
        //    Input, int LEVEL_MAX_MIN, the minimum value of LEVEL_MAX to consider.
        //
        //    Input, int LEVEL_MAX_MAX, the maximum value of LEVEL_MAX to consider.
        //
    {
        int dim_num;
        int level_max;

        Console.WriteLine("");
        Console.WriteLine("TEST012");
        Console.WriteLine("  SPARSE_GRID_OWN_SIZE returns the number of ");
        Console.WriteLine("  distinct points in a sparse grid made up of all ");
        Console.WriteLine("  product grids formed from open weakly nested ");
        Console.WriteLine("  quadrature rules.");
        Console.WriteLine("");
        Console.WriteLine("  The sparse grid is the sum of all product grids");
        Console.WriteLine("  of order LEVEL, with");
        Console.WriteLine("    0 <= LEVEL <= LEVEL_MAX.");
        Console.WriteLine("");
        Console.WriteLine("  LEVEL is the sum of the levels of the 1D rules,");
        Console.WriteLine("  the order of the 1D rule is 2^(LEVEL+1) - 1,");
        Console.WriteLine("  the region is [-1,1]^DIM_NUM.");
        Console.WriteLine("");
        Console.WriteLine("  For this kind of rule, there is weak nesting,");
        Console.WriteLine("  that is, 0.0 is the only point any two rules have in common.");
        Console.WriteLine("");
        string cout = "   DIM: ";
        for (dim_num = dim_min; dim_num <= dim_max; dim_num++)
        {
            cout += "  " + dim_num.ToString(CultureInfo.InvariantCulture).PadLeft(10);
        }

        Console.WriteLine(cout);
        Console.WriteLine("");
        Console.WriteLine("   LEVEL_MAX");
        Console.WriteLine("");

        for (level_max = level_max_min; level_max <= level_max_max; level_max++)
        {
            cout = "    " + level_max.ToString(CultureInfo.InvariantCulture).PadLeft(4);
            for (dim_num = dim_min; dim_num <= dim_max; dim_num++)
            {
                int point_num = Grid.sparse_grid_own_size(dim_num, level_max);
                cout += "  " + point_num.ToString(CultureInfo.InvariantCulture).PadLeft(10);
            }

            Console.WriteLine(cout);
        }
    }

    private static void test013(int dim_min, int dim_max, int level_max_min, int level_max_max)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST013 tests SPARSE_GRID_F2S_SIZE.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    26 December 2009
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int DIM_MIN, the minimum spatial dimension to consider.
        //
        //    Input, int DIM_MAX, the maximum spatial dimension to consider.
        //
        //    Input, int LEVEL_MAX_MIN, the minimum value of LEVEL_MAX to consider.
        //
        //    Input, int LEVEL_MAX_MAX, the maximum value of LEVEL_MAX to consider.
        //
    {
        int dim_num;
        int level_max;

        Console.WriteLine("");
        Console.WriteLine("TEST013");
        Console.WriteLine("  SPARSE_GRID_F2S_SIZE returns the number of ");
        Console.WriteLine("  distinct points in a sparse grid made up of all ");
        Console.WriteLine("  product grids formed from Fejer Type 2 Slow ");
        Console.WriteLine("  quadrature rules.");
        Console.WriteLine("");
        Console.WriteLine("  The sparse grid is the sum of all product grids");
        Console.WriteLine("  of order LEVEL, with");
        Console.WriteLine("    0 <= LEVEL <= LEVEL_MAX.");
        Console.WriteLine("");
        Console.WriteLine("  LEVEL is the sum of the levels of the 1D rules,");
        Console.WriteLine("  the order of the 1D rule is 2^(LEVEL+1) - 1,");
        Console.WriteLine("  the region is [-1,1]^DIM_NUM.");
        Console.WriteLine("");
        Console.WriteLine("  For this kind of rule, there is complete nesting,");
        Console.WriteLine("  that is, a sparse grid of a given level includes");
        Console.WriteLine("  ALL the points on grids of lower levels.");
        Console.WriteLine("");
        string cout = "   DIM: ";
        for (dim_num = dim_min; dim_num <= dim_max; dim_num++)
        {
            cout += "  " + dim_num.ToString(CultureInfo.InvariantCulture).PadLeft(10);
        }

        Console.WriteLine(cout);
        Console.WriteLine("");
        Console.WriteLine("   LEVEL_MAX");
        Console.WriteLine("");

        for (level_max = level_max_min; level_max <= level_max_max; level_max++)
        {
            cout = "    " + level_max.ToString(CultureInfo.InvariantCulture).PadLeft(4);
            for (dim_num = dim_min; dim_num <= dim_max; dim_num++)
            {
                int point_num = Grid.sparse_grid_f2s_size(dim_num, level_max);
                cout += "  " + point_num.ToString(CultureInfo.InvariantCulture).PadLeft(10);
            }

            Console.WriteLine(cout);
        }
    }

    private static void test015(int dim_min, int dim_max, int level_max_min, int level_max_max)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST015 tests SPARSE_GRID_GPS_SIZE.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    25 December 2009
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int DIM_MIN, the minimum spatial dimension to consider.
        //
        //    Input, int DIM_MAX, the maximum spatial dimension to consider.
        //
        //    Input, int LEVEL_MAX_MIN, the minimum value of LEVEL_MAX to consider.
        //
        //    Input, int LEVEL_MAX_MAX, the maximum value of LEVEL_MAX to consider.
        //
    {
        int dim_num;
        int level_max;

        Console.WriteLine("");
        Console.WriteLine("TEST015");
        Console.WriteLine("  SPARSE_GRID_GPS_SIZE returns the number of ");
        Console.WriteLine("  distinct points in a sparse grid made up of all ");
        Console.WriteLine("  product grids formed from Gauss-Patterson-Slow ");
        Console.WriteLine("  quadrature rules.");
        Console.WriteLine("");
        Console.WriteLine("  The sparse grid is the sum of all product grids");
        Console.WriteLine("  of order LEVEL, with");
        Console.WriteLine("    0 <= LEVEL <= LEVEL_MAX.");
        Console.WriteLine("");
        Console.WriteLine("  LEVEL is the sum of the levels of the 1D rules,");
        Console.WriteLine("  the order of the 1D rule is 2^(LEVEL+1) - 1,");
        Console.WriteLine("  the region is [-1,1]^DIM_NUM.");
        Console.WriteLine("");
        Console.WriteLine("  For this kind of rule, there is complete nesting,");
        Console.WriteLine("  that is, a sparse grid of a given level includes");
        Console.WriteLine("  ALL the points on grids of lower levels.");
        Console.WriteLine("");
        string cout = "   DIM: ";
        for (dim_num = dim_min; dim_num <= dim_max; dim_num++)
        {
            cout += "  " + dim_num.ToString(CultureInfo.InvariantCulture).PadLeft(10);
        }

        Console.WriteLine(cout);
        Console.WriteLine("");
        Console.WriteLine("   LEVEL_MAX");
        Console.WriteLine("");

        for (level_max = level_max_min; level_max <= level_max_max; level_max++)
        {
            cout = "    " + level_max.ToString(CultureInfo.InvariantCulture).PadLeft(4);
            for (dim_num = dim_min; dim_num <= dim_max; dim_num++)
            {
                int point_num = Grid.sparse_grid_gps_size(dim_num, level_max);
                cout += "  " + point_num.ToString(CultureInfo.InvariantCulture).PadLeft(10);
            }

            Console.WriteLine(cout);
        }
    }

    private static void test02(int dim_num, int level_max)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST02 tests LEVELS_OPEN_INDEX.
        //
        //  Discussion:
        //
        //    The routine under study computes the indices of the unique points
        //    used in a sparse multidimensional grid whose size is controlled
        //    by a parameter LEVEL.
        //
        //    Once these indices are returned, they can be converted into
        //    Fejer type 2 points, Gauss-Patterson, 
        //    Newton-Cotes Open, scaled to the appropriate 
        //    interval.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    19 April 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int j;

        Console.WriteLine("");
        Console.WriteLine("TEST02:");
        Console.WriteLine("  LEVELS_OPEN_INDEX returns all grid indexes");
        Console.WriteLine("  whose level value satisfies");
        Console.WriteLine("    0 <= LEVEL <= LEVEL_MAX.");
        Console.WriteLine("  Here, LEVEL is the sum of the levels of the 1D rules,");
        Console.WriteLine("  and the order of the rule is 2^(LEVEL+1) - 1.");

        Console.WriteLine("");
        Console.WriteLine("  LEVEL_MAX = " + level_max + "");
        Console.WriteLine("  Spatial dimension DIM_NUM = " + dim_num + "");

        int point_num = Grid.sparse_grid_ofn_size(dim_num, level_max);

        Console.WriteLine("");
        Console.WriteLine("  Number of unique points in the grid = " + point_num + "");
        //
        //  Compute the orders and points.
        //
        int[] grid_index = Grid.levels_open_index(dim_num, level_max, point_num);
        //
        //  Now we're done.  Print the merged grid data.
        //
        Console.WriteLine("");
        Console.WriteLine("  Grid index:");
        Console.WriteLine("");
        for (j = 0; j < point_num; j++)
        {
            string cout = "  " + j.ToString(CultureInfo.InvariantCulture).PadLeft(4) + "  ";
            int dim;
            for (dim = 0; dim < dim_num; dim++)
            {
                cout += grid_index[dim + j * dim_num].ToString(CultureInfo.InvariantCulture).PadLeft(6);
            }

            Console.WriteLine(cout);
        }
    }

    private static void test04(int dim_num, int level_max)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST04 tests LEVELS_OPEN_INDEX to create a Fejer Type 2 grid.
        //
        //  Discussion:
        //
        //    This routine gets the sparse grid indices and determines the 
        //    corresponding sparse grid abscissas.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    19 April 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int dim;
        int j;

        Console.WriteLine("");
        Console.WriteLine("TEST04:");
        Console.WriteLine("  Make a sparse Fejer Type 2 grid.");
        Console.WriteLine("");
        Console.WriteLine("  LEVELS_OPEN_INDEX returns all grid indexes");
        Console.WriteLine("  whose level value satisfies");
        Console.WriteLine("    0 <= LEVEL <= LEVEL_MAX.");
        Console.WriteLine("  Here, LEVEL is the sum of the levels of the 1D rules,");
        Console.WriteLine("  and the order of the rule is 2^(LEVEL+1) - 1.");
        Console.WriteLine("");
        Console.WriteLine("  Now we demonstrate how to convert grid indices");
        Console.WriteLine("  into physical grid points.  In this case, we");
        Console.WriteLine("  want points on [-1,+1]^DIM_NUM.");
        Console.WriteLine("");
        Console.WriteLine("  LEVEL_MAX = " + level_max + "");
        Console.WriteLine("  Spatial dimension DIM_NUM = " + dim_num + "");

        int point_num = Grid.sparse_grid_ofn_size(dim_num, level_max);

        Console.WriteLine("");
        Console.WriteLine("  Number of unique points in the grid = " + point_num + "");
        //
        //  Compute the grid indices.
        //
        int[] grid_index = Grid.levels_open_index(dim_num, level_max, point_num);
        //
        //  Print the grid indices.
        //
        Console.WriteLine("");
        Console.WriteLine("  Grid index:");
        Console.WriteLine("");
        for (j = 0; j < point_num; j++)
        {
            string cout = "  " + j.ToString(CultureInfo.InvariantCulture).PadLeft(4);
            for (dim = 0; dim < dim_num; dim++)
            {
                cout += grid_index[dim + j * dim_num].ToString(CultureInfo.InvariantCulture).PadLeft(6);
            }

            Console.WriteLine(cout);
        }

        //
        //  Convert index information to physical information.
        //
        int order_max = (int) Math.Pow(2, level_max + 1) - 1;

        double[] grid_point = new double[dim_num * point_num];

        for (j = 0; j < point_num; j++)
        {
            for (dim = 0; dim < dim_num; dim++)
            {
                grid_point[dim + j * dim_num] =
                    Fejer2.f2_abscissa(order_max, grid_index[dim + j * dim_num]);
            }
        }

        Console.WriteLine("");
        Console.WriteLine("  Grid points:");
        Console.WriteLine("");
        for (j = 0; j < point_num; j++)
        {
            string cout = "  " + j.ToString(CultureInfo.InvariantCulture).PadLeft(4);
            for (dim = 0; dim < dim_num; dim++)
            {
                cout += "  " + grid_point[dim + j * dim_num].ToString(CultureInfo.InvariantCulture).PadLeft(10);
            }

            Console.WriteLine(cout);
        }
    }

    private static void test05(int dim_num, int level_max)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST05 tests LEVELS_OPEN_INDEX to create a Gauss Patterson grid.
        //
        //  Discussion:
        //
        //    This routine gets the sparse grid indices and determines the 
        //    corresponding sparse grid abscissas.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    19 April 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int dim;
        int j;

        Console.WriteLine("");
        Console.WriteLine("TEST05:");
        Console.WriteLine("  Make a sparse Gauss Patterson grid.");
        Console.WriteLine("");
        Console.WriteLine("  LEVELS_OPEN_INDEX returns all grid indexes");
        Console.WriteLine("  whose level value satisfies");
        Console.WriteLine("    0 <= LEVEL <= LEVEL_MAX.");
        Console.WriteLine("  Here, LEVEL is the sum of the levels of the 1D rules,");
        Console.WriteLine("  and the order of the rule is 2^(LEVEL+1) - 1.");
        Console.WriteLine("");
        Console.WriteLine("  Now we demonstrate how to convert grid indices");
        Console.WriteLine("  into physical grid points.  In this case, we");
        Console.WriteLine("  want points on [-1,+1]^DIM_NUM.");
        Console.WriteLine("");
        Console.WriteLine("  LEVEL_MAX = " + level_max + "");
        Console.WriteLine("  Spatial dimension DIM_NUM = " + dim_num + "");

        int point_num = Grid.sparse_grid_ofn_size(dim_num, level_max);

        Console.WriteLine("");
        Console.WriteLine("  Number of unique points in the grid = " + point_num + "");
        //
        //  Compute the grid indices.
        //
        int[] grid_index = Grid.levels_open_index(dim_num, level_max, point_num);
        //
        //  Print the grid indices.
        //
        Console.WriteLine("");
        Console.WriteLine("  Grid index:");
        Console.WriteLine("");
        for (j = 0; j < point_num; j++)
        {
            string cout = "  " + j.ToString(CultureInfo.InvariantCulture).PadLeft(4);
            for (dim = 0; dim < dim_num; dim++)
            {
                cout += grid_index[dim + j * dim_num].ToString(CultureInfo.InvariantCulture).PadLeft(6);
            }

            Console.WriteLine(cout);
        }

        //
        //  Convert index information to physical information.
        //  Note that GP_ABSCISSA expects the LEVEL value, not the ORDER!
        //
        double[] grid_point = new double[dim_num * point_num];

        int order_max = (int) Math.Pow(2, level_max + 1) - 1;

        for (j = 0; j < point_num; j++)
        {
            for (dim = 0; dim < dim_num; dim++)
            {
                grid_point[dim + j * dim_num] =
                    PattersonQuadrature.gp_abscissa(order_max, grid_index[dim + j * dim_num]);
            }
        }

        Console.WriteLine("");
        Console.WriteLine("  Grid points:");
        Console.WriteLine("");
        for (j = 0; j < point_num; j++)
        {
            string cout = "  " + j.ToString(CultureInfo.InvariantCulture).PadLeft(4);
            for (dim = 0; dim < dim_num; dim++)
            {
                cout += "  " + grid_point[dim + j * dim_num].ToString(CultureInfo.InvariantCulture).PadLeft(10);
            }

            Console.WriteLine(cout);
        }

    }

    private static void test06(int dim_num, int level_max)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST06 tests levels_open_INDEX to create a Newton Cotes Open grid.
        //
        //  Discussion:
        //
        //    This routine gets the sparse grid indices and determines the 
        //    corresponding sparse grid abscissas.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    19 April 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int dim;
        int j;

        Console.WriteLine("");
        Console.WriteLine("TEST06:");
        Console.WriteLine("  Make a sparse Newton Cotes Open grid.");
        Console.WriteLine("");
        Console.WriteLine("  LEVELS_OPEN_INDEX returns all grid indexes");
        Console.WriteLine("  whose level value satisfies");
        Console.WriteLine("    0 <= LEVEL <= LEVEL_MAX.");
        Console.WriteLine("  Here, LEVEL is the sum of the levels of the 1D rules,");
        Console.WriteLine("  and the order of the rule is 2^(LEVEL+1) - 1.");
        Console.WriteLine("");
        Console.WriteLine("  Now we demonstrate how to convert grid indices");
        Console.WriteLine("  into physical grid points.  In this case, we");
        Console.WriteLine("  want points on [0,+1]^DIM_NUM.");
        Console.WriteLine("");
        Console.WriteLine("  LEVEL_MAX = " + level_max + "");
        Console.WriteLine("  Spatial dimension DIM_NUM = " + dim_num + "");

        int point_num = Grid.sparse_grid_ofn_size(dim_num, level_max);

        Console.WriteLine("");
        Console.WriteLine("  Number of unique points in the grid = " + point_num + "");
        //
        //  Compute the grid indices.
        //
        int[] grid_index = Grid.levels_open_index(dim_num, level_max, point_num);
        //
        //  Print the grid indices.
        //
        Console.WriteLine("");
        Console.WriteLine("  Grid index:");
        Console.WriteLine("");
        for (j = 0; j < point_num; j++)
        {
            string cout = "  " + j.ToString(CultureInfo.InvariantCulture).PadLeft(4);
            for (dim = 0; dim < dim_num; dim++)
            {
                cout += grid_index[dim + j * dim_num].ToString(CultureInfo.InvariantCulture).PadLeft(6);
            }

            Console.WriteLine(cout);
        }

        //
        //  Convert index information to physical information.
        //
        int order_max = (int) Math.Pow(2, level_max + 1) - 1;

        double[] grid_point = new double[dim_num * point_num];

        for (j = 0; j < point_num; j++)
        {
            for (dim = 0; dim < dim_num; dim++)
            {
                grid_point[dim + j * dim_num] =
                    NewtonCotesQuadrature.nco_abscissa(order_max, grid_index[dim + j * dim_num]);
            }
        }

        Console.WriteLine("");
        Console.WriteLine("  Grid points:");
        Console.WriteLine("");
        for (j = 0; j < point_num; j++)
        {
            string cout = "  " + j.ToString(CultureInfo.InvariantCulture).PadLeft(4);
            for (dim = 0; dim < dim_num; dim++)
            {
                cout += "  " + grid_point[dim + j * dim_num].ToString(CultureInfo.InvariantCulture).PadLeft(10);
            }

            Console.WriteLine(cout);
        }

    }

    private static void test08(int dim_num, int level_max)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST08 creates and writes sparse grid files of all types.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    10 July 2009
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int dim;
        int j;

        Console.WriteLine("");
        Console.WriteLine("TEST08:");
        Console.WriteLine("  Make sparse grids and write to files.");
        Console.WriteLine("");
        Console.WriteLine("  LEVEL_MAX = " + level_max + "");
        Console.WriteLine("  Spatial dimension DIM_NUM = " + dim_num + "");

        int point_num = Grid.sparse_grid_ofn_size(dim_num, level_max);

        Console.WriteLine("");
        Console.WriteLine("  Number of unique points in the grid = " + point_num + "");
        //
        //  Compute the grid indices.
        //
        int[] grid_index = Grid.levels_open_index(dim_num, level_max, point_num);
        //
        //  Print the grid indices.
        //
        Console.WriteLine("");
        Console.WriteLine("  Grid index:");
        Console.WriteLine("");
        for (j = 0; j < point_num; j++)
        {
            string cout = "  " + j.ToString(CultureInfo.InvariantCulture).PadLeft(4);
            for (dim = 0; dim < dim_num; dim++)
            {
                cout += grid_index[dim + j * dim_num].ToString(CultureInfo.InvariantCulture).PadLeft(6);
            }

            Console.WriteLine(cout);
        }

        //
        //  Convert index information to physical information.
        //
        int order_max = (int) Math.Pow(2, level_max + 1) - 1;

        double[] grid_point = new double[dim_num * point_num];
        //
        //  Create F2 data and write to file.
        //
        for (j = 0; j < point_num; j++)
        {
            for (dim = 0; dim < dim_num; dim++)
            {
                grid_point[dim + j * dim_num] =
                    Fejer2.f2_abscissa(order_max, grid_index[dim + j * dim_num]);
            }
        }

        string file_name = "f2_d" + dim_num
                                  + "_level" + level_max + ".txt";

        typeMethods.r8mat_write(file_name, dim_num, point_num, grid_point);

        Console.WriteLine("  Wrote file \"" + file_name + "\".");
        //
        //  Create GP data and write to file.
        //  Note that GP_ABSCISSA expects the value of LEVEL, not ORDER!
        //
        for (j = 0; j < point_num; j++)
        {
            for (dim = 0; dim < dim_num; dim++)
            {
                grid_point[dim + j * dim_num] =
                    PattersonQuadrature.gp_abscissa(order_max, grid_index[dim + j * dim_num]);
            }
        }

        file_name = "gp_d" + dim_num
                           + "_level" + level_max + ".txt";

        typeMethods.r8mat_write(file_name, dim_num, point_num, grid_point);

        Console.WriteLine("  Wrote file \"" + file_name + "\".");
        //
        //  Create NCO data and write to file.
        //
        for (j = 0; j < point_num; j++)
        {
            for (dim = 0; dim < dim_num; dim++)
            {
                grid_point[dim + j * dim_num] =
                    NewtonCotesQuadrature.nco_abscissa(order_max, grid_index[dim + j * dim_num]);
            }
        }

        file_name = "nco_d" + dim_num
                            + "_level" + level_max + ".txt";

        typeMethods.r8mat_write(file_name, dim_num, point_num, grid_point);

        Console.WriteLine("  Wrote file \"" + file_name + "\".");

    }

}