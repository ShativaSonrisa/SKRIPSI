using System.Collections.Generic;

namespace DataMining
{
    public class Node
    {
        readonly string _symbol;

        public Node Parent { get; set; }

        public Node NextHeader { get; set; }

        public List<Node> Children { get; private set; }

        public string Symbol
        {
            get { return _symbol; }
        }

        public int FpCount { get; set; }

        private Node()
        {
            FpCount = 0;
            NextHeader = null;
            Children = new List<Node>();
            Parent = null;
        }
        public Node(string symbol)
            : this()
        {
            _symbol = symbol;
            if (_symbol.Length != 0)
                FpCount = 1;
        }
        public bool IsNull()
        {
            return _symbol.Length == 0;
        }
        public void AddChild(Node child)
        {
            child.Parent = this;
            Children.Add(child);
        }
    }
}
