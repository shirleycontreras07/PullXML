using PullXml.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace PullXml.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (TempData["asientoData"] == null)
            {
                ViewBag.ShowList = false;
                return View();
            }
            else
            {
                List<AsientoContable> empList = (List<AsientoContable>)TempData["asientoData"];
                ViewBag.ShowList = true;
                return View(empList);
            }
        }


        [HttpPost]
        public ActionResult UploadXML()
        {
            try
            {
                List<AsientoContable> asientoList = new List<AsientoContable>();
                var xmlFile = Request.Files[0];
                if (xmlFile != null && xmlFile.ContentLength > 0)
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(xmlFile.InputStream);
                    XmlNodeList asiendoNodes = xmlDocument.SelectNodes("AsientoContable"); //cambiar
                    foreach (XmlNode asiento in asiendoNodes)
                    {
                        asientoList.Add(new AsientoContable()
                        {
                            //Id = Convert.ToInt32(asiento["id"].InnerText),
                            IdAsiento = asiento["IdAsiento"].InnerText,
                            NoAsiento = asiento["NoAsiento"].InnerText,
                            DescripcionAsiento = asiento["DescripcionAsiento"].InnerText,
                            FechaAsiento = asiento["FechaAsiento"].InnerText,
                            CuentaContable = asiento["CuentaContable"].InnerText,
                            TipoMovimiento = asiento["TipoMovimiento"].InnerText,
                            Monto = asiento["Monto"].InnerText
                        });
                    }
                    TempData["asientoData"] = asientoList;
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}