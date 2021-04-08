using Device_BE.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Device_BE.Management
{
    public class CallProcedure<T>
    {
        private readonly QLPhoneContext _context;
        public CallProcedure(QLPhoneContext context)
        {
            _context = context;
        }

        public List<T> BaoCao(string tenProc, Dictionary<string, object> d)
        {
            using (var cnn = (_context as DbContext).Database.GetDbConnection())
            {
                var cmm = cnn.CreateCommand();
                cmm.CommandType = System.Data.CommandType.StoredProcedure;
                cmm.CommandText = tenProc;
                if (d.Count > 0)
                {
                    foreach (var item in d)
                    {
                        if (item.Key.StartsWith("Id") && ( item.Value.ToString() == ""))
                        {
                            cmm.Parameters.Add(new SqlParameter(item.Key, Guid.Empty));
                        }
                        else
                        cmm.Parameters.Add(new SqlParameter(item.Key, item.Value));
                    }

                }
                cmm.Connection = cnn;
                cnn.Open();
                var reader = cmm.ExecuteReader();
                var dataTable = new DataTable();
                dataTable.Load(reader);
                List<T> myObjects = new List<T>();
                if (dataTable.Rows.Count > 0)
                {
                    var serializedMyObjects = JsonConvert.SerializeObject(dataTable);
                    // Here you get the object
                    myObjects = (List<T>)JsonConvert.DeserializeObject(serializedMyObjects, typeof(List<T>));
                }
                return myObjects;
            }
        }
    }
}
