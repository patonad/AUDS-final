using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace AVL
{
    class AvlTree<T> where T : IComparable<T>

    {
        public AvlNode<T> Root { get; set; }

        private string UpravVysku(ref AvlNode<T> node)
        {
            string akaRotacia = "";
            int vyskaPravy = (node.Right == null ? -1 : node.Right.Vyska) + 1;
            int vyskaLavy = (node.Left == null ? -1 : node.Left.Vyska) + 1;
            while (node.Parent != null)
            {
                node.Vyska = Math.Max(vyskaLavy, vyskaPravy);
                akaRotacia += node.SomPravy() ? "r" : "l";
                if (Math.Abs(vyskaLavy - vyskaPravy) > 1)
                {
                    return "e";
                }
                node = node.Parent;
                vyskaPravy = (node.Right == null ? -1 : node.Right.Vyska) + 1;
                vyskaLavy = (node.Left == null ? -1 : node.Left.Vyska) + 1;
                if (node.Parent == null)
                {
                    node.Vyska = Math.Max(vyskaLavy, vyskaPravy);
                }

                if (Math.Abs(vyskaLavy - vyskaPravy) > 1)
                {
                    var pomoc = akaRotacia.ToCharArray();

                    return "" + pomoc[pomoc.Length - 1] + pomoc[pomoc.Length - 2];
                }
            }
            node.Vyska = Math.Max(vyskaLavy, vyskaPravy);
            return Math.Abs(vyskaLavy - vyskaPravy) > 1 ? "e" : "ee";
        }
        public void Rotuj(AvlNode<T> treeNode)
        {
            var pomNode = treeNode;
            var str = UpravVysku(ref pomNode);

            if (str != "ee")
            {
                if (str == "rr")
                {
                    JednoduchaLava(pomNode);
                }
                else if (str == "ll")
                {
                    JednoduchaPrava(pomNode);
                }
                else if (str == "lr")
                {
                    JednoduchaLava(pomNode.Left);
                    JednoduchaPrava(pomNode);
                }
                else
                {
                    JednoduchaPrava(pomNode.Right);
                    JednoduchaLava(pomNode);
                }
            }
        }
        public void Delete(T data)
        {
            var node = FindNode(data);
            if (node.Right == null && node.Left == null)
            {
                if (node.Parent == null)
                {
                    Root = null;
                }
                else
                {
                    if (node.SomPravy())
                    {
                        node.Parent.Right = null;
                        RotaciaUpdate(node.Parent);
                    }
                    else
                    {
                        node.Parent.Left = null;
                        RotaciaUpdate(node.Parent);
                    }
                }
            }
            else
            {
                if (node.Right != null && node.Left == null) 
                {
                    if (node.Parent == null)
                    {
                        Root = node.Right;
                        Root.Parent = null;
                    }
                    else
                    {
                        if (node.SomPravy())
                        {
                            node.Parent.Right = node.Right;
                            node.Right.Parent = node.Parent;
                            RotaciaUpdate(node.Right);
                        }
                        else
                        {
                            node.Parent.Left = node.Right;
                            node.Right.Parent = node.Parent;
                            RotaciaUpdate(node.Right);
                        }
                    }
                }
                if (node.Right == null && node.Left != null)//4
                {
                    if (node.Parent == null)
                    {
                        Root = node.Left;
                        Root.Parent = null;
                    }
                    else
                    {

                        if (node.SomPravy())
                        {
                            node.Parent.Right = node.Left;
                            node.Left.Parent = node.Parent;
                            RotaciaUpdate(node.Left);
                        }
                        else
                        {
                            node.Parent.Left = node.Left;
                            node.Left.Parent = node.Parent;
                            RotaciaUpdate(node.Left);
                        }
                    }

                }

                if (node.Right != null && node.Left != null)
                {
                    var curr = InOrderPredchodca(node);
                    var parCurr = curr.Parent;
                    if (!curr.SomPravy())
                    {
                        if (node.Parent == null)
                        {
                            Root = curr;
                            curr.Parent = null;
                            curr.Right = node.Right;
                            curr.Right.Parent = curr;
                            RotaciaUpdate(curr);
                        }
                        else
                        {
                            if (node.SomPravy())
                            {
                                node.Parent.Right = curr;
                                curr.Parent = node.Parent;
                                curr.Right = node.Right;
                                curr.Right.Parent = curr;
                                RotaciaUpdate(node.Left);
                            }
                            else
                            {
                                node.Parent.Left = curr;
                                curr.Parent = node.Parent;
                                curr.Right = node.Right;
                                curr.Right.Parent = curr;
                                RotaciaUpdate(node.Left);
                            }
                        }
                    }
                    else
                    {
                        if (curr.Left == null)
                        {
                            curr.Left = node.Left;
                            curr.Left.Parent = curr;
                            curr.Right = node.Right;
                            curr.Right.Parent = curr;
                            curr.Parent.Right = null;
                            if (node.Parent == null)
                            {
                                Root = curr;
                                curr.Parent = null;
                            }
                            else
                            {
                                if (node.SomPravy())
                                {
                                    node.Parent.Right = curr;
                                    curr.Parent = node.Parent;
                                }
                                else
                                {
                                    node.Parent.Left = curr;
                                    curr.Parent = node.Parent;
                                }
                            }

                            
                           
                        }
                        else
                        {
                            curr.Parent.Right = curr.Left;
                            curr.Left.Parent = curr.Parent;
                            curr.Left = node.Left;
                            curr.Left.Parent = curr;
                            curr.Right = node.Right;
                            curr.Right.Parent = curr;
                            if (node.Parent == null)
                            {
                                Root = curr;
                                curr.Parent = null;
                            }
                            else
                            {
                                if (node.SomPravy())
                                {
                                    node.Parent.Right = curr;
                                    curr.Parent = node.Parent;
                                }
                                else
                                {
                                    node.Parent.Left = curr;
                                    curr.Parent = node.Parent;
                                }
                            }

                            
                        }
                        RotaciaUpdate(parCurr);
                    }
                }
            }
        }
        private string UpravVyskuUpdate(ref AvlNode<T> node)

        {
            int vyskaPravy = (node.Right == null ? -1 : node.Right.Vyska) + 1;
            int vyskaLavy = (node.Left == null ? -1 : node.Left.Vyska) + 1;
            node.Vyska = Math.Max(vyskaLavy, vyskaPravy);
            if (Math.Abs(vyskaLavy - vyskaPravy) > 1)
            {
                return "e";
            }
            while (node.Parent != null)
            {
               
                
                node = node.Parent;
                vyskaPravy = (node.Right == null ? -1 : node.Right.Vyska) + 1;
                vyskaLavy = (node.Left == null ? -1 : node.Left.Vyska) + 1;
                node.Vyska = Math.Max(vyskaLavy, vyskaPravy);
                if (Math.Abs(vyskaLavy - vyskaPravy) > 1)
                {
                    return "e";
                }
            }
             return "ee";
        }
        private void RotaciaUpdate(AvlNode<T> node)
        {
            var str = UpravVyskuUpdate(ref node);
            if (str == "ee")
            {
            }
            else
            {
                while (true)
                {
                int vyskaPravy;
                int vyskaLavy;
                int i = 0;
                str = "";
                var pomNode = node;
                while ((node.Right != null || node.Left != null) && i < 2)
                {
                    i++;
                    vyskaPravy = (node.Right == null ? -1 : node.Right.Vyska) + 1;
                    vyskaLavy = (node.Left == null ? -1 : node.Left.Vyska) + 1;
                    if (vyskaLavy < vyskaPravy)
                    {
                        str += "r";
                        node = node.Right;
                    }
                    else if (vyskaLavy > vyskaPravy)
                    {
                        str += "l";
                        node = node.Left;
                    }
                    else
                    {
                        if (str == "l")
                        {
                            str += "l";
                        }
                        else
                        {
                            str += "r";
                        }
                    }
                }

                if (str == "rr")
                {
                    JednoduchaLava(pomNode);
                }
                else if (str == "ll")
                {
                    JednoduchaPrava(pomNode);
                }
                else if (str == "lr")
                {
                    JednoduchaLava(pomNode.Left);
                    JednoduchaPrava(pomNode);
                }
                else
                {
                    JednoduchaPrava(pomNode.Right);
                    JednoduchaLava(pomNode);
                }

                str = UpravVyskuUpdate(ref pomNode);
                    node = pomNode;
                    if (str == "ee")
                    {
                        return;
                    }
                }
            }
        }
        public T Find(T data)
        {
            return FindNode(data).Data;
        }

        private AvlNode<T> FindNode(T data)
        {
            if (Root == null)
                throw new System.Exception("Prazdny strom");
            var pomRoor = Root;
            while (true)
            {
                if (data.CompareTo(pomRoor.Data) == 0)
                {
                    return pomRoor;
                }

                if (pomRoor.Data.CompareTo(data) > 0)//this je vacsi vrati 1
                {
                    if (pomRoor.Left == null)
                    {
                        throw new System.Exception("Prvok sa nenachadza");
                    }
                    pomRoor = pomRoor.Left;
                }
                else
                {
                    if (pomRoor.Right == null)
                    {
                        throw new System.Exception("Prvok sa nenachadza");
                    }
                    pomRoor = pomRoor.Right;
                }
            }
        }
        public void Insert(T data)
        {
            var treeNode = new AvlNode<T>();
            treeNode.Data = data;
            if (Root == null)
            {
                Root = treeNode;
            }
            else
            {
                var pomRoor = Root;
                while (true)
                {
                    if (treeNode.Data.CompareTo(pomRoor.Data) == 0)
                    {
                        throw new System.Exception("Kluc sa uz nachadza");
                    }

                    if (pomRoor.Data.CompareTo(treeNode.Data) > 0)
                    {
                        if (pomRoor.Left == null)
                        {
                            pomRoor.Left = treeNode;
                            treeNode.Parent = pomRoor;
                            Rotuj(treeNode);

                            return;
                        }
                        pomRoor = pomRoor.Left;
                    }
                    else
                    {
                        if (pomRoor.Right == null)
                        {
                            pomRoor.Right = treeNode;
                            treeNode.Parent = pomRoor;
                            Rotuj(treeNode);
                            return;
                        }
                        pomRoor = pomRoor.Right;
                    }
                }
            }
        }
        public void JednoduchaLava(AvlNode<T> vrchol)
        {
            if (vrchol.Right != null)
            {
                var pom = vrchol.Right;
                if (vrchol.Parent != null)
                {
                    if (vrchol.Parent.Left == vrchol)
                    {
                        vrchol.Parent.Left = pom;
                    }
                    else
                    {
                        vrchol.Parent.Right = pom;
                    }

                    pom.Parent = vrchol.Parent;
                }
                else
                {
                    Root = pom;
                    pom.Parent = null;
                }

                if (pom.Left != null)
                {
                    pom.Left.Parent = vrchol;
                    vrchol.Right = pom.Left;
                }
                else
                {
                    vrchol.Right = null;
                }

                vrchol.Parent = pom;
                pom.Left = vrchol;
                if (vrchol.Left == null && vrchol.Right == null)
                {
                    vrchol.Vyska = 0;
                }
                else
                {
                    vrchol.Vyska = Math.Max(vrchol.Left == null ? 0 : vrchol.Left.Vyska, (vrchol.Right == null ? 0 : vrchol.Right.Vyska)) + 1;
                }
                pom.Vyska = Math.Max(pom.Left == null ? 0 : pom.Left.Vyska, (pom.Right == null ? 0 : pom.Right.Vyska)) + 1;
            }
        }
        public void JednoduchaPrava(AvlNode<T> vrchol)
        {
            if (vrchol.Left != null)
            {
                var pom = vrchol.Left;
                var d = pom.Right;
                if (vrchol.Parent != null)
                {
                    if (vrchol.Parent.Left == vrchol)
                    {
                        vrchol.Parent.Left = pom;
                    }
                    else
                    {
                        vrchol.Parent.Right = pom;
                    }

                    pom.Parent = vrchol.Parent;
                }
                else
                {
                    Root = pom;
                    pom.Parent = null;
                }

                pom.Right = vrchol;
                vrchol.Parent = pom;
                if (pom.Right == null)
                {
                    vrchol.Left = null;
                }
                else
                {
                    vrchol.Left = d;
                    if (d != null)
                    {
                        d.Parent = vrchol;
                    }
                }
                if (vrchol.Left == null && vrchol.Right == null)
                {
                    vrchol.Vyska = 0;
                }
                else
                {
                    vrchol.Vyska = Math.Max(vrchol.Left == null ? 0 : vrchol.Left.Vyska, (vrchol.Right == null ? 0 : vrchol.Right.Vyska)) + 1;
                }
                pom.Vyska = Math.Max(pom.Left == null ? 0 : pom.Left.Vyska, (pom.Right == null ? 0 : pom.Right.Vyska)) + 1;
            }


        }

        public bool SkontrolujVysku()
        {
            var node = Root;
            int lavaVyska = VyskaRec(node.Left);
            int pravaVyska = VyskaRec(node.Right);

            if (node.Vyska ==Math.Max(lavaVyska,pravaVyska))
            {
                return true;
            }
            return false;
        }
        public int VyskaRec(AvlNode<T> node)
        {
            int vyska = 0;
            if (node == null)
            {
                return vyska;
            }
            int left = VyskaRec(node.Left);
            int right = VyskaRec(node.Right);
            vyska = Math.Max(left, right) + 1;
            return vyska;
        }
        public List<T> InOrder()
        {
            List<T> list = new List<T>();
            if (Root == null)
                return list;
            Stack<AvlNode<T>> s = new Stack<AvlNode<T>>();
            AvlNode<T> curr = Root;

            while (curr != null || s.Count > 0)
            {
                while (curr != null)
                {
                    s.Push(curr);
                    curr = curr.Left;
                }
                curr = s.Pop();
                list.Add(curr.Data);
                curr = curr.Right;
            }
            return list;
        }
        public void LevelOrderConsole()
        {
            Queue<AvlNode<T>> stack = new Queue<AvlNode<T>>();
            stack.Enqueue(Root);
            List<AvlNode<T>> tree = new List<AvlNode<T>>();
            while (stack.Count > 0 && stack.Count < Math.Pow(2, Root.Vyska + 2))
            {
                var actual = stack.Dequeue();
                tree.Add(actual);
                if (actual == null)
                {
                    stack.Enqueue(null);
                    stack.Enqueue(null);
                }
                else
                {
                    if (actual.Left != null) stack.Enqueue(actual.Left);
                    else stack.Enqueue(null);
                    if (actual.Right != null) stack.Enqueue(actual.Right);
                    else stack.Enqueue(null);
                }
            }

            int height = Root.Vyska;
            int deep = 0;
            string indent = new string(' ', (int)(Math.Pow(2, Root.Vyska) - 1));
            string spaces = new string(' ', (int)(Math.Pow(2, Root.Vyska + 1) - 1));
            int size = (int)Math.Pow(2, Root.Vyska + 1);
            int count = 1;
            int index = 0;
            for (int i = 0; i < size; i += (int)Math.Pow(2, deep))
            {
                Console.Write(indent);
                for (int j = index; j < count; j++)
                {
                    if (tree.ToArray()[j] != null) Console.Write(tree.ToArray()[j].Data + "" + tree.ToArray()[j].Vyska);
                    else Console.Write(" ");
                    Console.Write(spaces);
                    index++;
                }

                Console.WriteLine();

                deep++;
                indent = new string(' ', (int)(Math.Pow(2, (height - deep)) - 1));
                spaces = new string(' ', (int)(Math.Pow(2, (height - deep) + 1) - 1));
                count += (int)Math.Pow(2, deep);

            }
        }
        public AvlNode<T> InOrderPredchodca(AvlNode<T> node)
        {
            
            AvlNode<T> curr = node.Left; 
            while (curr.Right != null )
            {
                curr = curr.Right;
            }
            return curr;
        }

       
    }
}
