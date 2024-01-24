using Burkardt.Storage;
using Burkardt.Types;

namespace Burkardt_Tests.TestCompressedColumn.TestStorage;

public class TestStorage
{
    [Test]
    public static void test01()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 tests ccs_WRITE using a tiny matrix.
        //
        //  Discussion:
        //
        //    This test uses a trivial matrix whose full representation is:
        //
        //          2  3  0  0  0
        //          3  0  4  0  6
        //      A = 0 -1 -3  2  0
        //          0  0  1  0  0
        //          0  4  2  0  1
        //
        //    The 1-based CCS representation is
        //
        //      #  ICC  CCC  ACC
        //     --  ---  ---  ---
        //      1    1    1    2
        //      2    2         3
        //
        //      3    1    3    3
        //      4    3        -1
        //      5    5         4
        //
        //      6    2    6    4
        //      7    3        -3
        //      8    4         1
        //      9    5         2
        //
        //     10    3   10    2
        //
        //     11    2   11    6
        //     12    5         1
        //
        //     13    *   13
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    18 July 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        const int N = 5;
        const int NCC = 12;

        double[] acc =  {
                2.0, 3.0,
                3.0, -1.0, 4.0,
                4.0, -3.0, 1.0, 2.0,
                2.0,
                6.0, 1.0
            }
            ;
        int[] ccc =  {
                1, 3, 6, 10, 11, 13
            }
            ;
        int[] icc =  {
                1, 2,
                1, 3, 5,
                2, 3, 4, 5,
                3,
                2, 5
            }
            ;
        const string prefix = "simple";

        Console.WriteLine("");
        Console.WriteLine("TEST01");
        Console.WriteLine("  Write a sparse matrix in CCS format to 3 files.");
        //
        //  Full storage statistics
        //
        Console.WriteLine("");
        Console.WriteLine("  Full rows    M = " + N + "");
        Console.WriteLine("  Full columns N = " + N + "");
        Console.WriteLine("  Full storage   = " + N * N + "");
        //
        //  Decrement the 1-based data.
        //
        typeMethods.i4vec_dec(N + 1, ref ccc);
        typeMethods.i4vec_dec(NCC, ref icc);
        //
        //  Print the CCS matrix.
        //
        CompressedColumnStorage.ccs_print(N, N, NCC, icc, ccc, acc, "  The matrix in 0-based CCS format:");
        //
        //  Write the matrix to 3 files.
        //
        CompressedColumnStorage.ccs_write(prefix, NCC, N, icc, ccc, acc);

    }

    [Test]
    public static void test02()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST02 tests ccs_HEADER_READ and ccs_DATA_READ.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    18 July 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int n = 0;
        int ncc = 0;
        const string prefix = "simple";

        Console.WriteLine("");
        Console.WriteLine("TEST02");
        Console.WriteLine("  Read a sparse matrix in CCS format from 3 files.");
        //
        //  Read the header.
        //
        CompressedColumnStorage.ccs_header_read(prefix, ref ncc, ref n);
        //
        //  Allocate space.
        //
        double[] acc = new double[ncc];
        int[] ccc = new int[n + 1];
        int[] icc = new int[ncc];
        //
        //  Read the matrix data.
        //
        CompressedColumnStorage.ccs_data_read(prefix, ncc, n, ref icc, ref ccc, ref acc);
        //
        //  Print the CCS matrix.
        //
        int m = n;
        CompressedColumnStorage.ccs_print(m, n, ncc, icc, ccc, acc, "  The matrix in 0-based CCS format:");
        //
        //  Free memory.
        //
    }
}