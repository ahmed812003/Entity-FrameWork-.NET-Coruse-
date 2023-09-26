using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string? Url { get; set; }    
        public DateTime AddedOn { get; set; }
        public decimal Rating { get; set; }
        public List<Post> Posts { get; set; }

    }
}
