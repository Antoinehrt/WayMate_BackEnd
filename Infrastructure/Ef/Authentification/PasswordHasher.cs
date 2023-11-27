namespace Infrastructure.Ef.Authentification; 

public class PasswordHasher : IPasswordHasher {
    
    
    
    public string HashPwd(string pwd) {
        throw new NotImplementedException();
    }

    public bool VerifyPwd(string pwdHash, string inputPwd) {
        throw new NotImplementedException();
    }
}