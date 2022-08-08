using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AutorController : Controller
    {

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Autor autor = new ML.Autor();
            ML.Result result = BL.Autor.GetAll();

               autor.Autores = result.Objects;
           
           

            return View(autor);
        }

        [HttpGet]
        public ActionResult Form(int? IdAutor)
        {

            ML.Autor autor = new ML.Autor();
            if (IdAutor == null)
            {
                return View(autor);
            }
            else
            {
                ML.Result result = new ML.Result();
                result = BL.Autor.GetById(IdAutor.Value);

                if (result.Correct)
                {
                    autor = ((ML.Autor)result.Object);
                }

            }
            return View(autor);
        }


        [HttpPost]
        public ActionResult Form(ML.Autor autor)
        {
            ML.Result result = new ML.Result();




            if (autor.IdAutor == 0)
            {
                


                if (result.Correct)
                {

                    




                    ViewBag.Mensaje = "El Autor se ha agregado";
                }
                else
                {
                    ViewBag.Mensaje = "El Autor no se ha agregado";
                }
            }
            else
            {
                result = BL.Autor.Update(autor);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "El Autor se actualizo correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al realizar la actualizacion" + result.ErrorMessage;
                }
            }



            return PartialView("Modal");
        }


        [HttpGet]
        public ActionResult Delete(ML.Autor autor)
        {
            ML.Result result = BL.Autor.Delete(autor);

            if (result.Correct)
            {
                ViewBag.Mensaje = "El autor se ha eliminado";
            }
            else
            {
                ViewBag.Mensaje = "error al eliminar";
            }
            return PartialView("modal");
        }




















    }
}

