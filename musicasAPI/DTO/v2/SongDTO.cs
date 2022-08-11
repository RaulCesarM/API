using System.ComponentModel.DataAnnotations;

namespace musicasAPI.DTO.v2
{
    public class SongDTO
    {

        [Required(ErrorMessage = "the name is required")]
        public string Name { get; set; }
        public string Genre { get; set; }
        public string UrlImage { get; set; }

        

        [Required(ErrorMessage = "The Singer is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Artist id must be valid.")]
        public int SingerId { get; set; }


        [Required(ErrorMessage = "The Album is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Album id must be valid.")]
        public int AlbumId { get; set; }
       
     
      

    }
}