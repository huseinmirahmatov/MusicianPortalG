using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class TrackService : IBaseService<Track>
    {
        private readonly IBaseRepository<Track> _trackRepository;

        public TrackService(IBaseRepository<Track> trackRepository)
        {
            _trackRepository = trackRepository ?? throw new ArgumentNullException(nameof(trackRepository));
        }

        public async Task<Track> CreateAsync(Track track, CancellationToken token = default)
        {
            return await _trackRepository.CreateAsync(track, token);
        }

        public async Task<bool> DeleteAsync(Track track, CancellationToken token = default)
        {
            return await _trackRepository.DeleteAsync(track, token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token = default)
        {
            var track = await GetAsync(id, token);
            if (track != null)
            {
                return await DeleteAsync(track, token);
            }
            return false;
        }

        public async Task<IEnumerable<Track>> GetAllAsync(CancellationToken token = default)
        {
            return await _trackRepository.GetAllAsync(token);
        }

        public async Task<Track> GetAsync(int id, CancellationToken token = default)
        {
            return await _trackRepository.GetAsync(id, token);
        }

        public async Task<bool> UpdateAsync(Track track, CancellationToken token = default)
        {
            var existingTrack = await GetAsync(track.Id, token);
            if (existingTrack == null)
            {
                return false;
            }

            existingTrack.Title = track.Title;
            existingTrack.Duration = track.Duration;
            existingTrack.Artist = track.Artist;
            existingTrack.Genre = track.Genre;


            return await _trackRepository.UpdateAsync(existingTrack, token);
        }
    }
}
