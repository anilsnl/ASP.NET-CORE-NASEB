using NASEB.Library.Entities.ComplexType;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NASEB.Library.MVCWebUI.Models
{
    public class EditBookViewModel
    {
        public EditBookModel Book { get; set; }

        public List<BaseSelectModel>  BookTypes { get; set; }
        public List<BaseSelectModel>  Authors { get; set; }
        public List<BaseSelectModel>  Publishers { get; set; }
        public List<int>  SelectedAuthors { get; set; }


        public EditBookViewModel()
        {
            BookTypes = new List<BaseSelectModel>();
            Publishers = new List<BaseSelectModel>();
            SelectedAuthors = new List<int>();
            Authors = new List<BaseSelectModel>();
            Book = new EditBookModel();
        }
    }
}
