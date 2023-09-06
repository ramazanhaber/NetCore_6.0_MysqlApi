using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MysqlApi.Entities;
using MysqlApi.Models;
using MySqlConnector;
using Newtonsoft.Json;
using System.Data;

namespace MysqlApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YeniController : ControllerBase
    {
        [HttpGet]
        [Route("getKategoriler")]
        public IActionResult getKategoriler()
        {
            using var context = new Context();
            var values = context.tbl_log.ToList();
            return Ok(values);
        }


        [HttpPost]
        [Route("PostKategoriler")]
        public IActionResult PostKategoriler(tbl_log log)
        {
            using var context = new Context();
            var values = context.tbl_log.Add(log);
            context.SaveChanges();
            return Ok(log);
        }


        [HttpPut]
        [Route("PutKategoriler")]
        public IActionResult PutKategoriler(int id)
        {
            using var context = new Context();
            var values = context.tbl_log.Where(x=>x.id == id).ToList();
           // context.SaveChanges();
            return Ok(values);
        }


        [HttpGet]
        [Route("getKategoriler2")]
        public IActionResult getKategoriler2(int id)
        {
            using var context = new Context();
            var values = getQueryToDataTable("SELECT * FROM uzaktan_aydinlatma.tbl_log where id="+id+";", context);
            // context.SaveChanges();
            return Ok(JsonConvert.SerializeObject(values));
        }


        [ApiExplorerSettings(IgnoreApi = true)]
        [NonAction]
        public DataTable getQueryToDataTable(string query, DbContext context)
        {
            DataTable dt = new DataTable();
            try
            {
                using (var cmd = context.Database.GetDbConnection().CreateCommand())
                {
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
                    MySqlDataAdapter da = new MySqlDataAdapter((MySqlCommand)cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
            }
            return dt;
        }
    }
}
