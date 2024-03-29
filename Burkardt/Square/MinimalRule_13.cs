﻿using Burkardt.Types;

namespace Burkardt.Square;

public static partial class MinimalRule
{
    public static double[] smr13()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    SMR13 returns the SMR rule of degree 13.
        //
        //  Discussion:
        //
        //    DEGREE: 13
        //    ROTATIONALLY INVARIANT: (X,Y),(-Y,X),(-X,-Y),(Y,-X).
        //    POINTS CARDINALITY: 33
        //    NORM INF MOMS. RESIDUAL: 8.88178e-16
        //    SUM NEGATIVE WEIGHTS: 0.00000e+00,
        // 
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    21 February 2018
        //
        //  Author:
        //
        //    Original MATLAB version by Mattia Festa, Alvise Sommariva,
        //    C++ version by John Burkardt.
        //
        //  Reference:
        //
        //    Mattia Festa, Alvise Sommariva,
        //    Computing almost minimal formulas on the square,
        //    Journal of Computational and Applied Mathematics,
        //    Volume 17, Number 236, November 2012, pages 4296-4302.
        //
        //  Parameters:
        //
        //    Output, double *SMR13[3*33], the requested rule.
        //
    {
        const int degree = 13;
        double[] xw =
        {
            4.758086252182755e-01, 8.500766736997488e-01, 1.188446673005955e-01,
            3.427165560404069e-01, 4.093045616940387e-01, 2.568707494819678e-01,
            7.558053565720811e-01, 6.478216371870110e-01, 1.297635503700028e-01,
            9.413272258729251e-01, 3.907362161294611e-01, 7.749273853310545e-02,
            9.572976997863074e-01, 8.595560056416388e-01, 3.817442131708364e-02,
            7.788097115544195e-01, 9.834866824398723e-01, 2.999183886449914e-02,
            -7.074150899644469e-02, 6.962500784917494e-01, 2.133415814571894e-01,
            1.381834598624650e-01, 9.589251702875350e-01, 6.042492381774981e-02,
            -8.500766736997488e-01, 4.758086252182755e-01, 1.188446673005955e-01,
            -4.093045616940387e-01, 3.427165560404069e-01, 2.568707494819678e-01,
            -6.478216371870110e-01, 7.558053565720811e-01, 1.297635503700028e-01,
            -3.907362161294611e-01, 9.413272258729251e-01, 7.749273853310545e-02,
            -8.595560056416388e-01, 9.572976997863074e-01, 3.817442131708364e-02,
            -9.834866824398723e-01, 7.788097115544195e-01, 2.999183886449914e-02,
            -6.962500784917494e-01, -7.074150899644469e-02, 2.133415814571894e-01,
            -9.589251702875350e-01, 1.381834598624650e-01, 6.042492381774981e-02,
            -4.758086252182755e-01, -8.500766736997488e-01, 1.188446673005955e-01,
            -3.427165560404069e-01, -4.093045616940387e-01, 2.568707494819678e-01,
            -7.558053565720811e-01, -6.478216371870110e-01, 1.297635503700028e-01,
            -9.413272258729251e-01, -3.907362161294611e-01, 7.749273853310545e-02,
            -9.572976997863074e-01, -8.595560056416388e-01, 3.817442131708364e-02,
            -7.788097115544195e-01, -9.834866824398723e-01, 2.999183886449914e-02,
            7.074150899644469e-02, -6.962500784917494e-01, 2.133415814571894e-01,
            -1.381834598624650e-01, -9.589251702875350e-01, 6.042492381774981e-02,
            8.500766736997488e-01, -4.758086252182755e-01, 1.188446673005955e-01,
            4.093045616940387e-01, -3.427165560404069e-01, 2.568707494819678e-01,
            6.478216371870110e-01, -7.558053565720811e-01, 1.297635503700028e-01,
            3.907362161294611e-01, -9.413272258729251e-01, 7.749273853310545e-02,
            8.595560056416388e-01, -9.572976997863074e-01, 3.817442131708364e-02,
            9.834866824398723e-01, -7.788097115544195e-01, 2.999183886449914e-02,
            6.962500784917494e-01, 7.074150899644469e-02, 2.133415814571894e-01,
            9.589251702875350e-01, -1.381834598624650e-01, 6.042492381774981e-02,
            0.000000000000000e+00, 0.000000000000000e+00, 3.003821154312253e-01
        };

        int order = square_minimal_rule_order(degree);
        double[] xw_copy = typeMethods.r8mat_copy_new(3, order, xw);

        return xw_copy;
    }
}