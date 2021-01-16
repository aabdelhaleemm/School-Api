using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Dtos;
using ApplicationCore.Dtos.Student;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.IUser;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infrastructure.Repo
{
    public class UserRepository<T,TD> : IUserRepository<T,TD> where T : class, IUserEntity where TD : class, IUserReadDto
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext applicationDbContext , IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<T> AddAsync(T userEntity)
        {
            try
            {
                await _applicationDbContext.Set<T>().AddAsync(userEntity);
                await _applicationDbContext.SaveChangesAsync();
                
                return userEntity;
            }
            catch (Exception )
            {
                return null;
            }
        }
        public async Task<TD> GetByIdAsync(int id)
        {
            try
            {
                var entity =await _applicationDbContext.Set<T>()
                    .AsNoTracking()
                    .ProjectTo<TD>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.Id == id);
                await _applicationDbContext.SaveChangesAsync();
                 
                return entity ?? null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<bool> DeleteAsync( int id)
        {
            try
            {
                var userEntity = await _applicationDbContext.Set<T>()
                    .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.Id == id);
                if (userEntity == null)
                {
                    return false;
                }
                _applicationDbContext.Set<T>()
                    .Remove(userEntity);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<List<TD>> GetAllAsync()
        {
            try
            {
                var entity =await _applicationDbContext.Set<T>()
                    .AsNoTracking()
                    .ProjectTo<TD>(_mapper.ConfigurationProvider)
                    .ToListAsync();
                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<T> SignInAsync(LoginModel loginModel)
        {
            try
            {
                var entity =await _applicationDbContext.Set<T>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Ssn == loginModel.Ssn && x.Password == loginModel.Password);
                return entity ?? null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<T> UpdateAsync(T userEntity)
        {
            try
            {
                _applicationDbContext.Set<T>()
                    .Update(userEntity);
                await _applicationDbContext.SaveChangesAsync();
                return userEntity;
            }
            catch (Exception )
            {
                return null;
            }
        }
    }
}