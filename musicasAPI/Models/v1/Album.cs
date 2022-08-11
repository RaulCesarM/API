namespace musicasAPI.Models.v1
{
    public class Album
    {
        public int IdAlbum { get; internal set; }
        public string Name { get; set; }           
        public int YearRelease { get; set; }
        public string UrlFrontcover { get; set; }
        public Singer Singer { get; set; }

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