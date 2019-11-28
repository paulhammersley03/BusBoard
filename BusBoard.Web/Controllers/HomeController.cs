using System.Web.Mvc;
using BusBoard.Api;
using BusBoard.Web.Models;
using BusBoard.Web.ViewModels;
using System.Collections.Generic;


namespace BusBoard.Web.Controllers
{
    public class HomeController : Controller
    {
        public string Reference { get; private set; }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult BusInfo(PostcodeSelection selection)
        {
            var info = new BusInfo(selection.Postcode);
            List<StopPoint> stopPointList = APIClass.GetAPIData(selection.Postcode);

            var BusStop1 = stopPointList[0];
            var BusStop2 = stopPointList[1];

            var sortedArrivals1 = APIClass.GetArrivalsData(BusStop1.naptanId);
            var sortedArrivals2 = APIClass.GetArrivalsData(BusStop2.naptanId);

            info.BusStop1 = BusStop1;
            info.BusStop2 = BusStop2;
            info.Arrivals1 = sortedArrivals1;
            info.Arrivals2 = sortedArrivals2;

            return View(info);
        }


        public ActionResult About()
        {
            ViewBag.Message = "Information about this site";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us!";

            return View();
        }
    }
}