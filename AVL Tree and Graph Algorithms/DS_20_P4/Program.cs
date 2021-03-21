using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_20_P4
{
    class Program
    {
        static void Main(string[] args)
        {
            //2.soru AVL-Tree Testi
            Console.WriteLine("AVL-Tree Testi");
            Console.WriteLine("");

            AVLTree tree = new AVLTree();
            tree.Root = tree.Insert(tree.Root, 10);
            tree.Root = tree.Insert(tree.Root, 20);
            tree.Root = tree.Insert(tree.Root, 30);
            tree.Root = tree.Insert(tree.Root, 40);
            tree.Root = tree.Insert(tree.Root, 50);
            tree.Root = tree.Insert(tree.Root, 25);
            tree.preOrder(tree.Root);
            Console.WriteLine("");
            Console.WriteLine("");

            // 4.a Dijkstra's Shortest Path Testi
            Console.WriteLine("Dijkstra's Shortest Path Testi");
            Console.WriteLine("");
            Dijkstra_s_Shortest_Path dijkstra_S_Shortest_Path = new Dijkstra_s_Shortest_Path();
            int[,] graph = {
                            { 0, 4, 0, 0, 0, 0, 0, 8, 0 },
                            { 4, 0, 8, 0, 0, 0, 0, 11, 0 },
                            { 0, 8, 0, 7, 0, 4, 0, 0, 2 },
                            { 0, 0, 7, 0, 9, 14, 0, 0, 0 },
                            { 0, 0, 0, 9, 0, 10, 0, 0, 0 },
                            { 0, 0, 4, 0, 10, 0, 2, 0, 0 },
                            { 0, 0, 0, 14, 0, 2, 0, 1, 6 },
                            { 8, 11, 0, 0, 0, 0, 1, 0, 7 },
                            { 0, 0, 2, 0, 0, 0, 6, 7, 0 }
                            };
            dijkstra_S_Shortest_Path.Dijkstra(graph, 0, 9);
            Console.WriteLine("");
            Console.WriteLine("");

            // 4.b Prim's MST Testi
            Console.WriteLine("Prim's MST Testi");
            Console.WriteLine("");
            int[,] graf = {
                            { 0, 2, 0, 6, 0 },
                            { 2, 0, 3, 8, 5 },
                            { 0, 3, 0, 0, 7 },
                            { 6, 8, 0, 0, 9 },
                            { 0, 5, 7, 9, 0 },
                            };
            Prim_s_MST prim = new Prim_s_MST();
            prim.Prim(graf, 5);
            Console.WriteLine("");
            Console.WriteLine("");

            // 4.c Depth-first Traverse Testi
            Console.WriteLine("Depth-first Traverse Testi");
            Console.WriteLine("");

            int max = 5;
            int[] stack = new int[max];
            Depth_First_Traverse depth_First_Traverse = new Depth_First_Traverse();
            Depth_First_Traverse.Vertex[] tepeDizi = new Depth_First_Traverse.Vertex[max];
            int[,] komsulukMatrisi = new int[max, max];
            for (int i = 0; i < max; ++i)
                for (int j = 0; j < max; ++j)
                    komsulukMatrisi[i, j] = 0;
            depth_First_Traverse.TepeEkle(tepeDizi, 'K');
            depth_First_Traverse.TepeEkle(tepeDizi, 'L');
            depth_First_Traverse.TepeEkle(tepeDizi, 'M');
            depth_First_Traverse.TepeEkle(tepeDizi, 'N');
            depth_First_Traverse.TepeEkle(tepeDizi, 'O');
            depth_First_Traverse.KenarEkle(komsulukMatrisi, 0, 1);
            depth_First_Traverse.KenarEkle(komsulukMatrisi, 0, 2);
            depth_First_Traverse.KenarEkle(komsulukMatrisi, 0, 3);
            depth_First_Traverse.KenarEkle(komsulukMatrisi, 1, 4);
            depth_First_Traverse.KenarEkle(komsulukMatrisi, 2, 4);
            depth_First_Traverse.KenarEkle(komsulukMatrisi, 3, 4);
            Console.Write("Depth First Traverse: ");
            depth_First_Traverse.DepthFirstTraverse(tepeDizi, komsulukMatrisi, stack);
        }
    }
}
