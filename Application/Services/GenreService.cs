using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class GenreService : IBaseService<Genre>
    {
        private readonly IBaseRepository<Genre> _genreRepository;

        public GenreService(IBaseRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository ?? throw new ArgumentNullException(nameof(genreRepository));
        }

        public async Task<Genre> CreateAsync(Genre genre)
        {
            return await _genreRepository.CreateAsync(genre);
        }

        public Task<Genre> CreateAsync(Genre entity, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Genre genre)
        {
            return await _genreRepository.DeleteAsync(genre);
        }

        public Task<bool> DeleteAsync(int id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _genreRepository.GetAllAsync();
        }

        public Task<IEnumerable<Genre>> GetAllAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetAsync(int id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> UpdateAsync(Genre genre)
        {
            return await _genreRepository.UpdateAsync(genre);
        }

        public Task<bool> UpdateAsync(Genre entity, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
