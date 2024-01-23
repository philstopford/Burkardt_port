using Burkardt.MeshNS;
using Burkardt.Table;
using Burkardt.Types;

namespace Burkhardt_Tests.Triangulation.Mask;

public class MaskTest
{
    [Test]
    public static void testp15()
    {
        int i;
        int input_node;
        int order;
        string prefix;
        int triangle;

        Console.WriteLine("");
        Console.WriteLine("TRIANGULATION_MASK");
        Console.WriteLine("");
        Console.WriteLine("  Read a node file of NODE_NUM points in 2 dimensions.");
        Console.WriteLine("  Read an associated triangulation file of TRIANGLE_NUM");
        Console.WriteLine("  triangles using 3 or 6 nodes.");
        Console.WriteLine("");
        Console.WriteLine("  For each triangle, call a user masking routine");
        Console.WriteLine("  to see if the triangle should be MASKED (not shown).");
        Console.WriteLine("");
        Console.WriteLine("  Write new node and triangulation files corresponding");
        Console.WriteLine("  to the unmasked data only.");
        Console.WriteLine("");

        prefix = "p15";

        //
        //  Create the filenames.
        //
        string node_filename = prefix + "_nodes.txt";
        string element_filename = prefix + "_elements.txt";
        string node_mask_filename = prefix + "_mask_nodes.txt";
        string element_mask_filename = prefix + "_mask_elements.txt";
        //
        //  Read the node data.
        //
        TableHeader h = typeMethods.r8mat_header_read(node_filename);
        int dim_num = h.m;
        int input_node_num = h.n;

        Console.WriteLine("");
        Console.WriteLine("  Read the header of \"" + node_filename + "\".");
        Console.WriteLine("");
        Console.WriteLine("  Spatial dimension DIM_NUM = " + dim_num + "");
        Console.WriteLine("  Number of nodes NODE_NUM =  " + input_node_num + "");

        double[] input_node_xy = typeMethods.r8mat_data_read(node_filename, dim_num,
            input_node_num);

        Console.WriteLine("");
        Console.WriteLine("  Read the data in \"" + node_filename + "\".");

        typeMethods.r8mat_transpose_print_some(dim_num, input_node_num, input_node_xy,
            1, 1, dim_num, 5, "  First 5 nodes:");
        //
        //  Read the node data.
        //
        h = typeMethods.i4mat_header_read(element_filename);
        int triangle_order = h.m;
        int input_triangle_num = h.n;

        if (triangle_order != 3 && triangle_order != 6)
        {
            Console.WriteLine("");
            Console.WriteLine("TRIANGULATION_MASK - Fatal error!");
            Console.WriteLine("  Data is not for a 3-node or 6-node triangulation.");
            return;
        }

        Console.WriteLine("");
        Console.WriteLine("  Read the header of \"" + element_filename + "\".");
        Console.WriteLine("");
        Console.WriteLine("  Triangle order TRIANGLE_ORDER =    " + triangle_order + "");
        Console.WriteLine("  Number of triangles TRIANGLE_NUM = "
                          + input_triangle_num + "");

        int[] input_triangle_node = typeMethods.i4mat_data_read(element_filename,
            triangle_order, input_triangle_num);

        Console.WriteLine("");
        Console.WriteLine("  Read the data in \"" + element_filename + "\".");

        typeMethods.i4mat_transpose_print_some(triangle_order, input_triangle_num,
            input_triangle_node, 1, 1, triangle_order, 5,
            "  First 5 triangles::");
        //
        //  Detect and correct 1-based node indexing.
        //
        Mesh.mesh_base_zero(input_node_num, triangle_order, input_triangle_num,
            ref input_triangle_node);
        //
        //  Mask the triangles.
        //
        double[] coord = new double[dim_num * triangle_order];
        bool[] input_triangle_mask = new bool[input_triangle_num];
        int[] nodes = new int[triangle_order];

        int output_triangle_num = 0;

        for (triangle = 0; triangle < input_triangle_num; triangle++)
        {
            for (order = 0; order < triangle_order; order++)
            {
                nodes[order] = input_triangle_node[order + triangle * triangle_order];
            }

            for (order = 0; order < triangle_order; order++)
            {
                for (i = 0; i < dim_num; i++)
                {
                    coord[(i + order * dim_num + coord.Length) % coord.Length] = input_node_xy[(i + (nodes[order] - 1) * dim_num + input_node_xy.Length) % input_node_xy.Length];
                }
            }

            bool mask = P15.triangle_mask(dim_num, triangle_order, nodes, coord);

            input_triangle_mask[triangle] = mask;

            switch (mask)
            {
                case false:
                    output_triangle_num += 1;
                    break;
            }
        }

        switch (false)
        {
            case true:
                typeMethods.lvec_print(input_triangle_num, input_triangle_mask,
                    "  INPUT_TRIANGLE_MASK");
                break;
        }

        //
        //  Determine which nodes are being used.
        //
        bool[] input_node_mask = new bool[input_node_num];

        for (input_node = 0; input_node < input_node_num; input_node++)
        {
            input_node_mask[input_node] = true;
        }

        for (triangle = 0; triangle < input_triangle_num; triangle++)
        {
            switch (input_triangle_mask[triangle])
            {
                case false:
                {
                    for (order = 0; order < triangle_order; order++)
                    {
                        int node = input_triangle_node[order + triangle * triangle_order];
                        input_node_mask[node - 1] = false;
                    }

                    break;
                }
            }
        }

        switch (false)
        {
            case true:
                typeMethods.lvec_print(input_node_num, input_node_mask,
                    "  INPUT_NODE_MASK");
                break;
        }

        int[] input_to_output_node = new int[input_node_num];

        for (input_node = 0; input_node < input_node_num; input_node++)
        {
            input_to_output_node[input_node] = -1;
        }

        int output_node_num = 0;
        for (input_node = 0; input_node < input_node_num; input_node++)
        {
            switch (input_node_mask[input_node])
            {
                case false:
                    output_node_num += 1;
                    input_to_output_node[input_node] = output_node_num;
                    break;
            }
        }

        //
        //  Write the unmasked triangles.
        //
        int[] output_triangle_node = new int[triangle_order * output_triangle_num];

        output_triangle_num = 0;

        for (triangle = 0; triangle < input_triangle_num; triangle++)
        {
            switch (input_triangle_mask[triangle])
            {
                case false:
                {
                    for (order = 0; order < triangle_order; order++)
                    {
                        output_triangle_node[order + output_triangle_num * triangle_order] =
                            input_to_output_node[
                                input_triangle_node[order + triangle * triangle_order] - 1];
                    }

                    output_triangle_num += 1;
                    break;
                }
            }
        }

        typeMethods.i4mat_write(element_mask_filename, triangle_order,
            output_triangle_num, output_triangle_node);

        Console.WriteLine("");
        Console.WriteLine("  The masked triangle data was written to \""
                          + element_mask_filename + "\".");
        //
        //  Write the unmasked nodes.
        //
        double[] output_node_xy = new double[dim_num * output_node_num];

        for (input_node = 0; input_node < input_node_num; input_node++)
        {
            switch (input_node_mask[input_node])
            {
                case false:
                {
                    int output_node = input_to_output_node[input_node];
                    for (i = 0; i < dim_num; i++)
                    {
                        output_node_xy[i + (output_node - 1) * dim_num] =
                            input_node_xy[i + input_node * dim_num];
                    }

                    break;
                }
            }
        }

        typeMethods.r8mat_write(node_mask_filename, dim_num, output_node_num,
            output_node_xy);

        Console.WriteLine("");
        Console.WriteLine("  The masked node data was written to \"" + node_mask_filename
                                                                     + "\".");
        //
        //  Summary report.
        //
        Console.WriteLine("");
        Console.WriteLine("  Number of input triangles =   " + input_triangle_num + "");
        Console.WriteLine("  Number of output triangles =  " + output_triangle_num + "");
        Console.WriteLine("  Number of deleted triangles = " +
                          (input_triangle_num - output_triangle_num) + "");
        Console.WriteLine("");
        Console.WriteLine("  Number of input nodes =   " + input_node_num + "");
        Console.WriteLine("  Number of output nodes =  " + output_node_num + "");
        Console.WriteLine("  Number of deleted nodes = " +
                          (input_node_num - output_node_num) + "");

        typeMethods.i4mat_transpose_print_some(triangle_order, output_triangle_num,
            output_triangle_node, 1, 1, triangle_order, 5,
            "  First 5 output triangles:");

        typeMethods.r8mat_transpose_print_some(dim_num, output_node_num, output_node_xy,
            1, 1, dim_num, 5, "  First 5 output nodes:");

        Console.WriteLine("");
        Console.WriteLine("TRIANGULATION_MASK:");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }

    [Test]
    public static void testsmall()
    {
        int i;
        int input_node;
        int order;
        string prefix;
        int triangle;

        Console.WriteLine("");
        Console.WriteLine("TRIANGULATION_MASK");
        Console.WriteLine("");
        Console.WriteLine("  Read a node file of NODE_NUM points in 2 dimensions.");
        Console.WriteLine("  Read an associated triangulation file of TRIANGLE_NUM");
        Console.WriteLine("  triangles using 3 or 6 nodes.");
        Console.WriteLine("");
        Console.WriteLine("  For each triangle, call a user masking routine");
        Console.WriteLine("  to see if the triangle should be MASKED (not shown).");
        Console.WriteLine("");
        Console.WriteLine("  Write new node and triangulation files corresponding");
        Console.WriteLine("  to the unmasked data only.");
        Console.WriteLine("");

        prefix = "small";
        
        //
        //  Create the filenames.
        //
        string node_filename = prefix + "_nodes.txt";
        string element_filename = prefix + "_elements.txt";
        string node_mask_filename = prefix + "_mask_nodes.txt";
        string element_mask_filename = prefix + "_mask_elements.txt";
        //
        //  Read the node data.
        //
        TableHeader h = typeMethods.r8mat_header_read(node_filename);
        int dim_num = h.m;
        int input_node_num = h.n;

        Console.WriteLine("");
        Console.WriteLine("  Read the header of \"" + node_filename + "\".");
        Console.WriteLine("");
        Console.WriteLine("  Spatial dimension DIM_NUM = " + dim_num + "");
        Console.WriteLine("  Number of nodes NODE_NUM =  " + input_node_num + "");

        double[] input_node_xy = typeMethods.r8mat_data_read(node_filename, dim_num,
            input_node_num);

        Console.WriteLine("");
        Console.WriteLine("  Read the data in \"" + node_filename + "\".");

        typeMethods.r8mat_transpose_print_some(dim_num, input_node_num, input_node_xy,
            1, 1, dim_num, 5, "  First 5 nodes:");
        //
        //  Read the node data.
        //
        h = typeMethods.i4mat_header_read(element_filename);
        int triangle_order = h.m;
        int input_triangle_num = h.n;

        if (triangle_order != 3 && triangle_order != 6)
        {
            Console.WriteLine("");
            Console.WriteLine("TRIANGULATION_MASK - Fatal error!");
            Console.WriteLine("  Data is not for a 3-node or 6-node triangulation.");
            return;
        }

        Console.WriteLine("");
        Console.WriteLine("  Read the header of \"" + element_filename + "\".");
        Console.WriteLine("");
        Console.WriteLine("  Triangle order TRIANGLE_ORDER =    " + triangle_order + "");
        Console.WriteLine("  Number of triangles TRIANGLE_NUM = "
                          + input_triangle_num + "");

        int[] input_triangle_node = typeMethods.i4mat_data_read(element_filename,
            triangle_order, input_triangle_num);

        Console.WriteLine("");
        Console.WriteLine("  Read the data in \"" + element_filename + "\".");

        typeMethods.i4mat_transpose_print_some(triangle_order, input_triangle_num,
            input_triangle_node, 1, 1, triangle_order, 5,
            "  First 5 triangles::");
        //
        //  Detect and correct 1-based node indexing.
        //
        Mesh.mesh_base_zero(input_node_num, triangle_order, input_triangle_num,
            ref input_triangle_node);
        //
        //  Mask the triangles.
        //
        double[] coord = new double[dim_num * triangle_order];
        bool[] input_triangle_mask = new bool[input_triangle_num];
        int[] nodes = new int[triangle_order];

        int output_triangle_num = 0;

        for (triangle = 0; triangle < input_triangle_num; triangle++)
        {
            for (order = 0; order < triangle_order; order++)
            {
                nodes[order] = input_triangle_node[order + triangle * triangle_order];
            }

            for (order = 0; order < triangle_order; order++)
            {
                for (i = 0; i < dim_num; i++)
                {
                    coord[i + order * dim_num] = input_node_xy[i + (nodes[order] - 1) * dim_num];
                }
            }

            bool mask = Small.triangle_mask(dim_num, triangle_order, nodes, coord);

            input_triangle_mask[triangle] = mask;

            switch (mask)
            {
                case false:
                    output_triangle_num += 1;
                    break;
            }
        }

        switch (false)
        {
            case true:
                typeMethods.lvec_print(input_triangle_num, input_triangle_mask,
                    "  INPUT_TRIANGLE_MASK");
                break;
        }

        //
        //  Determine which nodes are being used.
        //
        bool[] input_node_mask = new bool[input_node_num];

        for (input_node = 0; input_node < input_node_num; input_node++)
        {
            input_node_mask[input_node] = true;
        }

        for (triangle = 0; triangle < input_triangle_num; triangle++)
        {
            switch (input_triangle_mask[triangle])
            {
                case false:
                {
                    for (order = 0; order < triangle_order; order++)
                    {
                        int node = input_triangle_node[order + triangle * triangle_order];
                        input_node_mask[node - 1] = false;
                    }

                    break;
                }
            }
        }

        switch (false)
        {
            case true:
                typeMethods.lvec_print(input_node_num, input_node_mask,
                    "  INPUT_NODE_MASK");
                break;
        }

        int[] input_to_output_node = new int[input_node_num];

        for (input_node = 0; input_node < input_node_num; input_node++)
        {
            input_to_output_node[input_node] = -1;
        }

        int output_node_num = 0;
        for (input_node = 0; input_node < input_node_num; input_node++)
        {
            switch (input_node_mask[input_node])
            {
                case false:
                    output_node_num += 1;
                    input_to_output_node[input_node] = output_node_num;
                    break;
            }
        }

        //
        //  Write the unmasked triangles.
        //
        int[] output_triangle_node = new int[triangle_order * output_triangle_num];

        output_triangle_num = 0;

        for (triangle = 0; triangle < input_triangle_num; triangle++)
        {
            switch (input_triangle_mask[triangle])
            {
                case false:
                {
                    for (order = 0; order < triangle_order; order++)
                    {
                        output_triangle_node[order + output_triangle_num * triangle_order] =
                            input_to_output_node[
                                input_triangle_node[order + triangle * triangle_order] - 1];
                    }

                    output_triangle_num += 1;
                    break;
                }
            }
        }

        typeMethods.i4mat_write(element_mask_filename, triangle_order,
            output_triangle_num, output_triangle_node);

        Console.WriteLine("");
        Console.WriteLine("  The masked triangle data was written to \""
                          + element_mask_filename + "\".");
        //
        //  Write the unmasked nodes.
        //
        double[] output_node_xy = new double[dim_num * output_node_num];

        for (input_node = 0; input_node < input_node_num; input_node++)
        {
            switch (input_node_mask[input_node])
            {
                case false:
                {
                    int output_node = input_to_output_node[input_node];
                    for (i = 0; i < dim_num; i++)
                    {
                        output_node_xy[i + (output_node - 1) * dim_num] =
                            input_node_xy[i + input_node * dim_num];
                    }

                    break;
                }
            }
        }

        typeMethods.r8mat_write(node_mask_filename, dim_num, output_node_num,
            output_node_xy);

        Console.WriteLine("");
        Console.WriteLine("  The masked node data was written to \"" + node_mask_filename
                                                                     + "\".");
        //
        //  Summary report.
        //
        Console.WriteLine("");
        Console.WriteLine("  Number of input triangles =   " + input_triangle_num + "");
        Console.WriteLine("  Number of output triangles =  " + output_triangle_num + "");
        Console.WriteLine("  Number of deleted triangles = " +
                          (input_triangle_num - output_triangle_num) + "");
        Console.WriteLine("");
        Console.WriteLine("  Number of input nodes =   " + input_node_num + "");
        Console.WriteLine("  Number of output nodes =  " + output_node_num + "");
        Console.WriteLine("  Number of deleted nodes = " +
                          (input_node_num - output_node_num) + "");

        typeMethods.i4mat_transpose_print_some(triangle_order, output_triangle_num,
            output_triangle_node, 1, 1, triangle_order, 5,
            "  First 5 output triangles:");

        typeMethods.r8mat_transpose_print_some(dim_num, output_node_num, output_node_xy,
            1, 1, dim_num, 5, "  First 5 output nodes:");

        Console.WriteLine("");
        Console.WriteLine("TRIANGULATION_MASK:");
        Console.WriteLine("  Normal end of execution.");
        Console.WriteLine("");
    }
    
}