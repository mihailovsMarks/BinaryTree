using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BinaryTree
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_generate_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            int num;
            tb_array.Text = "";
            tb_Sortedarray.Text = "";
            num = rnd.Next(0, 100);
            tb_array.Text = tb_array.Text + num.ToString().PadLeft(3);
            tree MyTree = new tree(num);

            int n = int.Parse(txt_input.Text);
            for (int i = 1; i < n; i++)
            {
                num = rnd.Next(0,100);
                tb_array.Text = tb_array.Text + num.ToString().PadLeft(3);
                MyTree.addRc(num); //using recursive function
                // MyTree.add(num); //none recursive function
            }

            string treestring = "";
            MyTree.Print(null, ref treestring);
            tb_Sortedarray.Text = treestring;
        }
    }

    class node
    {
        public int value;
        public node left;
        public node right;

        public node(int initial)
        {
            value = initial;
            left = null;
            right = null;
        }

    }

    class tree
    {
        node top;

        public tree()
        {
            top = null;
        }

        public tree (int initial)
        {
            top = new node (initial);

        }

        public void add(int value)
        {
            //non recursive funtion
            if (top == null) //tree is empty
            {
                //add item as the base node
                node newnode = new node(value);
                top = newnode;
                return;
            }
            node currentnode = top;
            bool added = false;
            do
            {
                //traverse tree
                if(value < currentnode.value)
                {
                    //go left
                    if (currentnode.left == null)
                    {
                        node newnode = new node(value);
                        currentnode.left = newnode;
                        added = true;
                    }
                    else
                    {
                        currentnode = currentnode.left;
                    }
                }
                if (value >= currentnode.value)
                {
                    //go right
                    if (currentnode.right == null)
                    {
                        node newnode = new node(value);
                        currentnode.right = newnode;
                        added = true;
                    }
                    else
                    {
                        currentnode = currentnode.right;
                    }
                }

            } while (!added);
        }

        public void addRc(int value)
        {
            //recursive
            addR(ref top, value);
        }

        private void addR(ref node N, int value)
        {
            //private recursive search for where to add the new node
            if(N == null)
            {
                node newnode = new node(value);
                N = newnode;
                return; // end fuction call
            }
            if(value < N.value)
            {
                addR(ref N.left, value);
                return;

            }
            if(value >= N.value)
            {
                addR(ref N.right, value);
                return;
            }
        }

        public void Print(node N, ref string s)
        {
            //write out the tree in a sorted order to the string newstring
            //implament using recursion
            if(N == null) { N = top; }
            if(N.left != null)
            {
                Print(N.left, ref s);
                s = s + N.value.ToString().PadLeft(3);
            }
            else
            {
                s = s + N.value.ToString().PadLeft(3);
            }
            if(N.right != null)
            {
                Print(N.right, ref s);
            }
        }
    }
}
