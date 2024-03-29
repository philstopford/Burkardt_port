using System.Globalization;
using Burkardt.TetrahedronNS;

namespace Burkardt_Tests.TestTetrahedron;

public class NewtonCotesOpenTest
{
    [Test]
    public static void test01()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 tests TETRAHEDRON_NCO_RULE_NUM, TETRAHEDRON_NCO_DEGREE, TETRAHEDRON_NCO_ORDER_NUM.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    31 January 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int rule;

        Console.WriteLine("");
        Console.WriteLine("TEST01");
        Console.WriteLine("  TETRAHEDRON_NCO_RULE_NUM returns the number of rules;");
        Console.WriteLine("  TETRAHEDRON_NCO_DEGREE returns the degree of a rule;");
        Console.WriteLine("  TETRAHEDRON_NCO_ORDER_NUM returns the order of a rule.");

        int rule_num = NewtonCotesOpen.tetrahedron_nco_rule_num();

        Console.WriteLine("");
        Console.WriteLine("  Number of available rules = " + rule_num + "");
        Console.WriteLine("");
        Console.WriteLine("      Rule    Degree     Order");
        Console.WriteLine("");

        for (rule = 1; rule <= rule_num; rule++)
        {
            int order_num = NewtonCotesOpen.tetrahedron_nco_order_num(rule);
            int degree = NewtonCotesOpen.tetrahedron_nco_degree(rule);
            Console.WriteLine("  " + rule.ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                   + "  " + degree.ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                   + "  " + order_num.ToString(CultureInfo.InvariantCulture).PadLeft(8) + "");
        }
    }

    [Test]
    public static void test02()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST02 tests TETRAHEDRON_NCO_RULE.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    31 January 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        const int dim_num = 3;
        int rule;

        Console.WriteLine("");
        Console.WriteLine("TEST02");
        Console.WriteLine("  TETRAHEDRON_NCO_RULE returns the points and weights");
        Console.WriteLine("  of an NCO rule for the tetrahedron.");
        Console.WriteLine("");
        Console.WriteLine("  In this test, we simply check that the weights");
        Console.WriteLine("  sum to 1.");

        int rule_num = NewtonCotesOpen.tetrahedron_nco_rule_num();

        Console.WriteLine("");
        Console.WriteLine("  Number of available rules = " + rule_num + "");

        Console.WriteLine("");
        Console.WriteLine("      Rule      Sum of weights");
        Console.WriteLine("");

        for (rule = 1; rule <= rule_num; rule++)
        {
            int order_num = NewtonCotesOpen.tetrahedron_nco_order_num(rule);

            double[] xyztab = new double[dim_num * order_num];
            double[] wtab = new double[order_num];

            NewtonCotesOpen.tetrahedron_nco_rule(rule, order_num, ref xyztab, ref wtab);

            double wtab_sum = 0.0;
            int order;
            for (order = 0; order < order_num; order++)
            {
                wtab_sum += wtab[order];
            }

            Console.WriteLine("  " + rule.ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                   + "  " + wtab_sum.ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
        }
    }

    [Test]
    public static void test03()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST03 tests TETRAHEDRON_NCO_RULE.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    30 January 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int rule;

        Console.WriteLine("");
        Console.WriteLine("TEST03");
        Console.WriteLine("  TETRAHEDRON_NCO_RULE returns the points and weights");
        Console.WriteLine("  of an NCO rule for the tetrahedron.");
        Console.WriteLine("");
        Console.WriteLine("  In this test, we simply check that, for each");
        Console.WriteLine("  quadrature point, the barycentric coordinates");
        Console.WriteLine("  add up to 1.");

        int rule_num = NewtonCotesOpen.tetrahedron_nco_rule_num();

        Console.WriteLine("");
        Console.WriteLine("      Rule    Suborder    Sum of coordinates");
        Console.WriteLine("");

        for (rule = 1; rule <= rule_num; rule++)
        {
            int suborder_num = NewtonCotesOpen.tetrahedron_nco_suborder_num(rule);

            double[] suborder_xyz = new double[4 * suborder_num];
            double[] suborder_w = new double[suborder_num];

            NewtonCotesOpen.tetrahedron_nco_subrule(rule, suborder_num, ref suborder_xyz, ref suborder_w);

            Console.WriteLine("");
            Console.WriteLine("  " + rule.ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                   + "  " + suborder_num.ToString(CultureInfo.InvariantCulture).PadLeft(8) + "");

            int suborder;
            for (suborder = 0; suborder < suborder_num; suborder++)
            {
                double xyz_sum = suborder_xyz[0 + suborder * 4]
                                 + suborder_xyz[1 + suborder * 4]
                                 + suborder_xyz[2 + suborder * 4]
                                 + suborder_xyz[3 + suborder * 4];
                Console.WriteLine("                    "
                                  + "  " + xyz_sum.ToString("0.################").PadLeft(25) + "");
            }
        }
    }

    [Test]
    public static void test04()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST04 tests TETRAHEDRON_NCO_RULE.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    31 January 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int a;
        const int dim_num = 3;

        Console.WriteLine("");
        Console.WriteLine("TEST04");
        Console.WriteLine("  TETRAHEDRON_NCO_RULE returns the points and weights of");
        Console.WriteLine("  an NCO rule for the unit tetrahedron.");
        Console.WriteLine("");
        Console.WriteLine("  This routine uses those rules to estimate the");
        Console.WriteLine("  integral of monomomials in the unit tetrahedron.");

        int rule_num = NewtonCotesOpen.tetrahedron_nco_rule_num();

        const double volume = 1.0 / 6.0;

        for (a = 0; a <= 6; a++)
        {
            int b;
            for (b = 0; b <= 6 - a; b++)
            {
                int c;
                for (c = 0; c <= 6 - a - b; c++)
                {
                    //
                    //  Multiplying X**A * Y**B * Z**C by COEF will give us an integrand
                    //  whose integral is exactly 1.  This makes the error calculations easy.
                    //
                    double coef = 1.0;

                    //      for ( i = 1; i <= a; i++ )
                    //      {
                    //        coef = coef * i / i;
                    //      }
                    int i;
                    for (i = a + 1; i <= a + b; i++)
                    {
                        coef = coef * i / (i - a);
                    }

                    for (i = a + b + 1; i <= a + b + c; i++)
                    {
                        coef = coef * i / (i - a - b);
                    }

                    for (i = a + b + c + 1; i <= a + b + c + 3; i++)
                    {
                        coef *= i;
                    }

                    Console.WriteLine("");
                    Console.WriteLine("  Integrate " + coef
                                                     + " * X^" + a
                                                     + " * Y^" + b
                                                     + " * Z^" + c + "");
                    Console.WriteLine("");
                    Console.WriteLine("      Rule       QUAD           ERROR");
                    Console.WriteLine("");

                    int rule;
                    for (rule = 1; rule <= rule_num; rule++)
                    {
                        int order_num = NewtonCotesOpen.tetrahedron_nco_order_num(rule);

                        double[] xyztab = new double[dim_num * order_num];
                        double[] wtab = new double[order_num];

                        NewtonCotesOpen.tetrahedron_nco_rule(rule, order_num, ref xyztab, ref wtab);

                        double quad = 0.0;

                        int order;
                        for (order = 0; order < order_num; order++)
                        {
                            double x = xyztab[0 + order * dim_num];
                            double y = xyztab[1 + order * dim_num];
                            double z = xyztab[2 + order * dim_num];
                            //
                            //  Some tedious calculations to avoid 0**0 complaints.
                            //
                            double value = coef;

                            if (a != 0)
                            {
                                value *= Math.Pow(x, a);
                            }

                            if (b != 0)
                            {
                                value *= Math.Pow(y, b);
                            }

                            if (c != 0)
                            {
                                value *= Math.Pow(z, c);
                            }

                            quad += wtab[order] * value;
                        }

                        quad = volume * quad;

                        double exact = 1.0;
                        double err = Math.Abs(exact - quad);

                        Console.WriteLine("  " + rule.ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                               + "  " + quad.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                               + "  " + err.ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
                    }
                }
            }
        }
    }

    [Test]
    public static void test05()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST05 demonstrates REFERENCE_TO_PHYSICAL_T4.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    31 January 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int DIM_NUM = 3;
        int NODE_NUM = 4;

        int node;
        double[] node_xyz =
        {
            0.0, 0.0, 0.0,
            1.0, 0.0, 0.0,
            0.0, 1.0, 0.0,
            0.0, 0.0, 1.0
        };
        double[] node_xyz2 =
        {
            4.0, 5.0, 1.0,
            6.0, 5.0, 1.0,
            4.0, 8.0, 1.0,
            4.0, 5.0, 5.0
        };
        int order;

        Console.WriteLine("");
        Console.WriteLine("TEST06");
        Console.WriteLine("  REFERENCE_TO_PHYSICAL_T4 transforms a rule");
        Console.WriteLine("  on the unit (reference) tetrahedron to a rule on ");
        Console.WriteLine("  an arbitrary (physical) tetrahedron.");

        int rule = 3;

        int order_num = NewtonCotesOpen.tetrahedron_nco_order_num(rule);

        double[] xyz = new double[DIM_NUM * order_num];
        double[] xyz2 = new double[DIM_NUM * order_num];
        double[] w = new double[order_num];

        NewtonCotesOpen.tetrahedron_nco_rule(rule, order_num, ref xyz, ref w);
        //
        //  Here is the reference tetrahedron, and its rule.
        //
        Console.WriteLine("");
        Console.WriteLine("  The reference tetrahedron:");
        Console.WriteLine("");

        for (node = 0; node < NODE_NUM; node++)
        {
            Console.WriteLine("  " + (node + 1).ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                   + "  " + node_xyz[0 + node * DIM_NUM].ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + node_xyz[1 + node * DIM_NUM].ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + node_xyz[2 + node * DIM_NUM].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
        }

        double volume = Tetrahedron.tetrahedron_volume(node_xyz);

        Console.WriteLine("");
        Console.WriteLine("  Rule " + rule + " for reference tetrahedron");
        Console.WriteLine("  with volume = " + volume + "");
        Console.WriteLine("");
        Console.WriteLine("                X               Y               Z               W");
        Console.WriteLine("");

        for (order = 0; order < order_num; order++)
        {
            Console.WriteLine("  " + order.ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                   + "  " + xyz[0 + order * DIM_NUM].ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + xyz[1 + order * DIM_NUM].ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + xyz[2 + order * DIM_NUM].ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + w[order].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
        }

        //
        //  Transform the rule.
        //
        Tetrahedron.reference_to_physical_t4(node_xyz2, order_num, xyz, ref xyz2);
        //
        //  Here is the physical tetrahedron, and its transformed rule.
        //
        Console.WriteLine("");
        Console.WriteLine("  The physical tetrahedron:");
        Console.WriteLine("");

        for (node = 0; node < NODE_NUM; node++)
        {
            Console.WriteLine("  " + (node + 1).ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                   + "  " + node_xyz2[0 + node * DIM_NUM].ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + node_xyz2[1 + node * DIM_NUM].ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + node_xyz2[2 + node * DIM_NUM].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
        }

        double volume2 = Tetrahedron.tetrahedron_volume(node_xyz2);

        Console.WriteLine("");
        Console.WriteLine("  Rule " + rule + " for physical tetrahedron");
        Console.WriteLine("  with volume = " + volume2 + "");
        Console.WriteLine("");
        Console.WriteLine("                X               Y               Z               W");
        Console.WriteLine("");

        for (order = 0; order < order_num; order++)
        {
            Console.WriteLine("  " + order.ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                   + "  " + xyz2[0 + order * DIM_NUM].ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + xyz2[1 + order * DIM_NUM].ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + xyz2[2 + order * DIM_NUM].ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + w[order].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
        }
    }

    [Test]
    public static void test06()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST06 tests TETRAHEDRON_NCO_RULE.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    31 January 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        const int dim_num = 3;
        int o;
        int s;

        Console.WriteLine("");
        Console.WriteLine("TEST06");
        Console.WriteLine("  TETRAHEDRON_NCO_RULE returns the points and weights");
        Console.WriteLine("  of an NCO rule for the tetrahedron.");

        const int rule = 4;

        Console.WriteLine("");
        Console.WriteLine("  In this test, we simply print rule " + rule + "");

        int suborder_num = NewtonCotesOpen.tetrahedron_nco_suborder_num(rule);

        int[] suborder = NewtonCotesOpen.tetrahedron_nco_suborder(rule, suborder_num);

        double[] suborder_w = new double[suborder_num];
        double[] suborder_xyz = new double[4 * suborder_num];

        NewtonCotesOpen.tetrahedron_nco_subrule(rule, suborder_num, ref suborder_xyz, ref suborder_w);

        Console.WriteLine("");
        Console.WriteLine("  The compressed rule:");
        Console.WriteLine("");
        Console.WriteLine("  Number of suborders = " + suborder_num + "");
        Console.WriteLine("");
        Console.WriteLine("     S   Sub     Weight     Xsi1      Xsi2      Xsi3      Xsi4");
        Console.WriteLine("");

        for (s = 0; s < suborder_num; s++)
        {
            Console.WriteLine("  " + (s + 1).ToString(CultureInfo.InvariantCulture).PadLeft(4)
                                   + "  " + suborder[s].ToString(CultureInfo.InvariantCulture).PadLeft(4)
                                   + "  " + suborder_w[s].ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                   + "  " + suborder_xyz[0 + s * 4].ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                   + "  " + suborder_xyz[1 + s * 4].ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                   + "  " + suborder_xyz[2 + s * 4].ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                   + "  " + suborder_xyz[3 + s * 4].ToString("0.####").PadLeft(8) + "");
        }

        int order_num = NewtonCotesOpen.tetrahedron_nco_order_num(rule);

        double[] xyz = new double[dim_num * order_num];
        double[] w = new double[order_num];

        NewtonCotesOpen.tetrahedron_nco_rule(rule, order_num, ref xyz, ref w);

        Console.WriteLine("");
        Console.WriteLine("  The full rule:");
        Console.WriteLine("");
        Console.WriteLine("  Order = " + order_num + "");
        Console.WriteLine("");
        Console.WriteLine("     O    Weight        X           Y           Z");
        Console.WriteLine("");

        for (o = 0; o < order_num; o++)
        {
            Console.WriteLine("  " + (o + 1).ToString(CultureInfo.InvariantCulture).PadLeft(4)
                                   + "  " + w[o].ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                   + "  " + xyz[0 + o * 3].ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                   + "  " + xyz[1 + o * 3].ToString(CultureInfo.InvariantCulture).PadLeft(8)
                                   + "  " + xyz[2 + o * 3].ToString("0.####").PadLeft(8) + "");
        }
    }
    
}