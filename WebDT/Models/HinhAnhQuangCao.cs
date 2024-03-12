﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebDT.Models
{
    public class HinhAnhQuangCao
    {
        [Key]
        public int MaAnhQuangCao {  get; set; } 
        public string FileAnh { get; set; }
        [NotMapped]
        public IFormFile ProfilePhoto { get; set; }

    }
}
