using Microsoft.EntityFrameworkCore;

public class PostManager : IPostManager
{
    private readonly DataContext dataContext;

    public PostManager(DataContext Context)
    {
        dataContext = Context;
    }
    public PostResponse GetPostById(int postId)
    {
        Post findPost = dataContext.Posts.FirstOrDefault(p => p.Id == postId);
        if(findPost != null){
            return new PostResponse(findPost);
        }
        return null;
    }
    public UserResponse GetUserById(int userId){
        User findUser = dataContext.Users.FirstOrDefault(u => u.Id == userId);
        if(findUser != null){
            return new UserResponse(findUser);
        }
        return null;
    }
    public void SetNewProfile(string username, string newUrl) 
    {
        dataContext.Users.FirstOrDefault(u => u.UserName == username).pictureUrl = newUrl;
        dataContext.SaveChanges();
    }
    public void SetNewDescription(string username, string newDescription)
    {
        dataContext.Users.FirstOrDefault(u => u.UserName == username).Description = newDescription;
        dataContext.SaveChanges();
    }
    public void Subscribe(string username, int toUserId)
    {   
        User FindUser = dataContext.Users.FirstOrDefault(u => u.Id == toUserId);
        if(FindUser != null){
            dataContext.Users.FirstOrDefault(u => u.UserName == username).Subscriptions.Add(FindUser);
            FindUser.Subscribers.Add(dataContext.Users.FirstOrDefault(u => u.UserName == username));
        }
        dataContext.SaveChanges();
    }

    public void SetRate(string username, int postId, int rate)
    {
        User user = dataContext.Users.FirstOrDefault(u => u.UserName == username);
        Post post = dataContext.Posts.FirstOrDefault(p => p.Id == postId);
        if(post != null && user != null)
        {
            if(!post.UserRateName.Any(i => i == username))
            {
                post.Rate = (post.Rate * post.UserRateName.Count()) + rate;
                post.UserRateName.Add(username);
                post.Rate /= post.UserRateName.Count();
                dataContext.SaveChanges();
            }
        }
    }
    public PostResponse CreatePost(string username, PostReqest postReqest)
    {
        User user = dataContext.Users.FirstOrDefault(u => u.UserName == username);
        List<Content> toConts = new List<Content>();
        foreach (var item in postReqest.Contents)
        {  
            Content cont = new Content();
            cont.Type = item.Type;
            cont.data = item.data;
            cont.Id = dataContext.Contents.Count();
            cont.ArticleId = dataContext.Posts.Count();
            toConts.Add(cont);
        }
        Post post = new Post()
            {
                Id = dataContext.Posts.Count(),
                IsVerified = false,
                Contents = toConts,
                Author = user,
                AuthorId = user.Id,
                PostName = postReqest.PostName,
                Description = postReqest.Description,
                PictureURL = postReqest.PictureURL,
                Category = postReqest.Category,
                Type = postReqest.Type,
                Rate = 0,
                UserRateName = new List<string>(),
                AverageTime = postReqest.AverageTime,
                CreateDate = DateTime.UtcNow
            };
        dataContext.Posts.Add(post);
        dataContext.SaveChanges();
        return new PostResponse(post);
    }

    public PostResponse RemakePost(string username, int postId, PostReqest postReqest)
    {
        User user = dataContext.Users.FirstOrDefault(u => u.UserName == username);
        Post post = dataContext.Posts.FirstOrDefault(p => p.Id == postId);
        List<Content> toConts = new List<Content>();
        foreach (var item in postReqest.Contents)
        {  
            Content cont = new Content();
            cont.Type = item.Type;
            cont.data = item.data;
            cont.Id = dataContext.Contents.Count();
            cont.ArticleId = dataContext.Posts.Count();
            toConts.Add(cont);
        }
        if(post != null && user != null)
        {
            if(post.Author.Id == user.Id)
            {
                post = new Post()
                {
                    Id = dataContext.Posts.Count(),
                    IsVerified = false,
                    Contents = toConts,
                    Author = user,
                    AuthorId = user.Id,
                    PostName = postReqest.PostName,
                    Description = postReqest.Description,
                    PictureURL = postReqest.PictureURL,
                    Category = postReqest.Category,
                    Type = postReqest.Type,
                    Rate = 0,
                    UserRateName = new List<string>(),
                    AverageTime = postReqest.AverageTime,
                    CreateDate = post.CreateDate
                };
                dataContext.SaveChanges();
                return new PostResponse(post);
            }
        }
        return null;
    }
    public void SavePost(string username, int postId)
    {
        Post post = dataContext.Posts.FirstOrDefault(p => p.Id == postId);
        if(post != null){
            dataContext.Users.FirstOrDefault(u => u.UserName == username).SavedListPosts.Add(post);
        }
        dataContext.SaveChanges();
    }

    public List<PostResponse> FiltreSearch(Filtre filtre)
    {
        List<Post> postResponses = dataContext.Posts.ToList();
        if(filtre.IsVerified != null){
            postResponses = postResponses.Where(p => p.IsVerified == filtre.IsVerified).ToList();
        }
        if(filtre.AuthorId != null){
            postResponses = postResponses.Where(p => p.AuthorId == filtre.AuthorId).ToList();
        }
        if(filtre.Category != null){
            postResponses = postResponses.Where(p => p.Category == filtre.Category).ToList();
        }
        if(filtre.Type != null){
            postResponses = postResponses.Where(p => p.Type == filtre.Type).ToList();
        }
        
        List<PostResponse> ReturnPost = new List<PostResponse>();
        foreach(Post post in postResponses){
            ReturnPost.Add(new PostResponse(post));
        }
        return ReturnPost;
    }

    public List<PostResponse> Recomendation()
    {
        List<Post> post = dataContext.Posts.ToList();
        List<PostResponse> sortedPost = new List<PostResponse>();
        post.Sort();
        post.Reverse();
        foreach(Post p in post){
            sortedPost.Add(new PostResponse(p));
        }
        return sortedPost;
    }
    public List<PostResponse> AuthRecomendation(string username)
    {
        List<Post> post = dataContext.Posts.ToList();
        List<PostResponse> sortedPost = new List<PostResponse>();
        post.Sort();
        post.Reverse();
        foreach(Post p in post){
            sortedPost.Add(new PostResponse(p));
        }
        return sortedPost;
    }
    public List<PostResponse> SearchPost(string query)
    {
        List<PostResponse> matchingPost = new List<PostResponse>();

        foreach (Post p in dataContext.Posts)
        {
            if (p.PostName.ToLower().Contains(query.ToLower()))
            {
                matchingPost.Add(new PostResponse(p));
            }
        }

        return matchingPost;
    }
}