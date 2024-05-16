public interface IPostManager
{
    
    public List<PostResponse> AuthRecomendation(string username);
    public List<PostResponse> Recomendation();
    public void SavePost(string username, int postId);
    public List<PostResponse> SearchPost(string query);
    public PostResponse CreatePost(string username, PostReqest postReqest);
    public void SetRate(string username, int postId, int rate);
    public List<PostResponse> FiltreSearch(Filtre filtre);
    public PostResponse GetPostById(int postId);
    public UserResponse GetUserById(int userId);
    public void SetNewProfile(string username, string newUrl);
    public PostResponse RemakePost(string username, int postId, PostReqest postReqest);
    public void SetNewDescription(string username, string newDescription);
    public void Subscribe(string username, int toUserId);
}