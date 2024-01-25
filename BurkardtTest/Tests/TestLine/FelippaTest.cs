using Burkardt.LineNS;

namespace Burkardt_Tests.TestLine;

public class FelippaTest
{
    [Test]
    public static void test1()
    {
        int degree_max = 4;
        Felippa.line_monomial_test(degree_max);
    }

    [Test]
    public static void test2()
    {
        int degree_max = 10;
        Felippa.line_quad_test(degree_max);

    }
}