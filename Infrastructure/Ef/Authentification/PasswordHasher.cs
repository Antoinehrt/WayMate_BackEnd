using BCrypt.Net;

namespace Infrastructure.Ef.Authentification; 

public class PasswordHasher : IPasswordHasher {
    
    private int _COST = 12;
    private HashType _hashType = HashType.SHA384; 
    
    
    public string HashPwd(string pwd) {
        return BCrypt.Net.BCrypt.HashPassword(pwd, workFactor: _COST);
        
    }

    public bool VerifyPwd(string hashedPwd, string inputPwd) {
        return BCrypt.Net.BCrypt.Verify(inputPwd, hashedPwd);
    }
}