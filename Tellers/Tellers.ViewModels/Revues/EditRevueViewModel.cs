using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tellers.ViewModels.Revues
{
    public class EditRevueViewModel : CreateRevueViewModel
    {
        public string UserId { get; set; }
        public int Id { get; set; }
    }
}
