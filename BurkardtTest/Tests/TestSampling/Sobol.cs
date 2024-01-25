using System.Globalization;
using Burkardt.Sobol;
using Burkardt.Uniform;

namespace Burkardt_Tests.TestSampling;

public class SobolTest
{
    [Test]
    public static void or_test ( )
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    OR_TEST tests OR.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    23 January 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int seed = 123456789;

        Console.WriteLine();
        Console.WriteLine("OR_TEST");
        Console.WriteLine("  The function ^ computes the bitwise exclusive OR");
        Console.WriteLine("  of two integers.");
        Console.WriteLine();
        Console.WriteLine("       I       J     I^J");
        Console.WriteLine();

        for (int test = 1; test <= 10; test++ )
        {
            int i = UniformRNG.i4_uniform( 0, 100, ref seed );
            int j = UniformRNG.i4_uniform( 0, 100, ref seed );
            int k = i ^ j;

            string cout = "  ";
            string t = i.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t; 
            t = j.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t; 
            t = k.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t; 
            Console.WriteLine(cout);
        }
    }


    [Test]
    public static void i4_bit_hi1_test ( )
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    I4_BIT_HI1_TEST tests I4_BIT_HI1.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    23 January 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int seed = 123456789;

        Console.WriteLine();
        Console.WriteLine("I4_BIT_HI1_TEST");
        Console.WriteLine("  I4_BIT_HI1 returns the location of the high bit in an integer.");
        Console.WriteLine();
        Console.WriteLine("       I  I4_BIT_HI1(I)");
        Console.WriteLine();

        for (int test = 1; test <= 10; test++ )
        {
            int i = UniformRNG.i4_uniform( 0, 100, ref seed );
            int j = SobolSampler.i4_bit_hi1 ( i );

            string cout = "  ";
            string t = i.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t;
            t = j.ToString(CultureInfo.InvariantCulture).PadLeft(6);
            cout += t;
            Console.WriteLine(cout);
        }
    }


    [Test]
    public static void i4_bit_lo0_test ( )
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    I4_BIT_LO0_TEST tests I4_BIT_LO0.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    23 January 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int seed = 123456789;

        Console.WriteLine();
        Console.WriteLine("I4_BIT_LO0_TEST");
        Console.WriteLine("  I4_BIT_LO0 returns the location of the low 0 bit in an integer.");
        Console.WriteLine();
        Console.WriteLine("       I  I4_BIT_LO0(I)");
        Console.WriteLine();

        for (int test = 1; test <= 10; test++ )
        {
            int i = UniformRNG.i4_uniform( 0, 100, ref seed );
            int j = SobolSampler.i4_bit_lo0 ( i );

            string cout = "  ";
            string t = i.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t;
            t = j.ToString(CultureInfo.InvariantCulture).PadLeft(6);
            cout += t;
            Console.WriteLine(cout);
        }
    }


    [Test]
    public static void test04 ( )
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST04 tests I4_SOBOL.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    23 January 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int DIM_NUM = 4;
            
        SobolSampler.SobolConfig config = new(DIM_NUM);

        Console.WriteLine();
        Console.WriteLine("TEST04");
        Console.WriteLine("  I4_SOBOL computes the next element of a Sobol sequence.");
        Console.WriteLine();
        Console.WriteLine("  In this test, we call I4_SOBOL repeatedly.");

        for (int dim_num = 2; dim_num <= DIM_NUM; dim_num++ )
        {
            config.seed = 0;

            Console.WriteLine();
            Console.WriteLine("  Using dimension DIM_NUM =   " + dim_num);
            Console.WriteLine();
            Console.WriteLine("  Seed  Seed   I4_SOBOL");
            Console.WriteLine("  In    Out");
            Console.WriteLine();

            for (int i = 0; i <= 110; i++ )
            {
                int seed_in = config.seed;
                int res = SobolSampler.i4_sobol ( dim_num, ref config);
                int seed_out = config.seed;

                switch (i)
                {
                    case <= 11:
                    case >= 95:
                    {
                        string cout = "";
                        string t = seed_in.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
                        cout += t;
                        t = seed_out.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
                        cout += t;
                        for (int j = 0; j < dim_num; j++ )
                        {
                            t = config.quasi[j].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "  ";
                            cout += t;
                        }
                        Console.WriteLine(cout);
                        break;
                    }
                    case 12:
                        Console.WriteLine("....................");
                        break;
                }
            }
        }
    }


    [Test]
    public static void test05 ( )

        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST05 tests I4_SOBOL.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    23 January 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int DIM_NUM = 3;

        SobolSampler.SobolConfig config = new(DIM_NUM);
            
        Console.WriteLine();
        Console.WriteLine("TEST05");
        Console.WriteLine("  I4_SOBOL computes the next element of a Sobol sequence.");
        Console.WriteLine();
        Console.WriteLine("  In this test, we demonstrate how the SEED can be");
        Console.WriteLine("  manipulated to skip ahead in the sequence, or");
        Console.WriteLine("  to come back to any part of the sequence.");
        Console.WriteLine();
        Console.WriteLine("  Using dimension DIM_NUM =   " + DIM_NUM);

        config.seed = 0;

        Console.WriteLine();
        Console.WriteLine("  Seed  Seed   I4_SOBOL");
        Console.WriteLine("  In    Out");
        Console.WriteLine();

        for (int i = 1; i <= 11; i++ )
        {
            int seed_in = config.seed;
            int res = SobolSampler.i4_sobol ( DIM_NUM, ref config);
            int seed_out = config.seed;
            string cout = "";
            string t = seed_in.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t;
            t = seed_out.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t;
            for (int j = 0; j < DIM_NUM; j++ )
            {
                t = config.quasi[j].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "  ";
                cout += t;
            }
            Console.WriteLine(cout);
        }

        Console.WriteLine();
        Console.WriteLine("  Jump ahead by increasing SEED:");

        config.seed = 100;

        Console.WriteLine();
        Console.WriteLine("  Seed  Seed   I4_SOBOL");
        Console.WriteLine("  In    Out");
        Console.WriteLine();

        for (int i = 1; i <= 5; i++ )
        {
            int seed_in = config.seed;
            int res = SobolSampler.i4_sobol ( DIM_NUM, ref config);
            int seed_out = config.seed;
            string cout = "";
            string t = seed_in.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t;
            t = seed_out.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t;
            for (int j = 0; j < DIM_NUM; j++ )
            {
                t = config.quasi[j].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "  ";
                cout += t;
            }
            Console.WriteLine(cout);
        }

        Console.WriteLine();
        Console.WriteLine("  Jump back by decreasing SEED:");

        config.seed = 3;

        Console.WriteLine();
        Console.WriteLine("  Seed  Seed   I4_SOBOL");
        Console.WriteLine("  In    Out");
        Console.WriteLine();
            
        for (int i = 1; i <= 11; i++ )
        {
            int seed_in = config.seed;
            int res = SobolSampler.i4_sobol ( DIM_NUM, ref config);
            int seed_out = config.seed;
            string cout = "";
            string t = seed_in.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t;
            t = seed_out.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t;
            for (int j = 0; j < DIM_NUM; j++ )
            {
                t = config.quasi[j].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "  ";
                cout += t;
            }
            Console.WriteLine(cout);
        }

        Console.WriteLine();
        Console.WriteLine("  Jump ahead by increasing SEED:");

        config.seed = 98;

        Console.WriteLine();
        Console.WriteLine("  Seed  Seed   I4_SOBOL");
        Console.WriteLine("  In    Out");
        Console.WriteLine();

        for (int i = 1; i <= 5; i++ )
        {
            int seed_in = config.seed;
            int res = SobolSampler.i4_sobol ( DIM_NUM, ref config);
            int seed_out = config.seed;
            string cout = "";
            string t = seed_in.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t;
            t = seed_out.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t;
            for (int j = 0; j < DIM_NUM; j++ )
            {
                t = config.quasi[j].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "  ";
                cout += t;
            }
            Console.WriteLine(cout);
        }
    }


    [Test]
    public static void test055 ( )
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST055 tests OR on long long ints.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    12 May 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int seed = 123456789;

        Console.WriteLine();
        Console.WriteLine("TEST055");
        Console.WriteLine("  The function ^ computes the bitwise exclusive OR");
        Console.WriteLine("  of two LONG LONG INT's.");
        Console.WriteLine();
        Console.WriteLine("       I       J     I^J");
        Console.WriteLine();

        for (int  test = 1; test <= 10; test++ )
        {
            long i = UniformRNG.i4_uniform( 0, 100, ref seed );
            long j = UniformRNG.i4_uniform( 0, 100, ref seed );
            long k = i ^ j;

            string cout = "  ";
            string t = i.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t;
            t = j.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t;
            t = k.ToString(CultureInfo.InvariantCulture).PadLeft(6);
            cout += t;
            Console.WriteLine(cout);
        }
    }


    [Test]
    public static void i8_bit_hi1_test ( )
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    I8_BIT_H1_TEST tests I8_BIT_HI1.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    12 May 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int seed = 123456789;

        Console.WriteLine();
        Console.WriteLine("I8_BIT_HI1_TEST");
        Console.WriteLine("  I8_BIT_HI1 returns the location of the high bit in an integer.");
        Console.WriteLine();
        Console.WriteLine("       I  I8_BIT_HI1(I)");
        Console.WriteLine();

        for (int test = 1; test <= 10; test++ )
        {
            long i = UniformRNG.i4_uniform( 0, 100, ref seed );
            int j = SobolSampler.i8_bit_hi1 ( i );

            string cout = "  ";
            string t = i.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            t += j.ToString(CultureInfo.InvariantCulture).PadLeft(6);
            cout += t;
            Console.WriteLine(cout);
        }
    }


    [Test]
    public static void i8_bit_lo0_test ( )
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    I8_BIT_LO0_TEST tests I8_BIT_LO0.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    12 May 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int seed = 123456789;

        Console.WriteLine();
        Console.WriteLine("I8_BIT_LO0_TEST");
        Console.WriteLine("  I8_BIT_LO0 returns the location of the low zero bit");
        Console.WriteLine("  in an integer.");
        Console.WriteLine();
        Console.WriteLine("       I  I8_BIT_LO0(I)");
        Console.WriteLine();

        for (int test = 1; test <= 10; test++ )
        {
            long i = UniformRNG.i4_uniform( 0, 100, ref seed );
            int j = SobolSampler.i8_bit_lo0 ( i );

            string cout = "  ";
            string t = i.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            t += j.ToString(CultureInfo.InvariantCulture).PadLeft(6);
            cout += t;
            Console.WriteLine(cout);
        }
    }


    [Test]
    public static void test08 ( )
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST08 tests I8_SOBOL.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    12 May 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int DIM_MAX = 4;
        SobolSampler.SobolConfigLarge config = new(DIM_MAX);
            
        Console.WriteLine();
        Console.WriteLine("TEST08");
        Console.WriteLine("  I8_SOBOL computes the next element of a Sobol sequence.");
        Console.WriteLine();
        Console.WriteLine("  In this test, we call I8_SOBOL repeatedly.");

        for (int dim_num = 2; dim_num <= DIM_MAX; dim_num++ )
        {
            config.seed = 0;

            Console.WriteLine();
            Console.WriteLine("  Using dimension DIM_NUM =   " + dim_num);
            Console.WriteLine();
            Console.WriteLine("  Seed  Seed   I8_SOBOL");
            Console.WriteLine("  In    Out");
            Console.WriteLine();

            for (int i = 0; i <= 110; i++ )
            {
                long seed_in = config.seed;
                int res = SobolSampler.i8_sobol ( dim_num, ref config );
                long seed_out = config.seed;

                switch (i)
                {
                    case <= 11:
                    case >= 95:
                    {
                        string cout = seed_in.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
                        string t = seed_out.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
                        cout += t;
                        for (int j = 0; j < dim_num; j++ )
                        {
                            t = config.quasi[j].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "  ";
                            cout += t;
                        }
                        Console.WriteLine(cout);
                        break;
                    }
                    case 12:
                        Console.WriteLine("....................");
                        break;
                }
            }

        }
    }

    [Test]
    public static void test09 ( )
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST09 tests I8_SOBOL.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    12 May 2007
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int DIM_NUM = 3;
        SobolSampler.SobolConfigLarge config = new(DIM_NUM);

        Console.WriteLine();
        Console.WriteLine("TEST09");
        Console.WriteLine("  I8_SOBOL computes the next element of a Sobol sequence.");
        Console.WriteLine();
        Console.WriteLine("  In this test, we demonstrate how the SEED can be");
        Console.WriteLine("  manipulated to skip ahead in the sequence, or");
        Console.WriteLine("  to come back to any part of the sequence.");
        Console.WriteLine();
        Console.WriteLine("  Using dimension DIM_NUM =   " + DIM_NUM);

        config.seed = 0;

        Console.WriteLine();
        Console.WriteLine("  Seed  Seed   I8_SOBOL");
        Console.WriteLine("  In    Out");
        Console.WriteLine();
            
        for (int i = 1; i <= 11; i++ )
        {
            long seed_in = config.seed;
            int res = SobolSampler.i8_sobol ( DIM_NUM, ref config );
            long seed_out = config.seed;
            string cout = seed_in.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            string t = seed_out.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t;
            for (int j = 0; j < DIM_NUM; j++ )
            {
                t = config.quasi[j].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "  ";
                cout += t;
            }
            Console.WriteLine(cout);
        }

        Console.WriteLine();
        Console.WriteLine("  Jump ahead by increasing SEED:");

        config.seed = 100;

        Console.WriteLine();
        Console.WriteLine("  Seed  Seed   I8_SOBOL");
        Console.WriteLine("  In    Out");
        Console.WriteLine();

        for (int i = 1; i <= 5; i++ )
        {
            long seed_in = config.seed;
            int res = SobolSampler.i8_sobol ( DIM_NUM, ref config );
            long seed_out = config.seed;
            string cout = seed_in.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            string t = seed_out.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t;
            for (int j = 0; j < DIM_NUM; j++ )
            {
                t = config.quasi[j].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "  ";
                cout += t;
            }
            Console.WriteLine(cout);
        }

        Console.WriteLine();
        Console.WriteLine("  Jump back by decreasing SEED:");

        config.seed = 3;

        Console.WriteLine();
        Console.WriteLine("  Seed  Seed   I8_SOBOL");
        Console.WriteLine("  In    Out");
        Console.WriteLine();

        for (int i = 1; i <= 11; i++ )
        {
            long seed_in = config.seed;
            int res = SobolSampler.i8_sobol ( DIM_NUM, ref config );
            long seed_out = config.seed;
            string cout = seed_in.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            string t = seed_out.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t;
            for (int j = 0; j < DIM_NUM; j++ )
            {
                t = config.quasi[j].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "  ";
                cout += t;
            }
            Console.WriteLine(cout);
        }

        Console.WriteLine();
        Console.WriteLine("  Jump ahead by increasing SEED:");

        config.seed = 98;

        Console.WriteLine();
        Console.WriteLine("  Seed  Seed   I8_SOBOL");
        Console.WriteLine("  In    Out");
        Console.WriteLine();

        for (int i = 1; i <= 5; i++ )
        {
            long seed_in = config.seed;
            int res = SobolSampler.i8_sobol ( DIM_NUM, ref config );
            long seed_out = config.seed;
            string cout = seed_in.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            string t = seed_out.ToString(CultureInfo.InvariantCulture).PadLeft(6) + "  ";
            cout += t;
            for (int j = 0; j < DIM_NUM; j++ )
            {
                t = config.quasi[j].ToString(CultureInfo.InvariantCulture).PadLeft(14) + "  ";
                cout += t;
            }
            Console.WriteLine(cout);
        }
    }
    
}