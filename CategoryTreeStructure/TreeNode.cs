using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CategoryTreeStructure
{
    public class TreeNode<T> 
    {
        readonly List<TreeNode<T>> _children = new List<TreeNode<T>>();

        public TreeNode(T data)
        {
            Data = data;
        }

        public T Data { get; set; }

        public TreeNode<T> Parent { get; private set; }
        public ReadOnlyCollection<TreeNode<T>> Children
        {
            get { return _children.AsReadOnly(); }
        }

        public void AddChild(TreeNode<T> value)
        {
            value.Parent = this ;
            _children.Add(value);
        }

        //public void Traverse(Action<T> action)
        //{
        //    action(Data);
        //    foreach (var child in _children)
        //        child.Traverse(action);
        //}

    }
}
