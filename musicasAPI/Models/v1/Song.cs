namespace musicasAPI.Models.v1
{
    public class Song
    {
        public int IdSong { get; internal set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string UrlImage { get; set; }
        public Singer Author { get; set; }
        public Album Album { get; set; }       

        public Song(string name, string genre, string urlImage, Singer author,Album album )
        {
            Name=name;
            Genre = genre;
            UrlImage =urlImage;
            Author = author;
            Album = album;

        }
       
    }
}