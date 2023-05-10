using EntityFremworkHelper.Context;
Console.WriteLine("Migrator running..");
using (var dataItemContext = new DataItemContext())
{
    var all = dataItemContext.DataItems.ToList();
}