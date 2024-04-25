using Application.Services;
using AutoMapper;
using Contracts.Requests.Genre;
using Contracts.Responses;
using Contracts.Responses.Genre;
using Domain.Entities;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Web.API;

namespace ApiAniLibria.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenreController : Controller
    {
        private readonly IBaseService<Genre> _genreService;
        private readonly IMapper _mapper;

        public GenreController(IBaseService<Genre> genreService, IMapper mapper)
        {
            _genreService = genreService;
            _mapper = mapper;
        }

        [HttpPost(ApiEndpoints.Method.Create)]
        public async Task<IActionResult> Create([FromBody] CreateGenreRequest request, CancellationToken token)
        {
            var genre = _mapper.Map<Genre>(request);

            var response = await _genreService.CreateAsync(genre, token);
            return CreatedAtAction(nameof(Create), new { id = response.Id }, response);
        }



        [HttpGet(ApiEndpoints.Method.Get)]
        public async Task<IActionResult> Get(int id, CancellationToken token)
        {
            var genreExist = await _genreService.GetAsync(id);

            if (genreExist == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<SingleGenreResponse>(genreExist);

            return response == null ? NotFound() : Ok(response);
        }


        [HttpGet(ApiEndpoints.Method.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var genre = await _genreService.GetAllAsync(token);

            var response = new GetAllGenreResponse()
            {
                Items = _mapper.Map<IEnumerable<SingleGenreResponse>>(genre)
            };

            return Ok(response);
        }

        [HttpPut(ApiEndpoints.Method.Update)]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateGenreRequest request, CancellationToken token)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            Genre genre = _mapper.Map<Genre>(request);

            await _genreService.UpdateAsync(genre, token);

            var response = _mapper.Map<SingleGenreResponse>(genre);

            return response == null ? NotFound() : Ok(response);
        }

        [HttpDelete(ApiEndpoints.Method.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int id, CancellationToken token)
        {
            var response = await _genreService.DeleteAsync(id, token);

            return response ? Ok() : NotFound($"Genre with ID {id} not found.");
        }
    }

}