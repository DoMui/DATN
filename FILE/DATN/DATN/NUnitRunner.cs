//using System;
//using System.Diagnostics;
////Dùng để chạy file test với Nunit
//public class NUnitRunner
//{
//    public static void RunTests(string testAssemblyPath)
//    {
//        var process = new Process();
//        process.StartInfo.FileName = "nunit3-console.exe"; // Tên file chạy NUnit (cần cài đặt NUnit Console)
//        process.StartInfo.Arguments = testAssemblyPath; // Tên file .dll chứa test cần chạy
//        process.StartInfo.UseShellExecute = false;
//        process.StartInfo.RedirectStandardOutput = true; // Cho phép lấy kết quả test từ cửa sổ Console
//        process.Start();

//        string output = process.StandardOutput.ReadToEnd(); // Đọc kết quả test
//        process.WaitForExit(); // Đợi test chạy xong

//        Console.WriteLine(output); // In ra kết quả test (Pass/Fail)
//    }
//}
