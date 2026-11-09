using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Entities
{
    public class Board
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string OwnerId { get; set; } = string.Empty;

        public ICollection<BoardColumn> Columns { get; set; } = [];
        public ICollection<BoardMember> Members { get; set; } = [];
    }
}
