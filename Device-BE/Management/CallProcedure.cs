using Dapper;
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

        public IEnumerable<T> BaoCaoCoOutPut(string tenProc, Dictionary<string, object> d, out int total)
        {
            using (var cnn = (_context as DbContext).Database.GetDbConnection())
            {
                var cmm = cnn.CreateCommand();
                var p = new DynamicParameters();
                if (d.Count > 0)
                {
                    foreach (var item in d)
                    {
                        if (item.Key.StartsWith("Id") && (item.Value.ToString() == ""))
                        {
                            p.Add(item.Key, Guid.Empty);
                        }
                        else
                            p.Add(item.Key, item.Value);
                    }

                }
                p.Add("total", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var data = cnn.Query<T>(tenProc, p, commandType: CommandType.StoredProcedure);
                total = p.Get<int>("total");
                return data;
            }
        }

        public IEnumerable<T> BaoCao(string tenProc, Dictionary<string, object> d)
        {
            using (var cnn = (_context as DbContext).Database.GetDbConnection())
            {
                var cmm = cnn.CreateCommand();
                var p = new DynamicParameters();
                if (d.Count > 0)
                {
                    foreach (var item in d)
                    {
                        if (item.Key.StartsWith("Id") && (item.Value.ToString() == ""))
                        {
                            p.Add(item.Key, Guid.Empty);
                        }
                        else
                            p.Add(item.Key, item.Value);
                    }

                }
                var data = cnn.Query<T>(tenProc, p, commandType: CommandType.StoredProcedure);
                return data;
            }
        }
    }
}
