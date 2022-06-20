using System;
using System.Collections.Generic;

namespace IMDB_Web_API.Models
{
    public partial class List
    {
        

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? UserId { get; set; }
        public bool IsDeleted { get; set; }

       
    }
}
