﻿using System;

namespace Burkardt.CompressedRow;

public static class ILUCR
{
    public static void ilu_cr(int n, int nz_num, int[] ia, int[] ja, double[] a, int[] ua,
            ref double[] l )

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    ILU_CR computes the incomplete LU factorization of a matrix.
        //
        //  Discussion:
        //
        //    The matrix A is assumed to be stored in compressed row format.  Only
        //    the nonzero entries of A are stored.  The vector JA stores the
        //    column index of the nonzero value.  The nonzero values are sorted
        //    by row, and the compressed row vector IA then has the property that
        //    the entries in A and JA that correspond to row I occur in indices
        //    IA[I] through IA[I+1]-1.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    25 July 2007
        //
        //  Author:
        //
        //    Original C version by Lili Ju.
        //    C++ version by John Burkardt.
        //
        //  Parameters:
        //
        //    Input, int N, the order of the system.
        //
        //    Input, int NZ_NUM, the number of nonzeros.
        //
        //    Input, int IA[N+1], JA[NZ_NUM], the row and column indices
        //    of the matrix values.  The row vector has been compressed.
        //
        //    Input, double A[NZ_NUM], the matrix values.
        //
        //    Input, int UA[N], the index of the diagonal element of each row.
        //
        //    Output, double L[NZ_NUM], the ILU factorization of A.
        //
    {
        int i;
        int k;

        int[] iw = new int[n];
        //
        //  Copy A.
        //
        for (k = 0; k < nz_num; k++)
        {
            l[k % l.Length] = a[k % a.Length];
        }

        for (i = 0; i < n; i++)
        {
            //
            //  IW points to the nonzero entries in row I.
            //
            int j;
            for (j = 0; j < n; j++)
            {
                iw[j] = -1;
            }

            for (k = ia[i % ia.Length]; k <= ia[(i + 1) % ia.Length] - 1; k++)
            {
                iw[ja[k % ja.Length] % iw.Length] = k;
            }

            j = ia[i % ia.Length];
            int jrow;
            do
            {
                jrow = ja[j % ja.Length];
                if (i <= jrow)
                {
                    break;
                }

                double tl = l[j % l.Length] * l[ua[jrow % ua.Length] % l.Length];
                l[j % l.Length] = tl;
                int jj;
                for (jj = ua[jrow % ua.Length] + 1; jj <= ia[(jrow + 1) % ia.Length] - 1; jj++)
                {
                    int jw = iw[ja[jj % ja.Length] % iw.Length];
                    if (jw != -1)
                    {
                        l[jw % l.Length] -= tl * l[jj % l.Length];
                    }
                }

                j += 1;
            } while (j <= ia[(i + 1) % ia.Length] - 1);

            ua[i % ua.Length] = j;

            if (jrow != i)
            {
                Console.WriteLine("");
                Console.WriteLine("ILU_CR - Fatal error!");
                Console.WriteLine("  JROW != I");
                Console.WriteLine("  JROW = " + jrow + "");
                Console.WriteLine("  I    = " + i + "");
                return;
            }

            switch (l[j % l.Length])
            {
                case 0.0:
                    Console.WriteLine("");
                    Console.WriteLine("ILU_CR - Fatal error!");
                    Console.WriteLine("  Zero pivot on step I = " + i + "");
                    Console.WriteLine("  L[" + j + "] = 0.0");
                    return;
                default:
                    l[j % l.Length] = 1.0 / l[j % l.Length];
                    break;
            }
        }

        for (k = 0; k < n; k++)
        {
            l[ua[k % ua.Length] % l.Length] = 1.0 / l[ua[k % ua.Length] % l.Length];
        }
    }
}