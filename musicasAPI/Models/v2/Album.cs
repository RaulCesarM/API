using System.Security.AccessControl;
using System.ComponentModel.DataAnnotations;

namespace musicasAPI.Models.v2
{
    public class Album
    {
        [Key]
        [Required]
        public int IdAlbum { get; internal set; }
        public string Name { get; set; }           
        public int YearRelease { get; set; }
        public string UrlFrontcover { get; set; }
        public Singer Singer { get; set; }
        public IEnumerable<Song> Songs { get; set; }

        public Album() {

        }

        public Album(string name, 
                        int yearRelease,
                     string urlFrontcover, 
                     Singer singer)
        {   
            Name = name;
            YearRelease = yearRelease;
            UrlFrontcover =urlFrontcover;
            Singer = singer;



        }

    }
   
}