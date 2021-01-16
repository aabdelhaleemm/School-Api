using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces.ISchool
{
    public interface ISchoolRepository <T,TD> where T : ISchoolEntity where TD: ISchoolReadDto
    {
        public Task<T> AddAsync(T schoolEntity);
        public Task<TD> GetByIdAsync(int id);
        public Task<TD> GetByClassNoAsync(int classNo);
        public Task<bool> DeleteAsync( int id);
        public Task<List<TD>> GetAllAsync();
        public Task<T> UpdateAsync(T schoolEntity);
    }
}