using System;
using System.Collections.Generic;
using System.IO;
using Burkardt.Edge;
using Burkardt.Types;

namespace EdgeTest;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    EDGE_TEST tests the EDGE library.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    21 September 2014
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("EDGE_TEST");
        Console.WriteLine("  Test the EDGE library.");

        test01();
        test02();
        test03();
        test035();
        test036();
        test037();
        test04();
        Console.WriteLine("");
        Console.WriteLine("EDGE_TEST");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}