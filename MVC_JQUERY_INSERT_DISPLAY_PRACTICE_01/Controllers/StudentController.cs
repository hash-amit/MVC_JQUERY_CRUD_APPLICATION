using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_JQUERY_INSERT_DISPLAY_PRACTICE_01.Controllers
{
    public class StudentController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con_string"].ConnectionString);

        public ActionResult StudentForm()
        {
            return View("StudentForm");
        }

        [HttpPost]
        public void StudentInsert(string A, string B, string C, long D)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_StudentInsert", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", A);
            cmd.Parameters.AddWithValue("@email", B);
            cmd.Parameters.AddWithValue("@pass", C);
            cmd.Parameters.AddWithValue("@mobile", D);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public JsonResult StudentShow()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_StudentShow", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            string data = JsonConvert.SerializeObject(dt);
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}