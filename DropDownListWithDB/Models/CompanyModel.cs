using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DropDownListWithDB.Models
{
    public class CompanyModel
    {
        public Guid ID { get; set; }
        public List<SelectListItem> CompanyList { get; set; }
    }
}
