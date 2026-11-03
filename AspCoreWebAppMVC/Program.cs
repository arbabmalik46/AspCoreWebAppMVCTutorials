using AspCoreWebAppMVC.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStudent, StudentRepository>();

var app = builder.Build();
app.UseRouting();

//app.MapGet("/",()=> "Hello World!");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Useres}/{action=index}/{id?}"
    );
// Can be used to map different HTTP methods to the same endpoint
//app.UseEndpoints(endpoints => {
//    endpoints.MapGet("/Home", async (context) => {
//    await context.Response.WriteAsync("This is homepage with Get Method..!");
//    });
//    endpoints.MapPut("/Home", async (context) => {
//        await context.Response.WriteAsync("This is homepage with Put Method..!");
//    }); 
//    endpoints.MapPost("/Home", async (context) => {
//        await context.Response.WriteAsync("This is homepage with Post Method..!");
//    }); 
//    endpoints.MapDelete("/Home", async (context) => {
//        await context.Response.WriteAsync("This is homepage with Delete Method..!");
//    });
//});

//app.MapGet("/Home", () => "Hello World");
//app.Map("/", () =>"This page is clear");
//app.MapGet("/", () => "hello World");
//app.MapGet("/", () => "Hello World");
//app.MapDefaultControllerRoute();

//app.MapControllerRoute(
//    name: "default", pattern: "{controller=Home}/{action=Index}/{id?}"
//    );
//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=User}/{action=Index}/{id?}");

//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("Welcome to ASP.Net Core");
//    await next(context);
//});

//app.Run(async (centext) =>
//{
//    await centext.Response.WriteAsync(Convert.ToString(centext.Connection.LocalPort));
//});

//app.MapControllers();
//app.MapControllerRoute();
//Run anything by default if no other route matches
//app.Run(async (httpContext) => {
//    await httpContext.Response.WriteAsync("This is a simple page");
//});
app.Run();