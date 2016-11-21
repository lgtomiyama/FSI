using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace FSI.Exposition.Forms
{
    public enum SearchType
    {
        StartsWith,
        EndsWith,
        Contains
    }
    public class TextTreeViewSearch : TextBox
    {
        public SearchType searchType { get; set; }
        public TreeView treeReferences
        {
            get;
            set;
        }
        TreeNode _fieldsTreeCache;
        public TreeNode fieldsTreeCache
        {
            get { return _fieldsTreeCache; }
            set
            {
                _fieldsTreeCache = value;
                ClonefieldsTreeCache();
            }
        }
        public bool EmBusca = false;
        public TextTreeViewSearch()
        {
            searchType = SearchType.Contains;
            this.Text = "Busca";
            this.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Italic, GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = SystemColors.GrayText;
            this.Enter += new EventHandler(txtTreeViewSearch_Enter);
            this.Leave += new EventHandler(txtTreeViewSearch_Leave);
            this.TextChanged += new EventHandler(txtTreeViewSearch_TextChanged);

        }

        private void txtTreeViewSearch_TextChanged(object sender, EventArgs e)
        {
            if (treeReferences != null)
            {
                treeReferences.BeginUpdate();
                treeReferences.Nodes.Clear();
                if (this.Text != string.Empty)
                {
                    findNodes(_fieldsTreeCache.Nodes, this.Text);
                }
                else
                {
                    ClonefieldsTreeCache();
                }
                this.treeReferences.EndUpdate();
            }
        }

        private void txtTreeViewSearch_Leave(object sender, EventArgs e)
        {
            PerderFoco();
        }

        private void PerderFoco()
        {
            try
            {
                if (!treeReferences.Focused)
                {
                    this.Text = "Busca";
                    this.Font = new Font(this.Font, FontStyle.Italic);
                    this.ForeColor = Color.Gray;
                    ClonefieldsTreeCache();
                }
            }
            catch { }
        }

        private void txtTreeViewSearch_Enter(object sender, EventArgs e)
        {
            EmBusca = true;
            this.Text = "";
            this.Font = new Font(this.Font, FontStyle.Regular);
            this.ForeColor = Color.Black;
        }

        private void findNodes(TreeNodeCollection nodes, string text)
        {
            foreach (TreeNode _childNode in nodes)
            {
                if ((_childNode.Text.Contains(text) && searchType == SearchType.Contains) 
                    || (_childNode.Text.StartsWith(text) && searchType == SearchType.StartsWith)
                    || (_childNode.Text.EndsWith(text) && searchType == SearchType.EndsWith))
                {
                    this.treeReferences.Nodes.Add((TreeNode)_childNode.Clone());
                }
                findNodes(_childNode.Nodes, text);
            }
        }

        private void ClonefieldsTreeCache()
        {
            if (_fieldsTreeCache != null)
            {
                foreach (TreeNode _node in this._fieldsTreeCache.Nodes)
                {
                    treeReferences.Nodes.Add(_node);
                }
            }
        }
    }
}
