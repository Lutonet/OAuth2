using OAuth2DataAccess.SQLAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OAuth2DataAccess.DataAccess
{
    public class ChecksData : IChecksData
    {
        private ISQLDataAccess _sql;

        public ChecksData(ISQLDataAccess sql)
        {
            _sql=sql;
        }

        public async Task<bool> NeedsInstall()
        {
            int result = await _sql.LoadSingleRecord<int, dynamic>("spUser_AnyExists", new { });
            if (result == 0) return true;
            return false;
        }

        public async Task<bool> EmailAlreadyRegistered(string email)
        {
            int result = await _sql.LoadSingleRecord<int, dynamic>("spUser_Exists", new { Email = email });
            return result == 0 ? false : true;
        }
    }
}