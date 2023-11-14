namespace Domain.Entities.Users; 

public class User {
    private string _username { get; set; }
    private string _password { get; set; }
    private string _email { get; set; }
    private string _birthdate { get; set; }

    public int CalculateAge(){
        return DateTime.Today.Year - DateTime.Parse(_birthdate).Year;
    }
}