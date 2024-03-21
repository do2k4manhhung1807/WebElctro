using Microsoft.EntityFrameworkCore;
using WebDT.Data;
using Microsoft.AspNetCore.Identity;
using WebDT.Models;
using WebDT.Service;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ElectroWeb"))
);


builder.Services.AddTransient<IEmailSender, EmailSender>();


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IOTimeout = TimeSpan.FromMinutes(15); //thoi gian ton tai
    options.Cookie.IsEssential = true;
});

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));


builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options => {
    // Thiết lập về Password
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 1;

    // Cấu hình Lockout - khóa user
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // Cấu hình về User.
    options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;  // Email là duy nhất

    // Cấu hình đăng nhập.
    options.SignIn.RequireConfirmedEmail = false;            
    options.SignIn.RequireConfirmedPhoneNumber = false;     
    options.SignIn.RequireConfirmedAccount = true;

});

var app = builder.Build();


app.UseSession();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


/*app.UseEndpoints(endpoints => {

    endpoints.MapGet("/testmail", async context => {

        // Lấy dịch vụ sendmailservice
        var sendmailservice = context.RequestServices.GetService<IEmailSender>();
        string orderId = "#123"; // Placeholder for order id
        string phoneNumber = "0123456789"; // Placeholder for phone number
        string address = "123 Main St, City, Country"; // Placeholder for address
        string totalMoney = "$100"; // Placeholder for total money
        string khachHang = "Donald Trump";
        MailContent content = new MailContent
        {
            To = "nnhoang0710@gmail.com",
            Subject = "Đơn hàng mới",
            Body = $@"
                        <p><strong>Mã đơn hàng: {orderId}</strong></p>
                        <p>Khách hàng: {khachHang}</p>
                        <p>Số điện thoại: {phoneNumber}</p>
                        <p>Địa chỉ: {address}</p>
                        <p>Tổng tiền: {totalMoney}</p>
                    "
        };

        await sendmailservice.SendMail(content);
        await context.Response.WriteAsync("Send mail");
    });

});*/

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
