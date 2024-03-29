using Burkardt.AppliedStatistics;

namespace Burkardt_Tests.TestAppliedStatisticsAlgorithms;

public class ASA299
{
    [Test]
    public static void test01 ( )
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 tests SIMPLEX_LATTICE_POINT_NEXT.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    10 January 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        const int N = 4;

        const int t = 4;
        int[] x = new int[N];

        Console.WriteLine("");
        Console.WriteLine("TEST01");
        Console.WriteLine("  SIMPLEX_LATTICE_POINT_NEXT generates lattice points");
        Console.WriteLine("  in the simplex");
        Console.WriteLine("    0 <= X");
        Console.WriteLine("    sum ( X(1:N) ) <= T");
        Console.WriteLine("  Here N = " + N + "");
        Console.WriteLine("  and T =  " + t + "");
        Console.WriteLine("");
        Console.WriteLine("     Index        X(1)      X(2)      X(3)      X(4)");
        Console.WriteLine("");

        bool more = false;

        int i = 0;

        for ( ; ; )
        {
            Algorithms.simplex_lattice_point_next ( N, t, ref more, ref x );

            i += 1;

            string cout = "  " + i.ToString().PadLeft(8);
            cout += "  ";
            int j;
            for ( j = 0; j < N; j++ )
            {
                cout += x[j].ToString().PadLeft(8);
            }
            Console.WriteLine(cout);

            if ( !more )
            {
                break;
            }
        }
    }

}