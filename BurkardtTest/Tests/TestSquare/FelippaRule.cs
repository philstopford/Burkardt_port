using Burkardt.Square;

namespace Burkardt_Tests.TestSquare;

public class FelippaRuleTest
{
    [Test]
    public static void test1()
    {
        int degree_max = 4;
        FelippaRule.square_monomial_test(degree_max);
    }

    [Test]
    public static void test2()
    {
        int degree_max = 5;
        FelippaRule.square_quad_test(degree_max);
    }

}