using Burkardt.AppliedStatistics;
using Burkardt.Types;

namespace Burkardt_Tests.TestAppliedStatisticsAlgorithms;

public class ASA159
{
    [Test]
    public static void test01 ( )
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 tests RCONT2.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    10 March 2009
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        const int M = 5;
        const int N = 5;

        int[] a = new int[M*N];
        int[] c = { 2, 2, 2, 2, 1 };
        int ierror = 0;
        bool key = false;
        const int ntest = 10;
        int[] r = { 3, 2, 2, 1, 1 };

        int seed = 123456789;

        Console.WriteLine("");
        Console.WriteLine("TEST01");
        Console.WriteLine("  RCONT2 constructs a random matrix with");
        Console.WriteLine("  given row and column sums.");

        typeMethods.i4vec_print ( M, r, "  The rowsum vector:" );
        typeMethods.i4vec_print ( N, c, "  The columnsum vector:" );

        Algorithms.RCont2Data data = new();

        for (int i = 1; i <= ntest; i++ )
        {
            Algorithms.rcont2 (ref data, M, N, r, c, ref key, ref seed, ref a, ref ierror );

            if ( ierror != 0 )
            {
                Console.WriteLine("");
                Console.WriteLine("  RCONT2 returned error flag IERROR = " + ierror + "");
                return;
            }

            typeMethods.i4mat_print ( M, N, a, "  The rowcolsum matrix:" );
        }
    }

}