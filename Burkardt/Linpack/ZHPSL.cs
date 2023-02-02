﻿using System;
using System.Numerics;
using Burkardt.BLAS;

namespace Burkardt.Linpack;

public static class ZHPSL
{
    public static void zhpsl(Complex[] ap, int n, int[] ipvt, ref Complex[] b)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    ZHPSL solves a complex hermitian system factored by ZHPFA.
        //
        //  Discussion:
        //
        //    A division by zero may occur if ZHPCO set RCOND to 0.0
        //    or ZHPFA set INFO nonzero.
        //
        //    To compute
        //
        //      inverse ( A ) * C
        //
        //    where C is a matrix with P columns
        //
        //      call zhpfa(ap,n,ipvt,info)
        //
        //      if ( info == 0 )
        //        do j = 1, p
        //          call zhpsl(ap,n,ipvt,c(1,j))
        //        end do
        //      }
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
        //    Input, Complex AP[N*(N+1)/2], the output from ZHPFA.
        //
        //    Input, int N, the order of the matrix.
        //
        //    Input, int IPVT[N], the pivot vector from ZHPFA.
        //
        //    Input/output, Complex B[N].  On input, the right hand side.
        //    On output, the solution.
        //
    {
        int kp;
        Complex t;
        //
        //  Loop backward applying the transformations and inverse ( D ) to B.
        //
        int k = n;
        int ik = n * (n - 1) / 2;

        while (0 < k)
        {
            int kk = ik + k;
            switch (ipvt[k - 1])
            {
                //
                //  1 x 1 pivot block.
                //
                case >= 0:
                {
                    if (k != 1)
                    {
                        kp = ipvt[k - 1];

                        if (kp != k)
                        {
                            t = b[k - 1];
                            b[k - 1] = b[kp - 1];
                            b[kp - 1] = t;
                        }

                        BLAS1Z.zaxpy(k - 1, b[k - 1], ap, 1, ref b, 1, xIndex: +ik);
                    }

                    //
                    //  Apply D inverse.
                    //
                    b[k - 1] /= ap[kk - 1];
                    k -= 1;
                    ik -= k;
                    break;
                }
                default:
                {
                    //
                    //  2 x 2 pivot block.
                    //
                    int ikm1 = ik - (k - 1);

                    if (k != 2)
                    {
                        kp = Math.Abs(ipvt[k - 1]);

                        if (kp != k - 1)
                        {
                            t = b[k - 2];
                            b[k - 2] = b[kp - 1];
                            b[kp - 1] = t;
                        }

                        BLAS1Z.zaxpy(k - 2, b[k - 1], ap, 1, ref b, 1, xIndex: +ik);
                        BLAS1Z.zaxpy(k - 2, b[k - 2], ap, 1, ref b, 1, xIndex: +ikm1);
                    }

                    //
                    //  Apply D inverse.
                    //
                    int km1k = ik + k - 1;
                    kk = ik + k;
                    Complex ak = ap[kk - 1] / Complex.Conjugate(ap[km1k - 1]);
                    int km1km1 = ikm1 + k - 1;
                    Complex akm1 = ap[km1km1 - 1] / ap[km1k - 1];
                    Complex bk = b[k - 1] / Complex.Conjugate(ap[km1k - 1]);
                    Complex bkm1 = b[k - 2] / ap[km1k - 1];
                    Complex denom = ak * akm1 - new Complex(1.0, 0.0);
                    b[k - 1] = (akm1 * bk - bkm1) / denom;
                    b[k - 2] = (ak * bkm1 - bk) / denom;
                    k -= 2;
                    ik = ik - (k + 1) - k;
                    break;
                }
            }
        }

        //
        //  Loop forward applying the transformations.
        //
        k = 1;
        ik = 0;

        while (k <= n)
        {
            switch (ipvt[k - 1])
            {
                //
                //  1 x 1 pivot block.
                //
                case >= 0:
                {
                    if (k != 1)
                    {
                        b[k - 1] += BLAS1Z.zdotc(k - 1, ap, 1, b, 1, xIndex: +ik);
                        kp = ipvt[k - 1];

                        if (kp != k)
                        {
                            t = b[k - 1];
                            b[k - 1] = b[kp - 1];
                            b[kp - 1] = t;
                        }
                    }

                    ik += k;
                    k += 1;
                    break;
                }
                //
                default:
                {
                    if (k != 1)
                    {
                        b[k - 1] += BLAS1Z.zdotc(k - 1, ap, 1, b, 1, xIndex: +ik);
                        int ikp1 = ik + k;
                        b[k] += BLAS1Z.zdotc(k - 1, ap, 1, b, 1, xIndex: +ikp1);
                        kp = Math.Abs(ipvt[k - 1]);

                        if (kp != k)
                        {
                            t = b[k - 1];
                            b[k - 1] = b[kp - 1];
                            b[kp - 1] = t;
                        }
                    }

                    ik = ik + k + k + 1;
                    k += 2;
                    break;
                }
            }
        }
    }

}