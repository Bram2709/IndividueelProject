using System;
using System.Collections.Generic;
using System.Text;
using MODEL.Table;

namespace DAL
{
    public class TableDAL : ITableDAL
    {

        List<TableModel> ITableDAL.GetAllTables()
        {
            throw new NotImplementedException();
        }
    }
}
