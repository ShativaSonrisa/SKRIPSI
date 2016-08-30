using System;
using System.Collections.Generic;
using System.Linq;

namespace DataMining
{
    public class FpTree
    {
        readonly Node _root;
        IDictionary<string, Node> _headerTable;
        int _minimumSupportCount;

        public List<Item> FrequentItems { get; private set; }

        private FpTree()
        {
            _root = new Node("");
            _headerTable = new Dictionary<string, Node>();
            FrequentItems = new List<Item>();
        }
        public FpTree(List<Item> frequentItems, List<ItemSet> trxList)
            : this()
        {

            FrequentItems = frequentItems;
            FrequentItems = FrequentItems.OrderByDescending(x => x.SupportCount).ToList();

            foreach (var itemSet in trxList)
            {
                InsertTransaction(itemSet.Items);
            }
        }

        private void InsertTransaction(IEnumerable<Item> aTransaction)
        {
            var tempRoot = _root;
            foreach (var aNode
                in aTransaction.Select(anItem => new Node(anItem.Kode.ToString())))
            {
                aNode.FpCount = 1;
                Node tempNode;
                if ((tempNode = tempRoot.Children.Find(c => c.Symbol == aNode.Symbol)) != null)
                {
                    tempNode.FpCount++;
                    tempRoot = tempNode;
                }
                else
                {
                    tempRoot.AddChild(aNode);
                    tempRoot = aNode;
                    if (_headerTable.ContainsKey(aNode.Symbol))
                    {
                        aNode.NextHeader = _headerTable[aNode.Symbol];
                    }
                    _headerTable[aNode.Symbol] = aNode;
                }
            }
        }

        private void CalculateFrequentItems(List<Item> frequentItems)
        {
            var items = frequentItems;

            foreach (var anItem
                in items.Where(anItem => anItem.SupportCount >= _minimumSupportCount))
            {
                FrequentItems.Add(anItem.Clone());
            }
        }

        private void InsertBranch(IReadOnlyList<Node> branch)
        {
            var tempRoot = _root;
            for (var i = 0; i < branch.Count; ++i)
            {
                var aNode = branch[i];
                var tempNode = tempRoot.Children.Find(x => x.Symbol == aNode.Symbol);
                if (null != tempNode)
                {
                    tempNode.FpCount += aNode.FpCount;
                    tempRoot = tempNode;
                }
                else
                {
                    while (i < branch.Count)
                    {
                        aNode = branch[i];
                        aNode.Parent = tempRoot;
                        tempRoot.AddChild(aNode);
                        if (_headerTable.ContainsKey(aNode.Symbol))
                        {
                            aNode.NextHeader = _headerTable[aNode.Symbol];
                        }

                        _headerTable[aNode.Symbol] = aNode;

                        tempRoot = aNode;
                        ++i;
                    }
                    break;
                }
            }
        }

        private int GetTotalSupportCount(string itemSymbol)
        {
            var sCount = 0;
            var node = _headerTable[itemSymbol];
            while (null != node)
            {
                sCount += node.FpCount;
                node = node.NextHeader;
            }

            return sCount;
        }

        public FpTree Project(Item anItem)
        {
            var tree = new FpTree { _minimumSupportCount = _minimumSupportCount };
            var startNode = _headerTable[anItem.Kode];

            while (startNode != null)
            {
                var projectedFpCount = startNode.FpCount;
                var tempNode = startNode;
                var aBranch = new List<Node>();
                while (tempNode.Parent != null)
                {
                    Console.WriteLine(tempNode.Symbol);
                    var parentNode = tempNode.Parent;
                    if (parentNode.IsNull())
                    {
                        break;
                    }
                    var newNode = new Node(parentNode.Symbol) { FpCount = projectedFpCount };
                    aBranch.Add(newNode);
                    tempNode = tempNode.Parent;
                }
                aBranch.Reverse();
                tree.InsertBranch(aBranch);
                startNode = startNode.NextHeader;
            }

            tree._headerTable = tree._headerTable.
                Where(x => tree.GetTotalSupportCount(x.Value.Symbol) >= _minimumSupportCount).
                ToDictionary(p => p.Key, p => p.Value);

            tree.FrequentItems = FrequentItems.FindAll
            (item => tree._headerTable.ContainsKey(item.Kode.ToString()));
            return tree;
        }

    }
}
