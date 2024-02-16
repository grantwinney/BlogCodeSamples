using System.Data.SqlClient;

namespace SqlDataReaderGetFieldValueByName
{
    public class StudentDataAccess
    {
        public void GetStudents()
        {
            using (var conn = new SqlConnection("yourConnectionString"))
            {
                using (var cmd = new SqlCommand("SELECT name, age FROM students", conn))
                {
                    conn.Open();

                    using (var dr = cmd.ExecuteReader())
                    {
                        var name = dr.GetFieldValue<string>("name");

                        var age = dr.GetFieldValue<int>("age");
                    }
                }
            }
        }
    }

    public static class SqlReaderExtensions
    {
        /// <summary>
        /// Gets the value of the specified column as a type, given the column name.
        /// </summary>
        /// <typeparam name="T">The expected type of the column being retrieved.</typeparam>
        /// <param name="reader">The reader from which to retrieve the column.</param>
        /// <param name="columnName">The name of the column to be retrieved.</param>
        /// <returns>The returned type object.</returns>
        public static T GetFieldValue<T>(this SqlDataReader reader, string columnName)
        {
            return reader.GetFieldValue<T>(reader.GetOrdinal(columnName));
        }
    }
}
