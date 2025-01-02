using EF9JsonEscapeRegression.Cmd;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptionsBuilder<MyDbContext>()
    .UseSqlServer("Server=.;Database=EF9JsonEscapeRegression;Trusted_Connection=True;Encrypt=False")
    .Options;

await using var ctx = new MyDbContext(options);
await ctx.Database.EnsureDeletedAsync();
await ctx.Database.EnsureCreatedAsync();

var name = new LocalizableString { En = "Door" };
var item = new Item { Name = name };

ctx.Items.Add(item);
await ctx.SaveChangesAsync();

item.Name.No = "Dør";
await ctx.SaveChangesAsync();

await using var ctx2 = new MyDbContext(options);
var actualItem = await ctx2.Items.SingleAsync();

// EF 8.0.11: "Dør"
// EF 9.0.0:  "D\\u00F8r"
Console.WriteLine(actualItem.Name.No);
