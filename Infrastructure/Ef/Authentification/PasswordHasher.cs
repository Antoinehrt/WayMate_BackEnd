using BCrypt.Net;

namespace Infrastructure.Ef.Authentification; 

public class PasswordHasher : IPasswordHasher {
    
    private int _COST = 12;
    private HashType _hashType = HashType.SHA384; 
    
    
    public string HashPwd(string pwd) {
        //D'après le READ.ME sur le github de la librairie, un salt est généré automatiquement en fonction du cost de donné en arg.
        //Et comme dans toutes les librairies BCrypt, le salt est stocké avec le pwd. 
        //Donc pas besoin de faire une nouvelle colonne, mais du coup je ne suis pas sur de correcpondre à ce que le prof à dit.
        
        
        //return BCrypt.Net.BCrypt.EnhancedHashPassword(pwd, workFactor: _COST, _hashType);
        return BCrypt.Net.BCrypt.HashPassword(pwd, workFactor: _COST);
        
    }

    public bool VerifyPwd(string hashedPwd, string inputPwd) {
        //return BCrypt.Net.BCrypt.EnhancedVerify(inputPwd, hashedPwd, _hashType);
        return BCrypt.Net.BCrypt.Verify(inputPwd, hashedPwd);
    }
}