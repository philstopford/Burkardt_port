using System.Globalization;
using Burkardt.Composition;
using Burkardt.MonomialNS;
using Burkardt.Types;
using QuadratureRule = Burkardt.TriangleNS.QuadratureRule;

namespace Burkardt_Tests.TestTriangle;

public class RulesTest
{
    [Test]
    public static void test1()
    {
        int degree_max = 4;
        triangle_unit_monomial_test(degree_max);
    }

    [Test]
    public static void test2()
    {
        int degree_max = 7;
        triangle_unit_quad_test(degree_max);
    }

    private static void triangle_unit_monomial_test(int degree_max)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TRIANGLE_UNIT_MONOMIAL_TEST tests TRIANGLE_UNIT_MONOMIAL.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    16 April 2009
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int DEGREE_MAX, the maximum total degree of the
        //    monomials to check.
        //
    {
        int alpha;
        int[] expon = new int[2];

        Console.WriteLine("");
        Console.WriteLine("TRIANGLE_UNIT_MONOMIAL_TEST");
        Console.WriteLine("  For the unit triangle,");
        Console.WriteLine("  TRIANGLE_UNIT_MONOMIAL returns the exact value of the");
        Console.WriteLine("  integral of X^ALPHA Y^BETA");
        Console.WriteLine("");
        Console.WriteLine("  Volume = " + QuadratureRule.triangle_unit_volume() + "");
        Console.WriteLine("");
        Console.WriteLine("     ALPHA      BETA      INTEGRAL");
        Console.WriteLine("");

        for (alpha = 0; alpha <= degree_max; alpha++)
        {
            expon[0] = alpha;
            int beta;
            for (beta = 0; beta <= degree_max - alpha; beta++)
            {
                expon[1] = beta;

                double value = QuadratureRule.triangle_unit_monomial(expon);

                Console.WriteLine("  " + expon[0].ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                       + "  " + expon[1].ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                       + "  " + value.ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
            }
        }
    }

    private static void triangle_unit_quad_test(int degree_max)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TRIANGLE_UNIT_QUAD_TEST tests the rules for the unit triangle.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    18 April 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int DEGREE_MAX, the maximum total degree of the
        //    monomials to check.
        //
    {
        const int DIM_NUM = 2;

        int[] expon = new int[DIM_NUM];
        int h = 0;
        int t = 0;

        Console.WriteLine("");
        Console.WriteLine("TRIANGLE_UNIT_QUAD_TEST");
        Console.WriteLine("  For the unit triangle,");
        Console.WriteLine("  we approximate monomial integrals with:");
        Console.WriteLine("  TRIANGLE_UNIT_O01,");
        Console.WriteLine("  TRIANGLE_UNIT_O03,");
        Console.WriteLine("  TRIANGLE_UNIT_O03b,");
        Console.WriteLine("  TRIANGLE_UNIT_O06,");
        Console.WriteLine("  TRIANGLE_UNIT_O06b,");
        Console.WriteLine("  TRIANGLE_UNIT_O07,");
        Console.WriteLine("  TRIANGLE_UNIT_O12,");

        bool more = false;

        SubCompData data = new();
            
        for (;;)
        {
            SubComp.subcomp_next(ref data, degree_max, DIM_NUM, ref expon, ref more, ref h, ref t);

            Console.WriteLine("");
            string cout = "  Monomial exponents: ";
            int dim;
            for (dim = 0; dim < DIM_NUM; dim++)
            {
                cout += "  " + expon[dim].ToString(CultureInfo.InvariantCulture).PadLeft(2);
            }

            Console.WriteLine(cout);
            Console.WriteLine("");

            int order = 1;
            double[] w = new double[order];
            double[] xy = new double[DIM_NUM * order];
            QuadratureRule.triangle_unit_o01(ref w, ref xy);
            double[] v = Monomial.monomial_value(DIM_NUM, order, expon, xy);
            double quad = QuadratureRule.triangle_unit_volume() * typeMethods.r8vec_dot_product(order, w, v);
            Console.WriteLine("  " + order.ToString(CultureInfo.InvariantCulture).PadLeft(6)
                                   + "  " + quad.ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");

            order = 3;
            w = new double[order];
            xy = new double[DIM_NUM * order];
            QuadratureRule.triangle_unit_o03(ref w, ref xy);
            v = Monomial.monomial_value(DIM_NUM, order, expon, xy);
            quad = QuadratureRule.triangle_unit_volume() * typeMethods.r8vec_dot_product(order, w, v);
            Console.WriteLine("  " + order.ToString(CultureInfo.InvariantCulture).PadLeft(6)
                                   + "  " + quad.ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");

            order = 3;
            w = new double[order];
            xy = new double[DIM_NUM * order];
            QuadratureRule.triangle_unit_o03b(ref w, ref xy);
            v = Monomial.monomial_value(DIM_NUM, order, expon, xy);
            quad = QuadratureRule.triangle_unit_volume() * typeMethods.r8vec_dot_product(order, w, v);
            Console.WriteLine("  " + order.ToString(CultureInfo.InvariantCulture).PadLeft(6)
                                   + "  " + quad.ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");

            order = 6;
            w = new double[order];
            xy = new double[DIM_NUM * order];
            QuadratureRule.triangle_unit_o06(ref w, ref xy);
            v = Monomial.monomial_value(DIM_NUM, order, expon, xy);
            quad = QuadratureRule.triangle_unit_volume() * typeMethods.r8vec_dot_product(order, w, v);
            Console.WriteLine("  " + order.ToString(CultureInfo.InvariantCulture).PadLeft(6)
                                   + "  " + quad.ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");

            order = 6;
            w = new double[order];
            xy = new double[DIM_NUM * order];
            QuadratureRule.triangle_unit_o06b(ref w, ref xy);
            v = Monomial.monomial_value(DIM_NUM, order, expon, xy);
            quad = QuadratureRule.triangle_unit_volume() * typeMethods.r8vec_dot_product(order, w, v);
            Console.WriteLine("  " + order.ToString(CultureInfo.InvariantCulture).PadLeft(6)
                                   + "  " + quad.ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");

            order = 7;
            w = new double[order];
            xy = new double[DIM_NUM * order];
            QuadratureRule.triangle_unit_o07(ref w, ref xy);
            v = Monomial.monomial_value(DIM_NUM, order, expon, xy);
            quad = QuadratureRule.triangle_unit_volume() * typeMethods.r8vec_dot_product(order, w, v);
            Console.WriteLine("  " + order.ToString(CultureInfo.InvariantCulture).PadLeft(6)
                                   + "  " + quad.ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");

            order = 12;
            w = new double[order];
            xy = new double[DIM_NUM * order];
            QuadratureRule.triangle_unit_o12(ref w, ref xy);
            v = Monomial.monomial_value(DIM_NUM, order, expon, xy);
            quad = QuadratureRule.triangle_unit_volume() * typeMethods.r8vec_dot_product(order, w, v);
            Console.WriteLine("  " + order.ToString(CultureInfo.InvariantCulture).PadLeft(6)
                                   + "  " + quad.ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");

            Console.WriteLine("");
            quad = QuadratureRule.triangle_unit_monomial(expon);
            Console.WriteLine("  " + " Exact"
                                   + "  " + quad.ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");

            if (!more)
            {
                break;
            }
        }
    }
    
}