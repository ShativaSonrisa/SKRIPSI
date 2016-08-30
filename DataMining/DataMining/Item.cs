namespace DataMining
{
    public class Item
    {
        private readonly string _symbol;

        public int SupportCount { get; private set; }

        public string Symbol
        {
            get { return _symbol; }
        }

        public string Kode { get; private set; }

        //constructors
        private Item()
        {
            _symbol = null;
            SupportCount = -1;
        }

        public Item(string kode, string symbol, int supportCount)
            : this()
        {
            Kode = kode;
            _symbol = symbol;
            SupportCount = supportCount;
        }

        public Item Clone()
        {
            var item = new Item(Kode, _symbol, SupportCount);
            return item;
        }
    }
}
