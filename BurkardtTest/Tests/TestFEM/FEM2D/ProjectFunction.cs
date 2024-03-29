using System.Globalization;
using Burkardt;
using Burkardt.SolveNS;

namespace Burkardt_Tests.TestFEM.FEM2D;

public class ProjectFunctionTest
{
    [Test]
    public static void test()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main routine of the finite element program FEM2D_PROJECT_FUNCTION.
        //
        //  Discussion:
        //
        //    This program seeks the continuous piecewise linear function U(X,Y) which
        //    minimizes the least squares approximation error to a given function W(X,Y),
        //    while satisfying given boundary conditions.
        //
        //    For basis functions V(x,y), we seek U(x,y) such that
        //
        //      ( U(x,y) - W(x,y), V(x,y) ) = 0
        //
        //    in a rectangular region in the plane.
        //
        //    At nodes on the boundary, exact conditions are imposed:
        //
        //      U(x,y) = W(x,y)
        //
        //    The code uses continuous piecewise linear basis functions on
        //    triangles determined by a uniform grid of NX by NY points.
        //
        //    In this version of the program, the function W is defined as:
        //
        //      W(x,y)  = sin ( pi * x ) * sin ( pi * y ) + x
        //
        //  THINGS YOU CAN EASILY CHANGE:
        //
        //    1) Change NX or NY, the number of nodes in the X and Y directions.
        //    2) Change XL, XR, YB, YT, the left, right, bottom and top limits of the rectangle.
        //    3) Change the exact solution in the EXACT routine.
        //
        //  HARDER TO CHANGE:
        //
        //    4) Change from "linear" to "quadratic" triangles;
        //    5) Change the region from a rectangle to a general triangulated region;
        //    6) Store the matrix as a sparse matrix so you can solve bigger systems.
        //    7) Handle Neumann boundary conditions.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    02 June 2009
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        const int nx = 17;
        const int ny = 17;

        double area;
        int e;
        int i;
        int i1;
        int i2;
        int i3;
        int j;
        int nti1;
        int nti2;
        int nti3;
        double[] q16 = { 0.0, 0.5, 0.5, 4.0 / 6.0, 1.0 / 6.0, 1.0 / 6.0 };
        double[] q26 = { 0.5, 0.0, 0.5, 1.0 / 6.0, 4.0 / 6.0, 1.0 / 6.0 };
        double[] q36 = { 0.5, 0.5, 0.0, 1.0 / 6.0, 1.0 / 6.0, 4.0 / 6.0 };
        double qi;
        int ti1;
        int ti2;
        int ti3;
        double w;
        double[] wq6 = { 1.0 / 30.0, 1.0 / 30.0, 1.0 / 30.0, 9.0 / 30.0, 9.0 / 30.0, 9.0 / 30.0 };
        const double xl = 0.0;
        double xq;
        const double xr = 1.0;
        const double yb = 0.0;
        double yq;
        const double yt = 1.0;

        Console.WriteLine("");
        Console.WriteLine("FEM2D_PROJECT_FUNCTION");
        Console.WriteLine("");
        Console.WriteLine("  Seek U(x,y), the solution of the least squares equation:");
        Console.WriteLine("");
        Console.WriteLine("  Minimize L2 norm of U(x,y) - W(x,y), for W(x,y) given,");
        Console.WriteLine("  with U(x,y) a piecewise linear function in the interior,");
        Console.WriteLine("  and matching W(x,y) on the boundary.");
        Console.WriteLine("");
        Console.WriteLine("  Reformulate this in terms of a finite element problem:");
        Console.WriteLine("");
        Console.WriteLine("  ( U(x,y) - W(x,y), V(x,y) ) = 0 inside the region,");
        Console.WriteLine("    U(x,y)                    = W(x,y) on the boundary");
        Console.WriteLine("");
        Console.WriteLine("  The region is a rectangle, defined by:");
        Console.WriteLine("");
        Console.WriteLine("  " + xl + " = XL<= X <= XR = " + xr + "");
        Console.WriteLine("  " + yb + " = YB<= Y <= YT = " + yt + "");
        Console.WriteLine("");
        Console.WriteLine("  The finite element method is used, with piecewise");
        Console.WriteLine("  linear basis functions on 3 node triangular");
        Console.WriteLine("  elements.");
        Console.WriteLine("");
        Console.WriteLine("  The corner nodes of the triangles are generated by an");
        Console.WriteLine("  underlying grid whose dimensions are");
        Console.WriteLine("");
        Console.WriteLine("  NX =                       " + nx + "");
        Console.WriteLine("  NY =                       " + ny + "");
        //
        //  NODE COORDINATES
        //
        //  Numbering of nodes is suggested by the following 5x10 example:
        //
        //    J=5 | K=41  K=42 ... K=50
        //    ... |
        //    J=2 | K=11  K=12 ... K=20
        //    J=1 | K= 1  K= 2     K=10
        //        +--------------------
        //          I= 1  I= 2 ... I=10
        //
        int node_num = nx * ny;

        Console.WriteLine("  Number of nodes =          " + node_num + "");

        double[] x = new double[node_num];
        double[] y = new double[node_num];

        int k = 0;
        for (j = 1; j <= ny; j++)
        {
            for (i = 1; i <= nx; i++)
            {
                x[k] = ((nx - i) * xl
                        + (i - 1) * xr)
                       / (nx - 1);

                y[k] = ((ny - j) * yb
                        + (j - 1) * yt)
                       / (ny - 1);
                k += 1;
            }
        }

        //
        //  ELEMENT array
        //
        //  Organize the nodes into a grid of 3-node triangles.
        //  Here is part of the diagram for a 5x10 example:
        //
        //    |  \ |  \ |  \ |
        //    |   \|   \|   \|
        //   21---22---23---24--
        //    |\ 8 |\10 |\12 |
        //    | \  | \  | \  |
        //    |  \ |  \ |  \ |  \ |
        //    |  7\|  9\| 11\|   \|
        //   11---12---13---14---15---16---17---18---19---20
        //    |\ 2 |\ 4 |\ 6 |\  8|                   |\ 18|
        //    | \  | \  | \  | \  |                   | \  |
        //    |  \ |  \ |  \ |  \ |      ...          |  \ |
        //    |  1\|  3\|  5\| 7 \|                   |17 \|
        //    1----2----3----4----5----6----7----8----9---10
        //
        int element_num = 2 * (nx - 1) * (ny - 1);

        Console.WriteLine("  Number of elements =       " + element_num + "");

        int[] element_node = new int[3 * element_num];

        k = 0;

        for (j = 1; j <= ny - 1; j++)
        {
            for (i = 1; i <= nx - 1; i++)
            {
                element_node[0 + k * 3] = i + (j - 1) * nx - 1;
                element_node[1 + k * 3] = i + 1 + (j - 1) * nx - 1;
                element_node[2 + k * 3] = i + j * nx - 1;
                k += 1;

                element_node[0 + k * 3] = i + 1 + j * nx - 1;
                element_node[1 + k * 3] = i + j * nx - 1;
                element_node[2 + k * 3] = i + 1 + (j - 1) * nx - 1;
                k += 1;
            }
        }

        //
        //  Assemble the coefficient matrix A and the right-hand side B of the
        //  finite element equations, ignoring boundary conditions.
        //
        double[] a = new double[node_num * node_num];
        double[] b = new double[node_num];

        for (i = 0; i < node_num; i++)
        {
            b[i] = 0.0;
        }

        for (j = 0; j < node_num; j++)
        {
            for (i = 0; i < node_num; i++)
            {
                a[i + j * node_num] = 0.0;
            }
        }

        for (e = 0; e < element_num; e++)
        {
            i1 = element_node[0 + e * 3];
            i2 = element_node[1 + e * 3];
            i3 = element_node[2 + e * 3];
            area = 0.5 *
                   (x[i1] * (y[i2] - y[i3])
                    + x[i2] * (y[i3] - y[i1])
                    + x[i3] * (y[i1] - y[i2]));
            //
            //  Consider each quadrature point.
            //  Here, we use the midside nodes as quadrature points.
            //
            int q1;
            for (q1 = 0; q1 < 3; q1++)
            {
                int q2 = (q1 + 1) % 3;

                int nq1 = element_node[q1 + e * 3];
                int nq2 = element_node[q2 + e * 3];

                xq = 0.5 * (x[nq1] + x[nq2]);
                yq = 0.5 * (y[nq1] + y[nq2]);
                double wq = 1.0 / 3.0;
                //
                //  Consider each test function in the element.
                //
                for (ti1 = 0; ti1 < 3; ti1++)
                {
                    ti2 = (ti1 + 1) % 3;
                    ti3 = (ti1 + 2) % 3;

                    nti1 = element_node[ti1 + e * 3];
                    nti2 = element_node[ti2 + e * 3];
                    nti3 = element_node[ti3 + e * 3];

                    qi = 0.5 * (
                        (x[nti3] - x[nti2]) * (yq - y[nti2])
                        - (y[nti3] - y[nti2]) * (xq - x[nti2])) / area;

                    w = Helpers.exact(xq, yq);

                    b[nti1] += area * wq * (w * qi);
                    //
                    //  Consider each basis function in the element.
                    //
                    int tj1;
                    for (tj1 = 0; tj1 < 3; tj1++)
                    {
                        int tj2 = (tj1 + 1) % 3;
                        int tj3 = (tj1 + 2) % 3;

                        int ntj1 = element_node[tj1 + e * 3];
                        int ntj2 = element_node[tj2 + e * 3];
                        int ntj3 = element_node[tj3 + e * 3];

                        double qj = 0.5 * (
                            (x[ntj3] - x[ntj2]) * (yq - y[ntj2])
                            - (y[ntj3] - y[ntj2]) * (xq - x[ntj2])) / area;

                        a[nti1 + ntj1 * node_num] += area * wq * (qi * qj);
                    }
                }
            }
        }

        //
        //  BOUNDARY CONDITIONS
        //
        //  If the K-th variable is at a boundary node, replace the K-th finite
        //  element equation by a boundary condition that sets the variable to U(K).
        //
        k = 0;
        for (j = 1; j <= ny; j++)
        {
            for (i = 1; i <= nx; i++)
            {
                if (i == 1 || i == nx || j == 1 || j == ny)
                {
                    w = Helpers.exact(x[k], y[k]);
                    int j2;
                    for (j2 = 0; j2 < node_num; j2++)
                    {
                        a[k + j2 * node_num] = 0.0;
                    }

                    a[k + k * node_num] = 1.0;
                    b[k] = w;
                }

                k += 1;
            }
        }

        //  SOLVE the linear system A * C = B.
        //
        //  The solution is returned in C.
        //
        double[] c = Burkardt.SolveNS.Solve.r8ge_fs(node_num, ref a, b);
        //
        //  COMPARE U and W at the grid points only.
        //  Unless W is itself a finite element function, we can't expect these values to
        //  be equal.  But we aren't trying to match the pointwise data.
        //
        Console.WriteLine("");
        Console.WriteLine("     K     I     J          X           Y        U(x,y)          W(x,y)");
        Console.WriteLine("");

        k = 0;

        for (j = 1; j <= ny; j++)
        {
            for (i = 1; i <= nx; i++)
            {
                w = Helpers.exact(x[k], y[k]);

                Console.WriteLine("  " + k.ToString(CultureInfo.InvariantCulture).PadLeft(4)
                                       + "  " + i.ToString(CultureInfo.InvariantCulture).PadLeft(4)
                                       + "  " + j.ToString(CultureInfo.InvariantCulture).PadLeft(4)
                                       + "  " + x[k].ToString(CultureInfo.InvariantCulture).PadLeft(10)
                                       + "  " + y[k].ToString(CultureInfo.InvariantCulture).PadLeft(10)
                                       + "  " + c[k].ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                       + "  " + w.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                       + "  " + Math.Abs(w - c[k]).ToString(CultureInfo.InvariantCulture).PadLeft(14) +
                                       "");

                k += 1;
            }

            Console.WriteLine("");
        }

        //
        //  COMPUTE the L2 norm of U - W over the region.  
        //  This is the quanity we want to be small.
        //
        //  Here, use a 6 point quadrature rule.
        //
        double u_norm = 0.0;
        double w_norm = 0.0;
        double uw_norm = 0.0;

        for (e = 0; e < element_num; e++)
        {
            i1 = element_node[0 + e * 3];
            i2 = element_node[1 + e * 3];
            i3 = element_node[2 + e * 3];

            area = 0.5 *
                   (x[i1] * (y[i2] - y[i3])
                    + x[i2] * (y[i3] - y[i1])
                    + x[i3] * (y[i1] - y[i2]));
            //
            //  Consider each quadrature point.
            //
            int q;
            for (q = 0; q < 6; q++)
            {
                xq = q16[q] * x[i1] + q26[q] * x[i2] + q36[q] * x[i3];
                yq = q16[q] * y[i1] + q26[q] * y[i2] + q36[q] * y[i3];
                //
                //  Inside element E, W is the sum of nodal values B times the basis functions.
                //
                double u = 0.0;

                for (ti1 = 0; ti1 < 3; ti1++)
                {
                    ti2 = (ti1 + 1) % 3;
                    ti3 = (ti1 + 2) % 3;

                    nti1 = element_node[ti1 + e * 3];
                    nti2 = element_node[ti2 + e * 3];
                    nti3 = element_node[ti3 + e * 3];

                    qi = 0.5 * (
                        (x[nti3] - x[nti2]) * (yq - y[nti2])
                        - (y[nti3] - y[nti2]) * (xq - x[nti2])) / area;

                    u += c[i1] * qi;
                }

                w = Helpers.exact(xq, yq);
                //
                //  Add the value of ( U - W )^2 to the quadrature sum.
                //
                u_norm += area * wq6[q] * u * u;
                w_norm += area * wq6[q] * w * w;
                uw_norm += area * wq6[q] * (u - w) * (u - w);
            }
        }

        u_norm = Math.Sqrt(u_norm);
        w_norm = Math.Sqrt(w_norm);
        uw_norm = Math.Sqrt(uw_norm);

        Console.WriteLine("");
        Console.WriteLine("  ||U||   = " + u_norm + "");
        Console.WriteLine("  ||W||   = " + w_norm + "");
        Console.WriteLine("  ||U-W|| = " + uw_norm + "");

        Console.WriteLine("");
        Console.WriteLine("FEM2D_PROJECT_FUNCTION:");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");

    }
}