using Microsoft.AspNetCore.Mvc;
using musicasAPI.Models.v2;
using musicasAPI.Repository.v2;

namespace musicasAPI.Controllers.v2;

[ApiController]
[Route("API/v{version:apiVersion}/Singer")]
[Route("API/Singer")]
[ApiVersion("2")]
public class SingerController : ControllerBase
{

    private readonly SingerRepository2 _singerRepository;

    public SingerController(SingerRepository2 singerRepository)
    {
        _singerRepository = singerRepository;
    }



    [HttpGet]
    public ActionResult<Singer> GetAll([FromQuery] string filter)
    {

        return Ok(_singerRepository.GetAllSinger(filter));
    }

    [HttpGet("{IdSinger}")]
    public ActionResult<Singer> GetBySinger([FromRoute] int IdSinger)
    {
        return Ok(_singerRepository.GetSingerById(IdSinger));
    }

    [HttpPost]
    public ActionResult<Singer> Post([FromBody] Singer newsinger)
    {
        var singer = _singerRepository.CreateSinger(newsinger);
        return Ok(newsinger);
    }

    [HttpPut("{IdSinger}")]
    public ActionResult<Singer> Put([FromBody] Singer singer, [FromRoute] int IdSinger)
    {
        var editSinger = _singerRepository.UpdateSinger(IdSinger, singer);
        return Ok(editSinger);
    }


    [HttpDelete("{IdSinger}")]
    public ActionResult<Singer> Delete([FromRoute]  int IdSinger)
    {
        _singerRepository.RemoveSinger(IdSinger);
        return NoContent();
    }
    

}
