using Burkardt.IO;

namespace Burkardt_Tests.TestIO;

public class PBMBTest
{
    [Test]
    public static void test01()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 tests PBMB_EXAMPLE, PBMB_WRITE.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    15 April 2003
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        string file_out_name = "pbmb_io_prb_01.pbm";
        const int xsize = 300;
        const int ysize = 300;

        Console.WriteLine("");
        Console.WriteLine("TEST01:");
        Console.WriteLine("  PBMB_EXAMPLE sets up PBMB data.");
        Console.WriteLine("  PBMB_WRITE writes a PBMB file.");
        Console.WriteLine("");
        Console.WriteLine("  Writing the file \"" + file_out_name + "\".");

        int[] b = new int[xsize * ysize];

        bool error = PBMB.pbmb_example(xsize, ysize, ref b);

        switch (error)
        {
            case true:
                Console.WriteLine("");
                Console.WriteLine("TEST01 - Fatal error!");
                Console.WriteLine("  PBMB_EXAMPLE failed!");
                Assert.Fail();
                return;
        }

        Console.WriteLine("");
        Console.WriteLine("  PBMB_EXAMPLE has set up the data.");

        error = PBMB.pbmb_write(file_out_name, xsize, ysize, b);

        switch (error)
        {
            case true:
                Console.WriteLine("");
                Console.WriteLine("TEST01 - Fatal error!");
                Console.WriteLine("  PBMB_WRITE failed!");
                Assert.Fail();
                break;
            default:
                Console.WriteLine("");
                Console.WriteLine("  PBMB_WRITE was successful.");
                break;
        }

        //
        //  Now have PBMB_READ_TEST look at the file we think we created.
        //
        error = PBMB.pbmb_read_test(file_out_name);

        Assert.False(error);
    }

    [Test]
    public static void test02()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST02 tests PBMB_READ_HEADER, PBMB_READ_DATA.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    22 July 2011
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int[] b = null;
        const string file_in_name = "pbmb_io_prb_02.pbm";
        int xsize = 0;
        int ysize = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST02");
        Console.WriteLine("  PBMB_READ reads the header and data of a PBMB file.");
        Console.WriteLine("");
        Console.WriteLine("  Reading the file \"" + file_in_name + "\".");
        //
        //  Create a data file to read.
        //
        bool error = PBMB.pbmb_write_test(file_in_name);

        switch (error)
        {
            case true:
                Console.WriteLine("");
                Console.WriteLine("  PBMB_WRITE_TEST failed!");
                Assert.Fail();
                break;
            default:
                Console.WriteLine("");
                Console.WriteLine("  PBMB_WRITE_TEST created some test data.");
                break;
        }

        //
        //  Now have PBMB_READ try to read it.
        //
        error = PBMB.pbmb_read(file_in_name, ref xsize, ref ysize, ref b);

        switch (error)
        {
            case true:
                Console.WriteLine("");
                Console.WriteLine("  PBMB_READ failed!");
                Assert.Fail();
                break;
            default:
                Console.WriteLine("");
                Console.WriteLine("  PBMB_READ read the test data successfully.");
                break;
        }

        Assert.False(error);
    }
    
}