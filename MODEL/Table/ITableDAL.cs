using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL.Table
{
    public interface ITableDAL
    {
        List<TableModel> GetAllTables();
        void AddTable(TableModel table);
    }


}
