using System;
using Burkardt.Types;

namespace Burkardt.CholeskyNS;

public static class HankelCholesky
{
    public static double[] hankel_cholesky_upper(int n, double[] h)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    HANKEL_CHOLESKY_UPPER computes the upper Cholesky factor of a Hankel matrix.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    30 January 2017
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Reference:
        //
        //    James Phillips,
        //    The triangular decomposition of Hankel matrices,
        //    Mathematics of Computation,
        //    Volume 25, Number 115, July 1971, pages 599-602.
        //
        //  Parameters:
        //
        //    Input, int N, the order of the matrix.
        //
        //    Input, double H[2*N-1], the values defining the antidiagonals.
        //
        //    Output, double HANKEL_CHOLESKY_UPPER[N*N], the upper triangular 
        //    Cholesky factor.
        //
    {
        int i;
        int j;

        double[] c = new double[(2 * n - 1) * (2 * n - 1)];

        for (j = 0; j < 2 * n - 1; j++)
        {
            c[((0 + j * (2 * n - 1)) + c.Length) % c.Length] = h[j % h.Length];
        }

        for (i = 0; i < n - 1; i++)
        {
            double b;
            double a;
            switch (i)
            {
                case 0:
                    a = c[((0 + 1 * (2 * n - 1)) + c.Length) % c.Length] / c[((0 + 0 * (2 * n - 1)) + c.Length) % c.Length];
                    b = 0.0;
                    break;
                default:
                    a = c[((i + (i + 1) * (2 * n - 1)) + c.Length) % c.Length] / c[((i + i * (2 * n - 1)) + c.Length) % c.Length] -
                        c[((i - 1 + i * (2 * n - 1)) + c.Length) % c.Length] / c[((i - 1 + (i - 1) * (2 * n - 1)) + c.Length) % c.Length];
                    b = c[((i + i * (2 * n - 1)) + c.Length) % c.Length] / c[((i - 1 + (i - 1) * (2 * n - 1)) + c.Length) % c.Length];
                    break;
            }

            for (j = i + 1; j < 2 * n - i - 2; j++)
            {
                c[((i + 1 + j * (2 * n - 1)) + c.Length) % c.Length] = c[((i + (j + 1) * (2 * n - 1)) + c.Length) % c.Length] - a * c[((i + j * (2 * n - 1)) + c.Length) % c.Length];
                switch (i)
                {
                    case > 0:
                        c[((i + 1 + j * (2 * n - 1)) + c.Length) % c.Length] -= b * c[((i - 1 + j * (2 * n - 1)) + c.Length) % c.Length];
                        break;
                }
            }
        }

        double[] r = new double[n * n];

        for (j = 0; j < n; j++)
        {
            for (i = 0; i < n; i++)
            {
                r[((i + j * n) + r.Length) % r.Length] = c[((i + j * (2 * n - 1)) + c.Length) % c.Length];
            }
        }

        //
        //  Normalize.
        //  This will fail if H is not positive definite.
        //
        for (i = 0; i < n; i++)
        {
            double t = Math.Sqrt(r[i + i * n]);
            for (j = 0; j < i; j++)
            {
                r[((i + j * n) + r.Length) % r.Length] = 0.0;
            }

            for (j = i; j < n; j++)
            {
                r[((i + j * n) + r.Length) % r.Length] /= t;
            }
        }
        return r;
    }

    public static double[] hankel_spd_cholesky_lower(int n, double[] lii, double[] liim1 )

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    HANKEL_SPD_CHOLESKY_LOWER returns L such that L*L' is Hankel SPD.
        //
        //  Discussion:
        //
        //    In other words, H = L * L' is a symmetric positive definite matrix
        //    with the property that H is constant along antidiagonals, so that
        //
        //      H(I+J) = h(k-1), for 1 <= I, J <= N, 1 <= K <= 2*N-1.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    27 January 2017
        //
        //  Author:
        //
        //    S Al-Homidan, M Alshahrani.
        //    C++ implementation by John Burkardt.
        //
        //  Reference:
        //
        //    S Al-Homidan, M Alshahrani,
        //    Positive Definite Hankel Matrices Using Cholesky Factorization,
        //    Computational Methods in Applied Mathematics,
        //    Volume 9, Number 3, pages 221-225, 2009.
        //
        //  Parameters:
        //
        //    Input, int N, the order of the matrix.
        //
        //    Input, double LII[N], values to be used in L(I,I), 
        //    for 1 <= I <= N.
        //
        //    Input, double LIIM1[N-1], values to be used in L(I+1,I) 
        //    for 1 <= I <= N-1.
        //
        //    Output, double HANKEL_SPD_CHOLESKY_LOWER[N,N], the lower 
        //    Cholesky factor.
        //
    {
        int i;

        double[] l = typeMethods.r8mat_zeros_new(n, n);

        for (i = 0; i < n; i++)
        {
            l[((i + i * n) + l.Length) % l.Length] = lii[i % lii.Length];
        }

        for (i = 0; i < n - 1; i++)
        {
            l[((i + 1 + i * n) + l.Length) % l.Length] = liim1[i % liim1.Length];
        }

        for (i = 2; i < n; i++)
        {
            int j;
            for (j = 0; j < i - 1; j++)
            {
                int r;
                int q;
                switch ((i + j) % 2)
                {
                    case 0:
                        q = (i + j) / 2;
                        r = q;
                        break;
                    default:
                        q = (i + j - 1) / 2;
                        r = q + 1;
                        break;
                }

                double alpha = 0.0;
                int s;
                for (s = 0; s <= q; s++)
                {
                    alpha += l[((q + s * n) + l.Length) % l.Length] * l[((r + s * n) + l.Length) % l.Length];
                }

                double beta = 0.0;
                int t;
                for (t = 0; t < j; t++)
                {
                    beta += l[((i + t * n) + l.Length) % l.Length] * l[((j + t * n) + l.Length) % l.Length];
                }

                l[((i + j * n) + l.Length) % l.Length] = (alpha - beta) / l[((j + j * n) + l.Length) % l.Length];
            }
        }

        return l;
    }
}