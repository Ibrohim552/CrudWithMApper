

public record BaseFilter
{
    public int PageSize { get; set; }=10;
    public int PageNumber { get; set; }=1;

    
    public BaseFilter()
    {
        
    }
   
    public BaseFilter(int pageSize, int pageNumber)
    {
         PageSize = pageSize <= 0 ? 10 : pageSize;
        PageNumber = pageNumber <= 0 ? 1 : pageNumber;
    }

}