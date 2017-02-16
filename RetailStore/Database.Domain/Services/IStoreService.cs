using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace DBase.Domain.Services
{
    interface CRUD
    {
        void create(Database db, int id, string name, int price);
        DataSet read(Database db);
        void update(Database db, int id, string name, int price);
        void delete(Database db, int id);        
    }

}
