using Kanban.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kanban.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<BoardMember> BoardMemberships { get; set; } = [];
        public ICollection<Board> OwnedBoards { get; set; } = [];
    }
}
