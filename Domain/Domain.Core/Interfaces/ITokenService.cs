using Domain.Core.Entities;

namespace Domain.Core.Interfaces;

public interface ITokenService
{
    string GenerateToken( User user);
}