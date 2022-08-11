using Microsoft.AspNetCore.Mvc;
using musicasAPI.DTO.v1;
using musicasAPI.Models.v1;
using musicasAPI.Repository.v1;

namespace musicasAPI.Controllers.v1
{

    [ApiController]
    [Route("API/v{version:apiVersion}/Albuns")]
    [Route("API/Albuns")]
    [ApiVersion("1", Deprecated = true)]
    public class AlbumController : ControllerBase
    {

        private readonly AlbumRepository1  _albumRepository; 
        private readonly SingerRepository1 _singerRepository;
        private readonly SongRepository1   _songRepository;

        public AlbumController(AlbumRepository1 albumRepository,
                              SingerRepository1 singerRepository,
                              SongRepository1   songRepository  )
        {
            _albumRepository  = albumRepository;
            _singerRepository = singerRepository;
            _songRepository   = songRepository;
        }        

        [HttpGet]
        public ActionResult<Album> GetAll([FromQuery] string filter)
        {
            return Ok(_albumRepository.GetAllAlbuns(filter));
        }

        [HttpGet("{IdSong}")]
        public ActionResult<Song> GetBySong([FromRoute] int IdSong)
        {
            return Ok(_songRepository.GetAlbumSong(IdSong));
        }

        [HttpPost]//#IMPORTANT
        public ActionResult<Album> Post([FromBody] AlbumDTO albumDTO)
        {
            var singer = _singerRepository.GetSingerById(albumDTO.SingerID);
            var album = new Album(albumDTO.Name,
                                  albumDTO.YearRelease,
                                  albumDTO.UrlFrontcover,
                                  singer
            );
            _albumRepository.CreateAlbum(album);
            return Ok(album);
        }

        [HttpPut("{IdAlbum}")]//#IMPORTANT
        public ActionResult<Album> Put([FromBody] AlbumDTO albumDTO,[FromRoute] int IdAlbum )
        {
            var singer = _singerRepository.GetSingerById(albumDTO.SingerID);

            var album = _albumRepository.UpdateAlbum(IdAlbum,new Album( albumDTO.Name,
                                                                        albumDTO.YearRelease,
                                                                        albumDTO.UrlFrontcover,
                                                                        singer)
         
            );
            return Ok(album);
        }


        [HttpDelete("{IdAlbum}")]
        public ActionResult<Album> Delete(int IdAlbum)
        {
            _albumRepository.RemoveAlbum(IdAlbum);
            return NoContent();
        }
        
    }
}