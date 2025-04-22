using NUnit.Framework;
using System;

[TestFixture]
public class CalculatorTests
{
    [Test]
    public void Add_Test()
    {
        var obj = new Calculator();
        var result = obj.Add(2, 2);
        Assert.AreEqual(0, result); // TODO: sửa 0 thành kết quả mong đợi
    }

    [Test]
    public void Subtract_Test()
    {
        var obj = new Calculator();
        var result = obj.Subtract(2, 2);
        Assert.AreEqual(0, result); // TODO: sửa 0 thành kết quả mong đợi
    }

}
