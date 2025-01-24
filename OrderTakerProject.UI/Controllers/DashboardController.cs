using Microsoft.AspNetCore.Mvc;
using OrderTakerProject.Core.Models;
using OrderTakerProject.Core.Models.DTOs;
using OrderTakerProject.UI.Services.Interface;
using System.Net.Http;

namespace OrderTakerProject.UI.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            this.dashboardService = dashboardService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CustomerList()
        {
            try
            {
                var customerViewModel = await dashboardService.GetCustomers();

                return PartialView("_CustomerLayout", customerViewModel);
            }
            catch { return RedirectToAction("Unauthorized_401", "Home"); }

        }
        public async Task<IActionResult> SKUList()
        {
            try
            {
                var skuViewModel = await dashboardService.GetSkus();

                return PartialView("_SKULayout", skuViewModel);
            }
            catch { return RedirectToAction("Unauthorized_401", "Home"); }

        }
        public async Task<IActionResult> PurchaseItemList(int purchaseOrderId)
        {
            try
            {
                var purchaseItemViewModel = await dashboardService.GetItems(purchaseOrderId);

                return PartialView("_PurchaseItemLayout", purchaseItemViewModel);
            }
            catch { return RedirectToAction("Unauthorized_401", "Home"); }

        }

        public async Task<IActionResult> OrdersList()
        {
            try
            {
                var orderViewModel = await dashboardService.GetOrders();

                return View("OrderList", orderViewModel);
            }
            catch { return RedirectToAction("Unauthorized_401", "Home"); }

        }

        public async Task<IActionResult> AddOrder()
        {
            try
            {
                var orderViewModel = await dashboardService.GetOrders();

                return View("AddOrder", orderViewModel);
            }
            catch { return RedirectToAction("Unauthorized_401", "Home"); }

        }
        public async Task<IActionResult> UpdateOrder(int id)
        {
            try
            {
                var orderViewModel = await dashboardService.GetExistingOrder(id);

                return View("UpdateOrder", orderViewModel);
            }
            catch { return RedirectToAction("Unauthorized_401", "Home"); }

        }

        //[HttpPost]
        ////[Route("SaveCustomer")]
        //public async Task<IActionResult> SaveCustomer([FromBody] CustomerModel model)
        //{
        //    try
        //    {
        //        var saveCustomerViewModel = await dashboardService.SaveCustomer(model);

        //        return Json(saveCustomerViewModel);
        //    }
        //    catch { return RedirectToAction("Unauthorized_401", "Home"); }
        //}

    }
}
