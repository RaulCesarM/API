using musicasAPI.Contexts;
using musicasAPI.Models.v2;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace musicasAPI.Repository.v2
{
    public class AlbumRepository2
    {
       

        private readonly MusicContext _context;

        public AlbumRepository2(MusicContext context)
        {
            _context = context;
        }


        public async Task<Album> CreateAlbum(Album album){

            await _context.Albuns.AddAsync(album);
            await _context.SaveChangesAsync();


            return album;
         
        }
        public async Task<Album> UpdateAlbum(int albumId, Album album)
        {
            _context.Albuns.Update(album);
            await _context.SaveChangesAsync();
            return album;  
            
            
            
            
            
              /*  
            var AlbumTemp = _context.FirstOrDefault(Album =>  Album.IdAlbum == albumId);
            if (AlbumTemp == null) return null;
                AlbumTemp.Name = album.Name;
                AlbumTemp.YearRelease = album.YearRelease;
                AlbumTemp.UrlFrontcover = album.UrlFrontcover;
                AlbumTemp.Singer = album.Singer;
            return AlbumTemp;*/
        }
        public async Task<Album> RemoveAlbum(int albumId)
        {
            Album album = await _context.Albuns.FindAsync(albumId);
            if (album == null)
            {
                return null;
            }
            else
            {
                _context.Remove(albumId);
                await _context.SaveChangesAsync();
                return album;

            }
        }
        public async Task<IEnumerable<Album>> GetAllAlbuns(string filter = null)
        {           

            if (!string.IsNullOrEmpty(filter))
            {
                return await _context.Albuns.Where(a => a.Name.Contains(filter)).ToListAsync();

            }

            return await _context.Albuns.ToListAsync();
        }
        public Album GetAlbumById(int albumId)
        {
            return _context.Albuns.FirstOrDefault(a => a.IdAlbum == albumId);
        }

    }
}