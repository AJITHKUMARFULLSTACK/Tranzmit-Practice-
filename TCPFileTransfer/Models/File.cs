using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TCPFileTransfer.Models
{
    public class File
    {
        public int Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public byte[] FileData { get; set; }
    }
}