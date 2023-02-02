﻿using Burkardt.Types;

namespace Burkardt.Square;

public static partial class MinimalRule
{
    public static double[] smr50()

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    SMR50 returns the SMR rule of degree 50.
        //
        //  Discussion:
        // 
        //    DEGREE: 50
        //    POINTS CARDINALITY: 454
        //    NORM INF MOMS. RESIDUAL: 1.97162e-16
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
        //    Output, double *SMR50[3*454], the requested rule.
        //
    {
        const int degree = 50;
        double[] xw =
        {
            -9.985305923732772e-01, 9.480346609653949e-01, 3.637016044890175e-04,
            -9.983266574377337e-01, -7.135200571279965e-01, 8.681375001274842e-04,
            -9.982410599710965e-01, -5.061487385182745e-02, 1.210422814431021e-03,
            -9.981979630190073e-01, 1.943963798210550e-01, 1.209667416017868e-03,
            -9.981164101550407e-01, 4.217828123427281e-01, 1.100221981712261e-03,
            -9.980251256813344e-01, 8.409407151717826e-01, 6.790256958329296e-04,
            -9.978977416561483e-01, -5.175396836215825e-01, 1.209910288842294e-03,
            -9.977749235731450e-01, -8.787383894116004e-01, 6.804808145574241e-04,
            -9.974790513531082e-01, -2.987478462479398e-01, 1.485043396561256e-03,
            -9.973044005791738e-01, 9.966139708183203e-01, 1.024593234561320e-04,
            -9.965354581345114e-01, -9.625283354808352e-01, 5.086867261717252e-04,
            -9.959776528397177e-01, 5.865612330340912e-01, 1.475073552829635e-03,
            -9.958674494848857e-01, 7.184881012827657e-01, 1.314678451882094e-03,
            -9.958634171963171e-01, -9.964330603430479e-01, 1.378555297245596e-04,
            -9.899892964541681e-01, -8.034025241583582e-01, 2.063321727799165e-03,
            -9.890089603003986e-01, -1.607654105825233e-01, 3.171831815687111e-03,
            -9.889269890822903e-01, 9.792253114023887e-01, 6.925166147590135e-04,
            -9.888556249081619e-01, 9.011374451124298e-01, 1.524076231835903e-03,
            -9.883405484188146e-01, 3.140956912031643e-01, 3.326070006645496e-03,
            -9.882926852196964e-01, 7.591140506738633e-02, 3.713229391963024e-03,
            -9.879532633546659e-01, -6.253049497236600e-01, 2.968377985270547e-03,
            -9.862738466801083e-01, -4.136828994040758e-01, 3.792003832590160e-03,
            -9.840867690629249e-01, -9.225459592561057e-01, 1.716688686998262e-03,
            -9.834561801290923e-01, 7.913470127721602e-01, 2.467251464100417e-03,
            -9.829084684207806e-01, 4.958738236441704e-01, 3.605246991559088e-03,
            -9.799751230610935e-01, -9.858070723372447e-01, 8.062256820069726e-04,
            -9.773121022170035e-01, 6.531868802837602e-01, 3.655328649772478e-03,
            -9.727540699799997e-01, -2.463858035039539e-01, 3.968311046518957e-03,
            -9.722508392684289e-01, 2.227204587069684e-01, 2.881691797859937e-03,
            -9.706187607468760e-01, -7.290537686894693e-01, 3.938655209703868e-03,
            -9.704346881779157e-01, 9.463998760417839e-01, 1.815054306514290e-03,
            -9.690510704309230e-01, 9.956152727894065e-01, 4.874122727335260e-04,
            -9.675183125664917e-01, -3.873668624805015e-02, 6.258912209048882e-03,
            -9.670967144416286e-01, -5.346820717217893e-01, 5.020688484630141e-03,
            -9.655166141119431e-01, -8.589490689754655e-01, 3.424882118788690e-03,
            -9.627685982819859e-01, 8.574258075931914e-01, 3.211357083932979e-03,
            -9.611985315766414e-01, 1.735034523650290e-01, 4.470806430187272e-03,
            -9.597845726633061e-01, 3.970047952525823e-01, 6.128594443133615e-03,
            -9.569446290012320e-01, -3.378216199983041e-01, 5.083719898994831e-03,
            -9.565067320986410e-01, -9.583763747944724e-01, 2.042573269760935e-03,
            -9.529509863706143e-01, 7.367253684069424e-01, 4.607147767328114e-03,
            -9.509009916467068e-01, -9.982452717308193e-01, 4.171743785231584e-04,
            -9.498639131139113e-01, 5.672749857805497e-01, 5.975731307616273e-03,
            -9.428689649793603e-01, -6.526060553577299e-01, 5.505889774975882e-03,
            -9.422311181031663e-01, 9.769229657788217e-01, 1.605353293384605e-03,
            -9.375241836457983e-01, -4.577530187027701e-01, 5.705829120945821e-03,
            -9.362131629000300e-01, -1.507446207119618e-01, 8.504765626649076e-03,
            -9.339474938107682e-01, 9.120768210172238e-01, 3.338622941804765e-03,
            -9.316644572520522e-01, -7.908094170683131e-01, 5.751538344933908e-03,
            -9.314325437683882e-01, 7.308639756184374e-02, 8.950456494516651e-03,
            -9.304457837028240e-01, -9.108477682553909e-01, 3.622093803410868e-03,
            -9.262042777363618e-01, 2.926429789075467e-01, 8.847143966496282e-03,
            -9.205873982096271e-01, 8.098896505724084e-01, 5.174844527226764e-03,
            -9.162051560377870e-01, -9.832510479457329e-01, 1.819552993042389e-03,
            -9.145628768323527e-01, -2.911965871109570e-01, 6.354190461823213e-03,
            -9.144568861286890e-01, 6.634543776500917e-01, 6.992029249399327e-03,
            -9.134662288030968e-01, 4.776130498503005e-01, 8.193380404605263e-03,
            -9.126046852400858e-01, 9.959169009245570e-01, 7.303402358793004e-04,
            -9.084013096944704e-01, -5.810944597640583e-01, 6.912234750082650e-03,
            -8.968296850710641e-01, -4.128318260767174e-01, 6.809730423186475e-03,
            -8.963106431292505e-01, 9.531579778618777e-01, 2.914835462196634e-03,
            -8.901833704330284e-01, -8.608019888123171e-01, 5.050561896084555e-03,
            -8.884475404720591e-01, -4.181808934399530e-02, 1.158653342037486e-02,
            -8.859496918290896e-01, -7.137986488176715e-01, 8.297704906842986e-03,
            -8.826270793702349e-01, 8.736037565380022e-01, 4.992525221172924e-03,
            -8.823557325667086e-01, 1.833542443150059e-01, 1.150671440741034e-02,
            -8.803378140572387e-01, -9.483904752475437e-01, 3.713568296274433e-03,
            -8.730496783252757e-01, -2.233431485071996e-01, 9.317119532426758e-03,
            -8.699283953657505e-01, 3.852358620688430e-01, 1.027156006726837e-02,
            -8.698133028410201e-01, 7.486827472812273e-01, 7.596749165870595e-03,
            -8.674834848675760e-01, 5.836354021401285e-01, 9.310768477516692e-03,
            -8.628243813571611e-01, -9.960431212097594e-01, 9.977579306457195e-04,
            -8.624814683206987e-01, 9.841369657891215e-01, 1.842174250748435e-03,
            -8.581906826960382e-01, -5.182071016007672e-01, 9.222800088580358e-03,
            -8.484873092060258e-01, -8.116205306074403e-01, 5.448026047767842e-03,
            -8.375416835189680e-01, 9.244249381249888e-01, 4.359562847763335e-03,
            -8.343496291886240e-01, -3.560928009556643e-01, 1.173308803213457e-02,
            -8.291306871234821e-01, 6.960605157818649e-02, 1.390910739512651e-02,
            -8.281553984054720e-01, -6.382569464166583e-01, 9.693436224505143e-03,
            -8.256425444491163e-01, -9.054076217011587e-01, 5.816411318368521e-03,
            -8.223579984614887e-01, 8.269951489970134e-01, 7.127087970713289e-03,
            -8.215593436322257e-01, 9.981381538674631e-01, 6.329945045794524e-04,
            -8.198483858368308e-01, -1.319278740037157e-01, 1.298320952391481e-02,
            -8.192027189051302e-01, 2.877778785137557e-01, 1.265773788043916e-02,
            -8.172502785117453e-01, -9.750039267897708e-01, 3.134812108850403e-03,
            -8.138299706643672e-01, 4.972544598166810e-01, 1.161528697363953e-02,
            -8.115048842276773e-01, 6.785974006783519e-01, 1.000389489115020e-02,
            -8.033489337701412e-01, -7.623411898836773e-01, 7.618682602864780e-03,
            -7.981451309405014e-01, 9.655610226211084e-01, 3.238149495801071e-03,
            -7.788793515049757e-01, -4.659125664753414e-01, 1.294788836398086e-02,
            -7.676616475483181e-01, 8.903050218772064e-01, 6.412981842164176e-03,
            -7.654405876460623e-01, -2.609719605681909e-01, 1.510691545326006e-02,
            -7.651705117791751e-01, -5.933719404029307e-01, 7.689899801767004e-03,
            -7.610553487070951e-01, -8.537787359055480e-01, 8.005675846962551e-03,
            -7.598494916125437e-01, 1.822273140486022e-01, 1.528388680362909e-02,
            -7.579923742217070e-01, -9.945462254206379e-01, 1.550380002631925e-03,
            -7.554414721363940e-01, 7.704489057786914e-01, 9.613889207061148e-03,
            -7.546303325899156e-01, -2.587451873434423e-02, 1.541716632386868e-02,
            -7.533501105520592e-01, 4.028033457447762e-01, 1.416780003145239e-02,
            -7.512634680369265e-01, -9.427500341739973e-01, 5.278060834005935e-03,
            -7.492677967965817e-01, 9.893278319960217e-01, 1.942720461021166e-03,
            -7.476477835194629e-01, 5.993754192648574e-01, 1.240433786628891e-02,
            -7.384396341741885e-01, -7.049337544138190e-01, 1.019806600177946e-02,
            -7.178686225860993e-01, 9.426175650021613e-01, 5.076879608670298e-03,
            -6.981541470167513e-01, -3.738996976336288e-01, 1.623617174158692e-02,
            -6.930270182761278e-01, -5.503057726865391e-01, 1.252261832635268e-02,
            -6.914007366726129e-01, -1.492403377321120e-01, 1.687175767189600e-02,
            -6.898255514942709e-01, 8.450597437929396e-01, 9.044588739380572e-03,
            -6.878471762364344e-01, -7.980792470880590e-01, 9.683099148036134e-03,
            -6.874914713445559e-01, 9.985765065838036e-01, 5.429828741714135e-04,
            -6.851758646966849e-01, 2.991299533883399e-01, 1.680000628152785e-02,
            -6.841372891501616e-01, -9.759846205669235e-01, 3.792981482377291e-03,
            -6.824533415259976e-01, 7.012478423815675e-01, 1.242282959150627e-02,
            -6.806130791896147e-01, 8.613441527468559e-02, 1.715469593857349e-02,
            -6.782455218903122e-01, 5.106365783701324e-01, 1.495469178663973e-02,
            -6.767016667485439e-01, -9.023128892125745e-01, 7.148516270448834e-03,
            -6.589112285487670e-01, 9.766144758417425e-01, 3.310403467016667e-03,
            -6.511681540558421e-01, -6.631624128792538e-01, 1.080993463231836e-02,
            -6.380516344996316e-01, -9.971292836795032e-01, 1.091941596727160e-03,
            -6.321934701591331e-01, 9.112877114102699e-01, 6.899365963636340e-03,
            -6.189763674514923e-01, -2.549410517879415e-01, 1.680578646075412e-02,
            -6.156902457901138e-01, -4.609743414379315e-01, 1.446782156032898e-02,
            -6.095366081540551e-01, -3.536699015280872e-02, 1.850017035472999e-02,
            -6.064980319841019e-01, 7.855933379724550e-01, 1.191421549804811e-02,
            -6.037838321468384e-01, -8.588880336516307e-01, 7.493653196531501e-03,
            -6.032572636799473e-01, 6.191506051681956e-01, 1.533794488328530e-02,
            -6.029215218823031e-01, 4.121372818661574e-01, 1.746667230493666e-02,
            -6.004670419231046e-01, 2.003417792141365e-01, 1.853576294985650e-02,
            -5.978165937113178e-01, -9.464336654728625e-01, 6.209112452624394e-03,
            -5.973624658830221e-01, -7.522142533728916e-01, 1.070955771848203e-02,
            -5.972383581448467e-01, 9.955134418355728e-01, 1.205515802358963e-03,
            -5.775575710831099e-01, -5.936186239487227e-01, 1.108117334138420e-02,
            -5.716545691484377e-01, 9.586937694828399e-01, 4.477003194366252e-03,
            -5.544501743841143e-01, -9.859194586440739e-01, 2.990668121908608e-03,
            -5.533389067322111e-01, 8.727090179141404e-01, 7.641422231771522e-03,
            -5.508248111710804e-01, -3.360687262652585e-01, 1.326315896795831e-02,
            -5.269836692039951e-01, -1.373273675486175e-01, 1.846993932273529e-02,
            -5.252683048124628e-01, 7.769369828819343e-02, 1.828457505601571e-02,
            -5.232549472077624e-01, -8.262684949558237e-01, 8.105817403692208e-03,
            -5.216149653619029e-01, -4.944286105148744e-01, 1.099366935751496e-02,
            -5.189971990652680e-01, 5.251343160031084e-01, 1.801382551804368e-02,
            -5.187072221708287e-01, 7.127559592388867e-01, 1.475721541133735e-02,
            -5.157523922022348e-01, -6.649848553773774e-01, 1.035112521727110e-02,
            -5.154577487348173e-01, 3.146569819892138e-01, 1.881013777037231e-02,
            -5.121209365416318e-01, 9.881269957126972e-01, 2.581279958818058e-03,
            -5.085478436271724e-01, -9.062214676374273e-01, 7.876549270964693e-03,
            -4.890864408748029e-01, 9.331958642967023e-01, 6.252083630599476e-03,
            -4.830798048819471e-01, 8.307910647681210e-01, 9.069844919775074e-03,
            -4.769568695143335e-01, -7.406437471378572e-01, 9.792607423330369e-03,
            -4.711384868324521e-01, -9.982442886371089e-01, 9.977513750498068e-04,
            -4.670429883275934e-01, -3.837258048261876e-01, 1.481809931562225e-02,
            -4.666978361533338e-01, -9.638780668495475e-01, 5.093634425116185e-03,
            -4.583860333911172e-01, -2.194459707654301e-01, 1.399842259428002e-02,
            -4.488372720482744e-01, 1.852523019019599e-01, 1.562937178489875e-02,
            -4.466182114907417e-01, 1.045052032899272e-02, 9.145117658682660e-03,
            -4.398969646289078e-01, -5.643439180041001e-01, 1.536885553161082e-02,
            -4.286607785443331e-01, 6.284182834880983e-01, 1.704743034990286e-02,
            -4.281803723972377e-01, 4.257307629052356e-01, 1.891821754399137e-02,
            -4.251215127406949e-01, 9.990156228445619e-01, 8.538043330161814e-04,
            -4.118280892991981e-01, 9.714759276031080e-01, 4.880101949369545e-03,
            -4.079009162767762e-01, -8.127761432326117e-01, 9.682944715935253e-03,
            -4.061050423178847e-01, -4.674050637680804e-02, 1.763350006605001e-02,
            -4.056845643788482e-01, -8.739980868114045e-01, 5.900069010534015e-03,
            -4.030307435938099e-01, 7.756488822994984e-01, 1.281187876680621e-02,
            -4.006967431242406e-01, 8.961755809836305e-01, 8.973613291265101e-03,
            -3.916049226821231e-01, -9.273410115124909e-01, 5.297964504333964e-03,
            -3.767714330669960e-01, -6.548167260904730e-01, 9.467239374026879e-03,
            -3.759401992622222e-01, 2.756208903780863e-01, 1.532016187158172e-02,
            -3.755012873186720e-01, -9.871862321784112e-01, 3.250146148554228e-03,
            -3.730541368999579e-01, -7.112556629483213e-01, 7.329934266008029e-03,
            -3.725289366278142e-01, -2.774273474801098e-01, 1.754335020704925e-02,
            -3.672221731554482e-01, -4.498269623849093e-01, 1.635160912830995e-02,
            -3.517016115907431e-01, 5.427475370188103e-01, 1.038435257761881e-02,
            -3.472072906873430e-01, 1.297375715246647e-01, 1.511255362750808e-02,
            -3.288603177035728e-01, 4.816597830509821e-01, 6.559008197617309e-03,
            -3.221265382254779e-01, -1.433656648153948e-01, 1.620111125789070e-02,
            -3.131321362159788e-01, 7.032975112241375e-01, 1.594512703102189e-02,
            -3.082989492612527e-01, -9.578410503896179e-01, 3.982391593695098e-03,
            -3.082247018694904e-01, 9.906739284535425e-01, 2.962374733019264e-03,
            -3.072260057987407e-01, 9.424355086678589e-01, 7.485667285562808e-03,
            -3.062114826214366e-01, -9.347879939525434e-01, 2.589717354994651e-03,
            -3.046631601690127e-01, 8.455016733897478e-01, 1.202814315872106e-02,
            -2.960605213864115e-01, -5.110628541558808e-01, 1.002716095596817e-02,
            -2.917625758358438e-01, 3.593747168154432e-01, 1.837042545246992e-02,
            -2.895557314330913e-01, -6.159501875196743e-01, 1.206000739213904e-02,
            -2.871906599030266e-01, -7.705048149609509e-01, 1.383267273104722e-02,
            -2.859792213471688e-01, -8.714115510524062e-01, 1.038591281351532e-02,
            -2.856503520749610e-01, 5.747007863914991e-02, 1.748058432381039e-02,
            -2.824592805060356e-01, 5.612750161066066e-01, 9.353603746527843e-03,
            -2.728487335032520e-01, -9.975408583725541e-01, 1.264352449742901e-03,
            -2.601809045605671e-01, -3.522853948258879e-01, 2.092850963826799e-02,
            -2.597903214660320e-01, -9.994084053639378e-02, 8.825557728414398e-03,
            -2.256215566562435e-01, 2.283770326898505e-01, 2.160089195520415e-02,
            -2.188098462531380e-01, -2.067500347682650e-01, 1.252332154956301e-02,
            -2.185684926171157e-01, -9.755155987010639e-01, 4.112709587283565e-03,
            -2.053682577466782e-01, 7.806266036689269e-01, 1.501612574781621e-02,
            -2.049162099957439e-01, 6.343543635897640e-01, 1.580531156711188e-02,
            -2.041124215059686e-01, -5.429590922002024e-01, 1.362853247269861e-02,
            -2.002875030215060e-01, 9.009976779341253e-01, 1.031145511059078e-02,
            -1.976029493822827e-01, 9.714461314931776e-01, 5.332016356692966e-03,
            -1.954132400791727e-01, 4.624136298055638e-01, 1.945983666591439e-02,
            -1.879132665032426e-01, -6.925128794555552e-01, 1.703923942906849e-02,
            -1.821951153235339e-01, -1.426582763733243e-02, 1.987409951184996e-02,
            -1.810578998197690e-01, -9.204035043869775e-01, 9.272464757303015e-03,
            -1.774507741267828e-01, 9.978134769969224e-01, 1.228301960791354e-03,
            -1.621404219665848e-01, -8.249452802330807e-01, 1.365662754138641e-02,
            -1.464771076898347e-01, -4.340215233356940e-01, 1.945862436948514e-02,
            -1.460344552467488e-01, -2.429282629387507e-01, 1.565971349603635e-02,
            -1.357303124694478e-01, -9.913278393826657e-01, 2.344766960985844e-03,
            -1.348850451544348e-01, 1.418182577007316e-01, 1.855959179083704e-02,
            -1.178453467617478e-01, 3.462124048386542e-01, 2.128688457301467e-02,
            -1.070963545859648e-01, 5.697167424399421e-01, 1.270219547686097e-02,
            -9.418089864452631e-02, 8.464061176824520e-01, 1.318512157781563e-02,
            -9.284665135473712e-02, 7.115189151497324e-01, 1.693264777896065e-02,
            -8.649884288942110e-02, 9.412721885997597e-01, 7.947036543700148e-03,
            -8.381550837050580e-02, -1.034404718739174e-01, 2.042114347858592e-02,
            -8.132901275144148e-02, -6.047646884556696e-01, 1.901873006719877e-02,
            -7.314393059200233e-02, -9.584726090471121e-01, 6.990580671801756e-03,
            -6.585476015650292e-02, 9.869964307266527e-01, 3.475568911966144e-03,
            -5.940953281811259e-02, -7.531405908206484e-01, 1.610516174433207e-02,
            -5.723571915110250e-02, -3.156995009383814e-01, 1.757545073276317e-02,
            -4.881350872683240e-02, -8.821229556281880e-01, 1.190858000679253e-02,
            -4.623125113800330e-02, -9.984756475663564e-01, 8.661846411096376e-04,
            -4.537127170091439e-02, 5.454245190895872e-01, 7.887365308447648e-03,
            -4.427946025894871e-02, 7.620061393862830e-02, 1.715262718303868e-02,
            -3.652498887773526e-02, -4.854048438229047e-01, 1.164475499560268e-02,
            -2.693515118939117e-02, 4.662758740691014e-01, 1.418575874574526e-02,
            -2.196660636199712e-02, 2.563688847935753e-01, 2.048504486701552e-02,
            1.684869503861126e-02, 9.985028110516669e-01, 8.343196408295555e-04,
            1.937078508280643e-02, 7.845643755910120e-01, 1.528657010406891e-02,
            2.203824694705822e-02, 8.989738024148887e-01, 1.069256626530232e-02,
            2.241772195214512e-02, -1.754589056829656e-01, 1.981467867657729e-02,
            2.975250703736150e-02, 1.862596862025734e-03, 1.586261473431975e-02,
            3.055821004449258e-02, -3.713097808061478e-01, 1.472665339094052e-02,
            3.289324396609741e-02, 6.432956961893939e-01, 1.864369020889923e-02,
            3.723492660056246e-02, -9.844719413983402e-01, 4.259554223135243e-03,
            4.770102526934471e-02, 9.660516213959782e-01, 5.910690727520699e-03,
            4.835037248406306e-02, -6.721798158089920e-01, 1.837739301039192e-02,
            5.239032096709587e-02, -5.201345460249732e-01, 1.609773629036364e-02,
            5.502518798282641e-02, -8.182265682703534e-01, 1.429356112573313e-02,
            5.830896522283972e-02, 4.016909728418846e-01, 1.831359832124226e-02,
            6.198731221349852e-02, -9.303653863405975e-01, 9.255582126803446e-03,
            7.857891643486636e-02, 1.766467214761190e-01, 1.939355213634587e-02,
            1.208356536244954e-01, 3.216785108904378e-01, 9.071620470626165e-03,
            1.208368243862543e-01, -2.541561566739803e-01, 2.021580169628961e-02,
            1.216863587634878e-01, 9.916346904595559e-01, 2.444055246895457e-03,
            1.232655916759636e-01, 5.414949782908248e-01, 1.986491824292366e-02,
            1.241778913712552e-01, -4.978636357670361e-02, 1.834144377738077e-02,
            1.337347631223449e-01, 8.472659711961135e-01, 1.284004194508113e-02,
            1.466010849626561e-01, 7.236699453278207e-01, 1.678250950273756e-02,
            1.496400580028691e-01, -9.975365491819376e-01, 1.471039139180874e-03,
            1.529671602153546e-01, -4.138359329741561e-01, 1.970291306047588e-02,
            1.553076799904455e-01, 9.825333958721993e-02, 1.331862934874382e-02,
            1.564393944563869e-01, 9.341317137357775e-01, 8.329285394320438e-03,
            1.607100339920880e-01, -8.768225824887561e-01, 1.145010706137546e-02,
            1.633664795918194e-01, -5.876766334680318e-01, 1.831745704958468e-02,
            1.649345927645013e-01, -7.456333961574857e-01, 1.658594926267819e-02,
            1.724639115261522e-01, -9.662243526431580e-01, 6.397001220461619e-03,
            1.856135967174529e-01, 3.019753251009087e-01, 1.604124847134084e-02,
            2.207568082418493e-01, -1.341768231114187e-01, 2.201353706987977e-02,
            2.216590623136845e-01, 6.237862843359905e-01, 1.130843281124745e-02,
            2.222728182351477e-01, 9.767149748533738e-01, 4.270350031153890e-03,
            2.251913391882167e-01, 4.515133683755246e-01, 1.961372976506132e-02,
            2.393332091219671e-01, 6.746796047622838e-02, 1.563788629592373e-02,
            2.454323613661074e-01, 9.987765164968539e-01, 8.734893357177072e-04,
            2.489948172638105e-01, 2.049235281953148e-01, 1.270930859704317e-02,
            2.551647790899600e-01, -4.986851928535581e-01, 1.121625142075451e-02,
            2.569501661619921e-01, 7.948735761125491e-01, 1.372820954751759e-02,
            2.586452498793473e-01, -9.219424663897881e-01, 8.044149671331794e-03,
            2.601094175807203e-01, -3.053795751586294e-01, 2.158658189071271e-02,
            2.633547449910876e-01, 8.921977837870594e-01, 1.019013452355202e-02,
            2.654090569206588e-01, 6.495375037274833e-01, 8.750452222218987e-03,
            2.690640635337399e-01, -8.151729320209684e-01, 1.356683615382717e-02,
            2.728833763425947e-01, -6.617494728362482e-01, 1.691235069293519e-02,
            2.832389697359580e-01, -4.580344348270283e-01, 7.865208224812631e-03,
            2.840896766783086e-01, -9.890120421665016e-01, 3.588966784785691e-03,
            3.151693234434736e-01, 9.534401100755432e-01, 5.557418660257084e-03,
            3.260081563690662e-01, -1.795252417843553e-02, 2.146401172038991e-02,
            3.274401122842648e-01, 3.681991260958348e-01, 1.852510306194186e-02,
            3.284833444644465e-01, 2.189215721397187e-01, 1.439774012533690e-02,
            3.337782993016923e-01, 5.444183052791469e-01, 1.768422453882693e-02,
            3.384090593283935e-01, -9.515287291879881e-01, 4.960138634028438e-03,
            3.438984906707113e-01, -5.371780889807538e-01, 1.068695089769454e-02,
            3.446230444324452e-01, 7.190351391805496e-01, 1.249860147037258e-02,
            3.543528388111687e-01, 9.902368488113547e-01, 2.826004111195709e-03,
            3.602282612815438e-01, -1.947302593649046e-01, 2.173836797361481e-02,
            3.612552194216351e-01, -7.319208685947469e-01, 1.249441852526187e-02,
            3.632929794407099e-01, -8.704852750274591e-01, 9.768989552535455e-03,
            3.744793900580320e-01, 8.286415194062603e-01, 6.671271590709352e-03,
            3.860890582535335e-01, -3.839824460224215e-01, 2.092918906725470e-02,
            3.928710017718934e-01, 8.672865777465832e-01, 6.936260220669673e-03,
            3.931996788966815e-01, 9.279235914180360e-01, 5.272293822412451e-03,
            4.007261695646738e-01, 1.223557508548206e-01, 1.739277111294605e-02,
            4.062478163754075e-01, -9.984412635687164e-01, 1.118910221718476e-03,
            4.106255773005774e-01, -5.988996724168920e-01, 1.562901284122264e-02,
            4.123501152038699e-01, 7.367091972519042e-01, 4.909337398435131e-03,
            4.172900522264887e-01, -9.721977396522211e-01, 4.399018232299250e-03,
            4.314957914891770e-01, 4.647378299513769e-01, 1.657826429386184e-02,
            4.317959505632551e-01, -7.839966309166440e-01, 1.002961987603591e-02,
            4.331331185623659e-01, 6.317320218888924e-01, 1.491157542954482e-02,
            4.400703045168821e-01, -9.090920579494268e-01, 6.758378154370627e-03,
            4.413453712232151e-01, 3.026452329003297e-01, 1.816222308777934e-02,
            4.563399517359142e-01, 9.712472856776212e-01, 4.837136504147411e-03,
            4.566101742568825e-01, -8.299751644192108e-02, 2.070092724204458e-02,
            4.600940256413679e-01, 7.358720101030228e-02, 9.566565631101559e-03,
            4.604812529078548e-01, 9.984195308056378e-01, 8.414203442745121e-04,
            4.808602748352557e-01, 7.905645541015534e-01, 1.052995268205664e-02,
            4.827694496186490e-01, -2.738930106938465e-01, 2.090057903801916e-02,
            4.902896825779680e-01, -4.796343698686354e-01, 1.970211671607839e-02,
            4.980721753534725e-01, 9.157146659597657e-01, 7.088539756844323e-03,
            4.998104630815455e-01, -6.796065261644658e-01, 1.577525512582634e-02,
            5.094252232151556e-01, -8.368693540841839e-01, 1.074700155814415e-02,
            5.192774433643107e-01, -9.883852225797410e-01, 3.036728485600766e-03,
            5.195781232521763e-01, -9.398491136525347e-01, 6.356409539852770e-03,
            5.199091809396583e-01, 8.569634476765962e-01, 5.258870099579074e-03,
            5.229669281084162e-01, 5.594933800929066e-01, 1.395310653595126e-02,
            5.277471964272620e-01, 2.088203156823199e-01, 1.879162946198670e-02,
            5.309038668016169e-01, 7.063079812356768e-01, 1.112337221025911e-02,
            5.382154499373017e-01, 4.065037042579824e-01, 1.597509886966357e-02,
            5.516901995859222e-01, 2.395725953104485e-02, 1.772537813373606e-02,
            5.527797967108647e-01, 9.898809035115810e-01, 2.406110601287913e-03,
            5.750934868747971e-01, -1.608553196274835e-01, 1.999458400282759e-02,
            5.826416379535926e-01, -5.769647685634977e-01, 1.716174776614503e-02,
            5.828982582142574e-01, -3.706431888713908e-01, 1.927115149218318e-02,
            5.850904508510351e-01, 9.536524310311831e-01, 5.849579241942577e-03,
            5.903129886530973e-01, -7.571779340576262e-01, 1.342299877672259e-02,
            5.958483435151166e-01, 8.681226767219122e-01, 7.303322832277533e-03,
            5.993502036615301e-01, -8.879811146186565e-01, 9.100212257108971e-03,
            6.050183737665353e-01, 6.475724613929950e-01, 1.074862599712923e-02,
            6.143297462629967e-01, 7.837772856375271e-01, 1.032139260028579e-02,
            6.153165941746209e-01, -9.665059604638701e-01, 4.843117865525232e-03,
            6.161439379518383e-01, -9.981214531139727e-01, 9.753216220325940e-04,
            6.175168884004676e-01, 3.159407352975249e-01, 1.637383804148541e-02,
            6.217394522871077e-01, 5.078428721394385e-01, 1.362126210274025e-02,
            6.299826667484392e-01, 1.276627125784212e-01, 1.607743572209873e-02,
            6.380312602008873e-01, 9.984592465433296e-01, 6.879014666059284e-04,
            6.619401281471743e-01, -4.910221084647453e-02, 1.800834418028045e-02,
            6.674023930795736e-01, -4.731419452655840e-01, 1.673528342997327e-02,
            6.681506875256884e-01, -6.664316392680106e-01, 1.423631431136118e-02,
            6.699586457560213e-01, -2.582142639784658e-01, 1.831293821635849e-02,
            6.700629393564212e-01, 9.153625801049049e-01, 7.211301710323832e-03,
            6.737233221090680e-01, 7.173277865865444e-01, 6.610660635246017e-03,
            6.745073548792663e-01, 9.808177327151206e-01, 3.335305616421728e-03,
            6.778146451052540e-01, -8.234922260494466e-01, 1.057682497759063e-02,
            6.908467734992273e-01, -9.289111905832840e-01, 6.533919963273618e-03,
            6.953563494538313e-01, 4.185159914801704e-01, 1.411689605267293e-02,
            6.956622893885850e-01, 5.981008752604229e-01, 1.164860612595941e-02,
            7.000653188381879e-01, 2.214609724485731e-01, 1.377466770804801e-02,
            7.037630540132982e-01, -9.876775194786391e-01, 2.680336723639033e-03,
            7.104138022608364e-01, 8.335936077499366e-01, 9.361402014358680e-03,
            7.312620222424863e-01, 7.241821704859189e-01, 7.324085688124115e-03,
            7.377947101997951e-01, 6.019282202794075e-02, 1.545266033002662e-02,
            7.432626735055564e-01, -5.692902294936619e-01, 1.380983624211225e-02,
            7.463716527825006e-01, -3.650065781089341e-01, 1.572334278442964e-02,
            7.473714210847725e-01, -7.438987523094117e-01, 1.119428524509579e-02,
            7.479060990243412e-01, 9.546404095610349e-01, 4.774712942139564e-03,
            7.497338213800094e-01, -1.437602092341267e-01, 1.665640989044135e-02,
            7.551017439728431e-01, 9.959903451333804e-01, 1.228086933220431e-03,
            7.591482573195993e-01, -8.774194742914248e-01, 7.586269856563272e-03,
            7.633324906212867e-01, 3.136203740000685e-01, 1.293765982026287e-02,
            7.650644572872880e-01, 5.091844736715609e-01, 1.189055699839011e-02,
            7.700358230014746e-01, -9.622554291254800e-01, 4.130632579632251e-03,
            7.803618979679303e-01, 8.901458109807174e-01, 6.979020029847049e-03,
            7.864173038832742e-01, -9.978780396924563e-01, 8.523818960483254e-04,
            7.865539415769538e-01, 6.444528101970656e-01, 9.779082708584302e-03,
            7.980764438789796e-01, 7.802200932109996e-01, 8.751239749911849e-03,
            7.998064049263058e-01, 1.573746239393782e-01, 1.153314940800488e-02,
            8.115339339837927e-01, -6.541157752948943e-01, 1.081501204510849e-02,
            8.122968512881367e-01, -4.669611624262626e-01, 1.275121734348267e-02,
            8.172332485051989e-01, -2.537325117758131e-01, 1.424812222167168e-02,
            8.173520738904602e-01, -8.098997527380203e-01, 8.129789190108278e-03,
            8.178221088482659e-01, 9.819369149456145e-01, 2.554058729705376e-03,
            8.203518851901087e-01, -2.848141797141588e-02, 1.462387517662095e-02,
            8.252880251126054e-01, 4.061913511894648e-01, 1.166744929568591e-02,
            8.273414827850937e-01, -9.223585802664281e-01, 4.998620758584853e-03,
            8.407955028132980e-01, -9.831208231993736e-01, 2.226504941332199e-03,
            8.434816562041050e-01, 9.360798445804146e-01, 4.637841436379602e-03,
            8.459602643116834e-01, 2.369112261168515e-01, 9.231435360575175e-03,
            8.471265891317460e-01, 5.607143752033232e-01, 9.370910316615211e-03,
            8.544039302272810e-01, 8.437316388011586e-01, 6.684546573241642e-03,
            8.584519706838185e-01, 7.001783215001461e-01, 8.637290041473251e-03,
            8.691797730219265e-01, -7.293852681306572e-01, 7.916587819483284e-03,
            8.694955383875622e-01, -5.578683468627721e-01, 9.777395917753213e-03,
            8.715225068140382e-01, 9.968629229036633e-01, 8.317205346907935e-04,
            8.737322022500262e-01, -3.624845067925466e-01, 1.142884436428019e-02,
            8.748455473474397e-01, -8.666688668665444e-01, 5.501879290681462e-03,
            8.783568279821649e-01, -1.408106351805172e-01, 1.222770107988572e-02,
            8.807000621010282e-01, 8.577202208035965e-02, 1.208916044443412e-02,
            8.861191555247315e-01, -9.524587365695271e-01, 2.996809350965912e-03,
            8.908714545623476e-01, 3.200728941018283e-01, 9.132233939830871e-03,
            8.918849262329097e-01, -9.953299489673937e-01, 8.349160581858519e-04,
            8.923957457559257e-01, 4.727862002708382e-01, 7.649082746924224e-03,
            8.992219867205118e-01, 9.696383870346604e-01, 2.712861853539782e-03,
            9.037366973903258e-01, 8.982722285187050e-01, 4.553188238165971e-03,
            9.058049717812220e-01, 7.750612684220821e-01, 6.573933171769569e-03,
            9.131013487425569e-01, 6.183060481541276e-01, 7.822429485807891e-03,
            9.152680757385779e-01, -7.967925142545168e-01, 5.472782958925398e-03,
            9.153194784422245e-01, -6.409066271644237e-01, 7.068811844211731e-03,
            9.212375062298164e-01, -4.626882296966913e-01, 8.505557437086888e-03,
            9.241806475212835e-01, -9.073693661022466e-01, 3.491966652690000e-03,
            9.242655253133358e-01, -2.553881984456130e-01, 9.435712214118857e-03,
            9.278685381584146e-01, -2.653703926395334e-02, 9.626254172659349e-03,
            9.292177091225340e-01, 1.981150041249339e-01, 9.120861207209665e-03,
            9.293709816985555e-01, -9.743419848916115e-01, 1.695761394360294e-03,
            9.361004878709992e-01, 4.885572309032284e-01, 3.587508119392231e-03,
            9.386011261575939e-01, 9.923607023625215e-01, 1.027746374416859e-03,
            9.416316207823281e-01, 3.848246163685812e-01, 5.939044760002660e-03,
            9.429469392782762e-01, -9.969137251707089e-01, 3.661853125669515e-04,
            9.451218403684011e-01, 8.425754983796822e-01, 4.380238586156267e-03,
            9.463230530060351e-01, 9.398320877335458e-01, 2.748352326578851e-03,
            9.496567334542220e-01, 7.028051861622154e-01, 5.415662354453875e-03,
            9.504527598249251e-01, -7.179397056605220e-01, 4.858056515732989e-03,
            9.545502432300008e-01, -8.483672446398389e-01, 3.493614776736699e-03,
            9.567226666698644e-01, -5.574361090807435e-01, 5.711544750304637e-03,
            9.604743008370903e-01, -3.634999075225396e-01, 6.518215206604805e-03,
            9.614350881231609e-01, -9.400793516785635e-01, 2.075637167332280e-03,
            9.617205731156480e-01, -1.437778684046163e-01, 6.766721124990966e-03,
            9.627292013618208e-01, 5.526147023410976e-01, 5.203862026907654e-03,
            9.645339614003799e-01, 8.912679972814096e-02, 6.720220154114170e-03,
            9.681982898776231e-01, -9.858482988016933e-01, 7.854806252207273e-04,
            9.684495587062435e-01, 2.941036296126024e-01, 5.195376918064249e-03,
            9.718043670689287e-01, 9.757438210857030e-01, 1.191159865328584e-03,
            9.761533852459922e-01, 7.788946250155976e-01, 3.220271808790217e-03,
            9.766012140635367e-01, 8.955372887998586e-01, 2.409386138666988e-03,
            9.789182968946982e-01, -7.802922134664675e-01, 2.851798066970247e-03,
            9.803687856312776e-01, -6.441628855863613e-01, 3.244928766737902e-03,
            9.822912045411591e-01, 9.984383651196385e-01, 2.341272827142674e-04,
            9.827025129630593e-01, 4.311771782500267e-01, 3.707882781947956e-03,
            9.827228609176302e-01, -8.919420074129613e-01, 1.854127115183594e-03,
            9.832282949134381e-01, -2.444850615823892e-01, 2.565975919898579e-03,
            9.842695902809974e-01, 6.440248345169696e-01, 3.235673284757067e-03,
            9.843960342896765e-01, -4.685449063372227e-01, 3.758206611082762e-03,
            9.863495085969685e-01, -9.979572836369498e-01, 1.885243013566843e-04,
            9.863894006621330e-01, -3.054206067550260e-02, 4.070957199968271e-03,
            9.884373933820602e-01, -9.631986863799080e-01, 8.909268125570525e-04,
            9.889831635646070e-01, 2.001521680789260e-01, 3.415256267259531e-03,
            9.895486008443393e-01, -2.802400020803678e-01, 1.784951229309678e-03,
            9.913011952915273e-01, 9.490722861303337e-01, 9.334114310415029e-04,
            9.939722207265341e-01, 8.378634329981455e-01, 1.348862490324860e-03,
            9.941405572471773e-01, 5.032506127587780e-01, 1.321839206521580e-03,
            9.943806852246193e-01, -6.860004265918137e-01, 7.140588378827780e-04,
            9.957633794231534e-01, -8.360114490592742e-01, 1.041707929268540e-03,
            9.966883143052717e-01, 7.278496613238243e-01, 1.191792248759857e-03,
            9.968035955361948e-01, -5.651523666439144e-01, 1.374867996046609e-03,
            9.968605145969733e-01, -7.336757652882711e-01, 7.990342391998070e-04,
            9.969384946190634e-01, 9.868433854178995e-01, 2.740236217096047e-04,
            9.975593611800366e-01, 3.360863758987011e-01, 1.454585250009066e-03,
            9.978110877289340e-01, -1.465750773024727e-01, 1.377030312298262e-03,
            9.979325714446113e-01, -9.249224066288942e-01, 4.777113521207585e-04,
            9.979765814666188e-01, -3.775646733998311e-01, 1.202710471482889e-03,
            9.980898127659592e-01, -9.874218489978037e-01, 1.849225119026519e-04,
            9.981040178114964e-01, 8.280125816480956e-02, 1.248796781507533e-03,
            9.982820382418868e-01, 5.769543802463517e-01, 7.519588496094478e-04,
            9.990895206748026e-01, 9.085198717249964e-01, 3.348164725496207e-04
        };

        int order = square_minimal_rule_order(degree);
        double[] xw_copy = typeMethods.r8mat_copy_new(3, order, xw);

        return xw_copy;
    }
}