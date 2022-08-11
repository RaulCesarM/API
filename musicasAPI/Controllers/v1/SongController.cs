using Microsoft.AspNetCore.Mvc;
using musicasAPI.DTO.v1;
using musicasAPI.Models.v1;
using musicasAPI.Repository.v1;

namespace musicasAPI.Controllers.v1
{



    [ApiController]
    [Route("API/v{version:apiVersion}/Song")]
    [Route("API/Song")]
    [ApiVersion("1", Deprecated = true)]
    public class SongController : ControllerBase
    {

        private readonly AlbumRepository1 _albumRepository;
        private readonly SingerRepository1 _singerRepository;
        private readonly SongRepository1 _songRepository;

        public SongController(AlbumRepository1 albumRepository,
                              SingerRepository1 singerRepository,
                              SongRepository1 songRepository)
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