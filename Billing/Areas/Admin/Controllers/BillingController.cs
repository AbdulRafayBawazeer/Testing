using BusinessLogicLayer.Implementation;
using BusinessLogicLayer.Interface;
using BusinessObjectLayer.CommonModels;
using DataAccessLayer.DataModel;
using DataAccessLayer.GenericPattern.Implementation;
using DataAccessLayer.GenericPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Billing.Areas.Admin.Controllers
{
    public class BillingController : Controller
    {
        private ProductModel _ProductModel;
        private readonly IProduct _ProductBusiness;

        private readonly IGenericPattern<Product> _Product;
       

        public BillingController()
        {
            _ProductModel = new ProductModel();
            _ProductBusiness = new ProductBusiness();
            _Product=new GenericPattern<Product>();
        }
        // GET: Admin/Billing
        public ActionResult Index()
        {
            _ProductModel.ProductList = _ProductBusiness.ProductList().ToList();
            return View(_ProductModel);
         
        }

        public ActionResult Calculations()
        {
            return View();
        }

        public JsonResult GetProductNames(string term)
        {
            var result = _Product.GetAll().Where(x => x.ProductName.StartsWith(term)).Select(
                 y => y.ProductName).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}