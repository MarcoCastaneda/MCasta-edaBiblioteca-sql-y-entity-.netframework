using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Autor
    {

        public static ML.Result Add(ML.Autor autor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.MCastanedaDigiProEntities context = new DLEF.MCastanedaDigiProEntities())
                {
                    var query = context.AlumnoAdd(autor.Nombre, autor.ApellidoPaterno, autor.ApellidoMaterno);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el insert";
                    }
                    result.Correct = true;
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Autor autor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.MCastanedaDigiProEntities context = new DLEF.MCastanedaDigiProEntities())
                {
                    var query = context.AlumnoUpdate(autor.IdAutor, autor.Nombre, autor.ApellidoPaterno, autor.ApellidoMaterno, autor.Email, autor.Password);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el update";
                    }
                    result.Correct = true;
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(ML.Autor autor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.MCastanedaDigiProEntities context = new DLEF.MCastanedaDigiProEntities())
                {
                    var query = context.AlumnoDelete(autor.IdAutor);

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar el insert";
                    }
                    result.Correct = true;
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdAutor)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.MCastanedaDigiProEntities context = new DLEF.MCastanedaDigiProEntities())
                {
                    var obj = context.AlumnoGetById(IdAutor).FirstOrDefault();
                    result.Objects = new List<object>();

                    if (obj != null)
                    {
                        ML.Autor autor = new ML.Autor();
                        autor.IdAutor = obj.IdAlumno;
                        autor.Nombre = obj.Nombre;
                        autor.ApellidoPaterno = obj.ApellidoPaterno;
                        autor.ApellidoMaterno = obj.ApellidoMaterno;


                        result.Object = autor;
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo realizar la consulta";
                    }

                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DLEF.MCastanedaDigiProEntities context = new DLEF.MCastanedaDigiProEntities())
                {
                    var query = context.AlumnoGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Autor autor = new ML.Autor();
                            autor.IdAutor = obj.IdAutor;
                            autor.Nombre = obj.Nombre;
                            autor.ApellidoPaterno = obj.ApellidoPaterno;
                            autor.ApellidoMaterno = obj.ApellidoMaterno;


                            result.Objects.Add(autor);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido realizar la consulta";

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }



    }
}