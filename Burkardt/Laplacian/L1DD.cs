﻿using System;

namespace Burkardt.Laplacian;

public static class L1DD
{
    public static double[] l1dd_apply(int n, double h, double[] u)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    L1DD_APPLY applies the 1D DD Laplacian to a vector.
        //
        //  Discussion:
        //
        //    The N grid points are assumed to be evenly spaced by H.
        //
        //    For N = 5, the discrete Laplacian with Dirichlet boundary conditions
        //    at both ends of [0,6] is applied to a vector of 7 values, with a spacing
        //    of H = 6/(N+1) = 1 at the points X:
        //
        //      0  1  2  3  4  5  6
        //
        //    and has the matrix form L:
        //
        //       2 -1  0  0  0
        //      -1  2 -1  0  0
        //       0 -1  2 -1  0
        //       0  0 -1  2 -1
        //       0  0  0 -1  2
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    30 October 2013
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int N, the number of points.
        //    N must be at least 3.
        //
        //    Input, double H, the spacing between points.
        //
        //    Input, double U[N], the value at each point.
        //
        //    Output, double L1DD_APPLY[N], the Laplacian evaluated at each point.
        //
    {
        switch (n)
        {
            case < 3:
                Console.WriteLine("");
                Console.WriteLine("L1DD_APPLY - Fatal error!");
                Console.WriteLine("  N < 3.");
                return null;
        }

        double[] lu = new double[n];

        int i = 0;
        lu[i] = (2.0 * u[i] - u[1]) / h / h;
        for (i = 1; i < n - 1; i++)
        {
            lu[i] = (-u[i - 1] + 2.0 * u[i] - u[i + 1]) / h / h;
        }

        i = n - 1;
        lu[i] = (-u[i - 1] + 2.0 * u[i]) / h / h;

        return lu;
    }

    public static double[] l1dd_cholesky(int n, double h)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    L1DD_CHOLESKY computes the Cholesky factor of the 1D DD Laplacian.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    30 October 2013
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int N, the number of points.
        //    N must be at least 3.
        //
        //    Input, double H, the spacing between points.
        //
        //    Output, double L1DD_CHOLESKY[N*N], the Cholesky factor.
        //
    {
        int i;
        int j;

        switch (n)
        {
            case < 3:
                Console.WriteLine("");
                Console.WriteLine("L1DD_CHOLESKY - Fatal error!");
                Console.WriteLine("  N < 3.");
                return null;
        }

        double[] c = new double[n * n];

        for (j = 0; j < n; j++)
        {
            for (i = 0; i < n; i++)
            {
                c[i + j * n] = 0.0;
            }
        }

        for (i = 0; i < n; i++)
        {
            c[i + i * n] = Math.Sqrt(i + 2) / Math.Sqrt(i + 1);
        }

        for (i = 0; i < n - 1; i++)
        {
            c[i + (i + 1) * n] = -Math.Sqrt(i + 1)
                                 / Math.Sqrt(i + 2);
        }

        for (j = 0; j < n; j++)
        {
            for (i = 0; i < n; i++)
            {
                c[i + j * n] /= h;
            }
        }

        return c;
    }

    public static void l1dd_eigen(int n, double h, ref double[] v, ref double[] lambda)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    L1DD_EIGEN returns eigeninformation for the 1D DD Laplacian.
        //
        //  Discussion:
        //
        //    The grid points are assumed to be evenly spaced by H.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    30 October 2013
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int N, the number of points.
        //
        //    Input, double H, the spacing between points.
        //
        //    Output, double V[N*N], the eigenvectors.
        //
        //    Output, double LAMBDA[N], the eigenvalues.
        //
    {
        int j;

        double n_r8 = n;

        for (j = 0; j < n; j++)
        {
            double j_r8 = j + 1;
            double theta = 0.5 * Math.PI * j_r8 / (n_r8 + 1.0);
            lambda[j] = Math.Pow(2.0 * Math.Sin(theta) / h, 2);
            int i;
            for (i = 0; i < n; i++)
            {
                double i_r8 = i + 1;
                theta = Math.PI * i_r8 * j_r8 / (n_r8 + 1.0);
                v[i + j * n] = Math.Sqrt(2.0 / (n_r8 + 1.0)) * Math.Sin(theta);
            }
        }
    }

    public static double[] l1dd(int n, double h)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    L1DD stores the 1D DD Laplacian as a full matrix.
        //
        //  Discussion:
        //
        //    The N grid points are assumed to be evenly spaced by H.
        //
        //    For N = 5, the discrete Laplacian with Dirichlet boundary conditions
        //    at both ends of [0,6] has the matrix form L:
        //
        //       2 -1  0  0  0
        //      -1  2 -1  0  0
        //       0 -1  2 -1  0
        //       0  0 -1  2 -1
        //       0  0  0 -1  2
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    30 October 2013
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int N, the number of points.
        //    N must be at least 3.
        //
        //    Input, double H, the spacing between points.
        //
        //    Output, double L1DD[N*N], the Laplacian matrix.
        //
    {
        int i;
        int j;

        switch (n)
        {
            case < 3:
                Console.WriteLine("");
                Console.WriteLine("L1DD - Fatal error!");
                Console.WriteLine("  N < 3.");
                return null;
        }

        double[] l = new double[n * n];

        for (j = 0; j < n; j++)
        {
            for (i = 0; i < n; i++)
            {
                l[i + j * n] = 0.0;
            }
        }

        i = 0;
        l[0] = 2.0 / h / h;
        l[n] = -1.0 / h / h;

        for (i = 1; i < n - 1; i++)
        {
            l[i + (i - 1) * n] = -1.0 / h / h;
            l[i + i * n] = 2.0 / h / h;
            l[i + (i + 1) * n] = -1.0 / h / h;
        }

        i = n - 1;
        l[i + (i - 1) * n] = -1.0 / h / h;
        l[i + i * n] = 2.0 / h / h;

        return l;
    }

    public static double[] l1dd_inverse(int n, double h)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    L1DD_INVERSE stores the inverse of the 1D DD Laplacian.
        //
        //  Discussion:
        //
        //    The N grid points are assumed to be evenly spaced by H.
        //
        //    For N = 5, the discrete Laplacian with Dirichlet boundary conditions
        //    at both ends of [0,6] has the matrix form L:
        //
        //       2 -1  0  0  0
        //      -1  2 -1  0  0
        //       0 -1  2 -1  0
        //       0  0 -1  2 -1
        //       0  0  0 -1  2
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    30 October 2013
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int N, the number of points.
        //    N must be at least 3.
        //
        //    Input, double H, the spacing between points.
        //
        //    Output, double L1DD_INVERSE[N*N], the inverse of the Laplacian matrix.
        //
    {
        int j;

        switch (n)
        {
            case < 3:
                Console.WriteLine("");
                Console.WriteLine("L1DD_INVERSE - Fatal error!");
                Console.WriteLine("  N < 3.");
                return null;
        }

        double[] l = new double[n * n];

        for (j = 0; j < n; j++)
        {
            int i;
            for (i = 0; i < n; i++)
            {
                l[i + j * n] = Math.Min(i + 1, j + 1) * (n - Math.Max(i, j))
                                                      * h * h / (n + 1);
            }
        }

        return l;
    }

    public static void l1dd_lu(int n, double h, ref double[] l, ref double[] u)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    L1DD_LU computes the LU factors of the 1D DD Laplacian.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    01 November 2013
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, int N, the number of points.
        //    N must be at least 3.
        //
        //    Input, double H, the spacing between points.
        //
        //    Output, double L[N*N], U[N*N], the LU factors.
        //
    {
        int i;
        double i_r8;
        int j;

        switch (n)
        {
            case < 3:
                Console.WriteLine("");
                Console.WriteLine("L1DD_LU - Fatal error!");
                Console.WriteLine("  N < 3.");
                return;
        }

        for (j = 0; j < n; j++)
        {
            for (i = 0; i < n; i++)
            {
                l[i + j * n] = 0.0;
            }
        }

        for (i = 0; i < n; i++)
        {
            l[i + i * n] = 1.0;
        }

        for (i = 1; i < n; i++)
        {
            i_r8 = i + 1;
            l[i + (i - 1) * n] = -(i_r8 - 1.0) / i_r8;
        }

        for (j = 0; j < n; j++)
        {
            for (i = 0; i < n; i++)
            {
                l[i + j * n] /= h;
            }
        }

        for (j = 0; j < n; j++)
        {
            for (i = 0; i < n; i++)
            {
                u[i + j * n] = 0.0;
            }
        }

        for (i = 0; i < n; i++)
        {
            i_r8 = i + 1;
            u[i + i * n] = (i_r8 + 1.0) / i_r8;
        }

        for (i = 0; i < n - 1; i++)
        {
            u[i + (i + 1) * n] = -1.0;
        }

        for (j = 0; j < n; j++)
        {
            for (i = 0; i < n; i++)
            {
                u[i + j * n] /= h;
            }
        }
    }
}