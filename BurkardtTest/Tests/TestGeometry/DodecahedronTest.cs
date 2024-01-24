﻿using System;
using Burkardt.Dodecahedron;

namespace Burkardt_Tests.TestGeometry;

public static class DodecahedronTest
{
    [Test]
    public static void test0236 ( )

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST0236 tests DODEC_SIZE_3D, DODEC_SHAPE_3D, SHAPE_PRINT_3D.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    22 July 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        const int DIM_NUM = 3;

        int edge_num = 0;
        int face_num = 0;
        int face_order_max = 0;
        int point_num = 0;

        Console.WriteLine("");
        Console.WriteLine("TEST0236");
        Console.WriteLine("  For the dodecahedron,");
        Console.WriteLine("  DODEC_SIZE_3D returns dimension information;");
        Console.WriteLine("  DODEC_SHAPE_3D returns face and order information.");
        Console.WriteLine("  SHAPE_PRINT_3D prints this information.");
        //
        //  Get the sizes.
        //
        Geometry.dodec_size_3d ( ref point_num, ref edge_num, ref face_num, ref face_order_max );

        Console.WriteLine("");
        Console.WriteLine("    Number of vertices: " + point_num + "");
        Console.WriteLine("    Number of edges   : " + edge_num + "");
        Console.WriteLine("    Number of faces   : " + face_num + "");
        Console.WriteLine("    Maximum face order: " + face_order_max + "");
        //
        //  Make room for the data.
        //
        int[] face_order = new int[face_num];
        int[] face_point = new int[face_order_max*face_num];
        double[] point_coord = new double[DIM_NUM*point_num];
        //
        //  Get the data.
        //
        Geometry.dodec_shape_3d ( point_num, face_num, face_order_max, ref point_coord,
            ref face_order, ref face_point );
        //
        //  Print the data.
        //
        Burkardt.Geometry.Shape.shape_print_3d ( point_num, face_num, face_order_max,
            point_coord, face_order, face_point );

    }

}