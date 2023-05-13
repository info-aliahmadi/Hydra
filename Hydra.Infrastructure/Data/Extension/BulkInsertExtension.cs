using EFCoreSecondLevelCacheInterceptor;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;


namespace Hydra.Infrastructure.Data.Extension
{
    internal static class BulkInsertExtension
    {

        public static async Task BulkInsertAsync<T>(
            this DbContext dbContext,
            IEnumerable<T> entities,
            IEFCacheServiceProvider _cacheService)
        {
            entities = entities.ToArray();

            string connectionString = dbContext.Database.GetConnectionString();
            var conn = new SqlConnection(connectionString);
            conn.Open();

            Type t = typeof(T);

            var tableAttribute = (TableAttribute)t.GetCustomAttributes(
                typeof(TableAttribute), false).Single();
            var bulkCopy = new SqlBulkCopy(conn)
            {
                DestinationTableName = tableAttribute.Name
            };

            var properties = t.GetProperties().Where(EventTypeFilter).ToArray();
            var table = new DataTable();

            foreach (var property in properties)
            {
                Type propertyType = property.PropertyType;
                if (propertyType.IsGenericType &&
                    propertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    propertyType = Nullable.GetUnderlyingType(propertyType);
                }

                table.Columns.Add(new DataColumn(property.Name, propertyType));
            }

            foreach (var entity in entities)
            {
                table.Rows.Add(properties.Select(
                  property => GetPropertyValue(
                  property.GetValue(entity, null))).ToArray());
            }

            await bulkCopy.WriteToServerAsync(table);
            conn.Close();

            _cacheService.ClearAllCachedEntries();


        }
        private static bool EventTypeFilter(System.Reflection.PropertyInfo p)
        {
            var attribute = Attribute.GetCustomAttribute(p,
                typeof(AssociationAttribute)) as AssociationAttribute;

            if (attribute == null) return true;
            if (attribute.IsForeignKey == false) return true;

            return false;
        }

        private static object GetPropertyValue(object o)
        {
            if (o == null)
                return DBNull.Value;
            return o;
        }


    }
}
