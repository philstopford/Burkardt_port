using Burkardt.Types;

namespace Burkhardt_Tests.TestTriangle;

public class SVG
{
    [Test]
    public static void test01()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 calls TRIANGLE_SVG to plot a triangle and some points.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    21 April 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double[] p =
        {
            0.333333333333333, 0.333333333333333,
            0.479308067841923, 0.260345966079038,
            0.260345966079038, 0.479308067841923,
            0.260345966079038, 0.260345966079038,
            0.869739794195568, 0.065130102902216,
            0.065130102902216, 0.869739794195568,
            0.065130102902216, 0.065130102902216,
            0.638444188569809, 0.312865496004875,
            0.638444188569809, 0.048690315425316,
            0.312865496004875, 0.638444188569809,
            0.312865496004875, 0.048690315425316,
            0.048690315425316, 0.638444188569809,
            0.048690315425316, 0.312865496004875
        };
        const int p_num = 13;
        const string plot_filename = "test01.svg";
        double[] t =
        {
            0.0, 0.0,
            1.0, 0.0,
            0.0, 1.0
        };

        typeMethods.triangle_svg(plot_filename, t, p_num, p);
    }
    
}