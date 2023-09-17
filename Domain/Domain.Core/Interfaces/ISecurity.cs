namespace Domain.Core.Interfaces;

public interface ISecurity
{
    string EncryptPassword(string password, string salt);
    bool ValidatePassword(string currentPassword, string password);
}