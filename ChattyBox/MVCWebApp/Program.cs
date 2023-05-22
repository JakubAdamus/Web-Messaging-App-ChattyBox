using BLL.DataTransferObjects;
using BLL.Services.ChatService;
using BLL.Services.FileMessageService;
using BLL.Services.TextMessageService;
using BLL.Services.UserService;
using DAL.Database;
using DAL.Repositories.ChatRepository;
using DAL.Repositories.FileMessageRepository;
using DAL.Repositories.TextMessageRepository;
using DAL.Repositories.UserRepository;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using BLL.Services.RoleService;
using DAL.Repositories.RoleRepository;
using MVCWebApp.Middleware;
using MVCWebApp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DbChattyBox>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ChattyBoxString")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IChatRepository, ChatRepository>();
builder.Services.AddScoped<ITextMessageRepository, TextMessageRepository>();
builder.Services.AddScoped<IFileMessageRepository, FileMessageRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IChatService, ChatService>();
builder.Services.AddScoped<ITextMessageService, TextMessageService>();
builder.Services.AddScoped<IFileMessageService, FileMessageService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped(provider =>
{
    var chatService = provider.GetRequiredService<IChatService>();
    return new RolesAuthorization(chatService, "role");
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}



app.UseStaticFiles();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
