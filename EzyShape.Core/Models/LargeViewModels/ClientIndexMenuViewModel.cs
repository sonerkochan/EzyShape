using EzyShape.Core.Models.Clients;
using EzyShape.Core.Models.Notes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzyShape.Core.Models.LargeViewModels
{
    public class ClientIndexMenuViewModel
    {
        public ClientViewModel Client { get; set; } = null!;
        public IEnumerable<NoteViewModel> TrainerNotes { get; set; }
    }
}
