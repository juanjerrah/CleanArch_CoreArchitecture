using System.Security.Cryptography;
using System.Text;
using Domain.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Domain.Core.Security;

public class SecurityService : ISecurity
{
    private readonly IConfiguration _configuration;

    public SecurityService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string EncryptPassword(string password, string salt = "pepper")
    {
        var key = _configuration["Key:Value"];
        //Transforma os campos inseridos em bytes
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var saltBytes = Encoding.UTF8.GetBytes(salt);
        var keyBytes = Encoding.UTF8.GetBytes(key);

        // unifica a senha com o salt
        var saltedPasswordBytes = new byte[passwordBytes.Length + saltBytes.Length];

        //Copia os bytes de um para o outro
        Buffer.BlockCopy(saltBytes, 0, saltedPasswordBytes, 0, saltBytes.Length);
        Buffer.BlockCopy(passwordBytes, 0, saltedPasswordBytes, saltBytes.Length, passwordBytes.Length);

        // Inicia a biblioteca de cryptografia com base na key criada
        var hmac = new HMACSHA512(keyBytes);

        //Cryptografa o salt com a senha
        var hashBytes = hmac.ComputeHash(saltedPasswordBytes);

        //Converte de bytes para string
        var encryptedPassword = Convert.ToBase64String(hashBytes);

        return encryptedPassword;
    }

    public bool ValidatePassword(string currentPassword, string password)
    {
        var hashSenhaInserida = EncryptPassword(password, "pepper");

        return hashSenhaInserida == currentPassword;
    }
}