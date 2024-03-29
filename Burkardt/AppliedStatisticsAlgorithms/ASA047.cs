﻿using System;

namespace Burkardt.AppliedStatistics;

public static partial class Algorithms
{
    public static void nelmin(Func<double[], double> fn, int n, ref double[] start, ref double[] xmin,
            ref double ynewlo, double reqmin, double[] step, int konvge, int kcount,
            ref int icount, ref int numres, ref int ifault)
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    NELMIN minimizes a function using the Nelder-Mead algorithm.
        //
        //  Discussion:
        //
        //    This routine seeks the minimum value of a user-specified function.
        //
        //    Simplex function minimisation procedure due to Nelder+Mead(1965),
        //    as implemented by O'Neill(1971, Appl.Statist. 20, 338-45), with
        //    subsequent comments by Chambers+Ertel(1974, 23, 250-1), Benyon(1976,
        //    25, 97) and Hill(1978, 27, 380-2)
        //
        //    The function to be minimized must be defined by a function of
        //    the form
        //
        //      function fn ( x, f )
        //      double fn
        //      double x(*)
        //
        //    and the name of this subroutine must be declared EXTERNAL in the
        //    calling routine and passed as the argument FN.
        //
        //    This routine does not include a termination test using the
        //    fitting of a quadratic surface.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    27 February 2008
        //
        //  Author:
        //
        //    Original FORTRAN77 version by R ONeill.
        //    C++ version by John Burkardt.
        //
        //  Reference:
        //
        //    John Nelder, Roger Mead,
        //    A simplex method for function minimization,
        //    Computer Journal,
        //    Volume 7, 1965, pages 308-313.
        //
        //    R ONeill,
        //    Algorithm AS 47:
        //    Function Minimization Using a Simplex Procedure,
        //    Applied Statistics,
        //    Volume 20, Number 3, 1971, pages 338-345.
        //
        //  Parameters:
        //
        //    Input, double FN ( double x[] ), the name of the routine which evaluates
        //    the function to be minimized.
        //
        //    Input, int N, the number of variables.
        //
        //    Input/output, double START[N].  On input, a starting point
        //    for the iteration.  On output, this data may have been overwritten.
        //
        //    Output, double XMIN[N], the coordinates of the point which
        //    is estimated to minimize the function.
        //
        //    Output, double YNEWLO, the minimum value of the function.
        //
        //    Input, double REQMIN, the terminating limit for the variance
        //    of function values.
        //
        //    Input, double STEP[N], determines the size and shape of the
        //    initial simplex.  The relative magnitudes of its elements should reflect
        //    the units of the variables.
        //
        //    Input, int KONVGE, the convergence check is carried out 
        //    every KONVGE iterations.
        //
        //    Input, int KCOUNT, the maximum number of function 
        //    evaluations.
        //
        //    Output, int *ICOUNT, the number of function evaluations 
        //    used.
        //
        //    Output, int *NUMRES, the number of restarts.
        //
        //    Output, int *IFAULT, error indicator.
        //    0, no errors detected.
        //    1, REQMIN, N, or KONVGE has an illegal value.
        //    2, iteration terminated because KCOUNT was exceeded without convergence.
        //
    {
        const double ccoeff = 0.5;
        const double ecoeff = 2.0;
        const double eps = 0.001;
        const double rcoeff = 1.0;
        switch (reqmin)
        {
            //
            //  Check the input parameters.
            //
            case <= 0.0:
                ifault = 1;
                return;
        }

        switch (n)
        {
            case < 1:
                ifault = 1;
                return;
        }

        switch (konvge)
        {
            case < 1:
                ifault = 1;
                return;
        }

        double[] p = new double[n * (n + 1)];
        double[] pstar = new double[n];
        double[] p2star = new double[n];
        double[] pbar = new double[n];
        double[] y = new double[n + 1];

        icount = 0;
        numres = 0;

        int jcount = konvge;
        double dn = n;
        int nn = n + 1;
        double dnn = nn;
        double del = 1.0;
        double rq = reqmin * dn;
        //
        //  Initial or restarted loop.
        //
        for (;;)
        {
            for (int i = 0; i < n; i++)
            {
                p[((i + n * n) + p.Length) % p.Length] = start[i % start.Length];
            }

            y[(n + y.Length) % y.Length] = fn(start);
            icount += 1;

            double x;
            for (int j = 0; j < n; j++)
            {
                x = start[j % start.Length];
                start[j % start.Length] += step[j % start.Length] * del;
                for (int i = 0; i < n; i++)
                {
                    p[((i + j * n) + p.Length) % p.Length] = start[i % start.Length];
                }

                y[j % y.Length] = fn(start);
                icount += 1;
                start[j % start.Length] = x;
            }

            //                    
            //  The simplex construction is complete.
            //                    
            //  Find highest and lowest Y values.  YNEWLO = Y(IHI) indicates
            //  the vertex of the simplex to be replaced.
            //                
            double ylo = y[0];
            int ilo = 0;

            for (int i = 1; i < nn; i++)
            {
                if (!(y[i % y.Length] < ylo))
                {
                    continue;
                }

                ylo = y[i % y.Length];
                ilo = i;
            }

            //
            //  Inner loop.
            //
            double z;
            for (;;)
            {
                if (kcount <= icount)
                {
                    break;
                }

                ynewlo = y[0];
                int ihi = 0;

                for (int i = 1; i < nn; i++)
                {
                    if (!(ynewlo < y[i % y.Length]))
                    {
                        continue;
                    }

                    ynewlo = y[i % y.Length];
                    ihi = i;
                }

                //
                //  Calculate PBAR, the centroid of the simplex vertices
                //  excepting the vertex with Y value YNEWLO.
                //
                for (int i = 0; i < n; i++)
                {
                    z = 0.0;
                    for (int j = 0; j < nn; j++)
                    {
                        z += p[((i + j * n) + p.Length) % p.Length];
                    }

                    z -= p[(i + ihi * n) % p.Length];
                    pbar[i % pbar.Length] = z / dn;
                }

                //
                //  Reflection through the centroid.
                //
                for (int i = 0; i < n; i++)
                {
                    pstar[i % pstar.Length] = pbar[i % pbar.Length] + rcoeff * (pbar[i % pbar.Length] - p[((i + ihi * n) + p.Length) % p.Length]);
                }

                double ystar = fn(pstar);
                icount += 1;
                //
                //  Successful reflection, so extension.
                //
                double y2star;
                if (ystar < ylo)
                {
                    for (int i = 0; i < n; i++)
                    {
                        p2star[i % p2star.Length] = pbar[i % pbar.Length] + ecoeff * (pstar[i % pstar.Length] - pbar[i % pbar.Length]);
                    }

                    y2star = fn(p2star);
                    icount += 1;
                    //
                    //  Check extension.
                    //
                    if (ystar < y2star)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            p[((i + ihi * n) + p.Length) % p.Length] = pstar[i % pstar.Length];
                        }

                        y[(ihi + y.Length) % y.Length] = ystar;
                    }
                    //
                    //  Retain extension or contraction.
                    //
                    else
                    {
                        for (int i = 0; i < n; i++)
                        {
                            p[((i + ihi * n) + p.Length) % p.Length] = p2star[i % p2star.Length];
                        }

                        y[ihi % y.Length] = y2star;
                    }
                }
                //
                //  No extension.
                //
                else
                {
                    int l = 0;
                    for (int i = 0; i < nn; i++)
                    {
                        if (ystar < y[i % y.Length])
                        {
                            l += 1;
                        }
                    }

                    switch (l)
                    {
                        case > 1:
                        {
                            for (int i = 0; i < n; i++)
                            {
                                p[((i + ihi * n) + p.Length) % p.Length] = pstar[i % pstar.Length];
                            }

                            y[ihi % y.Length] = ystar;
                            break;
                        }
                        //
                        //  Contraction on the Y(IHI) side of the centroid.
                        //
                        case 0:
                        {
                            for (int i = 0; i < n; i++)
                            {
                                p2star[i % p2star.Length] = pbar[i % pbar.Length] + ccoeff * (p[((i + ihi * n) + p.Length) % p.Length] - pbar[i % pbar.Length]);
                            }

                            y2star = fn(p2star);
                            icount += 1;
                            //
                            //  Contract the whole simplex.
                            //
                            if (y[ihi % y.Length] < y2star)
                            {
                                for (int j = 0; j < nn; j++)
                                {
                                    for (int i = 0; i < n; i++)
                                    {
                                        p[((i + j * n) + p.Length) % p.Length] = (p[((i + j * n) + p.Length) % p.Length] + p[((i + ilo * n) + p.Length) % p.Length]) * 0.5;
                                        xmin[i % xmin.Length] = p[((i + j * n) + p.Length) % p.Length];
                                    }

                                    y[(j + y.Length) % y.Length] = fn(xmin);
                                    icount += 1;
                                }

                                ylo = y[0];
                                ilo = 0;

                                for (int i = 1; i < nn; i++)
                                {
                                    if (!(y[i % y.Length] < ylo))
                                    {
                                        continue;
                                    }

                                    ylo = y[i % y.Length];
                                    ilo = i;
                                }

                                continue;
                            }
                            //
                            //  Retain contraction.
                            //

                            for (int i = 0; i < n; i++)
                            {
                                p[((i + ihi * n) + p.Length) % p.Length] = p2star[i % p2star.Length];
                            }

                            y[ihi % y.Length] = y2star;

                            break;
                        }
                        //
                        //  Contraction on the reflection side of the centroid.
                        //
                        case 1:
                        {
                            for (int i = 0; i < n; i++)
                            {
                                p2star[i % p2star.Length] = pbar[i % pbar.Length] + ccoeff * (pstar[i % pstar.Length] - pbar[i % pbar.Length]);
                            }

                            y2star = fn(p2star);
                            icount += 1;
                            //
                            //  Retain reflection?
                            //
                            if (y2star <= ystar)
                            {
                                for (int i = 0; i < n; i++)
                                {
                                    p[((i + ihi * n) + p.Length) % p.Length] = p2star[i % p2star.Length];
                                }

                                y[ihi] = y2star;
                            }
                            else
                            {
                                for (int i = 0; i < n; i++)
                                {
                                    p[((i + ihi * n) + p.Length) % p.Length] = pstar[i % pstar.Length];
                                }

                                y[ihi % y.Length] = ystar;
                            }

                            break;
                        }
                    }
                }

                //
                //  Check if YLO improved.
                //
                if (y[ihi % y.Length] < ylo)
                {
                    ylo = y[ihi % y.Length];
                    ilo = ihi;
                }

                jcount -= 1;

                switch (jcount)
                {
                    case > 0:
                        continue;
                }

                //
                //  Check to see if minimum reached.
                //
                if (icount > kcount)
                {
                    continue;
                }

                {
                    jcount = konvge;

                    z = 0.0;
                    for (int i = 0; i < nn; i++)
                    {
                        z += y[i % y.Length];
                    }

                    x = z / dnn;

                    z = 0.0;
                    for (int i = 0; i < nn; i++)
                    {
                        z += Math.Pow(y[i % y.Length] - x, 2);
                    }

                    if (z <= rq)
                    {
                        break;
                    }
                }
            }

            //
            //  Factorial tests to check that YNEWLO is a local minimum.
            //
            for (int i = 0; i < n; i++)
            {
                xmin[i % xmin.Length] = p[((i + ilo * n) + p.Length) % p.Length];
            }

            ynewlo = y[(ilo + y.Length) % y.Length];

            if (kcount < icount)
            {
                ifault = 2;
                break;
            }

            ifault = 0;

            for (int i = 0; i < n; i++)
            {
                del = step[i % step.Length] * eps;
                xmin[i % xmin.Length] += del;
                z = fn(xmin);
                icount += 1;
                if (z < ynewlo)
                {
                    ifault = 2;
                    break;
                }

                xmin[i % xmin.Length] = xmin[i % xmin.Length] - del - del;
                z = fn(xmin);
                icount += 1;
                if (z < ynewlo)
                {
                    ifault = 2;
                    break;
                }

                xmin[i % xmin.Length] += del;
            }

            if (ifault == 0)
            {
                break;
            }

            //
            //  Restart the procedure.
            //
            for (int i = 0; i < n; i++)
            {
                start[i % start.Length] = xmin[i % xmin.Length];
            }

            del = eps;
            numres += 1;
        }
    }
}