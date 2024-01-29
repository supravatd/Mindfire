using System;
using System.Collections.Generic;
using System.Data;

namespace ADONet.Tools
{
    public static class ListToDt
    {
        public static DataTable ToDataTable<T>(this IList<T> data, string v)
        {
            DataTable dataTable = new DataTable(v);
            if (data == null || data.Count == 0)
                return dataTable;

            var properties = typeof(T).GetProperties();

            foreach (var prop in properties)
            {
                dataTable.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (var item in data)
            {
                var row = dataTable.NewRow();

                foreach (var prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }
    }
}
