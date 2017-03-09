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
using DBase.Domain.Models;

namespace DBase.Domain.Services
{
    public interface IStoreService
    {
        int Create(Accessory accessoryTable);
        IList<Accessory> Read();
        void Update(Accessory accessoryTable);
        void Delete(int id);        
    }

}
