﻿using Burkardt.Types;

namespace Burkardt.Square;

public static partial class MinimalRule
{
    public static double[] smr24()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    SMR24 returns the SMR rule of degree 24.
        //
        //  Discussion:
        //
        //    DEGREE: 24
        //    POINTS CARDINALITY: 109
        //    NORM INF MOMS. RESIDUAL: 1.33227e-15
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
        //    Output, double *SMR24[3*109], the requested rule.
        //
    {
        const int degree = 24;
        double[] xw =
        {
            -9.947552488434938e-01, -4.385704490896414e-01, 2.698557791124145e-03,
            -9.931097629772323e-01, 6.703739358435329e-01, 7.377682774083533e-03,
            -9.926803856666530e-01, 2.074620875386726e-01, 6.953676686934647e-03,
            -9.906389564778285e-01, 9.389787594673664e-01, 4.005676169355294e-03,
            -9.853982980908041e-01, -1.546975310338203e-01, 1.391680440670080e-02,
            -9.837508975466611e-01, -8.419003469340943e-01, 8.844680842740435e-03,
            -9.834972384053117e-01, -5.844467591604228e-01, 1.101492580337329e-02,
            -9.818922098458703e-01, -9.808906804560406e-01, 2.833762301624789e-03,
            -9.737197710731226e-01, 3.846778957131831e-01, 1.346113092355880e-02,
            -9.500074961120746e-01, 8.209864656561424e-01, 1.735987104490214e-02,
            -9.403701834437002e-01, 9.898046509843106e-01, 4.134638994139726e-03,
            -9.322891009559756e-01, 6.891056205665078e-02, 3.385109951711678e-02,
            -9.291432442434125e-01, -3.649292941055270e-01, 3.313278955371516e-02,
            -9.278770514198088e-01, 5.372507215773373e-01, 2.595775803019849e-02,
            -9.160984294365914e-01, -7.088454133225529e-01, 2.740072723324332e-02,
            -9.158788280467461e-01, -9.354605631847065e-01, 1.341647825529986e-02,
            -8.614049341981235e-01, 9.223186488292008e-01, 1.828556090710842e-02,
            -8.411326781777169e-01, 2.986796133696130e-01, 5.109735452042367e-02,
            -8.399585109946057e-01, 6.941827653602577e-01, 3.578648643426428e-02,
            -8.284250818876616e-01, -1.413597089673544e-01, 5.450666609336831e-02,
            -8.258893393997301e-01, -9.946839974593770e-01, 5.524951523211650e-03,
            -8.061244501112171e-01, -5.249750016790736e-01, 5.069979449576008e-02,
            -8.039912747312149e-01, -8.393703760802331e-01, 3.118857585337858e-02,
            -7.503800600330690e-01, 9.808995135027622e-01, 1.020614373666720e-02,
            -7.159580396066608e-01, 8.204005009530653e-01, 3.345975676433573e-02,
            -7.066954614920985e-01, 5.015305614605768e-01, 6.001952691278750e-02,
            -6.885485793465114e-01, 9.202328849593100e-02, 7.346166114914886e-02,
            -6.800088501791149e-01, -9.443640836874199e-01, 2.298808927262541e-02,
            -6.560939841533527e-01, -3.083819563661853e-01, 7.136431171052350e-02,
            -6.549319709970016e-01, -6.928080924969605e-01, 5.352097766179938e-02,
            -5.986758659840633e-01, 9.036887631193311e-01, 2.206238875433044e-02,
            -5.440986421726908e-01, 6.690288689480005e-01, 5.524621622310746e-02,
            -5.421013331274553e-01, 9.805973671548335e-01, 1.050046021811538e-02,
            -5.117472121011815e-01, 3.140452735180922e-01, 8.289952810298720e-02,
            -5.059194733599800e-01, -9.837457937119135e-01, 1.096035229919467e-02,
            -4.980272781651189e-01, -8.405454275729934e-01, 4.487909208174960e-02,
            -4.827305043646576e-01, -4.980524078016305e-01, 7.003741329201849e-02,
            -4.657032616378755e-01, -8.311620500718582e-02, 9.203159768871901e-02,
            -3.984335431880944e-01, 7.823560336425450e-01, 3.533735180399633e-02,
            -3.812251842054403e-01, 9.211692018557595e-01, 2.479377740140328e-02,
            -3.254324649968378e-01, -6.106485217368141e-01, 1.987123465724002e-02,
            -3.081376572739211e-01, 5.152565145304252e-01, 8.148061878192561e-02,
            -3.061609471247951e-01, -9.953099499439115e-01, 4.421627578115842e-03,
            -3.040806099754977e-01, -6.945205873058414e-01, 4.874084869821138e-02,
            -3.040627168926376e-01, -9.238254614973810e-01, 2.731221830374910e-02,
            -2.730267547433428e-01, 9.914365779967292e-01, 9.183887978612177e-03,
            -2.548424890251378e-01, -3.019158326395579e-01, 9.514384875199645e-02,
            -2.519554856003144e-01, 1.492385558662303e-01, 1.000641506538448e-01,
            -1.931995209634114e-01, 8.232643617111496e-01, 3.769059900817138e-02,
            -1.885349353760669e-01, -8.893470388562837e-01, 8.285027518755494e-03,
            -1.018544959716391e-01, -7.832201508773523e-01, 4.767805838303123e-02,
            -9.655685106805004e-02, 6.703558020663598e-01, 5.541671674358566e-02,
            -7.901309787694769e-02, -9.687392227645953e-01, 1.819078482187320e-02,
            -7.169337674372403e-02, 9.452615682987324e-01, 2.860240343608491e-02,
            -4.349902330261272e-02, -5.144306594431935e-01, 8.777502677071561e-02,
            -2.884848343031785e-02, -7.515483993225638e-02, 1.033082821984657e-01,
            -1.950518268267537e-02, 3.687032706515938e-01, 9.771287132446460e-02,
            1.000713405257931e-01, -8.778592595775899e-01, 4.025365288851937e-02,
            1.288386576225213e-01, 8.499166400570952e-01, 4.727125786790465e-02,
            1.307155265497598e-01, -9.938241813833318e-01, 7.039833852159185e-03,
            1.308425147211156e-01, 6.526807421421726e-01, 4.979273601404909e-02,
            1.451164406166477e-01, 9.905591807186089e-01, 1.078258330904423e-02,
            1.853995153478054e-01, -3.035646033025806e-01, 9.690391758696711e-02,
            1.943247761163270e-01, -6.769527305130935e-01, 7.109638809439672e-02,
            2.052879132552834e-01, 1.494567879060908e-01, 1.010903998636895e-01,
            2.768585369952569e-01, 5.067311062472540e-01, 6.479712852470575e-02,
            3.149836876173980e-01, -9.498509878332206e-01, 2.600605597250065e-02,
            3.466439434503832e-01, 9.410184803711036e-01, 2.912818672968244e-02,
            3.903088921667896e-01, 4.250693093572162e-01, 2.571049499832495e-02,
            3.993865541451484e-01, 7.683264787575288e-01, 5.493699586057709e-02,
            4.086593369430472e-01, -4.969944946335217e-01, 7.910634640474691e-02,
            4.120045473805335e-01, -8.379854233451292e-02, 9.482614431233395e-02,
            4.170298041496714e-01, -8.110827678737819e-01, 5.059001095427527e-02,
            4.991948804043371e-01, 2.844383580006540e-01, 7.600131857765238e-02,
            5.215718300412919e-01, -9.911476542754794e-01, 8.938791600642888e-03,
            5.358795456370800e-01, 9.892706596240752e-01, 9.652257973711614e-03,
            5.675663650098263e-01, 6.269930547839709e-01, 5.565333636824790e-02,
            6.083113501735691e-01, -6.671573460757463e-01, 5.724631842495273e-02,
            6.091213803480886e-01, -3.002786277521432e-01, 7.620974249495195e-02,
            6.098130539524327e-01, 8.880641734983817e-01, 3.607781947134865e-02,
            6.133229089892412e-01, -9.115716813284614e-01, 2.976045072649638e-02,
            6.644692975845461e-01, 7.278284636752541e-02, 7.402473800633137e-02,
            7.058360022640749e-01, 4.736368348307747e-01, 5.128474162165504e-02,
            7.603978094655672e-01, 7.687530787837937e-01, 3.987086504850027e-02,
            7.680081930648918e-01, 9.719796486153569e-01, 1.425802911781755e-02,
            7.730566152310493e-01, -8.076103665001979e-01, 3.513944563783513e-02,
            7.740524973445363e-01, -5.000787609526253e-01, 5.331933422231531e-02,
            7.765031539359070e-01, -9.744702466310179e-01, 1.298770336406751e-02,
            8.105891537849745e-01, -1.496106096240346e-01, 5.659879783131575e-02,
            8.136030860267544e-01, 2.997934729123835e-01, 4.597071032159282e-02,
            8.738296548638522e-01, 6.252207344858673e-01, 3.235229209061567e-02,
            8.820767009721266e-01, 8.997350185706089e-01, 1.969080467560540e-02,
            8.968725800328660e-01, -6.749357059674395e-01, 3.049246549718226e-02,
            9.008567820439595e-01, -9.076509501580650e-01, 1.724041843190777e-02,
            9.036351991894711e-01, 1.066673951092828e-01, 3.553262749083069e-02,
            9.194113498715898e-01, -3.652426921938732e-01, 3.438229944741761e-02,
            9.235901436599459e-01, 4.967015317618840e-01, 1.373744804296171e-02,
            9.328830195971040e-01, -9.941380940892665e-01, 2.989382978667606e-03,
            9.404372628037821e-01, 9.889603686778536e-01, 4.443564861581591e-03,
            9.607926125333919e-01, 7.879019305115507e-01, 1.649904214759328e-02,
            9.627435059550357e-01, 3.759293384523862e-01, 1.893234461167443e-02,
            9.661246051400586e-01, -9.321465960805159e-02, 2.021199306716822e-02,
            9.772105063681134e-01, -8.054188902050837e-01, 1.143950510739337e-02,
            9.818083790572272e-01, -5.613562549296841e-01, 1.303588980687769e-02,
            9.873606864519788e-01, -9.558632391723191e-01, 3.650162385277064e-03,
            9.909481727417117e-01, 9.350098107984304e-01, 4.199764168210779e-03,
            9.933228865506706e-01, 1.717028973685849e-01, 7.977198513429708e-03,
            9.934734927244968e-01, 6.113673375988821e-01, 7.151800672626832e-03,
            9.958206097496789e-01, -2.883979781434184e-01, 5.617961121686336e-03
        };

        int order = square_minimal_rule_order(degree);
        double[] xw_copy = typeMethods.r8mat_copy_new(3, order, xw);

        return xw_copy;
    }
}