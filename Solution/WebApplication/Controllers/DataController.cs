using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using WebApplication.Moudules;

namespace WebApplication.Controllers
{
    public class DataController : Controller
    {
        private ArrayList list;
        [Route("api/Select")]
        [HttpGet]
        public ArrayList Select()
        {
            list = new ArrayList();
            DataBase db = new DataBase();
            MySqlDataReader mdr = db.GetReader("SELECT * FROM Notice;");

            while(mdr.Read())
            {
                Hashtable hashtable = new Hashtable();
                for (int i = 0; i < mdr.FieldCount; i++)
                {
                    hashtable.Add(mdr.GetName(i), mdr.GetValue(i));
                }
                list.Add(hashtable);
            }

            mdr.Close();
            db.ConnectionClose();

            return list;
        }
    }
}
