using Burkardt.IO;
using Burkardt.Table;
using Burkardt.Types;

namespace Burkardt_Tests.TestTable.Latinize;

public class LatinizeTest
{
    [Test]
    public static void test1()
    {
        handle("cvt_02_00010.txt");
    }
    
    [Test]
    public static void test2()
    {
        handle("cvt_03_00007.txt");
    }

    [Test]
    public static void test3()
    {
        handle("cvt_03_00056.txt");
    }

    [Test]
    public static void test4()
    {
        handle("cvt_07_00100.txt");
    }
    
    private static void handle(string input_filename)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    HANDLE handles a single file.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    08 October 2004
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, string INPUT_FILENAME, the name of the input file.
        //
        //  Local parameters:
        //
        //    Local, int DIM_NUM, the spatial dimension of the point set.
        //
        //    Local, int N, the number of points.
        //
        //    Local, double Z[DIM_NUM*N], the point set.
        //
        //    Local, int NS, the number of sample points.
        //
    {
        //
        //  Need to create the output file name from the input filename.
        //
        string output_filename = Files.file_name_ext_swap(input_filename, "latin.txt");

        TableHeader h = typeMethods.r8mat_header_read(input_filename);
        int dim_num = h.m;
        int n = h.n;

        Console.WriteLine("");
        Console.WriteLine("  Read the header of \"" + input_filename + "\".");
        Console.WriteLine("");
        Console.WriteLine("  Spatial dimension DIM_NUM = " + dim_num + "");
        Console.WriteLine("  Number of points N  = " + n + "");

        double[] table = typeMethods.r8mat_data_read(input_filename, dim_num, n);

        Console.WriteLine("");
        Console.WriteLine("  Read the data in \"" + input_filename + "\".");

        typeMethods.r8mat_print_some(dim_num, n, table, 1, 1, 5, 5,
            "  Small portion of data read from file:");

        typeMethods.r8mat_latinize(dim_num, n, ref table);

        Console.WriteLine("");
        Console.WriteLine("  Latinized the data.");

        typeMethods.r8mat_print_some(dim_num, n, table, 1, 1, 5, 5,
            "  Small portion of Latinized data:");

        typeMethods.r8mat_write(output_filename, dim_num, n, table);

        Console.WriteLine("");
        Console.WriteLine("  Wrote the latinized data to \"" + output_filename + "\".");

    }
    
}