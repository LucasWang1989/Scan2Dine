using Scan2Dine.EntityModels;

namespace Scan2Dine.UnitTests;

public class EntityModelTests
{
    [Fact]
    public void DatabaseConnectTest()
    {
        using OsDbContext osdb = new();
        Assert.True(osdb.Database.CanConnect());
    }
    
    [Fact]
    public void ChannelPayOrderCountTest()
    {
        using OsDbContext osdb = new();
        int expected = 44;
        int actual = osdb.OsChannelPayOrders.Count();
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void ProductDefID1isPizzaTest()
    {
        using OsDbContext osdb = new();
        string expected = "Pizza";
        OsProductDef? pd = osdb.OsProductDefs.Find((long)1);
        string actual = pd?.FName ?? string.Empty;
            
        Assert.Equal(expected, actual);
    }
}