using System.ComponentModel.DataAnnotations;

namespace musicasAPI.Models.v2
{
    public class Song
    {
        [Key]
        [Required]
        public int IdSong { get; internal set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string UrlImage { get; set; }
        public Singer Singer { get; set; }
        public Album Album { get; set; }

        public Song() {

        }

        public Song(string name, string genre, string urlImage, Singer singer, Album album)
        {
            Name = name;
            Genre = genre;
            UrlImage = urlImage;
            Singer = singer;
            Album = album;

        }

    }
}