using System;
using Burkardt.Wedge;

namespace Burkhardt_Tests.GeometryTest;

public static class WedgeTest
{
    [Test]
    public static void wedge01_volume_test ( )

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    WEDGE01_VOLUME_TEST tests WEDGE01_VOLUME.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    18 January 2018
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("WEDGE01_VOLUME_TEST");
        Console.WriteLine("  WEDGE01_VOLUME returns the volume of the unit wedge.");

        double volume = Geometry.wedge01_volume ( );

        Console.WriteLine("");
        Console.WriteLine("  Volume = " + volume + "");
    }
}