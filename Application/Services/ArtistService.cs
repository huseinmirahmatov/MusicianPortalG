using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ArtistService : IBaseService<Artist>
    {
        private readonly IBaseRepository<Artist> _artistRepository;

        public ArtistService(IBaseRepository<Artist> artistRepository)
        {
            _artistRepository = artistRepository ?? throw new ArgumentNullException(nameof(artistRepository));
        }

        public async Task<Artist> CreateAsync(Artist artist)
        {
            return await _artistRepository.CreateAsync(artist);
        }

        public Task<Artist> CreateAsync(Artist entity, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(Artist artist)
        {
            return await _artistRepository.DeleteAsync(artist);
        }

        public Task<bool> DeleteAsync(int id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Artist>> GetAllAsync()
        {
            return await _artistRepository.GetAllAsync();
        }

        public Task<IEnumerable<Artist>> GetAllAsync(CancellationToken token = default)
        {
            throw new NotImplementedException();
        }

        public Task<Artist> GetAsync(int id, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> UpdateAsync(Artist artist)
        {
            return await _artistRepository.UpdateAsync(artist);
        }

        public Task<bool> UpdateAsync(Artist entity, CancellationToken token = default)
        {
            throw new NotImplementedException();
        }
    }
}
