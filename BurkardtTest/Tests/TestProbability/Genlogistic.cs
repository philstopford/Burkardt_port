﻿using System;
using System.Globalization;
using Burkardt.Probability;
using Burkardt.Types;

namespace Burkardt_Tests.TestProbability;

internal static partial class TestProbability
{
    [Test]
    public static void genlogistic_cdf_test()

//****************************************************************************80
//
//  Purpose:
//
//    GENLOGISTIC_CDF_TEST tests GENLOGISTIC_CDF.
//
//  Licensing:
//
//    This code is distributed under the GNU LGPL license.
//
//  Modified:
//
//    03 April 2016
//
//  Author:
//
//    John Burkardt
//
    {
        int i;
        int seed = 123456789;

        Console.WriteLine("");
        Console.WriteLine("GENLOGISTIC_CDF_TEST");
        Console.WriteLine("  GENLOGISTIC_CDF evaluates the Genlogistic CDF;");
        Console.WriteLine("  GENLOGISTIC_CDF_INV inverts the Genlogistic CDF.");
        Console.WriteLine("  GENLOGISTIC_PDF evaluates the Genlogistic PDF;");

        const double a = 1.0;
        const double b = 2.0;
        const double c = 3.0;

        Console.WriteLine("");
        Console.WriteLine("  PDF parameter A =      " + a + "");
        Console.WriteLine("  PDF parameter B =      " + b + "");
        Console.WriteLine("  PDF parameter C =      " + c + "");

        if (!Genlogistic.genlogistic_check(a, b, c))
        {
            Console.WriteLine("");
            Console.WriteLine("GENLOGISTIC_CDF_TEST - Fatal error!");
            Console.WriteLine("  The parameters are not legal.");
            return;
        }

        Console.WriteLine("");
        Console.WriteLine("       X            PDF           CDF            CDF_INV");
        Console.WriteLine("");

        for (i = 1; i <= 10; i++)
        {
            double x = Genlogistic.genlogistic_sample(a, b, c, ref seed);
            double pdf = Genlogistic.genlogistic_pdf(x, a, b, c);
            double cdf = Genlogistic.genlogistic_cdf(x, a, b, c);
            double x2 = Genlogistic.genlogistic_cdf_inv(cdf, a, b, c);

            Console.WriteLine("  "
                              + x.ToString(CultureInfo.InvariantCulture).PadLeft(12) + "  "
                              + pdf.ToString(CultureInfo.InvariantCulture).PadLeft(12) + "  "
                              + cdf.ToString(CultureInfo.InvariantCulture).PadLeft(12) + "  "
                              + x2.ToString(CultureInfo.InvariantCulture).PadLeft(12) + "");
        }
    }

    [Test]
    public static void genlogistic_sample_test()

//****************************************************************************80
//
//  Purpose:
//
//    GENLOGISTIC_SAMPLE_TEST tests GENLOGISTIC_SAMPLE.
//
//  Licensing:
//
//    This code is distributed under the GNU LGPL license.
//
//  Modified:
//
//    27 January 2007
//
//  Author:
//
//    John Burkardt
//
    {
        const int SAMPLE_NUM = 1000;

        int i;
        int seed = 123456789;
        double[] x = new double [SAMPLE_NUM];

        Console.WriteLine("");
        Console.WriteLine("GENLOGISTIC_SAMPLE_TEST");
        Console.WriteLine("  GENLOGISTIC_MEAN computes the Genlogistic mean;");
        Console.WriteLine("  GENLOGISTIC_SAMPLE samples the Genlogistic distribution;");
        Console.WriteLine("  GENLOGISTIC_VARIANCE computes the Genlogistic variance;");

        const double a = 1.0;
        const double b = 2.0;
        const double c = 3.0;

        Console.WriteLine("");
        Console.WriteLine("  PDF parameter A =      " + a + "");
        Console.WriteLine("  PDF parameter B =      " + b + "");
        Console.WriteLine("  PDF parameter C =      " + c + "");

        if (!Genlogistic.genlogistic_check(a, b, c))
        {
            Console.WriteLine("");
            Console.WriteLine("GENLOGISTIC_SAMPLE_TEST - Fatal error!");
            Console.WriteLine("  The parameters are not legal.");
            return;
        }

        double mean = Genlogistic.genlogistic_mean(a, b, c);
        double variance = Genlogistic.genlogistic_variance(a, b, c);

        Console.WriteLine("");
        Console.WriteLine("  PDF mean =     " + mean + "");
        Console.WriteLine("  PDF variance = " + variance + "");

        for (i = 0; i < SAMPLE_NUM; i++)
        {
            x[i] = Genlogistic.genlogistic_sample(a, b, c, ref seed);
        }

        mean = typeMethods.r8vec_mean(SAMPLE_NUM, x);
        variance = typeMethods.r8vec_variance(SAMPLE_NUM, x);
        double xmax = typeMethods.r8vec_max(SAMPLE_NUM, x);
        double xmin = typeMethods.r8vec_min(SAMPLE_NUM, x);

        Console.WriteLine("");
        Console.WriteLine("  Sample size =     " + SAMPLE_NUM + "");
        Console.WriteLine("  Sample mean =     " + mean + "");
        Console.WriteLine("  Sample variance = " + variance + "");
        Console.WriteLine("  Sample maximum =  " + xmax + "");
        Console.WriteLine("  Sample minimum =  " + xmin + "");

    }

}