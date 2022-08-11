using System.ComponentModel.DataAnnotations;


namespace musicasAPI.DTO.v1
{
    public class SingerDTO
    {

        [Required(ErrorMessage = "the name is required")]
        public string Name { get; set; }      
        public string UrlImage { get; set; }
       

    }
}