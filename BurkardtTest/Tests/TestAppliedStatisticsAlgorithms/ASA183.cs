using System.Globalization;
using Burkardt.AppliedStatistics;

namespace Burkardt_Tests.TestAppliedStatisticsAlgorithms;

public class ASA183
{
        [Test]
    public static void test01()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST01 tests R4_RANDOM.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    08 July 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("TEST01");
        Console.WriteLine("  R4_RANDOM computes pseudorandom values.");
        Console.WriteLine("  Three seeds, S1, S2, and S3, are used.");

        int s1 = 12345;
        int s2 = 34567;
        int s3 = 56789;

        Console.WriteLine("");
        Console.WriteLine("      R                 S1        S2        S3");
        Console.WriteLine("");
        Console.WriteLine("                "
                          + "  " + s1.ToString().PadLeft(8)
                          + "  " + s2.ToString().PadLeft(8)
                          + "  " + s3.ToString().PadLeft(8) + "");

        for (int i = 0; i < 10; i++)
        {
            float r = Algorithms.r4_random(ref s1, ref s2, ref s3);
            Console.WriteLine("  " + r.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + s1.ToString().PadLeft(8)
                                   + "  " + s2.ToString().PadLeft(8)
                                   + "  " + s3.ToString().PadLeft(8) + "");
        }
    }

    [Test]
    public static void test02()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST02 tests R4_RANDOM.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    08 July 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        const int n = 100000;

        float[] u = new float[n];

        Console.WriteLine("");
        Console.WriteLine("TEST02");
        Console.WriteLine("  Examine the average and variance of a");
        Console.WriteLine("  sequence generated by R4_RANDOM.");
        //
        //  Start with known seeds.
        //
        int s1 = 12345;
        int s2 = 34567;
        int s3 = 56789;

        Console.WriteLine("");
        Console.WriteLine("  Now compute " + n + " elements.");

        float u_avg = 0.0f;
        for (int i = 0; i < n; i++)
        {
            u[i] = Algorithms.r4_random(ref s1, ref s2, ref s3);
            u_avg += u[i];
        }

        u_avg /= n;

        float u_var = 0.0f;
        for (int i = 0; i < n; i++)
        {
            u_var += (u[i] - u_avg) * (u[i] - u_avg);
        }

        u_var /= n - 1;

        Console.WriteLine("");
        Console.WriteLine("  Average value = " + u_avg + "");
        Console.WriteLine("  Expecting       " + 0.5 + "");

        Console.WriteLine("");
        Console.WriteLine("  Variance =      " + u_var + "");
        Console.WriteLine("  Expecting       " + 1.0 / 12.0 + "");

    }

    [Test]
    public static void test03()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST03 tests R4_RANDOM.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    08 July 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        float r;

        Console.WriteLine("");
        Console.WriteLine("TEST03");
        Console.WriteLine("  Show how the seeds used by R4_RANDOM,");
        Console.WriteLine("  which change on each step, can be reset to");
        Console.WriteLine("  restore any part of the sequence.");

        int s1_save = 12345;
        int s2_save = 34567;
        int s3_save = 56789;

        int s1 = s1_save;
        int s2 = s2_save;
        int s3 = s3_save;

        Console.WriteLine("");
        Console.WriteLine("  Begin sequence with following seeds");
        Console.WriteLine("");
        Console.WriteLine("  S1 = " + s1 + "");
        Console.WriteLine("  S2 = " + s2 + "");
        Console.WriteLine("  S3 = " + s3 + "");
        Console.WriteLine("");
        Console.WriteLine("         I      R                     S1            S2            S3");
        Console.WriteLine("");

        for (int i = 1; i <= 10; i++)
        {
            r = Algorithms.r4_random(ref s1, ref s2, ref s3);
            Console.WriteLine("  " + i.ToString().PadLeft(8)
                                   + "  " + r.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + s1.ToString().PadLeft(12)
                                   + "  " + s2.ToString().PadLeft(12)
                                   + "  " + s3.ToString().PadLeft(12) + "");

            switch (i)
            {
                case 5:
                    s1_save = s1;
                    s2_save = s2;
                    s3_save = s3;
                    break;
            }
        }

        s1 = s1_save;
        s2 = s2_save;
        s3 = s3_save;

        Console.WriteLine("");
        Console.WriteLine("  Restart the sequence, using the seeds");
        Console.WriteLine("  produced after step 5:");
        Console.WriteLine("");
        Console.WriteLine("  S1 = " + s1 + "");
        Console.WriteLine("  S2 = " + s2 + "");
        Console.WriteLine("  S3 = " + s3 + "");
        Console.WriteLine("");
        Console.WriteLine("         I      R                     S1            S2            S3");
        Console.WriteLine("");

        for (int i = 1; i <= 10; i++)
        {
            r = Algorithms.r4_random(ref s1, ref s2, ref s3);
            Console.WriteLine("  " + i.ToString().PadLeft(8)
                                   + "  " + r.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + s1.ToString().PadLeft(12)
                                   + "  " + s2.ToString().PadLeft(12)
                                   + "  " + s3.ToString().PadLeft(12) + "");
        }
    }

    [Test]
    public static void test04()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST04 tests R4_UNI.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    08 July 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int i;

        Console.WriteLine("");
        Console.WriteLine("TEST04");
        Console.WriteLine("  R4_UNI computes pseudorandom values.");
        Console.WriteLine("  Two seeds, S1 and S2, are used.");

        int s1 = 12345;
        int s2 = 34567;

        Console.WriteLine("");
        Console.WriteLine("      R                 S1        S2");
        Console.WriteLine("");
        Console.WriteLine("                "
                          + "  " + s1.ToString().PadLeft(8)
                          + "  " + s2.ToString().PadLeft(8) + "");

        for (i = 0; i < 10; i++)
        {
            float r = Algorithms.r4_uni(ref s1, ref s2);
            Console.WriteLine("  " + r.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + s1.ToString().PadLeft(8)
                                   + "  " + s2.ToString().PadLeft(8) + "");
        }
    }

    [Test]
    public static void test05()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST05 tests R4_UNI.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    08 July 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        const int n = 100000;

        float[] u = new float[n];

        Console.WriteLine("");
        Console.WriteLine("TEST05");
        Console.WriteLine("  Examine the average and variance of a");
        Console.WriteLine("  sequence generated by R4_UNI.");
        //
        //  Start with known seeds.
        //
        int s1 = 12345;
        int s2 = 34567;

        Console.WriteLine("");
        Console.WriteLine("  Now compute " + n + " elements.");

        float u_avg = 0.0f;
        for (int i = 0; i < n; i++)
        {
            u[i] = Algorithms.r4_uni(ref s1, ref s2);
            u_avg += u[i];
        }

        u_avg /= n;

        float u_var = 0.0f;
        for (int i = 0; i < n; i++)
        {
            u_var += (u[i] - u_avg) * (u[i] - u_avg);
        }

        u_var /= n - 1;

        Console.WriteLine("");
        Console.WriteLine("  Average value = " + u_avg + "");
        Console.WriteLine("  Expecting       " + 0.5 + "");

        Console.WriteLine("");
        Console.WriteLine("  Variance =      " + u_var + "");
        Console.WriteLine("  Expecting       " + 1.0 / 12.0 + "");
    }

    [Test]
    public static void test06()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST06 tests R4_UNI.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    08 July 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("TEST06");
        Console.WriteLine("  Show how the seeds used by R4_UNI,");
        Console.WriteLine("  which change on each step, can be reset to");
        Console.WriteLine("  restore any part of the sequence.");

        int s1_save = 12345;
        int s2_save = 34567;

        int s1 = s1_save;
        int s2 = s2_save;

        Console.WriteLine("");
        Console.WriteLine("  Begin sequence with following seeds");
        Console.WriteLine("");
        Console.WriteLine("  S1 = " + s1 + "");
        Console.WriteLine("  S2 = " + s2 + "");
        Console.WriteLine("");
        Console.WriteLine("         I      R                     S1            S2");
        Console.WriteLine("");

        for (int i = 1; i <= 10; i++)
        {
            float r = Algorithms.r4_uni(ref s1, ref s2);
            Console.WriteLine("  " + i.ToString().PadLeft(8)
                                   + "  " + r.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + s1.ToString().PadLeft(12)
                                   + "  " + s2.ToString().PadLeft(12) + "");

            switch (i)
            {
                case 5:
                    s1_save = s1;
                    s2_save = s2;
                    break;
            }
        }

        s1 = s1_save;
        s2 = s2_save;

        Console.WriteLine("");
        Console.WriteLine("  Restart the sequence, using the seeds");
        Console.WriteLine("  produced after step 5:");
        Console.WriteLine("");
        Console.WriteLine("  S1 = " + s1 + "");
        Console.WriteLine("  S2 = " + s2 + "");
        Console.WriteLine("");
        Console.WriteLine("         I      R                     S1            S2");
        Console.WriteLine("");

        for (int i = 1; i <= 10; i++)
        {
            float r = Algorithms.r4_uni(ref s1, ref s2);
            Console.WriteLine("  " + i.ToString().PadLeft(8)
                                   + "  " + r.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + s1.ToString().PadLeft(12)
                                   + "  " + s2.ToString().PadLeft(12) + "");

        }
    }

    [Test]
    public static void test07()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST07 tests R8_RANDOM.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    08 July 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int i;

        Console.WriteLine("");
        Console.WriteLine("TEST07");
        Console.WriteLine("  R8_RANDOM computes pseudorandom values.");
        Console.WriteLine("  Three seeds, S1, S2, and S3, are used.");

        int s1 = 12345;
        int s2 = 34567;
        int s3 = 56789;

        Console.WriteLine("");
        Console.WriteLine("      R                 S1        S2        S3");
        Console.WriteLine("");
        Console.WriteLine("                "
                          + "  " + s1.ToString().PadLeft(8)
                          + "  " + s2.ToString().PadLeft(8)
                          + "  " + s3.ToString().PadLeft(8) + "");

        for (i = 0; i < 10; i++)
        {
            double r = Algorithms.r8_random(ref s1, ref s2, ref s3);
            Console.WriteLine("  " + r.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + s1.ToString().PadLeft(8)
                                   + "  " + s2.ToString().PadLeft(8)
                                   + "  " + s3.ToString().PadLeft(8) + "");
        }
    }

    [Test]
    public static void test08()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST08 tests R8_RANDOM.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    08 July 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        const int n = 100000;

        double[] u = new double[n];

        Console.WriteLine("");
        Console.WriteLine("TEST08");
        Console.WriteLine("  Examine the average and variance of a");
        Console.WriteLine("  sequence generated by R8_RANDOM.");
        //
        //  Start with known seeds.
        //
        int s1 = 12345;
        int s2 = 34567;
        int s3 = 56789;

        Console.WriteLine("");
        Console.WriteLine("  Now compute " + n + " elements.");

        double u_avg = 0.0;
        for (int i = 0; i < n; i++)
        {
            u[i] = Algorithms.r8_random(ref s1, ref s2, ref s3);
            u_avg += u[i];
        }

        u_avg /= n;

        double u_var = 0.0;
        for (int i = 0; i < n; i++)
        {
            u_var += (u[i] - u_avg) * (u[i] - u_avg);
        }

        u_var /= n - 1;

        Console.WriteLine("");
        Console.WriteLine("  Average value = " + u_avg + "");
        Console.WriteLine("  Expecting       " + 0.5 + "");

        Console.WriteLine("");
        Console.WriteLine("  Variance =      " + u_var + "");
        Console.WriteLine("  Expecting       " + 1.0 / 12.0 + "");
    }

    [Test]
    public static void test09()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST09 tests R8_RANDOM.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    08 July 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("TEST09");
        Console.WriteLine("  Show how the seeds used by R8_RANDOM,");
        Console.WriteLine("  which change on each step, can be reset to");
        Console.WriteLine("  restore any part of the sequence.");

        int s1_save = 12345;
        int s2_save = 34567;
        int s3_save = 56789;

        int s1 = s1_save;
        int s2 = s2_save;
        int s3 = s3_save;

        Console.WriteLine("");
        Console.WriteLine("  Begin sequence with following seeds");
        Console.WriteLine("");
        Console.WriteLine("  S1 = " + s1 + "");
        Console.WriteLine("  S2 = " + s2 + "");
        Console.WriteLine("  S3 = " + s3 + "");
        Console.WriteLine("");
        Console.WriteLine("         I      R                     S1            S2            S3");
        Console.WriteLine("");

        for (int i = 1; i <= 10; i++)
        {
            double r = Algorithms.r8_random(ref s1, ref s2, ref s3);
            Console.WriteLine("  " + i.ToString().PadLeft(8)
                                   + "  " + r.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + s1.ToString().PadLeft(12)
                                   + "  " + s2.ToString().PadLeft(12)
                                   + "  " + s3.ToString().PadLeft(12) + "");

            switch (i)
            {
                case 5:
                    s1_save = s1;
                    s2_save = s2;
                    s3_save = s3;
                    break;
            }
        }

        s1 = s1_save;
        s2 = s2_save;
        s3 = s3_save;

        Console.WriteLine("");
        Console.WriteLine("  Restart the sequence, using the seeds");
        Console.WriteLine("  produced after step 5:");
        Console.WriteLine("");
        Console.WriteLine("  S1 = " + s1 + "");
        Console.WriteLine("  S2 = " + s2 + "");
        Console.WriteLine("  S3 = " + s3 + "");
        Console.WriteLine("");
        Console.WriteLine("         I      R                     S1            S2            S3");
        Console.WriteLine("");

        for (int i = 1; i <= 10; i++)
        {
            double r = Algorithms.r8_random(ref s1, ref s2, ref s3);
            Console.WriteLine("  " + i.ToString().PadLeft(8)
                                   + "  " + r.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + s1.ToString().PadLeft(12)
                                   + "  " + s2.ToString().PadLeft(12)
                                   + "  " + s3.ToString().PadLeft(12) + "");
        }
    }

    [Test]
    public static void test10()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST10 tests R8_UNI.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    08 July 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("TEST10");
        Console.WriteLine("  R8_UNI computes pseudorandom values.");
        Console.WriteLine("  Two seeds, S1 and S2, are used.");

        int s1 = 12345;
        int s2 = 34567;

        Console.WriteLine("");
        Console.WriteLine("      R                 S1        S2");
        Console.WriteLine("");
        Console.WriteLine("                "
                          + "  " + s1.ToString().PadLeft(8)
                          + "  " + s2.ToString().PadLeft(8) + "");

        for (int i = 0; i < 10; i++)
        {
            double r = Algorithms.r8_uni(ref s1, ref s2);
            Console.WriteLine("  " + r.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + s1.ToString().PadLeft(8)
                                   + "  " + s2.ToString().PadLeft(8) + "");
        }
    }

    [Test]
    public static void test11()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST11 tests R8_UNI.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    08 July 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        const int n = 100000;

        double[] u = new double[n];

        Console.WriteLine("");
        Console.WriteLine("TEST11");
        Console.WriteLine("  Examine the average and variance of a");
        Console.WriteLine("  sequence generated by R8_UNI.");
        //
        //  Start with known seeds.
        //
        int s1 = 12345;
        int s2 = 34567;

        Console.WriteLine("");
        Console.WriteLine("  Now compute " + n + " elements.");

        double u_avg = 0.0;
        for (int i = 0; i < n; i++)
        {
            u[i] = Algorithms.r8_uni(ref s1, ref s2);
            u_avg += u[i];
        }

        u_avg /= (float) n;

        double u_var = 0.0;
        for (int i = 0; i < n; i++)
        {
            u_var += (u[i] - u_avg) * (u[i] - u_avg);
        }

        u_var /= (float) (n - 1);

        Console.WriteLine("");
        Console.WriteLine("  Average value = " + u_avg + "");
        Console.WriteLine("  Expecting       " + 0.5 + "");

        Console.WriteLine("");
        Console.WriteLine("  Variance =      " + u_var + "");
        Console.WriteLine("  Expecting       " + 1.0 / 12.0 + "");
    }

    [Test]
    public static void test12()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    TEST12 tests R8_UNI.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    08 July 2008
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        int i;
        double r;

        Console.WriteLine("");
        Console.WriteLine("TEST12");
        Console.WriteLine("  Show how the seeds used by R8_UNI,");
        Console.WriteLine("  which change on each step, can be reset to");
        Console.WriteLine("  restore any part of the sequence.");

        int s1_save = 12345;
        int s2_save = 34567;

        int s1 = s1_save;
        int s2 = s2_save;

        Console.WriteLine("");
        Console.WriteLine("  Begin sequence with following seeds");
        Console.WriteLine("");
        Console.WriteLine("  S1 = " + s1 + "");
        Console.WriteLine("  S2 = " + s2 + "");
        Console.WriteLine("");
        Console.WriteLine("         I      R                     S1            S2");
        Console.WriteLine("");

        for (i = 1; i <= 10; i++)
        {
            r = Algorithms.r8_uni(ref s1, ref s2);
            Console.WriteLine("  " + i.ToString().PadLeft(8)
                                   + "  " + r.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + s1.ToString().PadLeft(12)
                                   + "  " + s2.ToString().PadLeft(12) + "");

            switch (i)
            {
                case 5:
                    s1_save = s1;
                    s2_save = s2;
                    break;
            }
        }

        s1 = s1_save;
        s2 = s2_save;

        Console.WriteLine("");
        Console.WriteLine("  Restart the sequence, using the seeds");
        Console.WriteLine("  produced after step 5:");
        Console.WriteLine("");
        Console.WriteLine("  S1 = " + s1 + "");
        Console.WriteLine("  S2 = " + s2 + "");
        Console.WriteLine("");
        Console.WriteLine("         I      R                     S1            S2");
        Console.WriteLine("");

        for (i = 1; i <= 10; i++)
        {
            r = Algorithms.r8_uni(ref s1, ref s2);
            Console.WriteLine("  " + i.ToString().PadLeft(8)
                                   + "  " + r.ToString(CultureInfo.InvariantCulture).PadLeft(14)
                                   + "  " + s1.ToString().PadLeft(12)
                                   + "  " + s2.ToString().PadLeft(12) + "");
        }
    }

}