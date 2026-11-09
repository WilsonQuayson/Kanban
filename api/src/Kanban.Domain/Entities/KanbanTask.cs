using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Domain.Entities
{
    public class KanbanTask
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Position { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


        public int BoardColumnId { get; set; }

        public BoardColumn BoardColumn { get; set; } = null!;

    }
}
