﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Net.Practise
{
    // definition of TreeNode<T>:
    public class TreeNode<T>
    {
        public T Data { get; }

        public List<TreeNode<T>> Child { get; set; }

        public TreeNode(T data)
        {
            this.Data = data;
            this.Child = new List<TreeNode<T>>();
        }

        public IEnumerable<TreeNode<T>> DepthFirstTraversal()
        {
            yield return this;

            foreach (var treeNode in this.Child)
            {
                foreach (var node in treeNode.DepthFirstTraversal())
                {
                    yield return node;
                }
            }
        }
        
        public IEnumerable<TreeNode<T>> BreadthFirstTraversal()
        {
            yield return this;

            foreach (var treeNode in this.Child)
            {
                yield return treeNode;
            }

            foreach (var treeNode in this.Child)
            {
                foreach (var node in treeNode.Child)
                {
                    yield return node;
                }
            }
        }
    }
}
