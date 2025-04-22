using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
//Sinh ra file chứa các test sinh ra
public class TestWriter
{
    public static void WriteTests(string outputPath, Type typeToTest)
    {
        var sb = new StringBuilder(); // Dùng để ghi code vào string

        sb.AppendLine("using NUnit.Framework;"); // Thêm thư viện NUnit
        sb.AppendLine("using System;");
        sb.AppendLine("");
        sb.AppendLine("[TestFixture]"); // Đánh dấu đây là class chứa test
        sb.AppendLine($"public class {typeToTest.Name}Tests"); // Tên class test, ví dụ: CalculatorTests
        sb.AppendLine("{");

        var methods = TestCaseGenerator.GetPublicMethods(typeToTest); // Lấy danh sách các hàm public

        foreach (var method in methods)
        {
            sb.AppendLine("    [Test]"); // Đánh dấu đây là 1 test case
            sb.AppendLine($"    public void {method.Name}_Test()"); // Tên hàm test, ví dụ: Add_Test
            sb.AppendLine("    {");
            sb.AppendLine($"        var obj = new {typeToTest.Name}();"); // Tạo đối tượng để test

            var parameters = method.GetParameters(); // Lấy danh sách tham số
            var paramValues = string.Join(", ", parameters.Select(p => GetSampleValue(p.ParameterType))); // Sinh dữ liệu mẫu

            if (method.ReturnType != typeof(void)) // Nếu hàm có trả về kết quả
            {
                sb.AppendLine($"        var result = obj.{method.Name}({paramValues});"); // Gọi hàm
                sb.AppendLine($"        Assert.AreEqual(0, result); // TODO: sửa 0 thành kết quả mong đợi"); // So sánh kết quả (tạm thời là 0)
            }
            else
            {
                sb.AppendLine($"        obj.{method.Name}({paramValues});"); // Gọi hàm không trả kết quả
                sb.AppendLine($"        // TODO: Viết kiểm tra cho hàm không trả về"); // Nhắc nhở người dùng tự thêm kiểm tra
            }

            sb.AppendLine("    }");
            sb.AppendLine("");
        }

        sb.AppendLine("}");

        File.WriteAllText(outputPath, sb.ToString()); // Ghi toàn bộ nội dung vào file mới
    }

    private static string GetSampleValue(Type type) // Hàm tạo dữ liệu mẫu cho các kiểu
    {
        if (type == typeof(int)) return "2";
        if (type == typeof(string)) return "\"test\"";
        if (type == typeof(bool)) return "true";
        if (type == typeof(double)) return "2.0";
        return "null"; // Nếu không biết kiểu gì thì trả về null
    }
}
