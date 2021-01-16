using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using ApplicationCore.Interfaces.ISchool;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastructure.Db;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repo
{
    public class SchoolRepository <T,TD> : ISchoolRepository<T,TD> where T : class, ISchoolEntity where TD :class, ISchoolReadDto
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;

        public SchoolRepository(ApplicationDbContext applicationDbContext, IMapper mapper)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }
        public async Task<T> AddAsync(T schoolEntity)
        {
            try
            {
                await _applicationDbContext.Set<T>()
                    .AddAsync(schoolEntity);
                await _applicationDbContext.SaveChangesAsync();
                return schoolEntity;
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
                return entity;
            }
            catch (Exception )
            {
                return null;
            }
        }

        public async Task<TD> GetByClassNoAsync(int classNo)
        {
            try
            {
                var entity = await _applicationDbContext.Set<T>()
                    .AsNoTracking()
                    .ProjectTo<TD>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync(x => x.ClassNo == classNo);
                return entity;
            }
            catch (Exception )
            {
                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var entity =await _applicationDbContext.Set<T>()
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (entity == null)
                {
                    return false;
                }

                _applicationDbContext.Set<T>()
                    .Remove(entity);
                await _applicationDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception )
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

        public async Task<T> UpdateAsync(T schoolEntity)
        {
            try
            {
                _applicationDbContext.Set<T>()
                    .Update(schoolEntity);
                await _applicationDbContext.SaveChangesAsync();
                return schoolEntity;

            }
            catch (Exception )
            {
                return null;
            }
        }
    }
}