using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTreeStructure
{
    public class CategoryTree : TreeNode<CategoryNode>
    {
        public CategoryTree(CategoryNode data) : base(data)
        {
            Root = data;
        }
        public CategoryNode Root { get; set; }

        public CategoryNode FindByID(int id)
        {
            CategoryNode retObj = null;
            Queue<CategoryNode> q = new Queue<CategoryNode>();
            q.Enqueue(this.Root);
            while (q.Count > 0)
            {
                var current = q.Dequeue();
                if (current.Data.ID == id)
                {
                    retObj = current;
                    retObj.Data.Keywords = GetKeywords(current);
                    retObj.Data.ParentCategoryID= current.Parent.Data.ID;
                    break;
                }
                foreach (CategoryNode children in current.Children)
                {
                    q.Enqueue(children);

                }

            }

            return retObj;

        }

        private string GetKeywords(CategoryNode node)
        {
            if (!string.IsNullOrEmpty(node.Data.Keywords))
            {
                return node.Data.Keywords;
            }
            else
            {
                return this.GetKeywords(node.Parent as CategoryNode);
            }
        }

        public int[] GetCategoryIDAtLevel(int level)
        {
            var node_level = 0;
            List<int> retCategories = new List<int>();
            Queue<CategoryNode> q = new Queue<CategoryNode>();
            q.Enqueue(this.Root);
            q.Enqueue(new CategoryNode(new Category { ID = -1000}));

            while (q.Count > 0)
            {
                var  node = q.Dequeue();
                if (node.Data.ID == -1000)
                {
                    if (node_level == level)
                    {
                        break;
                    }
                    else
                    {
                        node_level++;
                        q.Enqueue(node);
                    }
                }
                else
                {
                    if (node_level == level)
                    {
                        retCategories.Add(node.Data.ID);
                    }
                    foreach (CategoryNode children in node.Children)
                    {
                        q.Enqueue(children);

                    }

                }
            }
            return retCategories.ToArray();
        } 

    }
}
