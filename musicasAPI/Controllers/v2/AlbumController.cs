using Microsoft.AspNetCore.Mvc;
using musicasAPI.DTO.v2;
using musicasAPI.Models.v2;
using musicasAPI.Repository.v2;

namespace musicasAPI.Controllers.v2
{
    [ApiController]
    [Route("API/v{version:apiVersion}/Albuns")]
    [Route("API/Albuns")]
    [ApiVersion("2")]
    public class AlbumController : ControllerBase
    {

        private readonly AlbumRepository2  _albumRepository; 
        private readonly SingerRepository2 _singerRepository;
        private readonly SongRepository2   _songRepository;

        public AlbumController(AlbumRepository2 albumRepository,
                              SingerRepository2 singerRepository,
                              SongRepository2   songRepository  )
        {
            _albumRepository  = albumRepository;
            _singerRepository = singerRepository;
            _songRepository   = songRepository;
        }        

        [HttpGet]
        public async Task<ActionResult<Album>> GetAll([FromQuery] string filter)
        {
            return Ok( await _albumRepository.GetAllAlbuns(filter));
        }

        [HttpGet("{IdSong}")]
        public async Task<ActionResult<Song>> GetBySong([FromRoute] int IdSong)
        {
            return Ok( await _songRepository.GetAlbumSong(IdSong));
        }

        [HttpPost]//#IMPORTANT
        public async Task<ActionResult<Album>> Post([FromBody] AlbumDTO albumDTO)
        {
            var singer = await _singerRepository.GetSingerById(albumDTO.SingerID);
            var album = new Album(albumDTO.Name,
                                  albumDTO.YearRelease,
                                  albumDTO.UrlFrontcover,
                                  singer
            );
            await _albumRepository.CreateAlbum(album);
            return Ok(album);
        }

        [HttpPut("{IdAlbum}")]//#IMPORTANT
        public async Task<ActionResult<Album>> Put([FromBody] AlbumDTO albumDTO,[FromRoute] int IdAlbum )
        {
            var singer = await _singerRepository.GetSingerById(albumDTO.SingerID);

            var album = await _albumRepository.UpdateAlbum(IdAlbum,new Album( albumDTO.Name,
                                                                        albumDTO.YearRelease,
                                                                        albumDTO.UrlFrontcover,
                                                                        singer)
         
            );
            return Ok(album);
        }


        [HttpDelete("{IdAlbum}")]
        public  async Task<ActionResult<Album>> Delete(int IdAlbum)
        {
           await _albumRepository.RemoveAlbum(IdAlbum);
            return NoContent();
        }
        
    }
}