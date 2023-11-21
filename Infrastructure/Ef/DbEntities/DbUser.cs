namespace Infrastructure.Ef.DbEntities;

public class DbUser
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
   public bool IsBanned { get; set; }
}