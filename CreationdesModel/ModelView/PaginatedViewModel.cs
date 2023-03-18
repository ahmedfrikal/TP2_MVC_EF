namespace CreationdesModel.ModelView
{
    public class PaginatedViewModel<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public List<T> Items { get; set; }
    }

}
