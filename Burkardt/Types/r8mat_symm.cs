﻿using System;

namespace Burkardt.Types;

public static partial class typeMethods
{
    public static double[] r8mat_symm_eigen(int n, double[] x, double[] q)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    R8MAT_SYMM_EIGEN returns a symmetric matrix with given eigensystem.
        //
        //  Discussion:
        //
        //    An R8MAT is a doubly dimensioned array of R8 values, stored as a vector
        //    in column-major order.
        //
        //    The user must supply the desired eigenvalue vector, and the desired
        //    eigenvector matrix.  The eigenvector matrix must be orthogonal.  A
        //    suitable random orthogonal matrix can be generated by
        //    R8MAT_ORTH_UNIFORM_NEW.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    17 October 2005
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int N, the order of A.
        //
        //    Input, double X[N], the desired eigenvalues for the matrix.
        //
        //    Input, double Q[N*N], the eigenvector matrix of A.
        //
        //    Output, double R8MAT_SYMM_EIGEN[N*N], a symmetric N by N matrix with
        //    eigenvalues X and eigenvectors the columns of Q.
        //
    {
        int i;
        //
        //  Set A = Q * Lambda * Q'.
        //
        double[] a = new double[n * n];

        for (i = 0; i < n; i++)
        {
            int j;
            for (j = 0; j < n; j++)
            {
                a[i + j * n] = 0.0;
                int k;
                for (k = 0; k < n; k++)
                {
                    a[i + j * n] += q[i + k * n] * x[k] * q[j + k * n];
                }
            }
        }

        return a;
    }

    public static void r8mat_symm_jacobi(int n, ref double[] a)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    R8MAT_SYMM_JACOBI applies Jacobi eigenvalue iteration to a symmetric matrix.
        //
        //  Discussion:
        //
        //    An R8MAT is a doubly dimensioned array of R8 values, stored as a vector
        //    in column-major order.
        //
        //    This code was modified so that it treats as zero the off-diagonal
        //    elements that are sufficiently close to, but not exactly, zero.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    09 October 2005
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int N, the order of A.
        //
        //    Input/output, double A[N*N], a symmetric N by N matrix.
        //    On output, the matrix has been overwritten by an approximately
        //    diagonal matrix, with the eigenvalues on the diagonal.
        //
    {
        const double eps = 0.00001;
        const int it_max = 100;

        double norm_fro = r8mat_norm_fro(n, n, a);

        int it = 0;

        for (;;)
        {
            it += 1;

            int i;
            int j;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < i; j++)
                {
                    if (!(eps * norm_fro < Math.Abs(a[i + j * n]) + Math.Abs(a[j + i * n])))
                    {
                        continue;
                    }

                    double u = (a[j + j * n] - a[i + i * n]) / (a[i + j * n] + a[j + i * n]);

                    double t = r8_sign(u) / (Math.Abs(u) + Math.Sqrt(u * u + 1.0));
                    double c = 1.0 / Math.Sqrt(t * t + 1.0);
                    double s = t * c;
                    //
                    //  A -> A * Q.
                    //
                    int k;
                    double t1;
                    double t2;
                    for (k = 0; k < n; k++)
                    {
                        t1 = a[i + k * n];
                        t2 = a[j + k * n];
                        a[i + k * n] = t1 * c - t2 * s;
                        a[j + k * n] = t1 * s + t2 * c;
                    }

                    //
                    //  A -> QT * A
                    //
                    for (k = 0; k < n; k++)
                    {
                        t1 = a[k + i * n];
                        t2 = a[k + j * n];
                        a[k + i * n] = c * t1 - s * t2;
                        a[k + j * n] = s * t1 + c * t2;
                    }
                }
            }

            //
            //  Test the size of the off-diagonal elements.
            //
            double sum2 = 0.0;
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < i; j++)
                {
                    sum2 += Math.Abs(a[i + j * n]);
                }
            }

            if (sum2 <= eps * (norm_fro + 1.0))
            {
                break;
            }

            if (it_max <= it)
            {
                break;
            }

        }
    }
        
}