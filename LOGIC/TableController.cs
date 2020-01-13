using System;
using System.Collections.Generic;
using System.Text;
using MODEL.Table;
using DAL;

namespace LOGIC
{
    public class TableController
    {
        public void AddTable(TableModel table)
        {
            TableDAL tableDAL = new TableDAL();
            tableDAL.AddTable(table);

        }

    }
}
