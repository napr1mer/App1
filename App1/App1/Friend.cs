using System;
using System.Collections.Generic;
using System.Text;

using SQLite;

namespace App1
{
    [Table("Friends")]
    public class Friend
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public string Ingk { get; set; }
        public string Ing { get; set; }

    }
}
