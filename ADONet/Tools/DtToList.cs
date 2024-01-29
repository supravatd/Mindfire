using System;
using System.Collections.Generic;
using System.Data;

namespace ADONet.Tools
{
    public static class DtToList
    {
        public static List<T> ToList<T>(this DataTable dataTable) where T : new()
        {
            List<T> result = new List<T>();

            foreach (DataRow row in dataTable.Rows)
            {
                T item = new T();

                foreach (DataColumn column in dataTable.Columns)
                {
                    var property = typeof(T).GetProperty(column.ColumnName);

                    if (property != null)
                    { 
                        if (row[column] != DBNull.Value)
                        {
                            property.SetValue(item, row[column]);
                        }
                    }
                }

                result.Add(item);
            }

            return result;
        }
    }
}
