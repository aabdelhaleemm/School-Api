using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Dtos;

namespace ApplicationCore.Interfaces.IUser
{
    public interface IUserRepository<T,TD> where T: IUserEntity  where TD: IUserReadDto 
                                       
    {
        public Task<T> AddAsync(T userEntity);
        public Task<TD> GetByIdAsync(int id);
        public Task<bool> DeleteAsync( int id);
        public Task<List<TD>> GetAllAsync();
        public Task<T> SignInAsync(LoginModel loginModel);
        public Task<T> UpdateAsync(T userEntity);

    }
}