using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise2_4.Modelos
{
    public class Video
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String path { get; set; }
    }
}
