public class UserResponse
{
    public long Id{ get; set; }
    public string UserName{ get; set; }
    public string Description{ get; set; }
    public int SubscribersId{ get; set; }
    public string PictureUrl{ get; set; }
    public List<long> SavedListPostsId{ get; set; }
    public List<long> FromArticlesId{ get; set; }

    public UserResponse(User user)
    {
        Id = user.Id;
        UserName = user.UserName;
        Description = user.Description;
        SubscribersId = user.Subscribers.Count();
        PictureUrl = user.pictureUrl;

        foreach (var post in user.SavedListPosts){
            SavedListPostsId.Add(post.Id);
        }
        foreach (var post in user.FromArticles){
            FromArticlesId.Add(post.Id);
        }
    }
    
}