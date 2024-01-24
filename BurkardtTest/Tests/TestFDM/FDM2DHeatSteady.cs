using System.Globalization;
using Burkardt.FDM;
using Burkardt.Types;

namespace Burkardt_Tests.TestFDM;

public class FDM2DHeatSteadyTest
{
    [Test]
    public static void test01()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 computes the solution for a steady state heat equation problem.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    29 August 2013
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        const string command_filename = "test01_commands.txt";
        List<string> command_unit = new();
        const string data_filename = "test01_data.txt";
        List<string> data_unit = new();
        int i;
        int j;
        //
        //  Specify the spatial grid.
        //
        const int nx = 41;
        double[] xvec = typeMethods.r8vec_linspace_new(nx, 0.0, 2.0);

        const int ny = 21;
        double[] yvec = typeMethods.r8vec_linspace_new(ny, 0.0, 1.0);

        double[] xmat = new double[nx * ny];
        double[] ymat = new double[nx * ny];
        typeMethods.r8vec_mesh_2d(nx, ny, xvec, yvec, ref xmat, ref ymat);
        //
        //  Solve the finite difference approximation to the steady 2D heat equation.
        //
        double[] umat = FD2D_Heat_Steady.fd2d_heat_steady(nx, ny, xvec, yvec, d, f);
        //
        //  Create a data file.
        //
        for (j = 0; j < ny; j++)
        {
            for (i = 0; i < nx; i++)
            {
                data_unit.Add("  " + xmat[i + j * nx].ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + ymat[i + j * nx].ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + umat[i + j * nx].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "");
            }

            data_unit.Add("");
        }
            
        File.WriteAllLines(data_filename, data_unit);

        Console.WriteLine("");
        Console.WriteLine("  Created graphics data file '" + data_filename + "'");
        //
        //  Create the command file.
        //

        command_unit.Add("# " + command_filename + "");
        command_unit.Add("#");
        command_unit.Add("# Usage:");
        command_unit.Add("#  gnuplot < " + command_filename + "");
        command_unit.Add("#");
        command_unit.Add("set term png");
        command_unit.Add("set output 'test01.png'");
        command_unit.Add("set xlabel '<---X--->'");
        command_unit.Add("set ylabel '<---Y--->'");
        command_unit.Add("set zlabel '<---U(X,Y)--->'");
        command_unit.Add("set title 'Sample Solution'");
        command_unit.Add("set contour");
        command_unit.Add("set timestamp");
        command_unit.Add("set cntrparam levels 10");
        command_unit.Add("set view 75, 75");
        command_unit.Add("unset key");
        command_unit.Add("splot '" + data_filename + "'");

        File.WriteAllLines(command_filename, command_unit);
            
        Console.WriteLine("  Created graphics command file '" + command_filename + "'");
        //
        //  Report the average value of U.
        //
        double u_mean = 0.0;
        for (j = 0; j < ny; j++)
        {
            for (i = 0; i < nx; i++)
            {
                u_mean += umat[i + j * nx];
            }
        }

        u_mean /= nx * ny;

        Console.WriteLine("");
        Console.WriteLine("  Mean value of U is " + u_mean + "");
    }

    private static double d(double x, double y)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    D evaluates the heat conductivity coefficient.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    29 August 2013
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, double X, Y, the evaluation point.
        //
        //    Output, double D, the value of the heat conductivity at (X,Y).
        //
    {
        const double value = 1.0;

        return value;
    }

    private static double f(double x, double y)

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    F evaluates the heat source term.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    29 August 2013
        //
        //  Author:
        //
        //    John Burkardt
        //
        //  Parameters:
        //
        //    Input, double X, Y, the evaluation point.
        //
        //    Output, double F, the value of the heat source term at (X,Y).
        //
    {
        const double value = 0.0;

        return value;
    }
}