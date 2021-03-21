using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_20_P4
{
    class AVLTree
    {
        private Node root;
        internal Node Root { get => root; set => root = value; }
        // Ağacın yüksekliğini verir
        public int YukseklikAl(Node N)
        {
            if (N == null)
                return 0;
            return N.Yukseklik;
        }
        // iki integer sayıyı karşılaştırıp yükseğini döndürür
        public int Max(int a, int b)
        {
            return (a > b) ? a : b;
        }
        // y yi alt ağacın kökü kabul eder ve right rotation yapar.
        public Node RightRotate(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;
            // Döndürme gerçekleşir
            x.Right = y;
            y.Left = T2;
            // Yükseklik güncellenir
            y.Yukseklik = Max(YukseklikAl(y.Left), YukseklikAl(y.Right)) + 1;
            x.Yukseklik = Max(YukseklikAl(x.Left), YukseklikAl(x.Right)) + 1;
            return x;
        }
        // x i alt ağacın kökü kabul eder ve left rotation yapar.
        public Node LeftRotate(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;
            // Döndürme gerçekleşir
            y.Left = x;
            x.Right = T2;
            // Yükseklik güncellenir
            x.Yukseklik = Max(YukseklikAl(x.Left), YukseklikAl(x.Right)) + 1;
            y.Yukseklik = Max(YukseklikAl(y.Left), YukseklikAl(y.Right)) + 1;
            return y;
        }
        // sağ ve sol alt ağaç arasındaki yükseklik farkını verir.
        public int DengeAl(Node N)
        {
            if (N == null)
                return 0;
            return YukseklikAl(N.Left) - YukseklikAl(N.Right);
        }
        //kök ve veriyi alarak AVL ağacına verinin yerleştirilmesi
        public Node Insert(Node node, int veri)
        {
            //normal binary search tree eklemesi
            if (node == null)
                return (new Node(veri));
            if (veri < node.Veri)
                node.Left = Insert(node.Left, veri);
            else if (veri > node.Veri)
                node.Right = Insert(node.Right, veri);
            else // Değer varsa tekrar eklenmesin
                return node;
            //ancestor node un yüksekliği güncellenir
            node.Yukseklik = 1 + Max(YukseklikAl(node.Left),YukseklikAl(node.Right));
            //dengeli olup olmadığına bakmak için ancestor node un alt ağaçları
            //arasındaki yükseklik farkı alınır
            int denge = DengeAl(node);
            // Ağaç dengesini kaybettiyse
            // Left Left Durumu
            if (denge > 1 && veri < node.Left.Veri)
                return RightRotate(node);
            // Right Right Durumu
            if (denge < -1 && veri > node.Right.Veri)
                return LeftRotate(node);
            // Left Right Durumu
            if (denge > 1 && veri > node.Left.Veri)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }
            // Right Left Durumu
            if (denge < -1 && veri < node.Right.Veri)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }
            return node;
        }
        //ağacı preOrder dolaşma
        public void preOrder(Node node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Veri + " ");
                preOrder(node.Left);
                preOrder(node.Right);
            }
        }
    }
}
