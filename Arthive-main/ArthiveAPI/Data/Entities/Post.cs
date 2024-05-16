public class Post
{
    public long Id { get; set;}
    public bool IsVerified { get; set;}

    public List<Content> Contents { get; set; } 
    public User Author { get; set; }
    public long AuthorId { get; set;}
    public string PostName { get; set;}
    public string Description { get; set;}
    public string PictureURL { get; set;}
    public string Category { get; set;}
    public string Type { get; set;}
    public float Rate { get; set;}
    public List<string> UserRateName { get; set;}
    public string AverageTime { get; set;}
    public DateTime? CreateDate { get; set;}
}