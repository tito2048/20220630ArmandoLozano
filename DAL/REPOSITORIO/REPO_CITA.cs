using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.REPOSITORIO
{
    public class REPO_CITA
    {
        SqlConnection con = new SqlConnection("Data Source = LOZANO-PC'\'SQLEXPRESS; Initial Catalog= DemoDB; User Id=armando; Password=987654;");
        public string ClientesOpt(CITA cita)
        {
            string msg = string.Empty;
            try
            {
                SqlCommand com = new SqlCommand("sp_cita", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID_CITA", cita.ID_CITA);
                com.Parameters.AddWithValue("@ID_DOCTOR", cita.ID_DOCTOR);
                com.Parameters.AddWithValue("@ID_PACIENTE", cita.ID_PACIENTE);
                com.Parameters.AddWithValue("@FECHA", cita.FECHA);
                com.Parameters.AddWithValue("@HORA", cita.HORA);
                com.Parameters.AddWithValue("@ESTADO", cita.ESTADO);
                con.Open();
                com.ExecuteNonQuery();
                con.Close();
                msg = "exitosa";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        public DataSet ObtenerClientes(CITA cita, string msg)
        {
            msg = string.Empty;
            DataSet ds = new DataSet();
            try
            {
                SqlCommand com = new SqlCommand("sp_clientes", con);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID_CITA", cita.ID_CITA);
                com.Parameters.AddWithValue("@ID_DOCTOR", cita.ID_DOCTOR);
                com.Parameters.AddWithValue("@ID_PACIENTE", cita.ID_PACIENTE);
                com.Parameters.AddWithValue("@FECHA", cita.FECHA);
                com.Parameters.AddWithValue("@HORA", cita.HORA);
                com.Parameters.AddWithValue("@ESTADO", cita.ESTADO);
                SqlDataAdapter adapter = new SqlDataAdapter(com);
                adapter.Fill(ds);
                msg = "exitosa";
            }
            catch (Exception ex)
            {
                msg = ex.Message;
            }
            return ds;
        }
    }
}
