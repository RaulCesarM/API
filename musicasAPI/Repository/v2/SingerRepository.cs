using musicasAPI.Models.v2;

namespace musicasAPI.Repository.v2
{
    public class SingerRepository2
    {
        private static int _indiceID =1;
        private  static List<Singer> _singer = new(); 

        public Singer CreateSinger(Singer singer)
        {
            singer.IdSinger = _indiceID++;
            _singer.Add(singer);
            return singer;
        }
        public Singer UpdateSinger(int singerId, Singer singer)
        {
            var SingerTemp = _singer.FirstOrDefault(Singer => Singer.IdSinger == singerId);
            if(SingerTemp == null) return null;       
            SingerTemp.Name = singer.Name;
            SingerTemp.Country = singer.Country;
            SingerTemp.UrlImage = singer.UrlImage;           
            return SingerTemp;


        }        
        public void RemoveSinger(int singerId)
        {
            var SingerTemp = _singer
            .Find(SingerList => SingerList.IdSinger == singerId);           
            _singer.Remove(SingerTemp);
        
        }
        public List<Singer> GetAllSinger(string filter = null)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                return _singer
                    .Where(a => a.Name.Contains(filter))
                    .ToList();
            }

           
            return _singer;
        }
        public Singer GetSingerById(int SingerId)
        {
            return _singer.Find(a => a.IdSinger == SingerId);
        }

    }
    
}








