﻿using System;
using System.Numerics;
using Burkardt.BLAS;
using Burkardt.Types;

namespace Burkardt.Linpack;

public static class ZSIFA
{
    public static int zsifa(ref Complex[] a, int lda, int n, ref int[] ipvt)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    ZSIFA factors a complex symmetric matrix.
        //
        //  Discussion:
        //
        //    The factorization is accomplished by elimination with symmetric pivoting.
        //
        //    To solve A*X = B, follow ZSIFA by ZSISL.
        //
        //    To compute inverse(A)*C, follow ZSIFA by ZSISL.
        //
        //    To compute determinant(A), follow ZSIFA by ZSIDI.
        //
        //    To compute inverse(A), follow ZSIFA by ZSIDI.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    21 May 2006
        //
        //  Author:
        //
        //    C++ version by John Burkardt
        //
        //  Reference:
        //
        //    Jack Dongarra, Cleve Moler, Jim Bunch and Pete Stewart,
        //    LINPACK User's Guide,
        //    SIAM, (Society for Industrial and Applied Mathematics),
        //    3600 University City Science Center,
        //    Philadelphia, PA, 19104-2688.
        //
        //  Parameters:
        //
        //    Input/output, Complex A[LDA*N]; on input, the symmetric matrix to be
        //    factored.  On output, a block diagonal matrix and the multipliers which
        //    were used to obtain it.  The factorization can be written A = U*D*U'
        //    where U is a product of permutation and unit upper triangular matrices,
        //    U' is the transpose of U, and D is block diagonal with 1 by 1 and 2 by 2
        //    blocks.  Only the diagonal and upper triangle are used.
        //
        //    Input, int LDA, the leading dimension of A.
        //
        //    Input, int N, the order of the matrix.
        //
        //    Output, int IPVT[N], the pivot indices.
        //
        //    Output, int ZSIFA.
        //    0, normal value.
        //    K, if the K-th pivot block is singular.  This is not an error condition
        //    for this subroutine, but it does indicate that ZSISL or ZSIDI may
        //    divide by zero if called.
        //
    {
        //
        //  Initialize.
        //
        //  ALPHA is used in choosing pivot block size.
        //
        double alpha = (1.0 + Math.Sqrt(17.0)) / 8.0;

        int info = 0;
        //
        //  Main loop on K, which goes from N to 1.
        //
        int k = n;

        for (;;)
        {
            //
            //  Leave the loop if K = 0 or K = 1.
            //
            if (k == 0)
            {
                break;
            }

            if (k == 1)
            {
                ipvt[0] = 1;
                if (typeMethods.zabs1(a[0 + 0 * lda]) == 0.0)
                {
                    info = 1;
                }

                break;
            }

            //
            //  This section of code determines the kind of
            //  elimination to be performed.  When it is completed,
            //  KSTEP will be set to the size of the pivot block, and
            //  SWAP will be set to TRUE if an interchange is
            //  required.
            //
            int km1 = k - 1;
            double absakk = typeMethods.zabs1(a[k - 1 + (k - 1) * lda]);
            //
            //  Determine the largest off-diagonal element in column K.
            //
            int imax = BLAS1Z.izamax(k - 1, a, 1, index: + 0 + (k - 1) * lda);
            double colmax = typeMethods.zabs1(a[imax - 1 + (k - 1) * lda]);

            int kstep;
            bool swap;
            int j;
            if (alpha * colmax < absakk)
            {
                kstep = 1;
                swap = false;
            }
            //
            //  Determine the largest off-diagonal element in row IMAX.
            //
            else
            {
                double rowmax = 0.0;

                for (j = imax + 1; j <= k; j++)
                {
                    rowmax = Math.Max(rowmax, typeMethods.zabs1(a[imax - 1 + (j - 1) * lda]));
                }

                if (imax != 1)
                {
                    int jmax = BLAS1Z.izamax(imax - 1, a, 1, index: + 0 + (imax - 1) * lda);
                    rowmax = Math.Max(rowmax, typeMethods.zabs1(a[jmax - 1 + (imax - 1) * lda]));
                }

                if (alpha * rowmax <= typeMethods.zabs1(a[imax - 1 + (imax - 1) * lda]))
                {
                    kstep = 1;
                    swap = true;
                }
                else if (alpha * colmax * (colmax / rowmax) <= absakk)
                {
                    kstep = 1;
                    swap = false;
                }
                else
                {
                    kstep = 2;
                    swap = imax != km1;
                }
            }

            switch (Math.Max(absakk, colmax))
            {
                //
                //  Column K is zero.  Set INFO and iterate the loop.
                //
                case 0.0:
                    ipvt[k - 1] = k;
                    info = k;
                    k -= kstep;
                    continue;
            }

            Complex mulk;
            Complex t;
            int jj;
            if (kstep != 2)
            {
                switch (swap)
                {
                    //
                    //  1 x 1 pivot block.
                    //
                    //  Perform an interchange.
                    //
                    case true:
                    {
                        BLAS1Z.zswap(imax, ref a, 1, ref a, 1, xIndex: + 0 + (imax - 1) * lda, yIndex: + 0 + (k - 1) * lda);

                        for (jj = imax; jj <= k; jj++)
                        {
                            j = k + imax - jj;

                            t = a[j - 1 + (k - 1) * lda];
                            a[j - 1 + (k - 1) * lda] = a[imax - 1 + (j - 1) * lda];
                            a[imax - 1 + (j - 1) * lda] = t;
                        }

                        break;
                    }
                }

                //
                //  Perform the elimination.
                //
                for (jj = 1; jj <= km1; jj++)
                {
                    j = k - jj;
                    mulk = -a[j - 1 + (k - 1) * lda] / a[k - 1 + (k - 1) * lda];
                    t = mulk;
                    BLAS1Z.zaxpy(j, t, a, 1, ref a, 1, xIndex: + 0 + (k - 1) * lda, yIndex: + 0 + (j - 1) * lda);
                    a[j - 1 + (k - 1) * lda] = mulk;
                }

                ipvt[k - 1] = swap switch
                {
                    //
                    //  Set the pivot array.
                    //
                    true => imax,
                    _ => k
                };
            }
            //
            //  2 x 2 pivot block.
            //
            else
            {
                switch (swap)
                {
                    case true:
                    {
                        BLAS1Z.zswap(imax, ref a, 1, ref a, 1, xIndex: + 0 + (imax - 1) * lda, yIndex: + 0 + (k - 2) * lda);

                        for (jj = imax; jj <= km1; jj++)
                        {
                            j = km1 + imax - jj;

                            t = a[j - 1 + (k - 2) * lda];
                            a[j - 1 + (k - 2) * lda] = a[imax - 1 + (j - 1) * lda];
                            a[imax - 1 + (j - 1) * lda] = t;
                        }

                        t = a[k - 2 + (k - 1) * lda];
                        a[k - 2 + (k - 1) * lda] = a[imax - 1 + (k - 1) * lda];
                        a[imax - 1 + (k - 1) * lda] = t;
                        break;
                    }
                }

                //
                //  Perform the elimination.
                //
                int km2 = k - 2;

                if (km2 != 0)
                {
                    Complex ak = a[k - 1 + (k - 1) * lda] / a[k - 2 + (k - 1) * lda];
                    Complex akm1 = a[k - 2 + (k - 2) * lda] / a[k - 2 + (k - 1) * lda];
                    Complex denom = new Complex(1.0, 0.0) - ak * akm1;

                    for (jj = 1; jj <= km2; jj++)
                    {
                        j = km1 - jj;
                        Complex bk = a[j - 1 + (k - 1) * lda] / a[k - 2 + (k - 1) * lda];
                        Complex bkm1 = a[j - 1 + (k - 2) * lda] / a[k - 2 + (k - 1) * lda];
                        mulk = (akm1 * bk - bkm1) / denom;
                        Complex mulkm1 = (ak * bkm1 - bk) / denom;
                        t = mulk;
                        BLAS1Z.zaxpy(j, t, a, 1, ref a, 1, xIndex: + 0 + (k - 1) * lda, yIndex: + 0 + (j - 1) * lda);
                        t = mulkm1;
                        BLAS1Z.zaxpy(j, t, a, 1, ref a, 1, xIndex: + 0 + (k - 2) * lda, yIndex: + 0 + (j - 1) * lda);
                        a[j - 1 + (k - 1) * lda] = mulk;
                        a[j - 1 + (k - 2) * lda] = mulkm1;
                    }
                }

                ipvt[k - 1] = swap switch
                {
                    //
                    //  Set the pivot array.
                    //
                    true => -imax,
                    _ => 1 - k
                };

                ipvt[k - 2] = ipvt[k - 1];
            }

            k -= kstep;
        }

        return info;
    }

}