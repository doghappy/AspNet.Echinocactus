using DogHappy.AspNet.Echinocactus.Attributes;
using DogHappy.AspNet.Echinocactus.ValueConverters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DogHappy.AspNet.Echinocactus.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class DataTableExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static T GetCellValue<T>(this DataRow row, string columnName)
        {
            if (row == null)
            {
                return default;
            }
            else
            {
                object cell = row[columnName];
                if (cell == DBNull.Value)
                {
                    return default;
                }
                else
                {
                    return ValueConverter.As<T>(cell);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public static T GetCellValue<T>(this DataRow row, int columnIndex)
        {
            if (row == null)
            {
                return default;
            }
            else
            {
                object cell = row[columnIndex];
                return ValueConverter.As<T>(cell);
            }
        }

        /// <summary>
        /// Convert DataRow into an object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        /// <returns></returns>
        public static T As<T>(this DataRow row) where T : new()
        {
            if (row == null)
            {
                return default;
            }
            else
            {
                T data = new T();
                Type dateType = data.GetType();
                var props = dateType.GetProperties();
                foreach (DataColumn column in row.Table.Columns)
                {
                    foreach (var p in props)
                    {
                        var attr = p.GetCustomAttribute<PropertyNameAttribute>();
                        if ((attr != null && attr.Name == column.ColumnName) || p.Name == column.ColumnName)
                        {
                            var value = row[column.ColumnName];
                            if (DBNull.Value != value)
                            {
                                p.SetValue(data, row[column.ColumnName]);
                            }
                        }
                    }
                }
                return data;
            }
        }

        /// <summary>
        /// Convert DataRow into a list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="table"></param>
        /// <returns></returns>
        public static List<T> As<T>(this DataTable table) where T : new()
        {
            if (table == null)
            {
                return default;
            }
            else
            {
                List<T> list = new List<T>();
                foreach (DataRow row in table.Rows)
                {
                    var item = row.As<T>();
                    list.Add(item);
                }
                return list;
            }
        }
    }
}
