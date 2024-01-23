using System;
using System.Globalization;
using Burkardt.PDFLib;
using Burkardt.Types;

namespace PDFLibTest;

internal static class Program
{
    private static void Main()
//****************************************************************************80
//
//  Purpose:
//
//    MAIN is the main program for PDFLIB_TEST.
//
//  Discussion:
//
//    PDFLIB_TEST tests the PDFLIB library.
//
//  Licensing:
//
//    This code is distributed under the GNU LGPL license.
//
//  Modified:
//
//    25 January 2018
//
//  Author:
//
//    John Burkardt
//
    {
        Console.WriteLine("");
        Console.WriteLine("PDFLIB_TEST");
        Console.WriteLine("  Test the PDFLIB library.");

        i4_binomial_pdf_test();
        i4_binomial_sample_test();
        i4_uniform_sample_test();
        r8_chi_sample_test();
        r8po_fa_test();
        r8vec_multinormal_pdf_test();

        Console.WriteLine("");
        Console.WriteLine("PDFLIB_TEST");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

}