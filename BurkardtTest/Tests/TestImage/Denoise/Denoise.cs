using Burkardt.Function;
using Burkardt.IO;

namespace Burkardt_Tests.TestImage.Denoise;

public class DenoiseTest
{
    [Test]
    public static void test01()
    {
        do_test("glassware_noisy.ascii.pgm", "glassware_median_news.ascii.pgm");
    }
    
    private static void do_test(string input_filename, string output_filename)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 tests GRAY_MEDIAN_NEWS.
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
        int g_max = 0;
        //const string input_filename = "glassware_noisy.ascii.pgm";
        string[] input_unit;
        int m = 0;
        int n = 0;
        //const string output_filename = "glassware_median_news.ascii.pgm";

        Console.WriteLine("");
        Console.WriteLine("TEST01:");
        Console.WriteLine("  GRAY_MEDIAN_NEWS uses a NEWS median filter ");
        Console.WriteLine("  on a noisy grayscale image.");

        Console.WriteLine("");
        Console.WriteLine("  The input file is \"" + input_filename + "\".");

        //
        //  Open the input file and read the data.
        //
        try
        {
            input_unit = File.ReadAllLines(input_filename);
        }
        catch (Exception)
        {
            Console.WriteLine("");
            Console.WriteLine("TEST01 - Fatal error!");
            Console.WriteLine("  Could not open the file \"" + input_filename + "\"");
            return;
        }

        int index = 0;

        PGMA.pgma_read_header(input_unit, ref index, ref m, ref n, ref g_max);

        Console.WriteLine("");
        Console.WriteLine("  Number of rows =          " + m + "");
        Console.WriteLine("  Number of columns =       " + n + "");
        Console.WriteLine("  Maximum pixel intensity = " + g_max + "");

        int[] g = new int[m * n];

        PGMA.pgma_read_data(input_unit, ref index, m, n, ref g);

        int[] g2 = NEWS.gray_median_news(m, n, g);
        //
        //  Write the denoised images.
        //
        PGMA.pgma_write(output_filename, m, n, g2);

        Console.WriteLine("");
        Console.WriteLine("  Wrote denoised image to \"" + output_filename + "\".");

    }
}