using Cs_SuperMarketWebApp.customSessions;
using Cs_SuperMarketWebApp.Models;
using Cs_SuperMarketWebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Cs_SuperMarketWebApp.Controllers
{
    public class FinalBillController : Controller
    {
        IBill finalBill;

        public FinalBillController(IBill fb)
        {
            finalBill = fb;
        }
        public IActionResult Index()
        {
            var selProducts = HttpContext.Session.GetSessionData<List<BillDetail>>("PurchasedProduct");

            var billMaster = new BillMaster();
            //Calculate the Total Bill Amount
            foreach (var item in selProducts)
            {
                billMaster.BillAmount += item.RowPrice;
            }

            billMaster.BillDetails = selProducts;

            finalBill.GenerateBill(billMaster, billMaster.BillDetails.ToArray());

            return View(billMaster);
        }
    }
}
