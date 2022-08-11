using musicasAPI.Models.v1;

namespace musicasAPI.Repository.v1
{
    public class AlbumRepository1
    {
        private static int _indiceID =1;
        private static List<Album> _albuns = new();

        public Album CreateAlbum(Album album){

            album.IdAlbum = _indiceID++;
            _albuns.Add(album);
            return album;
        }
        public Album UpdateAlbum(int albumId, Album album)
        {            
            var AlbumTemp = _albuns.FirstOrDefault(Album =>  Album.IdAlbum == albumId);
            if (AlbumTemp == null) return null;
                AlbumTemp.Name = album.Name;
                AlbumTemp.YearRelease = album.YearRelease;
                AlbumTemp.UrlFrontcover = album.UrlFrontcover;
                AlbumTemp.Singer = album.Singer;
            return AlbumTemp;
        }
        public void RemoveAlbum(int albumId)
        {
            var AlbumTemp = _albuns
            .FirstOrDefault(AlbumList => AlbumList.IdAlbum == albumId);
            _albuns.Remove(AlbumTemp);
        }
        public List<Album> GetAllAlbuns(string filter = null)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                return _albuns
                    .Where(a => a.Name.Contains(filter))
                    .ToList();
            }

            return _albuns;
        }
        public Album GetAlbumById(int albumId)
        {
            return _albuns.FirstOrDefault(a => a.IdAlbum == albumId);
        }

    }
}