namespace Task3.Entities
{
    public class SearchParameters
    {
        public int? SumFrom { get; set; }
        public int? SumTo { get; set; }
        public ProductType? ProductType { get; set; }
        public SortType? SortType { get; set; }

        public SearchParameters(int sumFrom, int sumTo)
        {
            SumFrom = sumFrom;
            SumTo = sumTo;
        }


        public SearchParameters() { }
    }
}
