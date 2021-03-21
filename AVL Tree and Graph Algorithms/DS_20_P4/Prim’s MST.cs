using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_20_P4
{
    class Prim_s_MST
    {
        private void Yazdir(int[] parent, int[,] graf, int tepeSay)
        {
            Console.WriteLine("Kenar Ağırlık");
            for (int i = 1; i < tepeSay; ++i)
                Console.WriteLine("{0} - {1} {2}", parent[i], i, graf[i, parent[i]]);
        }
        private int MinAnahtar(int[] anahtar, bool[] set, int tepeSay)
        {
            int min = int.MaxValue, minIndex = 0;
            for (int v = 0; v < tepeSay; ++v)
            {
                if (set[v] == false && anahtar[v] < min)
                {
                    min = anahtar[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
        public void Prim(int[,] graf, int tepeSay)
        {
            int[] parent = new int[tepeSay];
            int[] anahtar = new int[tepeSay];
            bool[] mstSet = new bool[tepeSay];
            for (int i = 0; i < tepeSay; ++i)
            {
                anahtar[i] = int.MaxValue;
                mstSet[i] = false;
            }
            anahtar[0] = 0;
            parent[0] = -1;
            for (int count = 0; count < tepeSay - 1; ++count)
            {
                int u = MinAnahtar(anahtar, mstSet, tepeSay);
                mstSet[u] = true;
                for (int v = 0; v < tepeSay; ++v)
                {
                    
                    if (Convert.ToBoolean(graf[u, v]) && mstSet[v] == false && graf[u, v] < anahtar[v])
                    {
                        parent[v] = u;
                        anahtar[v] = graf[u, v];
                    }
                }
            }
            Yazdir(parent, graf, tepeSay);
        }
    }
}
