public class PostResponse
{
    public long Id{ get; set; }
    public bool IsVerified{ get; set; }
    public List<Content> Contents{ get; set; }
    public long AuthorId{ get; set; }
    public string AuthorName{ get; set; }
    public string AuthorImj{ get; set; }
    public string PostName{ get; set; }
    public string Description{ get; set; }
    public string PictureURL{ get; set; }
    public string Category{ get; set; }
    public string Type{ get; set; }
    public float Rate{ get; set; }
    public string AverageTime{ get; set; }
    public DateTime? CreateDate{ get; set; }


    public PostResponse(Post post){
        Id = post.Id;
        IsVerified = post.IsVerified;
        
        Contents = post.Contents;

        AuthorId = post.Author.Id;
        AuthorName = post.Author.UserName;
        AuthorImj = post.Author.pictureUrl;

        PostName = post.PostName;
        Description = post.Description;
        PictureURL = post.PictureURL;
        Category = post.Category;
        Type = post.Type;
        Rate = post.Rate;
        AverageTime = post.AverageTime;
        CreateDate = post.CreateDate;
        
    }
}

