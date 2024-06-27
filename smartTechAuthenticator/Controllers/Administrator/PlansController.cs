using smartTechAuthenticator.Models;
using smartTechAuthenticator.Services.Comman;
using smartTechAuthenticator.ViewModels;
using smartTechAuthenticator.Services.Customers;
//using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace smartTechAuthenticator.Controllers.Administrator
{
   
    public class PlansController : Controller
    {
        // GET: Plans
        private readonly ICustomersService customers;
        private readonly ApplicationDbContext context;

        public PlansController(ICustomersService _customers)
        {
            customers = _customers;            
        }

        public ActionResult Index()
        {
            if (Session["Role"].ToString() != "Admin" && Session["Role"].ToString() != "SubAdmin")
            {
                return RedirectToAction("AccessDenide", "Account");
            }
            return View();
        }

        public ActionResult PurchasePlan()
        {
            if (Session["Role"].ToString() != "Admin" && Session["Role"].ToString() != "SubAdmin")
            {
                return RedirectToAction("AccessDenide", "Account");
            }
            return View();
        }


        [HttpGet]
        public async Task<ActionResult> ViewPlans(string Id)
        { 
            PlansViewModel model = new PlansViewModel();
            model = await customers.GetPlans(Guid.Parse(Id));
            return View(model);

        }

        [HttpGet]
        public async Task<ActionResult> ViewPurchasePage(string Id)
        {
            PlansViewModel model = new PlansViewModel();
            model = await customers.GetPlans(Guid.Parse(Id));
            return View(model);
        }
        public ActionResult CreatePlans()
        {
            if (Session["Role"].ToString() != "Admin" && Session["Role"].ToString() != "SubAdmin")
            {
                return RedirectToAction("AccessDenide", "Account");
            }
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> CreatePlans(PlansViewModel model)
        {

            ResponseModel response = await customers.CreatePlans(model);
            if (response.Status == Status.Success)
            {
                this.ShowMessage("success", "Plan create successfully", ToastType.success);
                return RedirectToAction("Index");
            }
            else
            {
                this.ShowMessage("failure ", "Plan not create successfully ", ToastType.success);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> PlanDetails(string Id)
        {
            if (Session["Role"].ToString() != "Admin" && Session["Role"].ToString() != "SubAdmin")
            {
                return RedirectToAction("AccessDenide", "Account");
            }
            var CategoryInfofo = await customers.GetPlanDetail(Id);
            return View(CategoryInfofo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PlanDetails(PlansViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ResponseModel response = await customers.UpdatePlanData(model);
                    if (response.Status == Status.Success)
                    {
                        this.ShowMessage("success", "Details updated successfully", ToastType.success);
                        return RedirectToAction("Index");
                    }
                    else
                        this.ShowMessage("failiure ", "Details not upated successfully ", ToastType.error);
                }
            }
            catch (Exception ex)
            {
               // logger.Error(ex);
                this.ShowMessage("Error", "An error occured, please after some time,", ToastType.success);
            }
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> DeletePlans(PlansViewModel model)
        {
            return Json(await customers.DeletePlanDetails(model), JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult GetPlans()
        {
            try
            { 
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();
                int take = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                (int TotalCount, int FilteredCount, dynamic Customers) data = customers.GetPlans(skip, take, sortColumn, sortColumnDir, searchValue);
                return Json(new { draw = draw, recordsFiltered = data.TotalCount, recordsTotal = data.TotalCount, data = data.Customers });
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}