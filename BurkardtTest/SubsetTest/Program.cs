﻿using System;

namespace SubsetTestNS;

internal static class Program
{
    private static void Main()
        //****************************************************************************80
        //
        //  Purpose:
        //
        //    MAIN is the main program for SUBSET_TEST.
        //
        //  Discussion:
        //
        //    SUBSET_TEST tests SUBSET.
        //
        //  Licensing:
        //
        //    This code is distributed under the GNU LGPL license. 
        //
        //  Modified:
        //
        //    20 November 2019
        //
        //  Author:
        //
        //    John Burkardt
        //
    {
        Console.WriteLine("");
        Console.WriteLine("SUBSET_TEST");
        Console.WriteLine("  Test the SUBSET library.");

        AlternatingSignMatrixTest.asm_enum_test();
        AlternatingSignMatrixTest.asm_triangle_test();
        BellTest.bell_test();
        CatalanTest.catalan_test();
        CatalanTest.catalan_row_next_test();
        FractionTest.cfrac_to_rat_test();
        FractionTest.cfrac_to_rfrac_test();
        CombTest.comb_next_test();
        CombTest.comb_row_next_test();
        CombTest.comb_unrank_test();
        CompTest.comp_enum_test();
        CompTest.comp_next_test();
        CompTest.comp_next_grlex_test();
        CompTest.comp_random_test();
        CompTest.comp_random_grlex_test();
        CompTest.comp_rank_grlex_test();
        CompTest.comp_to_ksub_test();
        CompTest.comp_unrank_grlex_test();
        CompTest.compnz_next_test();
        CompTest.compnz_random_test();
        CompTest.compnz_to_ksub_test();
        CongruenceTest.congruence_test();
        DebruijnTest.debruijn_test();

        DecMatTest.decmat_det_test();
        DecMatTest.decmat_print_test();
        DerangeTest.derange_enum_test();
        DerangeTest.derange_enum2_test();
        DerangeTest.derange_enum3_test();
        DerangeTest.derange0_back_next_test();
        DerangeTest.derange0_check_test();
        DerangeTest.derange0_weed_next_test();
        DigraphTest.digraph_arc_euler_test();
        DigraphTest.digraph_arc_print_test();
        DiophantineTest.diophantine_test();
        DiophantineTest.diophantine_solution_minimize_test();
        DVecTest.dvec_add_test();
        DVecTest.dvec_complementx_test();
        DVecTest.dvec_mul_test();
        DVecTest.dvec_print_test();
        DVecTest.dvec_sub_test();
        DVecTest.dvec_to_i4_test();
        EquivTest.equiv_next_test();
        EquivTest.equiv_next2_test();
        EquivTest.equiv_print_test();
        EquivTest.equiv_print2_test();
        EquivTest.equiv_random_test();
        EulerTest.euler_row_test();
        FrobeniusTest.frobenius_number_order2_test();
        GrayTest.gray_next_test();
        GrayTest.gray_rank_test();
        GrayTest.gray_rank2_test();
        GrayTest.gray_unrank_test();
        GrayTest.gray_unrank2_test();
        i4Test.i4_bclr_test();
        i4Test.i4_bset_test();
        i4Test.i4_btest_test();
        i4Test.i4_choose_test();
        i4Test.i4_factor_test();
        i4Test.i4_fall_test();
        i4Test.i4_gcd_test();
        i4Test.i4_huge_test();
        i4Test.i4_log_10_test();
        i4Test.i4_modp_test();
        i4Test.i4_moebius_test();
        i4Test.i4_partition_conj_test();
        i4Test.i4_partition_count_test();
        i4Test.i4_partition_count2_test();
        i4Test.i4_partition_next_test();
        i4Test.i4_partition_next2_test();
        i4Test.i4_partition_print_test();
        i4Test.i4_partition_random_test();
        i4Test.i4_partitions_next_test();
        i4Test.i4_rise_test();
        i4Test.i4_sqrt_test();
        i4Test.i4_sqrt_cf_test();
        i4Test.i4_to_dvec_test();
        i4Test.i4_to_i4poly_test();
        i4Test.i4_to_van_der_corput_test();
        i4Test.i4mat_01_rowcolsum_test();
        i4Test.i4mat_u1_inverse_test();
        i4Test.i4mat_perm0_test();
        i4Test.i4mat_2perm0_test();
        i4Test.i4poly_test();
        i4Test.i4poly_add_test();
        i4Test.i4poly_cyclo_test();
        i4Test.i4poly_degree_test();
        i4Test.i4poly_dif_test();
        i4Test.i4poly_div_test();
        i4Test.i4poly_mul_test();
        i4Test.i4poly_print_test();
        i4Test.i4poly_to_i4_test();
        i4Test.i4vec_backtrack_test();
        i4Test.i4vec_descends_test();
        i4Test.i4vec_frac_test();
        i4Test.i4vec_index_test();
        i4Test.i4vec_maxloc_last_test();
        i4Test.i4vec_pairwise_prime_test();
        i4Test.i4vec_reverse_test();
        i4Test.i4vec_sort_bubble_a_test();
        i4Test.i4vec_sort_heap_index_d_test();
        i4Test.i4vec_transpose_print_test();
        i4Test.i4vec_uniform_ab_test();
        IndexTest.index_box_next_2d_test();
        IndexTest.index_box_next_3d_test();
        IndexTest.index_box2_next_2d_test();
        IndexTest.index_box2_next_3d_test();
        IndexTest.index_next0_test();
        IndexTest.index_next1_test();
        IndexTest.index_next2_test();
        IndexTest.index_rank0_test();
        IndexTest.index_rank1_test();
        IndexTest.index_rank2_test();
        IndexTest.index_unrank0_test();
        IndexTest.index_unrank1_test();
        IndexTest.index_unrank2_test();
        InverseTest.inverse_mod_n_test();
        PermTest.inversion_to_perm0_test();
        InvoluteTest.involute_enum_test();
        FractionTest.jfrac_to_rfrac_test();
        JosephusTest.josephus_test();
        KsubTest.ksub_next_test();
        KsubTest.ksub_next2_test();
        KsubTest.ksub_next3_test();
        KsubTest.ksub_next4_test();
        KsubTest.ksub_random_test();
        KsubTest.ksub_random2_test();
        KsubTest.ksub_random3_test();
        KsubTest.ksub_random4_test();
        KsubTest.ksub_random5_test();
        KsubTest.ksub_rank_test();
        KsubTest.ksub_to_comp_test();
        KsubTest.ksub_to_compnz_test();
        KsubTest.ksub_unrank_test();
        l4Test.l4vec_next_test();
        MatrixTest.matrix_product_opt_test();
        MoebiusMatrixTest.moebius_matrix_test();
        MonomialTest.monomial_count_test();
        MonomialTest.monomial_counts_test();
        MorseThueTest.morse_thue_test();
        MultinomialTest.multinomial_coef1_test();
        MultinomialTest.multinomial_coef2_test();
        PermTest.multiperm_enum_test();
        PermTest.multiperm_next_test();
        UnsignTest.nim_sum_test();
        PadovanTest.padovan_test();
        PellTest.pell_basic_test();
        PellTest.pell_next_test();
        PentEnumTest.pent_enum_test();
        PermTest.perm_ascend_test();
        PermTest.perm_fixed_enum_test();
        PermTest.perm0_break_count_test();
        PermTest.perm0_check_test();
        PermTest.perm0_cycle_test();
        PermTest.perm0_distance_test();
        PermTest.perm0_free_test();
        PermTest.perm0_inverse_test();
        PermTest.perm0_inverse2_test();
        PermTest.perm0_inverse3_new_test();
        PermTest.perm0_lex_next_test();
        PermTest.perm0_mul_test();
        PermTest.perm0_next_test();
        PermTest.perm0_next2_test();
        PermTest.perm0_next3_test();
        PermTest.perm0_print_test();
        PermTest.perm0_random_test();
        PermTest.perm0_random2_test();
        PermTest.perm0_rank_test();
        PermTest.perm0_sign_test();
        PermTest.perm0_to_equiv_test();
        PermTest.perm0_to_inversion_test();
        PermTest.perm0_to_ytb_test();
        PermTest.perm0_unrank_test();
        PermTest.perm1_canon_to_cycle_test();
        PermTest.perm1_check_test();
        PermTest.perm1_cycle_to_canon_test();
        PermTest.perm1_cycle_to_index_test();
        PermTest.perm1_index_to_cycle_test();
        PermTest.perm1_print_test();
        PerrinTest.perrin_test();
        PartialOrderingTest.pord_check_test();
        PowerTest.power_mod_test();
        PowerTest.power_series1_test();
        PowerTest.power_series2_test();
        PowerTest.power_series3_test();
        PowerTest.power_series4_test();
        PrimeTest.prime_test();
        PythagorusTest.pythag_triple_next_test();
        r8Test.r8_agm_test();
        r8Test.r8_choose_test();
        r8Test.r8_epsilon_test();
        r8Test.r8_fall_test();
        r8Test.r8_rise_test();
        r8Test.r8_to_cfrac_test();
        r8Test.r8_to_dec_test();
        r8Test.r8_to_rat_test();
        r8Test.r8mat_det_test();
        r8Test.r8mat_perm0_test();
        r8Test.r8mat_2perm0_test();
        r8Test.r8mat_permanent_test();
        r8Test.r8poly_test();
        r8Test.r8poly_f2p_test();
        r8Test.r8poly_fval_test();
        r8Test.r8poly_n2p_test();
        r8Test.r8poly_nval_test();
        r8Test.r8poly_nx_test();
        r8Test.r8poly_p2f_test();
        r8Test.r8poly_p2n_test();
        r8Test.r8poly_p2t_test();
        r8Test.r8poly_print_test();
        r8Test.r8poly_pval_test();
        r8Test.r8poly_t2p_test();
        r8Test.r8vec_backtrack_test();
        r8Test.r8vec_frac_test();
        r8Test.r8vec_mirror_next_test();
        RationalTest.rat_add_test();
        RationalTest.rat_div_test();
        RationalTest.rat_farey_test();
        RationalTest.rat_farey2_test();
        RationalTest.rat_mul_test();
        RationalTest.rat_normalize_test();
        RationalTest.rat_sum_formula_test();
        RationalTest.rat_to_cfrac_test();
        RationalTest.rat_to_dec_test();
        RationalTest.rat_to_r8_test();
        RationalTest.rat_to_s_test();
        RationalTest.rat_width_test();
        RationalTest.ratmat_det_test();
        RationalTest.ratmat_print_test();
        RestrictedGrowthTest.regro_next_test();
        FractionTest.rfrac_to_cfrac_test();
        FractionTest.rfrac_to_jfrac_test();
        SchroederTest.schroeder_test();
        SortHeapExternalTest.sort_heap_external_test();
        SubsetTest.subset_by_size_next_test();
        SubsetTest.subset_lex_next_test();
        SubsetTest.subset_gray_next_test();
        SubsetTest.subset_random_test();
        SubsetTest.subset_gray_rank_test();
        SubsetTest.subset_gray_unrank_test();
        SubcompTest.subcomp_next_test();
        SubcompTest.subcompnz_next_test();
        SubcompTest.subcompnz2_next_test();
        TriangleTest.subtriangle_next_test();
        Thuetest.thue_binary_next_test();
        Thuetest.thue_ternary_next_test();
        TriangTest.triang_test();
        TupleTest.tuple_next_test();
        TupleTest.tuple_next_fast_test();
        TupleTest.tuple_next_ge_test();
        TupleTest.tuple_next2_test();
        UnsignTest.ubvec_add_test();
        UnsignTest.ubvec_print_test();
        UnsignTest.ubvec_to_ui4_test();
        UnsignTest.ubvec_xor_test();
        UnsignTest.ui4_to_ubvec_test();
        VectorTest.vec_colex_next_test();
        VectorTest.vec_colex_next2_test();
        VectorTest.vec_colex_next3_test();
        VectorTest.vec_gray_next_test();
        VectorTest.vec_gray_rank_test();
        VectorTest.vec_gray_unrank_test();
        VectorTest.vec_lex_next_test();
        VectorTest.vec_random_test();
        VectorTest.vector_constrained_next_test();
        VectorTest.vector_constrained_next2_test();
        VectorTest.vector_constrained_next3_test();
        VectorTest.vector_constrained_next4_test();
        VectorTest.vector_constrained_next5_test();
        VectorTest.vector_constrained_next6_test();
        VectorTest.vector_constrained_next7_test();
        VectorTest.vector_next_test();
        YoungTableauTest.ytb_enum_test();
        YoungTableauTest.ytb_next_test();
        YoungTableauTest.ytb_random_test();
        Console.WriteLine("");
        Console.WriteLine("SUBSET_TEST");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }
}