using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Libro
    {


        public static ML.Result GetAll()

        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "LibroGetAll";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableMateria = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableMateria);

                        if (tableMateria.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableMateria.Rows)
                            {
                                ML.Libro libro = new ML.Libro();
                                libro.IdLibro = int.Parse(row[0].ToString());
                                libro.Nombre = row[1].ToString();
                                libro.Genero = row[2].ToString();
                                libro.año = row[3].ToString();



                                result.Objects.Add(libro);

                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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




        public static ML.Result Add(ML.Libro libro)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "LibroAdd";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[3];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = libro.Nombre;

                        collection[1] = new SqlParameter("Genero", SqlDbType.VarChar);
                        collection[1].Value = libro.Genero;


                        collection[2] = new SqlParameter("Año", SqlDbType.VarChar);
                        collection[2].Value = libro.año;




                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }

                        else
                        {
                            result.Correct = false;
                        }
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


        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "LibroGetById";

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdLibro", SqlDbType.Int);
                        collection[0].Value = IdUsuario;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        DataTable tablaUsuario = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tablaUsuario);

                        if (tablaUsuario.Rows.Count > 0)
                        {
                            DataRow row = tablaUsuario.Rows[0];

                            ML.Libro libto = new ML.Libro();
                            libto.IdLibro = int.Parse(row[0].ToString());
                            libto.Nombre = row[1].ToString();
                            libto.Genero = row[2].ToString();
                            libto.año = row[3].ToString();



                            result.Object = libto;
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
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

        public static ML.Result Delete(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    String query = "LibroDelete";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("@IdLibro", SqlDbType.Int);
                    collection[0].Value = libro.IdLibro;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {

                        result.Correct = false;
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
        public static ML.Result Update(ML.Libro libro)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    String query = "LibroUpdate";
                    SqlCommand cmd = new SqlCommand();

                    cmd.Connection = context;
                    cmd.CommandText = query;
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[3];

                    collection[0] = new SqlParameter("@IdLibro", SqlDbType.Int);
                    collection[0].Value = libro.IdLibro;

                    collection[1] = new SqlParameter("Nombre", SqlDbType.VarChar);
                    collection[1].Value = libro.Nombre;

                    collection[2] = new SqlParameter("Genero", SqlDbType.VarChar);
                    collection[2].Value = libro.Genero;

                    collection[3] = new SqlParameter("Año", SqlDbType.VarChar);
                    collection[3].Value = libro.año;


                    cmd.Parameters.AddRange(collection);

                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();

                    cmd.Connection.Close();

                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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