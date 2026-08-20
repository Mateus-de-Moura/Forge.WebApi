using Ardalis.Result;
using Forge.WebApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.WebApi.Domain.Interfaces.User
{
    public interface IUserRepository
    {
        Task<Result<Domain.Entities.User>> Update(Domain.Entities.User user);
        Task<Result<Domain.Entities.User>> GetUserByEmail(string email);
    }
}
