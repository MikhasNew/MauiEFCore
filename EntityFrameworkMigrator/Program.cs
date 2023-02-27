using EntityFremworkHelper.Context;
Console.WriteLine("Migrator running..");
using (var blogContext = new DataItemContext())
{
    var all = blogContext.DataItems.ToList();
}