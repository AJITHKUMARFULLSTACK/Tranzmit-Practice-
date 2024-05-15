using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TCPFileTransfer.Models
{
    public class FileDbContext : DbContext
    {
        public DbSet<File> Files { get; set; }
    }
}