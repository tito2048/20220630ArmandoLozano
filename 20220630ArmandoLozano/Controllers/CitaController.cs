using DAL;
using DAL.REPOSITORIO;
using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _20220630ArmandoLozano.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        // GET: api/<CitaController>
        REPO_CITA repo = new REPO_CITA();
        string msg = string.Empty;
        [HttpGet]
        public List<CITA> Get()
        {
            CITA cita = new CITA();
            cita.TIPO_TRANSACCION = "1";
            DataSet ds = repo.ObtenerClientes(cita, msg);
            List<CITA> list = new List<CITA>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new CITA
                {
                    ID_CITA = Convert.ToInt32(dr["ID_CITA"]),
                    ID_DOCTOR = Convert.ToInt32(dr["ID_DOCTOR"]),
                    ID_PACIENTE = Convert.ToInt32(dr["ID_PACIENTE"]),
                    FECHA = Convert.ToDateTime(dr["FECHA"]),
                    HORA = dr["HORA"].ToString(),
                    ESTADO = dr["ESTADO"].ToString()
                });
            }
            return list;
        }

        // GET api/<CitaController>/5
        [HttpGet("{id}")]
        public List<CITA> Get(int id)
        {
            CITA cita = new CITA();
            cita.ID_CITA = id;
            cita.TIPO_TRANSACCION = "5";
            DataSet ds = repo.ObtenerClientes(cita, msg);
            List<CITA> list = new List<CITA>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new CITA
                {
                    ID_CITA = Convert.ToInt32(dr["ID_CITA"]),
                    ID_DOCTOR = Convert.ToInt32(dr["ID_DOCTOR"]),
                    ID_PACIENTE = Convert.ToInt32(dr["ID_PACIENTE"]),
                    FECHA = Convert.ToDateTime(dr["FECHA"]),
                    HORA = dr["HORA"].ToString(),
                    ESTADO = dr["ESTADO"].ToString()
                });
            }
            return list;
        }

        // POST api/<CitaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CitaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CitaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
