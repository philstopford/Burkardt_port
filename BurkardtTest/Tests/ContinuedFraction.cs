using Burkardt;

namespace Burkardt_Tests;

public class ContinuedFractionTest
{
    public static void test1()
    {
        ContinuedFraction.i4cf_evaluate_test();
    }
    public static void test2()
    {
        ContinuedFraction.i4scf_evaluate_test ( );
    }
    public static void test3()
    {
        ContinuedFraction.i8cf_evaluate_test ( );
    }
    public static void test4()
    {
        ContinuedFraction.i8scf_evaluate_test ( );
    }
    public static void test5()
    {
        ContinuedFraction.r8_to_i4scf_test ( );
    }
    public static void test6()
    {
        ContinuedFraction.r8_to_i8scf_test ( );
    }
    public static void test7()
    {
        ContinuedFraction.r8cf_evaluate_test ( );
    }
    public static void test8()
    {
        ContinuedFraction.r8scf_evaluate_test ( );
    }
    
}