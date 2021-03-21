using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_20_P4
{
    public class Dijkstra_s_Shortest_Path
    {
        private void Yazdır(int[] mesafe, int tepeSay)
        {
            Console.WriteLine("Tepe Kaynaktan Uzaklık");
            for (int i = 0; i < tepeSay; ++i)
                Console.WriteLine("{0}\t {1}", i, mesafe[i]);
        }
        public void Dijkstra(int[,] graf, int kaynak, int tepeSay)
        {
            int[] mesafe = new int[tepeSay];
            bool[] enKisaYolSet = new bool[tepeSay];
            for (int i = 0; i < tepeSay; ++i)
            {
                mesafe[i] = int.MaxValue;
                enKisaYolSet[i] = false;
            }
            mesafe[kaynak] = 0;
            for (int count = 0; count < tepeSay - 1; ++count)
            {
                int u = MinMesafe(mesafe, enKisaYolSet, tepeSay);
                enKisaYolSet[u] = true;
                for (int v = 0; v < tepeSay; ++v)
                    if (!enKisaYolSet[v] && Convert.ToBoolean(graf[u, v]) && mesafe[u] != int.MaxValue && mesafe[u] + graf[u, v] < mesafe[v])
                        mesafe[v] = mesafe[u] + graf[u, v];
            }
            Yazdır(mesafe, tepeSay);
        }
        private int MinMesafe(int[] mesafe, bool[] enKisaYolSet, int tepeSay)
        {
            int min = int.MaxValue;
            int minIndex = 0;
            for (int v = 0; v < tepeSay; ++v)
            {
                if (enKisaYolSet[v] == false && mesafe[v] <= min)
                {
                    min = mesafe[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
    }
}
