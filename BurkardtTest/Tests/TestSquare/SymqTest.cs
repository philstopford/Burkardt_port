using System.Globalization;
using Burkardt.PolynomialNS;
using Burkardt.Square;
using Burkardt.Types;

namespace Burkardt_Tests.TestSquare;

public class SymqTest
{
    static int degree = 8;
    static int n = Symq.rule_full_size(degree);
    static string header = "square08";

    [Test]
    public static void test01()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 calls SQUARESYMQ for a quadrature rule of given order.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU GPL license.
        //
        //  Modified:
        //
        //    02 July 2014
        //
        //  Author:
        //
        //    Original FORTRAN77 version by Hong Xiao, Zydrunas Gimbutas.
        //    C++ version by John Burkardt.
        //
        //  Reference:
        //
        //    Hong Xiao, Zydrunas Gimbutas,
        //    A numerical algorithm for the construction of efficient quadrature
        //    rules in two and higher dimensions,
        //    Computers and Mathematics with Applications,
        //    Volume 59, 2010, pages 663-676.
        //
        //  Parameters:
        //
        //    Input, int DEGREE, the desired total polynomial degree exactness
        //    of the quadrature rule.
        //
        //    Input, int N, the number of nodes.
        //
    {
        int j;

        Console.WriteLine("");
        Console.WriteLine("TEST01");
        Console.WriteLine("  Symmetric quadrature rule for a square.");
        Console.WriteLine("  Polynomial exactness degree DEGREE = " + degree + "");

        const double area = 4.0;
        //
        //  Retrieve and print a symmetric quadrature rule.
        //
        double[] x = new double[2 * n];
        double[] w = new double[n];

        Symq.square_symq(degree, n, ref x, ref w);

        Console.WriteLine("");
        Console.WriteLine("  Number of nodes N = " + n + "");

        Console.WriteLine("");
        Console.WriteLine("     J  W       X       Y");
        Console.WriteLine("");
        for (j = 0; j < n; j++)
        {
            Console.WriteLine(j.ToString().PadLeft(4) + "  "
                                                      + w[j].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "  "
                                                      + x[0 + j * 2].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "  "
                                                      + x[1 + j * 2].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
        }

        double d = typeMethods.r8vec_sum(n, w);

        Console.WriteLine("   Sum  " + d + "");
        Console.WriteLine("  Area  " + area + "");
    }

    [Test]
    public static void test02()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST02 gets a rule and writes it to a file.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU GPL license.
        //
        //  Modified:
        //
        //    02 July 2014
        //
        //  Author:
        //
        //    Original FORTRAN77 version by Hong Xiao, Zydrunas Gimbutas.
        //    C++ version by John Burkardt.
        //
        //  Reference:
        //
        //    Hong Xiao, Zydrunas Gimbutas,
        //    A numerical algorithm for the construction of efficient quadrature
        //    rules in two and higher dimensions,
        //    Computers and Mathematics with Applications,
        //    Volume 59, 2010, pages 663-676.
        //
        //  Parameters:
        //
        //    Input, int DEGREE, the desired total polynomial degree exactness
        //    of the quadrature rule.  0 <= DEGREE <= 50.
        //
        //    Input, int N, the number of nodes to be used by the rule.
        //
        //    Input, string HEADER, an identifier for the filenames.
        //
    {
        int i;
        List<string> rule_unit = new();

        Console.WriteLine("");
        Console.WriteLine("TEST02");
        Console.WriteLine("  Get a quadrature rule for the symmetric square.");
        Console.WriteLine("  Then write it to a file.");
        Console.WriteLine("  Polynomial exactness degree DEGREE = " + degree + "");
        //
        //  Retrieve a symmetric quadrature rule.
        //
        double[] x = new double[2 * n];
        double[] w = new double[n];

        Symq.square_symq(degree, n, ref x, ref w);
        //
        //  Write the points and weights to a file.
        //
        string rule_filename = header + ".txt";

        for (i = 0; i < n; i++)
        {
            rule_unit.Add(x[0 + i * 2] + "  "
                                       + x[1 + i * 2] + "  "
                                       + w[i] + "");
        }

        File.WriteAllLines(rule_filename, rule_unit);

        Console.WriteLine("");
        Console.WriteLine("  Quadrature rule written to file '" + rule_filename + "'");

    }

    [Test]
    public static void test03()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST03 gets a rule and creates GNUPLOT input files.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU GPL license.
        //
        //  Modified:
        //
        //    02 July 2014
        //
        //  Author:
        //
        //    Original FORTRAN77 version by Hong Xiao, Zydrunas Gimbutas.
        //    C++ version by John Burkardt.
        //
        //  Reference:
        //
        //    Hong Xiao, Zydrunas Gimbutas,
        //    A numerical algorithm for the construction of efficient quadrature
        //    rules in two and higher dimensions,
        //    Computers and Mathematics with Applications,
        //    Volume 59, 2010, pages 663-676.
        //
        //  Parameters:
        //
        //    Input, int DEGREE, the desired total polynomial degree exactness
        //    of the quadrature rule.  0 <= DEGREE <= 50.
        //
        //    Input, int N, the number of nodes to be used by the rule.
        //
        //    Input, string HEADER, an identifier for the filenames.
        //
    {
        Console.WriteLine("");
        Console.WriteLine("TEST03");
        Console.WriteLine("  Get a quadrature rule for the symmetric square.");
        Console.WriteLine("  Set up GNUPLOT graphics input.");
        Console.WriteLine("  Polynomial exactness degree DEGREE = " + degree + "");
        //
        //  Retrieve a symmetric quadrature rule.
        //
        double[] x = new double[2 * n];
        double[] w = new double[n];

        Symq.square_symq(degree, n, ref x, ref w);
        //
        //  Create files for input to GNUPLOT.
        //
        Symq.square_symq_gnuplot(n, x, header);

    }

    [Test]
    public static void test04()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST04 gets a rule and tests its accuracy.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU GPL license.
        //
        //  Modified:
        //
        //    02 July 2014
        //
        //  Author:
        //
        //    Original FORTRAN77 version by Hong Xiao, Zydrunas Gimbutas.
        //    C++ version by John Burkardt.
        //
        //  Reference:
        //
        //    Hong Xiao, Zydrunas Gimbutas,
        //    A numerical algorithm for the construction of efficient quadrature
        //    rules in two and higher dimensions,
        //    Computers and Mathematics with Applications,
        //    Volume 59, 2010, pages 663-676.
        //
        //  Parameters:
        //
        //    Input, int DEGREE, the desired total polynomial degree exactness
        //    of the quadrature rule.  0 <= DEGREE <= 50.
        //
        //    Input, int N, the number of nodes to be used by the rule.
        //
    {
        int i;
        int j;
        double[] z = new double[2];

        Console.WriteLine("");
        Console.WriteLine("TEST04");
        Console.WriteLine("  Get a quadrature rule for the symmetric square.");
        Console.WriteLine("  Test its accuracy.");
        Console.WriteLine("  Polynomial exactness degree DEGREE = " + degree + "");
        //
        //  Retrieve a symmetric quadrature rule.
        //
        double[] x = new double[2 * n];
        double[] w = new double[n];

        Symq.square_symq(degree, n, ref x, ref w);

        int npols = (degree + 1) * (degree + 2) / 2;
        double[] rints = new double[npols];

        for (j = 0; j < npols; j++)
        {
            rints[j] = 0.0;
        }

        for (i = 0; i < n; i++)
        {
            z[0] = x[0 + i * 2];
            z[1] = x[1 + i * 2];

            double[] pols = Polynomial.lege2eva(degree, z);
            for (j = 0; j < npols; j++)
            {
                rints[j] += w[i] * pols[j];
            }
        }

        const double area = 4.0;

        double d = Math.Pow(rints[0] - Math.Sqrt(area), 2);
        for (i = 1; i < npols; i++)
        {
            d += Math.Pow(rints[i], 2);
        }

        d = Math.Sqrt(d) / npols;

        Console.WriteLine("");
        Console.WriteLine("  RMS error = " + d + "");

    }
}