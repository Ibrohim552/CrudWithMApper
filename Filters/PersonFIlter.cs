


public record PersonFilter:BaseFilter
{
    public decimal Salary { get; set; } 
    public string? Name { get; set; }
}