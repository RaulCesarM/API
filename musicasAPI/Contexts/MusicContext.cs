using musicasAPI.Models.v2;
using Microsoft.EntityFrameworkCore;

namespace musicasAPI.Contexts
{
    public class MusicContext :DbContext
    {

        public MusicContext(DbContextOptions<MusicContext> options) : base(options)
        {
            
        }

        public DbSet<Album> Albuns { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Song> Songs { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Singer>().HasKey(SI => SI.IdSinger);
            modelBuilder.Entity<Song>().HasKey(SO => SO.IdSong);
            modelBuilder.Entity<Album>().HasKey(AL => AL.IdAlbum);

         
                     
                
           

                
                   


        }


    }
}