using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Exercise2_4.Modelos;

namespace Exercise2_4.Controlador
{
    public class Database
    {
        readonly SQLiteAsyncConnection db;
        public Database(String path)
        {
            db = new SQLiteAsyncConnection(path);
            db.CreateTableAsync<Video>().Wait();
        }
        # region metodos del video
        public Task<List<Video>> GetListVid()
        {
            return db.Table<Video>().ToListAsync();
        }
        public Task<Video> GetVideosporId(int id)
        {
            return db.Table<Video>()
                .Where(i => i.id == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> guardaVideos(Video vid)
        {
            return vid.id != 0 ? db.UpdateAsync(vid) : db.InsertAsync(vid);
        }
        public Task<int> borrarVideo(Video vid)
        {
            return db.DeleteAsync(vid);
        }
        #endregion
    }
}
