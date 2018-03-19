using Assessment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Data
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Case Case { get; set; }
    }
}
