using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Models.Notes
{
    using System;

    public class NoteViewModel
    {
        public int Id { get; set; }

        public string ClientId { get; set; }

        public string TrainerId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool IsArchived { get; set; }

        // Optional: Add client/trainer names if you want to show them in the view
        public string ClientName { get; set; }

        public string TrainerName { get; set; }
    }
}
