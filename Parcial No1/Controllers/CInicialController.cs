using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Parcial_No1.Models;

namespace Parcial_No1.Controllers
{
    public class CInicialController : Controller
    {
        // GET: CInicial
   

        public ActionResult Usuario()
        {
            return View();
        }


        public JsonResult obtenerCedula(int cedula)
        {
            try
            {

                ClaseUsuario obj = new ClaseUsuario();
                Logica_de_negocio objLogic = new Logica_de_negocio();
                objLogic.cadenaCedula(cedula);
                TempData["tempCedula"] = obj.devolverCedula(cedula);
                return Json(objLogic.cadenaCedula(cedula), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json("Ingrese cedula", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Encuesta()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Encuesta(int valor1, int valor2, int valor3, int valor4, int valor5)
        {
            Logica_de_negocio obj = new Logica_de_negocio();
            obj.resultadoCuestionario(valor1, valor2, valor3, valor4, valor5);
            
            int resultado = obj.resultadoCuestionario(valor1, valor2, valor3, valor4, valor5);
            int tempCedula = Convert.ToInt32(TempData["tempCedula"]);

            Logica_de_negocio objIns = new Logica_de_negocio();
          //  ClaseUsuario objUsu = new ClaseUsuario();
            objIns.insertaDatos(tempCedula, valor1, valor2, valor3, valor4, valor5, resultado);
            return Json((obj.resultadoCuestionario(valor1, valor2, valor3, valor4, valor5) + " es el resultado final"), JsonRequestBehavior.AllowGet);
        }

        public ActionResult listarTabla()
        {
            Logica_de_negocio objNew = new Logica_de_negocio();
            var vari = objNew.consultaSQL();
            return View(vari);           
        }

    }
}