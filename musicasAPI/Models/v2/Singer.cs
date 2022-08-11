using System.ComponentModel.DataAnnotations;

namespace musicasAPI.Models.v2
{
    public class Singer
    {
        [Key]
        [Required]
        public int IdSinger { get; internal set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string UrlImage { get; set; }

        public virtual ICollection<Song> Songs { get; set; }

        public virtual ICollection<Album> Albuns { get; set; }

        public Singer() {

        }
       
    }
}