using Burkardt.PDFLib;
using Burkardt.Types;
using Burkardt.Uniform;

namespace Burkardt_Tests;

public class Discrete2DPDFTest
{
    private static int n = 1000;
    [Test]
    public static void test01()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 looks at a 20x20 region.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    16 December 2012
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int N, the number of sample points to be generated.
        //
    {
        int n1 = 0;
        int n2 = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST01");
        Console.WriteLine("  Consider data skewed toward the upper left corner of the unit square.");
        Console.WriteLine("  Generate " + n + " samples");
        //
        //  Get the dimensions of the PDF data.
        //
        Discrete2D.get_discrete_pdf_size1(ref n1, ref n2);
        Console.WriteLine("  PDF data is on a " + n1 + " by " + n2 + " grid.");
        //
        //  Construct a PDF from the data.
        //
        double[] pdf = Discrete2D.get_discrete_pdf_data1(n1, n2);
        //
        //  "Integrate" the data over rows and columns of the region to get the CDF.
        //
        double[] cdf = Discrete2D.set_discrete_cdf(n1, n2, pdf);
        //
        //  Choose N CDF values at random.
        //
        int seed = 123456789;

        double[] u = UniformRNG.r8vec_uniform_01_new(n, ref seed);
        //
        //  Find the cell corresponding to each CDF value,
        //  and choose a random point in that cell.
        //
        double[] xy = Discrete2D.discrete_cdf_to_xy(n1, n2, cdf, n, u, ref seed);
        //
        //  Write data to a file for examination, plotting, or analysis.
        //
        const string filename = "test01.txt";
        typeMethods.r8mat_write(filename, 2, n, xy);

        Console.WriteLine("");
        Console.WriteLine("  Wrote sample data to file \"" + filename + "\".");
    }

    [Test]
    public static void test02()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST02 looks at a 12x8 region.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    16 December 2012
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int N, the number of sample points to be generated.
        //
    {
        int n1 = 0;
        int n2 = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST02");
        Console.WriteLine("  Consider data suggested by the shape and density of Iowa.");
        Console.WriteLine("  Generate " + n + " samples");
        //
        //  Get the dimensions of the PDF data.
        //
        Discrete2D.get_discrete_pdf_size2(ref n1, ref n2);
        Console.WriteLine("  PDF data is on a " + n1 + " by " + n2 + " grid.");
        //
        //  Construct a PDF from the data.
        //
        double[] pdf = Discrete2D.get_discrete_pdf_data2(n1, n2);
        //
        //  "Integrate" the data over rows and columns of the region to get the CDF.
        //
        double[] cdf = Discrete2D.set_discrete_cdf(n1, n2, pdf);
        //
        //  Choose N CDF values at random.
        //
        int seed = 123456789;

        double[] u = UniformRNG.r8vec_uniform_01_new(n, ref seed);
        //
        //  Find the cell corresponding to each CDF value,
        //  and choose a random point in that cell.
        //
        double[] xy = Discrete2D.discrete_cdf_to_xy(n1, n2, cdf, n, u, ref seed);
        //
        //  Write data to a file for examination, plotting, or analysis.
        //
        const string filename = "test02.txt";
        typeMethods.r8mat_write(filename, 2, n, xy);

        Console.WriteLine("");
        Console.WriteLine("  Wrote sample data to file \"" + filename + "\".");
    }
    
}