using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class User : IdentityUser<long>
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set;}
    public List<Post> FromArticles { get; set; } 
    public List<Post> SavedListPosts { get; set; }
    public string pictureUrl { get; set; } = "";
    public string Description { get; set; } = "";
    public List<User>? Subscriptions { get; set; } // Навигационное свойство для подписок пользователя
    public List<User>? Subscribers { get; set; }
}