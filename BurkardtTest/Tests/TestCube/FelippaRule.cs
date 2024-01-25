using Burkardt.Cube;

namespace Burkardt_Tests.TestCube;

public class FelippaRuleTest
{
    [Test]
    public static void test1()
    {
        int degree_max = 4;
        Integrals.cube_monomial_test(degree_max);
    }

    [Test]
    public static void test2()
    {
        int degree_max = 6;
        QuadratureRule.cube_quad_test(degree_max);

    }
}