using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Entities
{
    public class BoardMember
    {
        public string UserId { get; set; } = string.Empty;
        public int BoardId { get; set; }

        public Board Board { get; set; } = null!;
    }
}
