using LiteDB;

namespace MoCat.Core.Db
{
  public class CoreDbContext
  {
    public LiteDatabase Db; 
    
    public CoreDbContext()
    {
      this.Db = new LiteDatabase(":memory:");
    }
  }
}