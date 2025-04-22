using System;
using System.Reflection;
//Dùng Reflection để lấy hàm
public class TestCaseGenerator
{
    public static MethodInfo[] GetPublicMethods(Type type) // Lấy danh sách các hàm public trong class
    {
        // BindingFlags dùng để giới hạn chỉ lấy những hàm được định nghĩa trong class (không lấy hàm kế thừa)
        return type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
    }
}
