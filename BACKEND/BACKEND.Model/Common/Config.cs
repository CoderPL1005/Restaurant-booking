using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BACKEND.Model.Common
{
    public static class Config
    {
        private static int _isPublish = 0;
        public static string ConnectionString
        {
            get
            {
                string connectionString = @"Server=LAPTOP-T4J6JF2T\SQLEXPRESS;database=RestaurantDB;User Id = sa; Password=1;TrustServerCertificate=True";
                if (_isPublish == 1) connectionString = @"Server=NAM;Initial Catalog=RTC;User ID=sa;Password=1";
                return connectionString;
            }
        }


    }
}
