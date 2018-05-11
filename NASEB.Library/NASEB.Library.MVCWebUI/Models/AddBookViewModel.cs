using NASEB.Library.Entities.ComplexType;
using NASEB.Library.Entities.Concrete;
using System.Collections.Generic;

namespace NASEB.Library.MVCWebUI.Models
{
    public class AddBookViewModel
    {
        public Book Book { get; set; }
        public List<BaseSelectModel> Authors { get; set; }
        public List<BaseSelectModel> Publishers { get; set; }
        public List<BaseSelectModel> BookTypes { get; set; }
        public List<int> SelectedAuthors { get; set; }
        public AddBookViewModel()
        {
            Book=new Book();
            Authors=new List<BaseSelectModel>();
            Publishers=new List<BaseSelectModel>();
            BookTypes=new List<BaseSelectModel>();
            SelectedAuthors =new List<int>();

            Publishers.Add(new BaseSelectModel("","-Yayınevi Seçin-"));
            BookTypes.Add(new BaseSelectModel("","-Ktap Türü Seçin-"));
        }

    }

    
}
