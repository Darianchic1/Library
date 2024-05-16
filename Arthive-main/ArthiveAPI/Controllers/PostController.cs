using System.Runtime.CompilerServices;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("pc/")]
public class PostController : ControllerBase
{
    private readonly IPostManager _postManager;

    public PostController(IPostManager postManager)
    {
        _postManager = postManager;
    }

    [HttpGet("post/{id}")]
    public IActionResult GetPostById(int id)
    {
       var post =  _postManager.GetPostById(id);
       if(post != null){
        return Ok(post);
       }
       return BadRequest("post not found");
    }

    [HttpGet("user/{id}")]
    public IActionResult GetUserById(int id)
    {
        var post =  _postManager.GetUserById(id);
       if(post != null){
        return Ok(post);
       }
       return BadRequest("user is not found");
    }

    [Authorize]
    [HttpGet("user/setnew/picture/{pictureUrl}")]
    public IActionResult SetNewProfile(string pictureUrl)
    {
        string username = HttpContext.User.Identity.Name;
        _postManager.SetNewProfile(username, pictureUrl);
        return Ok("Profile picture replased");
    }
    [Authorize]
    [HttpGet("user/setnew/description/{Description}")]
    public IActionResult SetNewDescription(string Description)
    {
        string username = HttpContext.User.Identity.Name;
        _postManager.SetNewDescription(username, Description);
        return Ok("Profile description replased");
    }
    [Authorize]
    [HttpGet("user/subscribe/{toUserId}")]
    public IActionResult Subscribe(int toUserId)
    {
        string username = HttpContext.User.Identity.Name;
        _postManager.Subscribe(username, toUserId);
        return Ok($"User {username} subscribed to {toUserId}");
    }
    [Authorize]
    [HttpGet("post/{postid}/setrate/{rate}")]
    public IActionResult SetRate(int postId, int rate)
    {
        string username = HttpContext.User.Identity.Name;
        _postManager.SetRate(username, postId, rate);
        return Ok($"User {username} rated {postId}");
    }
    [Authorize]
    [HttpPost("post/create")]
    public IActionResult CreatePost([FromBody]PostReqest postReqest)
    {
        string username = HttpContext.User.Identity.Name;
        var post = _postManager.CreatePost(username, postReqest);
        return Ok(post);
    }
    [Authorize]
    [HttpPost("post/remake/{postId}")]
    public IActionResult RemakePost([FromBody]PostReqest postReqest, int postId)
    {
        string username = HttpContext.User.Identity.Name;
        var post = _postManager.RemakePost(username, postId, postReqest);
        if(post != null){
            return Ok(post);
        }
        else
        {
            return BadRequest("Post is not found");
        }
    }
    [Authorize]
    [HttpPost("post/save/{postId}")]
    public IActionResult SavePost(int postId)
    {
        string username = HttpContext.User.Identity.Name;
        _postManager.SavePost(username, postId);
        return Ok("Post is saved");
    }

    [HttpPost("post/filtred/")]
    public IActionResult SavePost([FromBody] Filtre filtre)
    {
        var posts = _postManager.FiltreSearch(filtre);
        if(posts != null){
            return Ok(posts);
        }
        else{
            return BadRequest("not posts with this filter");
        }
    }
    [HttpGet("post/recomendation/")]
    public IActionResult Recomendations()
    {
        var posts = _postManager.Recomendation();
        if(posts != null){
            return Ok(posts);
        }
        else{
            return BadRequest("WTF (server dont save all post?)");
        }
    }
    [Authorize]
    [HttpGet("post/recomendation/auth")]
    public IActionResult AuthRecomendation()
    {
        string username = HttpContext.User.Identity.Name;
        var posts = _postManager.AuthRecomendation(username);
        if(posts != null){
            return Ok(posts);
        }
        else{
            return BadRequest("WTF (server dont save all post?)");
        }
    }
    [HttpPost("post/search/{query}")]
    public IActionResult SearchPost(string query)
    {
        var posts = _postManager.SearchPost(query);
        if(posts != null){
            return Ok(posts);
        }
        else{
            return BadRequest("Post is not found");
        }
    }
}