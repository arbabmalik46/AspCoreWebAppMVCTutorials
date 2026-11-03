using DropDownListWithDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Packaging.Signing;
using System.Diagnostics;

namespace DropDownListWithDB.Controllers
{
    public class HomeController : Controller
    {
        private readonly CompanyEmployeeContext _companyEmployeeContext;

        public HomeController(CompanyEmployeeContext companyEmployeeContext)
        {
            _companyEmployeeContext = companyEmployeeContext;
        }
        private CompanyModel BindCompanyModel()
        {
            CompanyModel companyModel = new CompanyModel();
            companyModel.CompanyList = new List<SelectListItem>();
            var data = _companyEmployeeContext.Companies.ToList();
            foreach (var item in data)
            {
                companyModel.CompanyList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.CompanyId.ToString()

                });

            }
            return companyModel;
        }
        public IActionResult Index()
        {
            var companyModel = BindCompanyModel();
            return View(companyModel);
        }
        [HttpPost]
        public IActionResult Index(CompanyModel companyModel)
        {
            if (companyModel == null)
            {
                return View("Error");
            }
            var companyList = _companyEmployeeContext.Companies.Where(x=>x.CompanyId == companyModel.ID).FirstOrDefault();
            if(companyList != null)
            {
                ViewBag.SelectedValue= companyList.Name;
            }
            var modelToBind = BindCompanyModel();
            return View(modelToBind);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
