﻿using System;
using Burkardt.BLAS;
using Burkardt.Types;

namespace Burkardt.SolveNS;

public static class QRSolve
{
    public static void qform(int m, int n, ref double[] q, int ldq, int qIndex = 0)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    qform() constructs the standard form of Q from its factored form.
        //
        //  Discussion:
        //
        //    This function proceeds from the computed QR factorization of
        //    an M by N matrix A to accumulate the M by M orthogonal matrix
        //    Q from its factored form.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    02 January 2018
        //
        //  Author:
        //
        //    Original FORTRAN77 version by Jorge More, Burt Garbow, Ken Hillstrom.
        //    C++ version by John Burkardt.
        //
        //  Reference:
        //
        //    Jorge More, Burton Garbow, Kenneth Hillstrom,
        //    User Guide for MINPACK-1,
        //    Technical Report ANL-80-74,
        //    Argonne National Laboratory, 1980.
        //
        //  Parameters:
        //
        //    Input, int M, the number of rows of A, and the order of Q.
        //
        //    Input, int N, the number of columns of A.
        //
        //    Input/output, double Q[LDQ*N].  On input, the full lower trapezoid in
        //    the first min(M,N) columns of Q contains the factored form.
        //    On output Q has been accumulated into a square matrix.
        //
        //    Input, int LDQ, the leading dimension of the array Q.
        //
    {
        int i;
        int j;
        int k;
        //
        //  Zero out the upper triangle of Q in the first min(M,N) columns.
        //
        int minmn = Math.Min(m, n);

        for (j = 1; j < minmn; j++)
        {
            for (i = 0; i <= j - 1; i++)
            {
                q[(qIndex + i + j * ldq) % q.Length] = 0.0;
            }
        }

        //
        //  Initialize remaining columns to those of the identity matrix.
        //
        for (j = n; j < m; j++)
        {
            for (i = 0; i < m; i++)
            {
                q[(qIndex + i + j * ldq) % q.Length] = 0.0;
            }

            q[(qIndex + j + j * ldq) % q.Length] = 1.0;
        }

        //
        //  Accumulate Q from its factored form.
        //
        double[] wa = new double[m];

        for (k = minmn - 1; 0 <= k; k--)
        {
            for (i = k; i < m; i++)
            {
                wa[i % wa.Length] = q[(qIndex + i + k * ldq) % q.Length];
                q[(qIndex + i + k * ldq) % q.Length] = 0.0;
            }

            q[(qIndex + k + k * ldq) % q.Length] = 1.0;

            if (wa[k % wa.Length] == 0.0)
            {
                continue;
            }

            for (j = k; j < m; j++)
            {
                double sum = 0.0;
                for (i = k; i < m; i++)
                {
                    sum += q[(qIndex + i + j * ldq) % q.Length] * wa[i % wa.Length];
                }

                double temp = sum / wa[k % wa.Length];
                for (i = k; i < m; i++)
                {
                    q[(qIndex + i + j * ldq) % q.Length] -= temp * wa[i % wa.Length];
                }
            }
        }
    }

    public static void qrfac ( int m, int n, ref double[] a, int lda, bool pivot, ref int[] ipvt,
            ref int lipvt, ref double[] rdiag, ref double[] acnorm, int aIndex = 0, int rdiagIndex = 0, int acnormIndex = 0 )

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    qrfac() computes the QR factorization of an M by N matrix.
        //
        //  Discussion:
        //
        //    This function uses Householder transformations with optional column
        //    pivoting to compute a QR factorization of the M by N matrix A. 
        //
        //    That is, QRFAC determines an orthogonal
        //    matrix Q, a permutation matrix P, and an upper trapezoidal
        //    matrix R with diagonal elements of nonincreasing magnitude,
        //    such that A*P = Q*R. 
        //
        //    The Householder transformation for
        //    column k, k = 1,2,...,min(m,n), is of the form
        //
        //      i - (1/u(k))*u*u'
        //
        //    where U has zeros in the first K-1 positions. 
        //
        //    The form of this transformation and the method of pivoting first
        //    appeared in the corresponding LINPACK function.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    02 January 2017
        //
        //  Author:
        //
        //    Original FORTRAN77 version by Jorge More, Burt Garbow, Ken Hillstrom.
        //    C++ version by John Burkardt.
        //
        //  Reference:
        //
        //    Jorge More, Burton Garbow, Kenneth Hillstrom,
        //    User Guide for MINPACK-1,
        //    Technical Report ANL-80-74,
        //    Argonne National Laboratory, 1980.
        //
        //  Parameters:
        //
        //    Input, int M, the number of rows of A.
        //
        //    Input, int N, the number of columns of A.
        //
        //    Input/output, double A[M*N].  On input, the matrix for which the QR 
        //    factorization is to be computed.  On output, the strict upper trapezoidal 
        //    part contains the strict upper trapezoidal part of the R factor, and 
        //    the lower trapezoidal part contains a factored form of Q, the non-trivial
        //    elements of the U vectors described above.
        //
        //    Input, int LDA, a positive value not less than M which specifies the 
        //    leading dimension of the array A.
        //
        //    Input, bool PIVOT.  If true, then column pivoting is enforced.
        //
        //    Output, integer IPVT[LIPVT].  If PIVOT is true, then on output IPVT 
        //    defines the permutation matrix P such that A*P = Q*R.  Column J of P
        //    is column IPVT[J] of the identity matrix.
        //
        //       lipvt is a positive integer input variable. if pivot is false,
        //         then lipvt may be as small as 1. if pivot is true, then
        //         lipvt must be at least n.
        //
        //       rdiag is an output array of length n which contains the
        //         diagonal elements of r.
        //
        //       acnorm is an output array of length n which contains the
        //         norms of the corresponding columns of the input matrix a.
        //         if this information is not needed, then acnorm can coincide
        //         with rdiag.
        //
    {
        int j;
        const double p05 = 0.05;
        //
        //  EPSMCH is the machine precision.
        //
        double epsmch = typeMethods.r8_epsilon();
        //
        //  Compute the initial column norms and initialize several arrays.
        //
        double[] wa = new double[n];

        for (j = 0; j < n; j++)
        {
            acnorm[(acnormIndex + j) % acnorm.Length] = Helpers.enorm(m, a, xIndex: aIndex + j * lda);
            rdiag[(rdiagIndex + j) % rdiag.Length] = acnorm[(acnormIndex + j) % acnorm.Length];
            wa[j % wa.Length] = rdiag[(rdiagIndex + j) % rdiag.Length];
            ipvt[j % ipvt.Length] = pivot switch
            {
                true => j,
                _ => ipvt[j % ipvt.Length]
            };
        }

        //
        //  Reduce A to R with Householder transformations.
        //
        int minmn = Math.Min(m, n);

        for (j = 0; j < minmn; j++)
        {
            int i;
            double temp;
            int k;
            switch (pivot)
            {
                case true:
                {
                    //
                    //  Bring the column of largest norm into the pivot position.
                    //
                    int kmax = j;
                    for (k = j; k < n; k++)
                    {
                        if (rdiag[(rdiagIndex + kmax) % rdiag.Length] < rdiag[(rdiagIndex + k) % rdiag.Length])
                        {
                            kmax = k;
                        }
                    }

                    if (kmax != j)
                    {
                        for (i = 0; i < m; i++)
                        {
                            temp = a[(aIndex + i + j * lda) % a.Length];
                            a[(aIndex + i + j * lda) % a.Length] = a[(aIndex + i + kmax * lda) % a.Length];
                            a[(aIndex + i + kmax * lda) % a.Length] = temp;
                        }

                        rdiag[(rdiagIndex + kmax) % rdiag.Length] = rdiag[(rdiagIndex + j) % rdiag.Length];
                        wa[kmax % wa.Length] = wa[j % wa.Length];
                        k = ipvt[j % ipvt.Length];
                        ipvt[j % ipvt.Length] = ipvt[kmax % ipvt.Length];
                        ipvt[kmax % ipvt.Length] = k;
                    }

                    break;
                }
            }

            //
            //  Compute the Householder transformation to reduce the
            //  J-th column of A to a multiple of the J-th unit vector.
            //
            double ajnorm = Helpers.enorm(m - j, a, xIndex: aIndex + + j + j * lda);

            if (ajnorm != 0.0)
            {
                ajnorm = a[(aIndex + j + j * lda) % a.Length] switch
                {
                    < 0.0 => -ajnorm,
                    _ => ajnorm
                };

                for (i = j; i < m; i++)
                {
                    a[(aIndex + i + j * lda) % a.Length] /= ajnorm;
                }

                a[(aIndex + j + j * lda) % a.Length] += 1.0;
                //
                //  Apply the transformation to the remaining columns and update the norms.
                //
                for (k = j + 1; k < n; k++)
                {
                    double sum = 0.0;
                    for (i = j; i < m; i++)
                    {
                        sum += a[(aIndex + i + j * lda) % a.Length] * a[(aIndex + i + k * lda) % a.Length];
                    }

                    temp = sum / a[aIndex + j + j * lda];
                    for (i = j; i < m; i++)
                    {
                        a[(aIndex + i + k * lda) % a.Length] -= temp * a[(aIndex + i + j * lda) % a.Length];
                    }

                    switch (pivot)
                    {
                        case true when rdiag[rdiagIndex + k] != 0.0:
                        {
                            temp = a[(aIndex + j + k * lda) % a.Length] / rdiag[(rdiagIndex + k) % rdiag.Length];
                            rdiag[(rdiagIndex + k) % rdiag.Length] *= Math.Sqrt(Math.Max(0.0, 1.0 - temp * temp));
                            if (p05 * (rdiag[(rdiagIndex + k) % rdiag.Length] / wa[k % wa.Length]) * (rdiag[(rdiagIndex + k) % rdiag.Length] / wa[k % wa.Length]) <= epsmch)
                            {
                                rdiag[(rdiagIndex + k) % rdiag.Length] = Helpers.enorm(m - 1 - j, a, xIndex: aIndex + + (j + 1) + k * lda);
                                wa[k % wa.Length] = rdiag[(rdiagIndex + k) % rdiag.Length];
                            }

                            break;
                        }
                    }
                }
            }

            rdiag[(rdiagIndex + j) % rdiag.Length] = -ajnorm;
        }
    }

    public static double[] qr_solve ( int m, int n, double[] a, double[] b )

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    QR_SOLVE solves a linear system in the least squares sense.
        //
        //  Discussion:
        //
        //    If the matrix A has full column rank, then the solution X should be the
        //    unique vector that minimizes the Euclidean norm of the residual.
        //
        //    If the matrix A does not have full column rank, then the solution is
        //    not unique; the vector X will minimize the residual norm, but so will
        //    various other vectors.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    21 April 2012
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Reference:
        //
        //    David Kahaner, Cleve Moler, Steven Nash,
        //    Numerical Methods and Software,
        //    Prentice Hall, 1989,
        //    ISBN: 0-13-627258-4,
        //    LC: TA345.K34.
        //
        //  Parameters:
        //
        //    Input, int M, the number of rows of A.
        //
        //    Input, int N, the number of columns of A.
        //
        //    Input, double A[M*N], the matrix.
        //
        //    Input, double B[M], the right hand side.
        //
        //    Output, double QR_SOLVE[N], the least squares solution.
        //
    {
        int kr = 0;

        double[] a_qr = typeMethods.r8mat_copy_new ( m, n, a );
        double tol = typeMethods.r8_epsilon() / typeMethods.r8mat_amax ( m, n, a_qr );
        double[] x = new double[n];
        int[] jpvt = new int[n];
        double[] qraux = new double[n];
        double[] r = new double[m];
        const int itask = 1;

        for (int i = 0; i < qraux.Length; i++)
        {
            qraux[i % qraux.Length] = -6.2774385622041925e+66;
        }

        dqrls ( ref a_qr, m, m, n, tol, ref kr, b, ref x, ref r, jpvt, qraux, itask );

        return x;
    }
        
    public static void dqrank(ref double[] a, int lda, int m, int n, double tol, ref int kr,
            ref int[] jpvt, ref double[] qraux )

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    DQRANK computes the QR factorization of a rectangular matrix.
        //
        //  Discussion:
        //
        //    This routine is used in conjunction with sqrlss to solve
        //    overdetermined, underdetermined and singular linear systems
        //    in a least squares sense.
        //
        //    DQRANK uses the LINPACK subroutine DQRDC to compute the QR
        //    factorization, with column pivoting, of an M by N matrix A.
        //    The numerical rank is determined using the tolerance TOL.
        //
        //    Note that on output, ABS ( A(1,1) ) / ABS ( A(KR,KR) ) is an estimate
        //    of the condition number of the matrix of independent columns,
        //    and of R.  This estimate will be <= 1/TOL.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    21 April 2012
        //
        //  Author:
        //
        //    C++ version by John Burkardt
        //
        //  Reference:
        //
        //    Jack Dongarra, Cleve Moler, Jim Bunch, Pete Stewart,
        //    LINPACK User's Guide,
        //    SIAM, 1979,
        //    ISBN13: 978-0-898711-72-1,
        //    LC: QA214.L56.
        //
        //  Parameters:
        //
        //    Input/output, double A[LDA*N].  On input, the matrix whose
        //    decomposition is to be computed.  On output, the information from DQRDC.
        //    The triangular matrix R of the QR factorization is contained in the
        //    upper triangle and information needed to recover the orthogonal
        //    matrix Q is stored below the diagonal in A and in the vector QRAUX.
        //
        //    Input, int LDA, the leading dimension of A, which must
        //    be at least M.
        //
        //    Input, int M, the number of rows of A.
        //
        //    Input, int N, the number of columns of A.
        //
        //    Input, double TOL, a relative tolerance used to determine the
        //    numerical rank.  The problem should be scaled so that all the elements
        //    of A have roughly the same absolute accuracy, EPS.  Then a reasonable
        //    value for TOL is roughly EPS divided by the magnitude of the largest
        //    element.
        //
        //    Output, int &KR, the numerical rank.
        //
        //    Output, int JPVT[N], the pivot information from DQRDC.
        //    Columns JPVT(1), ..., JPVT(KR) of the original matrix are linearly
        //    independent to within the tolerance TOL and the remaining columns
        //    are linearly dependent.
        //
        //    Output, double QRAUX[N], will contain extra information defining
        //    the QR factorization.
        //
    {
        int i;
        int j;

        for (i = 0; i < n; i++)
        {
            jpvt[i % jpvt.Length] = 0;
        }

        double[] work = new double[n];
        const int job = 1;

        dqrdc(ref a, lda, m, n, ref qraux, ref jpvt, work, job);

        kr = 0;
        int k = Math.Min(m, n);

        for (j = 0; j < k; j++)
        {
            if (Math.Abs(a[(j + j * lda) % a.Length]) <= tol * Math.Abs(a[(0 + 0 * lda) % a.Length]))
            {
                return;
            }

            kr = j + 1;
        }
    }

    public static void dqrdc(ref double[] a, int lda, int n, int p, ref double[] qraux, ref int[] jpvt,
            double[] work, int job )

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    DQRDC computes the QR factorization of a real rectangular matrix.
        //
        //  Discussion:
        //
        //    DQRDC uses Householder transformations.
        //
        //    Column pivoting based on the 2-norms of the reduced columns may be
        //    performed at the user's option.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    07 June 2005
        //
        //  Author:
        //
        //    C++ version by John Burkardt.
        //
        //  Reference:
        //
        //    Jack Dongarra, Cleve Moler, Jim Bunch and Pete Stewart,
        //    LINPACK User's Guide,
        //    SIAM, (Society for Industrial and Applied Mathematics),
        //    3600 University City Science Center,
        //    Philadelphia, PA, 19104-2688.
        //    ISBN 0-89871-172-X
        //
        //  Parameters:
        //
        //    Input/output, double A(LDA,P).  On input, the N by P matrix
        //    whose decomposition is to be computed.  On output, A contains in
        //    its upper triangle the upper triangular matrix R of the QR
        //    factorization.  Below its diagonal A contains information from
        //    which the orthogonal part of the decomposition can be recovered.
        //    Note that if pivoting has been requested, the decomposition is not that
        //    of the original matrix A but that of A with its columns permuted
        //    as described by JPVT.
        //
        //    Input, int LDA, the leading dimension of the array A.  LDA must
        //    be at least N.
        //
        //    Input, int N, the number of rows of the matrix A.
        //
        //    Input, int P, the number of columns of the matrix A.
        //
        //    Output, double QRAUX[P], contains further information required
        //    to recover the orthogonal part of the decomposition.
        //
        //    Input/output, integer JPVT[P].  On input, JPVT contains integers that
        //    control the selection of the pivot columns.  The K-th column A(*,K) of A
        //    is placed in one of three classes according to the value of JPVT(K).
        //      > 0, then A(K) is an initial column.
        //      = 0, then A(K) is a free column.
        //      < 0, then A(K) is a final column.
        //    Before the decomposition is computed, initial columns are moved to
        //    the beginning of the array A and final columns to the end.  Both
        //    initial and final columns are frozen in place during the computation
        //    and only free columns are moved.  At the K-th stage of the
        //    reduction, if A(*,K) is occupied by a free column it is interchanged
        //    with the free column of largest reduced norm.  JPVT is not referenced
        //    if JOB == 0.  On output, JPVT(K) contains the index of the column of the
        //    original matrix that has been interchanged into the K-th column, if
        //    pivoting was requested.
        //
        //    Workspace, double WORK[P].  WORK is not referenced if JOB == 0.
        //
        //    Input, int JOB, initiates column pivoting.
        //    0, no pivoting is done.
        //    nonzero, pivoting is done.
        //
    {
        int j;
        int jp;
        int l;
        int xIndex;
        int yIndex;
        int index;
            
        int pl = 1;
        int pu = 0;
        //
        //  If pivoting is requested, rearrange the columns.
        //
        if (job != 0)
        {
            for (j = 1; j <= p; j++)
            {
                bool swapj = 0 < jpvt[j - 1];

                jpvt[(j - 1) % jpvt.Length] = jpvt[(j - 1) % jpvt.Length] switch
                {
                    < 0 => -j,
                    _ => j
                };

                switch (swapj)
                {
                    case true:
                    {
                        if (j != pl)
                        {
                            xIndex = +0 + (pl - 1);
                            yIndex = 0 + (j - 1) * lda;
                            BLAS1D.dswap(n, ref a, 1, ref a, 1, xIndex, yIndex);
                        }

                        jpvt[(j - 1) % jpvt.Length] = jpvt[(pl - 1) % jpvt.Length];
                        jpvt[(pl - 1) % jpvt.Length] = j;
                        pl += 1;
                        break;
                    }
                }
            }

            pu = p;

            for (j = p; 1 <= j; j--)
            {
                switch (jpvt[(j - 1) % jpvt.Length])
                {
                    case < 0:
                    {
                        jpvt[(j - 1) % jpvt.Length] = -jpvt[(j - 1) % jpvt.Length];

                        if (j != pu)
                        {
                            xIndex = 0 + (pu - 1) * lda;
                            yIndex = 0 + (j - 1) * lda;
                            BLAS1D.dswap(n, ref a, 1, ref a, 1, xIndex, yIndex);
                            jp = jpvt[(pu - 1) % jpvt.Length];
                            jpvt[(pu - 1) % jpvt.Length] = jpvt[(j - 1) % jpvt.Length];
                            jpvt[(j - 1) % jpvt.Length] = jp;
                        }

                        pu -= 1;
                        break;
                    }
                }
            }
        }

        //
        //  Compute the norms of the free columns.
        //
        for (j = pl; j <= pu; j++)
        {
            index = +0 + (j - 1) * lda;
            qraux[(j - 1) % qraux.Length] = BLAS1D.dnrm2(n, a, 1, index);
        }

        for (j = pl; j <= pu; j++)
        {
            work[(j - 1) % work.Length] = qraux[(j - 1) % qraux.Length];
        }

        //
        //  Perform the Householder reduction of A.
        //
        int lup = Math.Min(n, p);

        for (l = 1; l <= lup; l++)
        {
            //
            //  Bring the column of largest norm into the pivot position.
            //
            if (pl <= l && l < pu)
            {
                double maxnrm = 0.0;
                int maxj = l;
                for (j = l; j <= pu; j++)
                {
                    if (!(maxnrm < qraux[(j - 1) % qraux.Length]))
                    {
                        continue;
                    }

                    maxnrm = qraux[(j - 1) % qraux.Length];
                    maxj = j;
                }

                if (maxj != l)
                {
                    xIndex = +0 + (l - 1) * lda;
                    yIndex = +0 + (maxj - 1) * lda;
                    BLAS1D.dswap(n, ref a, 1, ref a, 1, xIndex, yIndex);
                    qraux[(maxj - 1) % qraux.Length] = qraux[(l - 1) % qraux.Length];
                    work[(maxj - 1) % work.Length] = work[(l - 1) % work.Length];
                    jp = jpvt[(maxj - 1) % jpvt.Length];
                    jpvt[(maxj - 1) % jpvt.Length] = jpvt[(l - 1) % jpvt.Length];
                    jpvt[(l - 1) % jpvt.Length] = jp;
                }
            }

            //
            //  Compute the Householder transformation for column L.
            //
            qraux[(l - 1) % qraux.Length] = 0.0;

            if (l == n)
            {
                continue;
            }

            index = +l - 1 + (l - 1) * lda;
            double nrmxl = BLAS1D.dnrm2(n - l + 1, a, 1, index);

            if (nrmxl == 0.0)
            {
                continue;
            }

            if (a[(l - 1 + (l - 1) * lda) % a.Length] != 0.0)
            {
                nrmxl *= typeMethods.r8_sign(a[index % a.Length]);
            }

            BLAS1D.dscal(n - l + 1, 1.0 / nrmxl, ref a, 1, index);
            a[index % a.Length] = 1.0 + a[index % a.Length];
            //
            //  Apply the transformation to the remaining columns, updating the norms.
            //
            for (j = l + 1; j <= p; j++)
            {
                yIndex = +l - 1 + (j - 1) * lda;
                double t = -BLAS1D.ddot(n - l + 1, a, 1, a, 1, index, yIndex)
                           / a[index % a.Length];
                BLAS1D.daxpy(n - l + 1, t, a, 1, ref a, 1, index, yIndex);

                if (pl > j || j > pu || qraux[(j - 1) % qraux.Length] == 0.0)
                {
                    continue;
                }

                double tt = 1.0 - Math.Pow(Math.Abs(a[yIndex % a.Length]) / qraux[(j - 1) % qraux.Length], 2);
                tt = Math.Max(tt, 0.0);
                t = tt;
                tt = 1.0 + 0.05 * tt * Math.Pow(qraux[(j - 1) % qraux.Length] / work[(j - 1) % work.Length], 2);

                if (Math.Abs(tt - 1.0) > typeMethods.r8_epsilon())
                {
                    qraux[(j - 1) % qraux.Length] *= Math.Sqrt(t);
                }
                else
                {
                    int index2 = +l + (j - 1) * lda;
                    qraux[(j - 1) % qraux.Length] = BLAS1D.dnrm2(n - l, a, 1, index2);
                    work[(j - 1) % work.Length] = qraux[(j - 1) % qraux.Length];
                }
            }

            //
            //  Save the transformation.
            //
            qraux[(l - 1) % qraux.Length] = a[index % a.Length];
            a[index % a.Length] = -nrmxl;
        }
    }

    public static int dqrls(ref double[] a, int lda, int m, int n, double tol, ref int kr, double[] b,
            ref double[] x, ref double[] rsd, int[] jpvt, double[] qraux, int itask )

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    DQRLS factors and solves a linear system in the least squares sense.
        //
        //  Discussion:
        //
        //    The linear system may be overdetermined, underdetermined or singular.
        //    The solution is obtained using a QR factorization of the
        //    coefficient matrix.
        //
        //    DQRLS can be efficiently used to solve several least squares
        //    problems with the same matrix A.  The first system is solved
        //    with ITASK = 1.  The subsequent systems are solved with
        //    ITASK = 2, to avoid the recomputation of the matrix factors.
        //    The parameters KR, JPVT, and QRAUX must not be modified
        //    between calls to DQRLS.
        //
        //    DQRLS is used to solve in a least squares sense
        //    overdetermined, underdetermined and singular linear systems.
        //    The system is A*X approximates B where A is M by N.
        //    B is a given M-vector, and X is the N-vector to be computed.
        //    A solution X is found which minimimzes the sum of squares (2-norm)
        //    of the residual,  A*X - B.
        //
        //    The numerical rank of A is determined using the tolerance TOL.
        //
        //    DQRLS uses the LINPACK subroutine DQRDC to compute the QR
        //    factorization, with column pivoting, of an M by N matrix A.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    21 April 2012
        //
        //  Author:
        //
        //    C++ version by John Burkardt.
        //
        //  Reference:
        //
        //    David Kahaner, Cleve Moler, Steven Nash,
        //    Numerical Methods and Software,
        //    Prentice Hall, 1989,
        //    ISBN: 0-13-627258-4,
        //    LC: TA345.K34.
        //
        //  Parameters:
        //
        //    Input/output, double A[LDA*N], an M by N matrix.
        //    On input, the matrix whose decomposition is to be computed.
        //    In a least squares data fitting problem, A(I,J) is the
        //    value of the J-th basis (model) function at the I-th data point.
        //    On output, A contains the output from DQRDC.  The triangular matrix R
        //    of the QR factorization is contained in the upper triangle and
        //    information needed to recover the orthogonal matrix Q is stored
        //    below the diagonal in A and in the vector QRAUX.
        //
        //    Input, int LDA, the leading dimension of A.
        //
        //    Input, int M, the number of rows of A.
        //
        //    Input, int N, the number of columns of A.
        //
        //    Input, double TOL, a relative tolerance used to determine the
        //    numerical rank.  The problem should be scaled so that all the elements
        //    of A have roughly the same absolute accuracy EPS.  Then a reasonable
        //    value for TOL is roughly EPS divided by the magnitude of the largest
        //    element.
        //
        //    Output, int &KR, the numerical rank.
        //
        //    Input, double B[M], the right hand side of the linear system.
        //
        //    Output, double X[N], a least squares solution to the linear
        //    system.
        //
        //    Output, double RSD[M], the residual, B - A*X.  RSD may
        //    overwrite B.
        //
        //    Workspace, int JPVT[N], required if ITASK = 1.
        //    Columns JPVT(1), ..., JPVT(KR) of the original matrix are linearly
        //    independent to within the tolerance TOL and the remaining columns
        //    are linearly dependent.  ABS ( A(1,1) ) / ABS ( A(KR,KR) ) is an estimate
        //    of the condition number of the matrix of independent columns,
        //    and of R.  This estimate will be <= 1/TOL.
        //
        //    Workspace, double QRAUX[N], required if ITASK = 1.
        //
        //    Input, int ITASK.
        //    1, DQRLS factors the matrix A and solves the least squares problem.
        //    2, DQRLS assumes that the matrix A was factored with an earlier
        //       call to DQRLS, and only solves the least squares problem.
        //
        //    Output, int DQRLS, error code.
        //    0:  no error
        //    -1: LDA < M   (fatal error)
        //    -2: N < 1     (fatal error)
        //    -3: ITASK < 1 (fatal error)
        //
    {
        int ind;

        if (lda < m)
        {
            Console.WriteLine("");
            Console.WriteLine("DQRLS - Fatal error!");
            Console.WriteLine("  LDA < M.");
            ind = -1;
            return ind;
        }

        switch (n)
        {
            case <= 0:
                Console.WriteLine("");
                Console.WriteLine("DQRLS - Fatal error!");
                Console.WriteLine("  N <= 0.");
                ind = -2;
                return ind;
        }

        switch (itask)
        {
            case < 1:
                Console.WriteLine("");
                Console.WriteLine("DQRLS - Fatal error!");
                Console.WriteLine("  ITASK < 1.");
                ind = -3;
                return ind;
        }

        ind = 0;
        switch (itask)
        {
            //
            //  Factor the matrix.
            //
            case 1:
                dqrank(ref a, lda, m, n, tol, ref kr, ref jpvt, ref qraux);
                break;
        }

        //
        //  Solve the least-squares problem.
        //
        dqrlss(a, lda, m, n, kr, b, ref x, ref rsd, jpvt, qraux);

        return ind;
    }

    public static void dqrlss(double[] a, int lda, int m, int n, int kr, double[] b, ref double[] x,
            ref double[] rsd, int[] jpvt, double[] qraux )

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    DQRLSS solves a linear system in a least squares sense.
        //
        //  Discussion:
        //
        //    DQRLSS must be preceeded by a call to DQRANK.
        //
        //    The system is to be solved is
        //      A * X = B
        //    where
        //      A is an M by N matrix with rank KR, as determined by DQRANK,
        //      B is a given M-vector,
        //      X is the N-vector to be computed.
        //
        //    A solution X, with at most KR nonzero components, is found which
        //    minimizes the 2-norm of the residual (A*X-B).
        //
        //    Once the matrix A has been formed, DQRANK should be
        //    called once to decompose it.  Then, for each right hand
        //    side B, DQRLSS should be called once to obtain the
        //    solution and residual.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    15 April 2012
        //
        //  Parameters:
        //
        //    Input, double A[LDA*N], the QR factorization information
        //    from DQRANK.  The triangular matrix R of the QR factorization is
        //    contained in the upper triangle and information needed to recover
        //    the orthogonal matrix Q is stored below the diagonal in A and in
        //    the vector QRAUX.
        //
        //    Input, int LDA, the leading dimension of A, which must
        //    be at least M.
        //
        //    Input, int M, the number of rows of A.
        //
        //    Input, int N, the number of columns of A.
        //
        //    Input, int KR, the rank of the matrix, as estimated by DQRANK.
        //
        //    Input, double B[M], the right hand side of the linear system.
        //
        //    Output, double X[N], a least squares solution to the
        //    linear system.
        //
        //    Output, double RSD[M], the residual, B - A*X.  RSD may
        //    overwite B.
        //
        //    Input, int JPVT[N], the pivot information from DQRANK.
        //    Columns JPVT[0], ..., JPVT[KR-1] of the original matrix are linearly
        //    independent to within the tolerance TOL and the remaining columns
        //    are linearly dependent.
        //
        //    Input, double QRAUX[N], auxiliary information from DQRANK
        //    defining the QR factorization.
        //
    {
        int i;
        int j;

        if (kr != 0)
        {
            const int job = 110;
            dqrsl(a, lda, m, kr, qraux, b, ref rsd, ref rsd, ref x, ref rsd, ref rsd, job);
        }

        for (i = 0; i < n; i++)
        {
            jpvt[i % jpvt.Length] = -jpvt[i % jpvt.Length];
        }

        for (i = kr; i < n; i++)
        {
            x[i % x.Length] = 0.0;
        }

        for (j = 1; j <= n; j++)
        {
            switch (jpvt[(j - 1) % jpvt.Length])
            {
                case <= 0:
                {
                    int k = -jpvt[(j - 1) % jpvt.Length];
                    jpvt[(j - 1) % jpvt.Length] = k;

                    while (k != j)
                    {
                        (x[(j - 1) % x.Length], x[(k - 1) % x.Length]) = (x[(k - 1) % x.Length], x[(j - 1) % x.Length]);
                        jpvt[(k - 1)  % jpvt.Length] = -jpvt[(k - 1) % jpvt.Length];
                        k = jpvt[(k - 1) % jpvt.Length];
                    }

                    break;
                }
            }
        }
    }

    public static int dqrsl(double[] a, int lda, int n, int k, double[] qraux, double[] y,
            ref double[] qy, ref double[] qty, ref double[] b, ref double[] rsd, ref double[] ab, int job )

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    DQRSL computes transformations, projections, and least squares solutions.
        //
        //  Discussion:
        //
        //    DQRSL requires the output of DQRDC.
        //
        //    For K <= min(N,P), let AK be the matrix
        //
        //      AK = ( A(JPVT[0]), A(JPVT(2)), ..., A(JPVT(K)) )
        //
        //    formed from columns JPVT[0], ..., JPVT(K) of the original
        //    N by P matrix A that was input to DQRDC.  If no pivoting was
        //    done, AK consists of the first K columns of A in their
        //    original order.  DQRDC produces a factored orthogonal matrix Q
        //    and an upper triangular matrix R such that
        //
        //      AK = Q * (R)
        //               (0)
        //
        //    This information is contained in coded form in the arrays
        //    A and QRAUX.
        //
        //    The parameters QY, QTY, B, RSD, and AB are not referenced
        //    if their computation is not requested and in this case
        //    can be replaced by dummy variables in the calling program.
        //    To save storage, the user may in some cases use the same
        //    array for different parameters in the calling sequence.  A
        //    frequently occuring example is when one wishes to compute
        //    any of B, RSD, or AB and does not need Y or QTY.  In this
        //    case one may identify Y, QTY, and one of B, RSD, or AB, while
        //    providing separate arrays for anything else that is to be
        //    computed.
        //
        //    Thus the calling sequence
        //
        //      dqrsl ( a, lda, n, k, qraux, y, dum, y, b, y, dum, 110, info )
        //
        //    will result in the computation of B and RSD, with RSD
        //    overwriting Y.  More generally, each item in the following
        //    list contains groups of permissible identifications for
        //    a single calling sequence.
        //
        //      1. (Y,QTY,B) (RSD) (AB) (QY)
        //
        //      2. (Y,QTY,RSD) (B) (AB) (QY)
        //
        //      3. (Y,QTY,AB) (B) (RSD) (QY)
        //
        //      4. (Y,QY) (QTY,B) (RSD) (AB)
        //
        //      5. (Y,QY) (QTY,RSD) (B) (AB)
        //
        //      6. (Y,QY) (QTY,AB) (B) (RSD)
        //
        //    In any group the value returned in the array allocated to
        //    the group corresponds to the last member of the group.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    07 June 2005
        //
        //  Author:
        //
        //    C++ version by John Burkardt.
        //
        //  Reference:
        //
        //    Jack Dongarra, Cleve Moler, Jim Bunch and Pete Stewart,
        //    LINPACK User's Guide,
        //    SIAM, (Society for Industrial and Applied Mathematics),
        //    3600 University City Science Center,
        //    Philadelphia, PA, 19104-2688.
        //    ISBN 0-89871-172-X
        //
        //  Parameters:
        //
        //    Input, double A[LDA*P], contains the output of DQRDC.
        //
        //    Input, int LDA, the leading dimension of the array A.
        //
        //    Input, int N, the number of rows of the matrix AK.  It must
        //    have the same value as N in DQRDC.
        //
        //    Input, int K, the number of columns of the matrix AK.  K
        //    must not be greater than min(N,P), where P is the same as in the
        //    calling sequence to DQRDC.
        //
        //    Input, double QRAUX[P], the auxiliary output from DQRDC.
        //
        //    Input, double Y[N], a vector to be manipulated by DQRSL.
        //
        //    Output, double QY[N], contains Q * Y, if requested.
        //
        //    Output, double QTY[N], contains Q' * Y, if requested.
        //
        //    Output, double B[K], the solution of the least squares problem
        //      minimize norm2 ( Y - AK * B),
        //    if its computation has been requested.  Note that if pivoting was
        //    requested in DQRDC, the J-th component of B will be associated with
        //    column JPVT(J) of the original matrix A that was input into DQRDC.
        //
        //    Output, double RSD[N], the least squares residual Y - AK * B,
        //    if its computation has been requested.  RSD is also the orthogonal
        //    projection of Y onto the orthogonal complement of the column space
        //    of AK.
        //
        //    Output, double AB[N], the least squares approximation Ak * B,
        //    if its computation has been requested.  AB is also the orthogonal
        //    projection of Y onto the column space of A.
        //
        //    Input, integer JOB, specifies what is to be computed.  JOB has
        //    the decimal expansion ABCDE, with the following meaning:
        //
        //      if A != 0, compute QY.
        //      if B != 0, compute QTY.
        //      if C != 0, compute QTY and B.
        //      if D != 0, compute QTY and RSD.
        //      if E != 0, compute QTY and AB.
        //
        //    Note that a request to compute B, RSD, or AB automatically triggers
        //    the computation of QTY, for which an array must be provided in the
        //    calling sequence.
        //
        //    Output, int DQRSL, is zero unless the computation of B has
        //    been requested and R is exactly singular.  In this case, INFO is the
        //    index of the first zero diagonal element of R, and B is left unaltered.
        //
    {
        int i;
        int j;
        int jj;
        double t;
        double temp;
        //
        //  set info flag.
        //
        int info = 0;
        //
        //  Determine what is to be computed.
        //
        bool cqy = job / 10000 != 0;
        bool cqty = job % 10000 != 0;
        bool cb = job % 1000 / 100 != 0;
        bool cr = job % 100 / 10 != 0;
        bool cab = job % 10 != 0;

        int ju = Math.Min(k, n - 1);
        switch (ju)
        {
            //
            //  Special action when N = 1.
            //
            case 0:
            {
                qy[0] = cqy switch
                {
                    true => y[0],
                    _ => qy[0]
                };

                qty[0] = cqty switch
                {
                    true => y[0],
                    _ => qty[0]
                };

                ab[0] = cab switch
                {
                    true => y[0],
                    _ => ab[0]
                };

                switch (cb)
                {
                    case true when a[(0 + 0 * lda) % a.Length] == 0.0:
                        info = 1;
                        break;
                    case true:
                        b[0] = y[0] / a[(0 + 0 * lda) % a.Length];
                        break;
                }

                rsd[0] = cr switch
                {
                    true => 0.0,
                    _ => rsd[0]
                };

                return info;
            }
        }

        switch (cqy)
        {
            //
            //  Set up to compute QY or QTY.
            //
            case true:
            {
                for (i = 1; i <= n; i++)
                {
                    qy[(i - 1) % qy.Length] = y[(i - 1) % y.Length];
                }

                break;
            }
        }

        switch (cqty)
        {
            case true:
            {
                for (i = 1; i <= n; i++)
                {
                    qty[(i - 1) % qty.Length] = y[(i - 1) % y.Length];
                }

                break;
            }
        }

        switch (cqy)
        {
            //
            //  Compute QY.
            //
            case true:
            {
                for (jj = 1; jj <= ju; jj++)
                {
                    j = ju - jj + 1;

                    if (qraux[(j - 1) % qraux.Length] == 0.0)
                    {
                        continue;
                    }

                    temp = a[(j - 1 + (j - 1) * lda) % a.Length];
                    a[(j - 1 + (j - 1) * lda) % a.Length] = qraux[(j - 1) % qraux.Length];
                    t = -BLAS1D.ddot(n - j + 1, a, 1, qy, 1, + j - 1 + (j - 1) * lda, + j - 1 ) / a[(j - 1 + (j - 1) * lda) % a.Length];
                    BLAS1D.daxpy(n - j + 1, t, a, 1, ref qy, 1, + j - 1 + (j - 1) * lda, + j - 1);
                    a[(j - 1 + (j - 1) * lda) % a.Length] = temp;
                }

                break;
            }
        }

        switch (cqty)
        {
            //
            //  Compute Q'*Y.
            //
            case true:
            {
                for (j = 1; j <= ju; j++)
                {
                    if (qraux[(j - 1) % qraux.Length] == 0.0)
                    {
                        continue;
                    }

                    temp = a[(j - 1 + (j - 1) * lda) % a.Length];
                    a[(j - 1 + (j - 1) * lda) % a.Length] = qraux[(j - 1) % qraux.Length];
                    t = -BLAS1D.ddot(n - j + 1, a, 1, qty, 1, + j - 1 + (j - 1) * lda, + j - 1) / a[(j - 1 + (j - 1) * lda) % a.Length];
                    BLAS1D.daxpy(n - j + 1, t, a, 1, ref qty, 1, + j - 1 + (j - 1) * lda, + j - 1);
                    a[(j - 1 + (j - 1) * lda) % a.Length] = temp;
                }

                break;
            }
        }

        switch (cb)
        {
            //
            //  Set up to compute B, RSD, or AB.
            //
            case true:
            {
                for (i = 1; i <= k; i++)
                {
                    b[(i - 1) % b.Length] = qty[(i - 1) % qty.Length];
                }

                break;
            }
        }

        switch (cab)
        {
            case true:
            {
                for (i = 1; i <= k; i++)
                {
                    ab[(i - 1) % ab.Length] = qty[(i - 1) % qty.Length];
                }

                break;
            }
        }

        switch (cr)
        {
            case true when k < n:
            {
                for (i = k + 1; i <= n; i++)
                {
                    rsd[(i - 1) % rsd.Length] = qty[(i - 1) % qty.Length];
                }

                break;
            }
        }

        switch (cab)
        {
            case true when k + 1 <= n:
            {
                for (i = k + 1; i <= n; i++)
                {
                    ab[(i - 1) % ab.Length] = 0.0;
                }

                break;
            }
        }

        switch (cr)
        {
            case true:
            {
                for (i = 1; i <= k; i++)
                {
                    rsd[(i - 1) % rsd.Length] = 0.0;
                }

                break;
            }
        }

        switch (cb)
        {
            //
            //  Compute B.
            //
            case true:
            {
                for (jj = 1; jj <= k; jj++)
                {
                    j = k - jj + 1;

                    if (a[(j - 1 + (j - 1) * lda) % a.Length] == 0.0)
                    {
                        info = j;
                        break;
                    }

                    b[(j - 1) % b.Length] /= a[(j - 1 + (j - 1) * lda) % a.Length];

                    if (j == 1)
                    {
                        continue;
                    }

                    t = -b[(j - 1) % b.Length];
                    BLAS1D.daxpy(j - 1, t, a, 1, ref b, 1, + 0 + (j - 1) * lda);
                }

                break;
            }
        }

        //
        //  Compute RSD or AB as required.
        //
        if (!cr && !cab)
        {
            return info;
        }

        for (jj = 1; jj <= ju; jj++)
        {
            j = ju - jj + 1;

            if (qraux[(j - 1) % qraux.Length] == 0.0)
            {
                continue;
            }

            temp = a[(j - 1 + (j - 1) * lda) % a.Length];
            a[(j - 1 + (j - 1) * lda) % a.Length] = qraux[(j - 1) % qraux.Length];

            switch (cr)
            {
                case true:
                    t = -BLAS1D.ddot(n - j + 1, a, 1, rsd, 1, + j - 1 + (j - 1) * lda, + j - 1)
                        / a[(j - 1 + (j - 1) * lda) % a.Length];
                    BLAS1D.daxpy(n - j + 1, t, a, 1, ref rsd, 1, + j - 1 + (j - 1) * lda, + j - 1);
                    break;
            }

            switch (cab)
            {
                case true:
                    t = -BLAS1D.ddot(n - j + 1, a, 1, ab, 1, + j - 1 + (j - 1) * lda, + j - 1)
                        / a[(j - 1 + (j - 1) * lda) % a.Length];
                    BLAS1D.daxpy(n - j + 1, t, a, 1, ref ab, 1, + j - 1 + (j - 1) * lda, + j - 1);
                    break;
            }

            a[(j - 1 + (j - 1) * lda) % a.Length] = temp;
        }

        return info;
    }
}