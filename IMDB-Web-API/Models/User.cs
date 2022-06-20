using System;
using System.Collections.Generic;

namespace IMDB_Web_API.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string NickName { get; set; } = null!;
        public string? IdentificationNo { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public DateTime? Birthday { get; set; }
        public bool? Sex { get; set; }
        public bool Approved { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Img { get; set; } = null!;
        public string BackgroundImg { get; set; } = null!;

    }
}
