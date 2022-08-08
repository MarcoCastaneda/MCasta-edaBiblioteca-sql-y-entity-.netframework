using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class LibroController : Controller
    {

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Libro libro = new ML.Libro();
            ML.Result result = BL.Autor.GetAll();

            libro.Libros = result.Objects;



            return View(libro);
        }

        [HttpGet]
        public ActionResult Form(int? IdLibro)
        {

            ML.Libro libro = new ML.Libro();
            if (IdLibro == null)
            {
                return View(libro);
            }
            else
            {
                ML.Result result = new ML.Result();
                result = BL.Autor.GetById(IdLibro.Value);

                if (result.Correct)
                {
                    libro = ((ML.Libro)result.Object);
                }

            }
            return View(libro);
        }


        [HttpPost]
        public ActionResult Form(ML.Libro libro)
        {
            ML.Result result = new ML.Result();




            if (libro.IdLibro == 0)
            {



                if (result.Correct)
                {






                    ViewBag.Mensaje = "El Libro se ha agregado";
                }
                else
                {
                    ViewBag.Mensaje = "El Libro no se ha agregado";
                }
            }
            else
            {
                result = BL.Libro.Update(libro);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "El Libro se actualizo correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al realizar la actualizacion" + result.ErrorMessage;
                }
            }



            return PartialView("Modal");
        }


        [HttpGet]
        public ActionResult Delete(ML.Libro libro)
        {
            ML.Result result = BL.Libro.Delete(libro);

            if (result.Correct)
            {
                ViewBag.Mensaje = "El libro se ha eliminado";
            }
            else
            {
                ViewBag.Mensaje = "error al eliminar";
            }
            return PartialView("modal");
        }





    }
}
