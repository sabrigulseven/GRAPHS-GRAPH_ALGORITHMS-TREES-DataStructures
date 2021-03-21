using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_20_P4
{
    class Node
    {
        private int veri;
        private int yukseklik;
        private Node left;
        private Node right;
        public Node(int d)
        {
            veri = d;
            yukseklik = 1;
        }
        public int Veri { get => veri; set => veri = value; }
        public int Yukseklik { get => yukseklik; set => yukseklik = value; }
        internal Node Left { get => left; set => left = value; }
        internal Node Right { get => right; set => right = value; }
    }

}
