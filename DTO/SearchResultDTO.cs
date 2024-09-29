namespace my_orange_easyxls.DTO
{
    public class SearchResultDTO<T>
    {
        public T? Data { get; set; }

        // 固定的int类型属性，表示总条数  
    
        public int TotalCount { get; set; }
        // 另一个固定的int类型属性，表示页数  
        public string PageHtml { get; set; }

        public SearchResultDTO(T data,  string pageHtml, int totalCount)
        {
            Data = data;
            PageHtml = pageHtml;
            TotalCount = totalCount;
        }

    }

}
