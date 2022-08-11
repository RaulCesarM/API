using musicasAPI.Models.v2;

namespace musicasAPI.Repository.v2
{
    public class SongRepository2
    {
        private static int _indiceID = 1;
        private static List<Song> _song = new();

        public Song CreateSong(Song song)
        {
            song.IdSong = _indiceID++;
            _song.Add(song);
            return song;
           
        }
        public Song UpdateSong(int songId, Song song)
        {
            var SongTemp = _song.FirstOrDefault(Song => Song.IdSong == songId);
            if (SongTemp == null) return null;
            SongTemp.Name = song.Name;
            SongTemp.Singer = song.Singer;
            SongTemp.Genre = song.Genre;
            SongTemp.Album = song.Album;        
            SongTemp.UrlImage = song.UrlImage;
            return SongTemp;
        }
        public void RemoveSong(int songId)
        {
            var SongTemp = _song
            .Find(SongList => SongList.IdSong == songId);
            _song.Remove(SongTemp);

        }
        public List<Song> GetAllSong(string filter=null)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                return _song
                    .Where(a => a.Name.Contains(filter))
                    .ToList();
            }
            return _song;
        }
        public List<Song> GetAlbumSong(int albumId)
        {
            
            return _song
            .Where(s=> s.Album != null)
            .Where(s=>s.Album.IdAlbum == albumId)
            .ToList();
        }
        public Song GetSongById(int songId)
        {
            return _song.Find(a => a.IdSong == songId);
        }




    }
}