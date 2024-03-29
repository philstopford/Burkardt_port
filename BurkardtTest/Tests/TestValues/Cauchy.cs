﻿using System;
using System.Globalization;
using Burkardt.Values;

namespace Burkardt_Tests.TestValues;

public static class CauchyTestValues
{
    [Test]
    public static void cauchy_cdf_values_test ( )
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    CAUCHY_CDF_VALUES_TEST tests CAUCHY_CDF_VALUES.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    02 March 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        double fx = 0;
        double mu = 0;
        double sigma = 0;
        double x = 0;
        Console.WriteLine("");
        Console.WriteLine("CAUCHY_CDF_VALUES_TEST:");
        Console.WriteLine("  CAUCHY_CDF_VALUES returns values of ");
        Console.WriteLine("  the Cauchy Cumulative Density Function.");
        Console.WriteLine("");
        Console.WriteLine("     Mu      Sigma        X   CDF(X)");
        Console.WriteLine("");
        int n_data = 0;
        for (;;)
        {
            Cauchy.cauchy_cdf_values(ref n_data, ref mu, ref sigma, ref x, ref fx);
            if (n_data == 0)
            {
                break;
            }

            Console.WriteLine("  "
                              + mu.ToString(CultureInfo.InvariantCulture).PadLeft(8) + "  "
                              + sigma.ToString(CultureInfo.InvariantCulture).PadLeft(8) + "  "
                              + x.ToString(CultureInfo.InvariantCulture).PadLeft(8) + "  "
                              + fx.ToString("0.################").PadLeft(24) + "");
        }
    }

}