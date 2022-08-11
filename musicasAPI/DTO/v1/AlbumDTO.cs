using System.ComponentModel.DataAnnotations;


namespace musicasAPI.DTO.v1
{
   
    public class AlbumDTO
    {
       
        [Required(ErrorMessage =  "the name is required")]
        public string Name { get; set; }
       
        [Range(1500, 3000 , ErrorMessage = "The release year must be valid.")]
        public int YearRelease  { get ; set ; }
        public string UrlFrontcover { get; set; }

        [Required(ErrorMessage = "The Singer is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Artist id must be valid.")]
        public  int  SingerID { get; set; }
     
       


    }

}