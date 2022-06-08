using OAuth2DataAccess.Models;
using OAuth2DataAccess.SQLAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2DataAccess.DataAccess
{
    public class ApplicationData : IApplicationData
    {
        private ISQLDataAccess _sql;

        public ApplicationData(ISQLDataAccess sql)
        {
            _sql = sql;
        }

        public async Task CreateApplication(ApplicationModel newApplication)
        {
            await _sql.SaveData("spApplication_CreateApplication", newApplication);
        }
    }
}