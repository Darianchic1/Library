# API

## [post]/accounts/register/
### [FromBody] RegisterRequest request
{
  "name": "string",
  "email": "string",
  "password": "string"
}

### return 
{
  "username": "string",
  "email": "string",
  "token": "string",
  "refreshToken": "string"
}

## [post]/accounts/login/
### [FromBody] RegisterRequest request
{
  "email": "string",
  "password": "string"
}


### return 
{
  "username": "string",
  "email": "string",
  "token": "string",
  "refreshToken": "string"
}

## [post]/accounts/refresh-token/
### [FromBody] RegisterRequest request
{
  "accessToken": "string",
  "refreshToken": "string"
}


### return 
"refreshToken": "string"

## [get]/accounts/test-auth/
### [Auth Jwt Berer] token


### return 
"username": "string"



## [get]/pc/post/{id}
### [FromBody] RegisterRequest request
{
  "email": "string",
  "password": "string"
}


### return 
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
}

## [get]/pc/user/{id}
### [FromBody] RegisterRequest request
{
  "email": "string",
  "password": "string"
}


### return 
public class PostResponse
{
    public long Id{ get; set; }
    public string UserName{ get; set; }
    public string Description{ get; set; }
    public int SubscribersId{ get; set; }
    public string PictureUrl{ get; set; }
    public List<long> SavedListPostsId{ get; set; }
    public List<long> FromArticlesId{ get; set; }
}

## [get]/pc/user/setnew/picture/{pictureUrl}
### [Auth Jwt Berer] token 


### return 
Profile picture replased

## [get]/pc/user/setnew/description/{Description}
### [Auth Jwt Berer] token 


### return 
Profile description replased

## [get]/pc/user/subscribe/{toUserId}
### [Auth Jwt Berer] token 


### return 
User {username} subscribed to {toUserId}

## [get]/pc/post/{postid}/setrate/{rate}
### [Auth Jwt Berer] token 


### return 
User {username} rated {postId}

## [post]/pc/post/create
### [Auth Jwt Berer] token 
[Frombody]public class PostReqest
{
    public List<Content> Contents{ get; set; }
    public string PostName{ get; set; }
    public string Description{ get; set; }
    public string PictureURL{ get; set; }
    public string Category{ get; set; }
    public string Type{ get; set; }
    public string AverageTime{ get; set; }
}

### return 
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
}

## [post]/pc/post/remake/{postId}
### [Auth Jwt Berer] token 
[Frombody]public class PostReqest
{
    public List<Content> Contents{ get; set; }
    public string PostName{ get; set; }
    public string Description{ get; set; }
    public string PictureURL{ get; set; }
    public string Category{ get; set; }
    public string Type{ get; set; }
    public string AverageTime{ get; set; }
}

### return 
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
}

## [post]/pc/post/save/{postId}
### [Auth Jwt Berer] token 

### return 
Post is saved

## [post]/pc/post/filtred/
### [Auth Jwt Berer] token 
public class Filtre
{
    public bool? IsVerified{ get; set; }
    public int? AuthorId{ get; set; }
    public string? Category{ get; set; }
    public string? Type{ get; set; }
}

### return 
List<PostResponse>
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
}

## [post]/pc/post/recomendation/
### 

### return 
List<PostResponse>
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
}

## [post]/pc/post/search/{query}
### 

### return 
List<PostResponse>
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
}