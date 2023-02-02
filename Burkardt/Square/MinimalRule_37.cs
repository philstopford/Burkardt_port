﻿using Burkardt.Types;

namespace Burkardt.Square;

public static partial class MinimalRule
{
    public static double[] smr37()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    SMR37 returns the SMR rule of degree 37.
        //
        //  Discussion:
        // 
        //    DEGREE: 37
        //    ROTATIONALLY INVARIANT: (X,  Y),  (-Y,  X),  (-X, -Y),  (Y, -X).
        //    POINTS CARDINALITY: 245
        //    NORM INF MOMS. RESIDUAL: 1.97628e-15
        //    SUM NEGATIVE WEIGHTS: 0.00000e+00,  
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license.
        //
        //  Modified:
        //
        //    22 February 2018
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
        //    Output, double *SMR37[3*245], the requested rule.
        //
    {
        const int degree = 37;
        double[] xw =
        {
            1.688689515698905e-01, 1.899855310442196e-01, 1.879076889689011e-02,
            1.664922672701527e-01, 3.429140133623845e-01, 3.449917667815708e-02,
            1.789345703476781e-01, 5.923725055750423e-01, 3.712580251685875e-02,
            1.912828097143278e-01, 8.047865391631479e-01, 2.804589806906416e-02,
            1.909000554810340e-01, 9.526563151843329e-01, 1.317147780067464e-02,
            1.197461382570857e-01, 9.934656721499447e-01, 3.246786042836229e-03,
            3.142942982925143e-01, 1.085212763112808e-01, 4.073944662145704e-02,
            3.136430658350363e-01, 3.168853969514266e-01, 1.888769495196758e-02,
            3.257592735310023e-01, 4.744364447040339e-01, 3.338316795412049e-02,
            3.370767611845376e-01, 7.018261748212855e-01, 3.160597567460757e-02,
            3.228638369287264e-01, 8.961218476259737e-01, 1.882298564453669e-02,
            3.240794429041066e-01, 9.907076643667728e-01, 5.242591968441962e-03,
            4.573043899331568e-01, 2.595246348757670e-01, 3.729781542768577e-02,
            4.752591359356870e-01, 4.488205755197494e-01, 1.479677650128667e-02,
            4.758333073820230e-01, 5.902241348085835e-01, 2.899670157191689e-02,
            5.652930131354381e-01, 7.267134552411152e-01, 2.191839430308059e-02,
            4.508159401323132e-01, 8.204509229358563e-01, 2.228800060943608e-02,
            4.475176031554735e-01, 9.598714005292409e-01, 1.115771006747028e-02,
            5.961940658067776e-01, 1.285519929807882e-01, 3.745963783702447e-02,
            5.958894993059283e-01, 4.008434952939153e-01, 3.161819475642853e-02,
            6.758517622961954e-01, 5.420453939309517e-01, 1.197569541821857e-02,
            6.440973695595638e-01, 6.074025740384232e-01, 1.687104351509356e-02,
            6.599539606557937e-01, 8.196857529727558e-01, 1.433025041492978e-02,
            5.662112657592980e-01, 9.051653639016278e-01, 1.517136608765207e-02,
            6.604704311527990e-01, 9.545232264955925e-01, 5.954681784138311e-03,
            5.550021925411663e-01, 9.938020253544084e-01, 3.779613188841330e-03,
            7.175598471168050e-01, 2.730403569607258e-01, 3.181466382684873e-02,
            7.689529149485085e-01, 4.849501945095196e-01, 2.205707035359098e-02,
            7.225244519379806e-01, 7.346670194240615e-01, 8.555695820639366e-03,
            7.402191126180568e-01, 8.767789551273115e-01, 1.086516778783751e-02,
            6.901879840655373e-01, 9.774065816278240e-01, 4.413949586651726e-03,
            8.145402907615753e-01, 1.194770600468978e-01, 2.773238005998524e-02,
            8.468674880069054e-01, 3.677292203050513e-01, 2.040170735025986e-02,
            7.709894430969280e-01, 6.883167579089596e-01, 1.537385690938401e-02,
            8.412324448391584e-01, 8.049116063955287e-01, 1.469009646857076e-02,
            8.046126375110838e-01, 9.350177341085882e-01, 8.737871041426535e-03,
            7.820614187450875e-01, 9.953174665105079e-01, 2.315496884250784e-03,
            9.508079160816079e-01, 1.063127388777120e-01, 1.140349599008745e-02,
            9.083772470189286e-01, 2.392578185017081e-01, 1.649605664974265e-02,
            8.623376059969516e-01, 6.074887398627125e-01, 1.799944191342780e-02,
            9.049650989085555e-01, 8.906584714348453e-01, 8.885404075061408e-03,
            9.414987804698027e-01, 9.972662607622250e-01, 1.012999506114864e-03,
            8.784002089990299e-01, 9.767224278002355e-01, 4.609542770434277e-03,
            9.277718380370786e-01, 4.868377946168942e-01, 1.482235294209374e-02,
            9.740284280473888e-01, 6.153952571724473e-01, 8.444452079041077e-03,
            9.261384032176685e-01, 7.279402581589705e-01, 1.230535711494119e-02,
            9.679546133670914e-01, 8.320886256235162e-01, 6.228411019066719e-03,
            9.563820929391198e-01, 9.496839487816863e-01, 4.116804695327055e-03,
            9.926061411961665e-01, 2.123910718029504e-01, 4.298821847813497e-03,
            9.709143978580982e-01, 3.514215085134095e-01, 9.842825211091850e-03,
            9.964469722990946e-01, 4.826995164323201e-01, 3.063734063870583e-03,
            9.948590950034147e-01, 7.363116181982159e-01, 2.686189437945335e-03,
            9.924033492665334e-01, 8.341694790656329e-01, 4.583425786943879e-04,
            9.936078762597962e-01, 9.109429166275763e-01, 1.832840176946247e-03,
            9.897652124914369e-01, 9.843626854080677e-01, 1.073091219432144e-03,
            3.032916166693916e-02, 1.723425646848686e-01, 3.655713458299797e-02,
            2.217294601980654e-02, 4.663686154054668e-01, 4.027271183981319e-02,
            2.814942665710626e-02, 7.102048981913600e-01, 3.373438958414005e-02,
            4.438627067827642e-02, 8.900063168860698e-01, 2.195827523559744e-02,
            6.744822333126831e-03, 9.762502292316360e-01, 5.490273279461521e-03,
            -4.982446329191517e-02, 9.956312481563887e-01, 1.436535699659639e-03,
            -1.899855310442196e-01, 1.688689515698905e-01, 1.879076889689011e-02,
            -3.429140133623845e-01, 1.664922672701527e-01, 3.449917667815708e-02,
            -5.923725055750423e-01, 1.789345703476781e-01, 3.712580251685875e-02,
            -8.047865391631479e-01, 1.912828097143278e-01, 2.804589806906416e-02,
            -9.526563151843329e-01, 1.909000554810340e-01, 1.317147780067464e-02,
            -9.934656721499447e-01, 1.197461382570857e-01, 3.246786042836229e-03,
            -1.085212763112808e-01, 3.142942982925143e-01, 4.073944662145704e-02,
            -3.168853969514266e-01, 3.136430658350363e-01, 1.888769495196758e-02,
            -4.744364447040339e-01, 3.257592735310023e-01, 3.338316795412049e-02,
            -7.018261748212855e-01, 3.370767611845376e-01, 3.160597567460757e-02,
            -8.961218476259737e-01, 3.228638369287264e-01, 1.882298564453669e-02,
            -9.907076643667728e-01, 3.240794429041066e-01, 5.242591968441962e-03,
            -2.595246348757670e-01, 4.573043899331568e-01, 3.729781542768577e-02,
            -4.488205755197494e-01, 4.752591359356870e-01, 1.479677650128667e-02,
            -5.902241348085835e-01, 4.758333073820230e-01, 2.899670157191689e-02,
            -7.267134552411152e-01, 5.652930131354381e-01, 2.191839430308059e-02,
            -8.204509229358563e-01, 4.508159401323132e-01, 2.228800060943608e-02,
            -9.598714005292409e-01, 4.475176031554735e-01, 1.115771006747028e-02,
            -1.285519929807882e-01, 5.961940658067776e-01, 3.745963783702447e-02,
            -4.008434952939153e-01, 5.958894993059283e-01, 3.161819475642853e-02,
            -5.420453939309517e-01, 6.758517622961954e-01, 1.197569541821857e-02,
            -6.074025740384232e-01, 6.440973695595638e-01, 1.687104351509356e-02,
            -8.196857529727558e-01, 6.599539606557937e-01, 1.433025041492978e-02,
            -9.051653639016278e-01, 5.662112657592980e-01, 1.517136608765207e-02,
            -9.545232264955925e-01, 6.604704311527990e-01, 5.954681784138311e-03,
            -9.938020253544084e-01, 5.550021925411663e-01, 3.779613188841330e-03,
            -2.730403569607258e-01, 7.175598471168050e-01, 3.181466382684873e-02,
            -4.849501945095196e-01, 7.689529149485085e-01, 2.205707035359098e-02,
            -7.346670194240615e-01, 7.225244519379806e-01, 8.555695820639366e-03,
            -8.767789551273115e-01, 7.402191126180568e-01, 1.086516778783751e-02,
            -9.774065816278240e-01, 6.901879840655373e-01, 4.413949586651726e-03,
            -1.194770600468978e-01, 8.145402907615753e-01, 2.773238005998524e-02,
            -3.677292203050513e-01, 8.468674880069054e-01, 2.040170735025986e-02,
            -6.883167579089596e-01, 7.709894430969280e-01, 1.537385690938401e-02,
            -8.049116063955287e-01, 8.412324448391584e-01, 1.469009646857076e-02,
            -9.350177341085882e-01, 8.046126375110838e-01, 8.737871041426535e-03,
            -9.953174665105079e-01, 7.820614187450875e-01, 2.315496884250784e-03,
            -1.063127388777120e-01, 9.508079160816079e-01, 1.140349599008745e-02,
            -2.392578185017081e-01, 9.083772470189286e-01, 1.649605664974265e-02,
            -6.074887398627125e-01, 8.623376059969516e-01, 1.799944191342780e-02,
            -8.906584714348453e-01, 9.049650989085555e-01, 8.885404075061408e-03,
            -9.972662607622250e-01, 9.414987804698027e-01, 1.012999506114864e-03,
            -9.767224278002355e-01, 8.784002089990299e-01, 4.609542770434277e-03,
            -4.868377946168942e-01, 9.277718380370786e-01, 1.482235294209374e-02,
            -6.153952571724473e-01, 9.740284280473888e-01, 8.444452079041077e-03,
            -7.279402581589705e-01, 9.261384032176685e-01, 1.230535711494119e-02,
            -8.320886256235162e-01, 9.679546133670914e-01, 6.228411019066719e-03,
            -9.496839487816863e-01, 9.563820929391198e-01, 4.116804695327055e-03,
            -2.123910718029504e-01, 9.926061411961665e-01, 4.298821847813497e-03,
            -3.514215085134095e-01, 9.709143978580982e-01, 9.842825211091850e-03,
            -4.826995164323201e-01, 9.964469722990946e-01, 3.063734063870583e-03,
            -7.363116181982159e-01, 9.948590950034147e-01, 2.686189437945335e-03,
            -8.341694790656329e-01, 9.924033492665334e-01, 4.583425786943879e-04,
            -9.109429166275763e-01, 9.936078762597962e-01, 1.832840176946247e-03,
            -9.843626854080677e-01, 9.897652124914369e-01, 1.073091219432144e-03,
            -1.723425646848686e-01, 3.032916166693916e-02, 3.655713458299797e-02,
            -4.663686154054668e-01, 2.217294601980654e-02, 4.027271183981319e-02,
            -7.102048981913600e-01, 2.814942665710626e-02, 3.373438958414005e-02,
            -8.900063168860698e-01, 4.438627067827642e-02, 2.195827523559744e-02,
            -9.762502292316360e-01, 6.744822333126831e-03, 5.490273279461521e-03,
            -9.956312481563887e-01, -4.982446329191517e-02, 1.436535699659639e-03,
            -1.688689515698905e-01, -1.899855310442196e-01, 1.879076889689011e-02,
            -1.664922672701527e-01, -3.429140133623845e-01, 3.449917667815708e-02,
            -1.789345703476781e-01, -5.923725055750423e-01, 3.712580251685875e-02,
            -1.912828097143278e-01, -8.047865391631479e-01, 2.804589806906416e-02,
            -1.909000554810340e-01, -9.526563151843329e-01, 1.317147780067464e-02,
            -1.197461382570857e-01, -9.934656721499447e-01, 3.246786042836229e-03,
            -3.142942982925143e-01, -1.085212763112808e-01, 4.073944662145704e-02,
            -3.136430658350363e-01, -3.168853969514266e-01, 1.888769495196758e-02,
            -3.257592735310023e-01, -4.744364447040339e-01, 3.338316795412049e-02,
            -3.370767611845376e-01, -7.018261748212855e-01, 3.160597567460757e-02,
            -3.228638369287264e-01, -8.961218476259737e-01, 1.882298564453669e-02,
            -3.240794429041066e-01, -9.907076643667728e-01, 5.242591968441962e-03,
            -4.573043899331568e-01, -2.595246348757670e-01, 3.729781542768577e-02,
            -4.752591359356870e-01, -4.488205755197494e-01, 1.479677650128667e-02,
            -4.758333073820230e-01, -5.902241348085835e-01, 2.899670157191689e-02,
            -5.652930131354381e-01, -7.267134552411152e-01, 2.191839430308059e-02,
            -4.508159401323132e-01, -8.204509229358563e-01, 2.228800060943608e-02,
            -4.475176031554735e-01, -9.598714005292409e-01, 1.115771006747028e-02,
            -5.961940658067776e-01, -1.285519929807882e-01, 3.745963783702447e-02,
            -5.958894993059283e-01, -4.008434952939153e-01, 3.161819475642853e-02,
            -6.758517622961954e-01, -5.420453939309517e-01, 1.197569541821857e-02,
            -6.440973695595638e-01, -6.074025740384232e-01, 1.687104351509356e-02,
            -6.599539606557937e-01, -8.196857529727558e-01, 1.433025041492978e-02,
            -5.662112657592980e-01, -9.051653639016278e-01, 1.517136608765207e-02,
            -6.604704311527990e-01, -9.545232264955925e-01, 5.954681784138311e-03,
            -5.550021925411663e-01, -9.938020253544084e-01, 3.779613188841330e-03,
            -7.175598471168050e-01, -2.730403569607258e-01, 3.181466382684873e-02,
            -7.689529149485085e-01, -4.849501945095196e-01, 2.205707035359098e-02,
            -7.225244519379806e-01, -7.346670194240615e-01, 8.555695820639366e-03,
            -7.402191126180568e-01, -8.767789551273115e-01, 1.086516778783751e-02,
            -6.901879840655373e-01, -9.774065816278240e-01, 4.413949586651726e-03,
            -8.145402907615753e-01, -1.194770600468978e-01, 2.773238005998524e-02,
            -8.468674880069054e-01, -3.677292203050513e-01, 2.040170735025986e-02,
            -7.709894430969280e-01, -6.883167579089596e-01, 1.537385690938401e-02,
            -8.412324448391584e-01, -8.049116063955287e-01, 1.469009646857076e-02,
            -8.046126375110838e-01, -9.350177341085882e-01, 8.737871041426535e-03,
            -7.820614187450875e-01, -9.953174665105079e-01, 2.315496884250784e-03,
            -9.508079160816079e-01, -1.063127388777120e-01, 1.140349599008745e-02,
            -9.083772470189286e-01, -2.392578185017081e-01, 1.649605664974265e-02,
            -8.623376059969516e-01, -6.074887398627125e-01, 1.799944191342780e-02,
            -9.049650989085555e-01, -8.906584714348453e-01, 8.885404075061408e-03,
            -9.414987804698027e-01, -9.972662607622250e-01, 1.012999506114864e-03,
            -8.784002089990299e-01, -9.767224278002355e-01, 4.609542770434277e-03,
            -9.277718380370786e-01, -4.868377946168942e-01, 1.482235294209374e-02,
            -9.740284280473888e-01, -6.153952571724473e-01, 8.444452079041077e-03,
            -9.261384032176685e-01, -7.279402581589705e-01, 1.230535711494119e-02,
            -9.679546133670914e-01, -8.320886256235162e-01, 6.228411019066719e-03,
            -9.563820929391198e-01, -9.496839487816863e-01, 4.116804695327055e-03,
            -9.926061411961665e-01, -2.123910718029504e-01, 4.298821847813497e-03,
            -9.709143978580982e-01, -3.514215085134095e-01, 9.842825211091850e-03,
            -9.964469722990946e-01, -4.826995164323201e-01, 3.063734063870583e-03,
            -9.948590950034147e-01, -7.363116181982159e-01, 2.686189437945335e-03,
            -9.924033492665334e-01, -8.341694790656329e-01, 4.583425786943879e-04,
            -9.936078762597962e-01, -9.109429166275763e-01, 1.832840176946247e-03,
            -9.897652124914369e-01, -9.843626854080677e-01, 1.073091219432144e-03,
            -3.032916166693916e-02, -1.723425646848686e-01, 3.655713458299797e-02,
            -2.217294601980654e-02, -4.663686154054668e-01, 4.027271183981319e-02,
            -2.814942665710626e-02, -7.102048981913600e-01, 3.373438958414005e-02,
            -4.438627067827642e-02, -8.900063168860698e-01, 2.195827523559744e-02,
            -6.744822333126831e-03, -9.762502292316360e-01, 5.490273279461521e-03,
            4.982446329191517e-02, -9.956312481563887e-01, 1.436535699659639e-03,
            1.899855310442196e-01, -1.688689515698905e-01, 1.879076889689011e-02,
            3.429140133623845e-01, -1.664922672701527e-01, 3.449917667815708e-02,
            5.923725055750423e-01, -1.789345703476781e-01, 3.712580251685875e-02,
            8.047865391631479e-01, -1.912828097143278e-01, 2.804589806906416e-02,
            9.526563151843329e-01, -1.909000554810340e-01, 1.317147780067464e-02,
            9.934656721499447e-01, -1.197461382570857e-01, 3.246786042836229e-03,
            1.085212763112808e-01, -3.142942982925143e-01, 4.073944662145704e-02,
            3.168853969514266e-01, -3.136430658350363e-01, 1.888769495196758e-02,
            4.744364447040339e-01, -3.257592735310023e-01, 3.338316795412049e-02,
            7.018261748212855e-01, -3.370767611845376e-01, 3.160597567460757e-02,
            8.961218476259737e-01, -3.228638369287264e-01, 1.882298564453669e-02,
            9.907076643667728e-01, -3.240794429041066e-01, 5.242591968441962e-03,
            2.595246348757670e-01, -4.573043899331568e-01, 3.729781542768577e-02,
            4.488205755197494e-01, -4.752591359356870e-01, 1.479677650128667e-02,
            5.902241348085835e-01, -4.758333073820230e-01, 2.899670157191689e-02,
            7.267134552411152e-01, -5.652930131354381e-01, 2.191839430308059e-02,
            8.204509229358563e-01, -4.508159401323132e-01, 2.228800060943608e-02,
            9.598714005292409e-01, -4.475176031554735e-01, 1.115771006747028e-02,
            1.285519929807882e-01, -5.961940658067776e-01, 3.745963783702447e-02,
            4.008434952939153e-01, -5.958894993059283e-01, 3.161819475642853e-02,
            5.420453939309517e-01, -6.758517622961954e-01, 1.197569541821857e-02,
            6.074025740384232e-01, -6.440973695595638e-01, 1.687104351509356e-02,
            8.196857529727558e-01, -6.599539606557937e-01, 1.433025041492978e-02,
            9.051653639016278e-01, -5.662112657592980e-01, 1.517136608765207e-02,
            9.545232264955925e-01, -6.604704311527990e-01, 5.954681784138311e-03,
            9.938020253544084e-01, -5.550021925411663e-01, 3.779613188841330e-03,
            2.730403569607258e-01, -7.175598471168050e-01, 3.181466382684873e-02,
            4.849501945095196e-01, -7.689529149485085e-01, 2.205707035359098e-02,
            7.346670194240615e-01, -7.225244519379806e-01, 8.555695820639366e-03,
            8.767789551273115e-01, -7.402191126180568e-01, 1.086516778783751e-02,
            9.774065816278240e-01, -6.901879840655373e-01, 4.413949586651726e-03,
            1.194770600468978e-01, -8.145402907615753e-01, 2.773238005998524e-02,
            3.677292203050513e-01, -8.468674880069054e-01, 2.040170735025986e-02,
            6.883167579089596e-01, -7.709894430969280e-01, 1.537385690938401e-02,
            8.049116063955287e-01, -8.412324448391584e-01, 1.469009646857076e-02,
            9.350177341085882e-01, -8.046126375110838e-01, 8.737871041426535e-03,
            9.953174665105079e-01, -7.820614187450875e-01, 2.315496884250784e-03,
            1.063127388777120e-01, -9.508079160816079e-01, 1.140349599008745e-02,
            2.392578185017081e-01, -9.083772470189286e-01, 1.649605664974265e-02,
            6.074887398627125e-01, -8.623376059969516e-01, 1.799944191342780e-02,
            8.906584714348453e-01, -9.049650989085555e-01, 8.885404075061408e-03,
            9.972662607622250e-01, -9.414987804698027e-01, 1.012999506114864e-03,
            9.767224278002355e-01, -8.784002089990299e-01, 4.609542770434277e-03,
            4.868377946168942e-01, -9.277718380370786e-01, 1.482235294209374e-02,
            6.153952571724473e-01, -9.740284280473888e-01, 8.444452079041077e-03,
            7.279402581589705e-01, -9.261384032176685e-01, 1.230535711494119e-02,
            8.320886256235162e-01, -9.679546133670914e-01, 6.228411019066719e-03,
            9.496839487816863e-01, -9.563820929391198e-01, 4.116804695327055e-03,
            2.123910718029504e-01, -9.926061411961665e-01, 4.298821847813497e-03,
            3.514215085134095e-01, -9.709143978580982e-01, 9.842825211091850e-03,
            4.826995164323201e-01, -9.964469722990946e-01, 3.063734063870583e-03,
            7.363116181982159e-01, -9.948590950034147e-01, 2.686189437945335e-03,
            8.341694790656329e-01, -9.924033492665334e-01, 4.583425786943879e-04,
            9.109429166275763e-01, -9.936078762597962e-01, 1.832840176946247e-03,
            9.843626854080677e-01, -9.897652124914369e-01, 1.073091219432144e-03,
            1.723425646848686e-01, -3.032916166693916e-02, 3.655713458299797e-02,
            4.663686154054668e-01, -2.217294601980654e-02, 4.027271183981319e-02,
            7.102048981913600e-01, -2.814942665710626e-02, 3.373438958414005e-02,
            8.900063168860698e-01, -4.438627067827642e-02, 2.195827523559744e-02,
            9.762502292316360e-01, -6.744822333126831e-03, 5.490273279461521e-03,
            9.956312481563887e-01, 4.982446329191517e-02, 1.436535699659639e-03,
            0.000000000000000e+00, 0.000000000000000e+00, 2.733962437974891e-02
        };

        int order = square_minimal_rule_order(degree);
        double[] xw_copy = typeMethods.r8mat_copy_new(3, order, xw);

        return xw_copy;
    }
}