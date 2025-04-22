using System;
//Chương trình chính 
class Program
{
    static void Main(string[] args)
    {
        Type targetType = typeof(Calculator); // Xác định class cần sinh test (ở đây là class Calculator)
        string testPath = "GeneratedTests.cs"; // Đường dẫn lưu file test được sinh ra

        TestWriter.WriteTests(testPath, targetType); // Gọi hàm sinh test
        Console.WriteLine("Đã sinh file test: " + testPath); // In ra thông báo hoàn thành

        
    }
}
