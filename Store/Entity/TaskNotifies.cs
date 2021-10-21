using System;

namespace SVPT.WebAPI.Store.Entity
{
    public class TaskNotifies : Default
    {
        public Guid Id { get; set; }
        public Guid SVTPTaskId { get; set; }
        public string Email { get; set; }
    }
}
