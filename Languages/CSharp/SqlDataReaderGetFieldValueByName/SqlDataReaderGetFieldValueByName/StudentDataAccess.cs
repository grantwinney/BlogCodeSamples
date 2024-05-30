using System.Data.SqlClient;

namespace SqlDataReaderGetFieldValueByName;

public class StudentDataAccess
{
    public void GetStudents()
    {
        using var conn = new SqlConnection("yourConnectionString");
        using var cmd = new SqlCommand("SELECT name, age FROM students", conn);
        conn.Open();

        using var dr = cmd.ExecuteReader();
        var name = dr.GetFieldValue<string>("name");
        var age = dr.GetFieldValue<int>("age");
    }
}
