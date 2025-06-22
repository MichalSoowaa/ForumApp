using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Domain.Repositories
{
    public interface IUsersRepository
    {
        Task<bool> VerifyUserLoginAsync(string email, string password);
    }
}
