using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_20_P4
{
    class Depth_First_Traverse
    {
        public struct Vertex
        {
            public char Etiket;
            public bool Ugrandi;
        }
        private int ust = -1;
        private int tepeSay = 0;
        private int Peek(int[] stack)
        {
            return stack[ust];
        }
        private void Push(int[] stack, int item)
        {
            stack[++ust] = item;
        }
        private int Pop(int[] stack)
        {
            return stack[ust--];
        }
        private int UgranmisKomsuTepeAl(Vertex[] tepeDizi, int[,] komsulukMatrisi, int tepeIndeks)
        {
            for (int i = 0; i < tepeSay; ++i)
            {
                if (komsulukMatrisi[tepeIndeks, i] == 1 && tepeDizi[i].Ugrandi == false)
                {
                    return i;
                }
            }
            return -1;
        }
        public void TepeEkle(Vertex[] tepeDizi, char etiket)
        {
            Vertex vertex = new Vertex();
            vertex.Etiket = etiket;
            vertex.Ugrandi = false;
            tepeDizi[tepeSay++] = vertex;
        }
        private void TepeGoruntule(Vertex[] tepeDizi, int tepeIndeks)
        {
            Console.Write(tepeDizi[tepeIndeks].Etiket + " ");
        }
        public void KenarEkle(int[,] komsulukMatrisi, int baslangic, int bitis)
        {
            komsulukMatrisi[baslangic, bitis] = 1;
            komsulukMatrisi[bitis, baslangic] = 1;
        }
        private bool StackBosMu()
        {
            return ust == -1;
        }
        public void DepthFirstTraverse(Vertex[] tepeDizi, int[,] komsulukMatrisi,int[] stack)
        {
            tepeDizi[0].Ugrandi = true;
            TepeGoruntule(tepeDizi, 0);
            Push(stack, 0);
            while (!StackBosMu())
            {
                int unvisitedVertex = UgranmisKomsuTepeAl(tepeDizi, komsulukMatrisi, Peek(stack));
                if (unvisitedVertex == -1)
                {
                    Pop(stack);
                }
                else
                {
                    tepeDizi[unvisitedVertex].Ugrandi = true;
                    TepeGoruntule(tepeDizi, unvisitedVertex);
                    Push(stack, unvisitedVertex);
                }
            }
            for (int i = 0; i < tepeSay; ++i)
            {
                tepeDizi[i].Ugrandi = false;
            }
        }

    }
}
