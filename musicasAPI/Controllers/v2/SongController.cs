using Microsoft.AspNetCore.Mvc;
using musicasAPI.DTO.v2;
using musicasAPI.Models.v2;
using musicasAPI.Repository.v2;

namespace musicasAPI.Controllers.v2
{

    [ApiController]
    [Route("API/v{version:apiVersion}/Song")]
    [Route("API/Song")]
    [ApiVersion("2")]
    public class SongController : ControllerBase
    {

        private readonly AlbumRepository2 _albumRepository;
        private readonly SingerRepository2 _singerRepository;
        private readonly SongRepository2 _songRepository;

        public SongController(AlbumRepository2 albumRepository,
                              SingerRepository2 singerRepository,
                              SongRepository2 songRepository)
        {
            _albumRepository = albumRepository;
            _singerRepository = singerRepository;
            _songRepository = songRepository;
        }


        [HttpGet]
        public ActionResult<Song> GetAll([FromQuery] string filter)
        {
            return Ok(_songRepository.GetAllSong(filter));
        }

        [HttpGet("GetById/{idSong}")]
        public ActionResult<Song> GetById([FromRoute] int idSong)
        {
            return Ok(_songRepository.GetSongById(idSong));
        }


        [HttpGet("GetByAlbum/{idAlbum}")]
        public ActionResult<Album> GetByAlbum([FromRoute] int idAlbum)
        {
            return Ok(_albumRepository.GetAlbumById(idAlbum));
        }

        [HttpPost]
        public ActionResult<Song> Post([FromBody] SongDTO songDTO)
        {
            var singer = _singerRepository.GetSingerById(songDTO.SingerId);
            var album = _albumRepository.GetAlbumById(songDTO.SingerId);
            var song = new Song(
                 songDTO.Name,                 
                 songDTO.Genre,
                 songDTO.UrlImage,
                 singer,
                 album              
            );

           _songRepository.CreateSong(song);
            return Ok(song);
        }

        [HttpPut]
        public ActionResult<Song> Put([FromBody] SongDTO songDTO ,[FromRoute] int IdSong)
        {
            var singer = _singerRepository.GetSingerById(songDTO.SingerId);
            var album = _albumRepository.GetAlbumById(songDTO.SingerId);
            var song = new Song(
                 songDTO.Name,
                 songDTO.Genre,
                 songDTO.UrlImage,
                 singer,
                 album
            );

            _songRepository.UpdateSong(IdSong,song);
            return Ok(song);
        }


        [HttpDelete("{IdSong}")]
        public ActionResult Delete(int IdSong)
        {
            _songRepository.RemoveSong(IdSong);
            return NoContent();
        }


    }
}