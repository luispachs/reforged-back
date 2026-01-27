using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using nago_reforged_api.Context;
using nago_reforged_api.Models;
using Microsoft.EntityFrameworkCore;
using nago_reforged_api.Enums;
using nago_reforged_api.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddOpenApiDocument(opt =>
{
    opt.Title = "NAGO v4 API";
    opt.Version = "v1";
    opt.Description = "NAGO v4 API Documentation for test concept";
});
builder.Services.AddCors(
                          opt =>
                          {
                              opt.AddPolicy(name:"reforgedPolicy", policy =>
                              {
                                  policy.WithOrigins(["http://localhost:5181","http://localhost:5173"])
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                              });
                          }
                        );

builder.Services.AddAuthentication(opt =>
                                        {
                                            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                                        }
                )
                .AddJwtBearer(config =>
                {
                    string? secretKey = builder.Configuration.GetValue<string>("reforgedSecret");
                    if (string.IsNullOrEmpty(secretKey))
                    {
                        throw new Exception("Secret key mustn't be null or empty");
                    }
                    config.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
                });


builder.Services.AddDbContext<ReforgedContext>((opt)=>{
    opt.UseNpgsql(
            builder.Configuration.GetConnectionString("DefaultConnection"),
            (opt)=>{
                opt.MapEnum<RoleArea>("role_area");
            }
        )
        .UseSeeding(
            (context,_)=>{
                var user = context.Set<User>().FirstOrDefault(x => x.Email =="desarrollo@tercol.com.co");
                if(user==null){
                    user =  new User {
                        Email="desarrollo@tercol.com.co",
                        PasswordHash=Hash.make("lapsDev1308"),
                        Name="luis",
                        Middlename="alfredo",
                        Lastname="pacheco sandoval",
                        Phone="3209345419",
                        CreatedAt=DateTime.Now,
                        UpdatedAt=DateTime.Now,
                        PhotoUrl=null
                    };
                     context.Set<User>().Add(user);
                    var enterprise =new Enterprise{
                        Name = "Tercol",
                        Nit = "123456789",
                        Address = "Calle 123",
                        Phone = "123456789",
                        Email = "tercol@tercol.com.co",
                    };
                    context.Set<Enterprise>().Add(enterprise);
                    var rol =  new Role{
                        Name = "MASTER",
                        Description = "Role for system admin",
                        Type =RoleArea.ADMIN
                    };
                    context.Set<Role>().Add(rol);
                    var turn = new Turn{
                        Name = "Admin turn",
                        Description = "Turn for admin",
                        FromTime = TimeOnly.FromDateTime(DateTime.Now),
                        ToTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(8))
                    };
                    context.Set<Turn>().Add(turn);
                    var area = new Area{
                        Name = "Admin area",
                        Description = "Area for admin",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = null
                    };
                    context.Set<Area>().Add(area);
                    var profile = new Profile{
                        User = user,
                        Enterprice = enterprise,
                        SalaryHour = 0,
                        LeaderId = null,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = null,
                        Turn = turn,
                        Area = area
                    };
                    context.Set<Profile>().Add(profile);
                    var permision = new Permission{
                        Role = rol,
                        Profile = profile,
                        CreateUser = true,
                        ReadUser = true,
                        UpdateUser = true,
                        DeleteUser = true,
                        CreateRoles = true,
                        ReadRoles = true,
                        UpdateRoles = true,
                        DeleteRoles = true,
                        CreateEnterprises = true,
                        ReadEnterprises = true,
                        UpdateEnterprises = true,
                        DeleteEnterprises = true,
                        CreateTurn = true,
                        ReadTurn = true,
                        UpdateTurn = true,
                        DeleteTurn = true,
                        CreateAreas = true,
                        ReadAreas = true,
                        UpdateAreas = true,
                        DeleteAreas = true,
                        CreateMachines = true,
                        ReadMachines = true,
                        UpdateMachines = true,
                        DeleteMachines = true,
                        CreateProducts = true,
                        ReadProducts = true,
                        UpdateProducts = true,
                        DeleteProducts = true,
                        CreateProcesses = true,
                        ReadProcesses = true,
                        UpdateProcesses = true,
                        DeleteProcesses = true,
                        CreateBom = true,
                        ReadBom = true,
                        UpdateBom = true,
                        DeleteBom = true,
                        CreateProviders = true,
                        ReadProviders = true,
                        UpdateProviders = true,
                        DeleteProviders = true,
                        CreateContacts = true,
                        ReadContacts = true,
                        UpdateContacts = true,
                        DeleteContacts = true,
                        CreateServices = true,
                        ReadServices = true,
                        UpdateServices = true,
                        DeleteServices = true,
                        CreateOdp = true,
                        ReadOdp = true,
                        UpdateOdp = true,
                        DeleteOdp = true,
                        CreateReportOdp = true,
                        ReadReportOdp = true,
                        UpdateReportOdp = true,
                        DeleteReportOdp = true,
                        CreateDpnc = true,
                        ReadDpnc = true,
                        UpdateDpnc = true,
                        DeleteDpnc = true,
                        CreateSolutionDpnc = true,
                        ReadSolutionDpnc = true,
                        UpdateSolutionDpnc = true,
                        DeleteSolutionDpnc = true,
                        CreateSchedule = true,
                        ReadSchedule = true,
                        UpdateSchedule = true,
                        DeleteSchedule = true,
                        CreateOc = true,
                        ReadOc = true,
                        UpdateOc = true,
                        DeleteOc = true,
                        CreateOs = true,
                        ReadOs = true,
                        UpdateOs = true,
                        DeleteOs = true,
                        CreatePayments = true,
                        ReadPayments = true,
                        UpdatePayments = true,
                        DeletePayments = true,
                        ReadReports = true,
                        GeneratedReports = true,
                        ReadReception = true,
                        UpdateReception = true,
                        DeleteReception = true,
                        CreateReception = true,
                    };
                    context.Set<Permission>().Add(permision);
                    context.SaveChanges();
                }
            }
        )
        .UseAsyncSeeding(async (context,_,cancellationToken)=>{
                var user =await context.Set<User>().FirstOrDefaultAsync(x => x.Email =="desarrollo@tercol.com.co");
                if(user==null){
                    user =  new User {
                        Email="desarrollo@tercol.com.co",
                        PasswordHash=Hash.make("lapsDev1308"),
                        Name="luis",
                        Middlename="alfredo",
                        Lastname="pacheco sandoval",
                        Phone="3209345419",
                        CreatedAt=DateTime.Now,
                        UpdatedAt=DateTime.Now,
                        PhotoUrl=null
                    };
                    context.Set<User>().Add(user);
                    var enterprise =new Enterprise{
                        Name = "Tercol",
                        Nit = "123456789",
                        Address = "Calle 123",
                        Phone = "123456789",
                        Email = "tercol@tercol.com.co",
                    };
                    context.Set<Enterprise>().Add(enterprise);
                    var rol =  new Role{
                        Name = "MASTER",
                        Description = "Master Role for system admin",
                        Type = RoleArea.ADMIN

                    };
                    context.Set<Role>().Add(rol);
                    var turn = new Turn{
                        Name = "Admin turn",
                        Description = "Turn for admin",
                        FromTime = TimeOnly.FromDateTime(DateTime.Now),
                        ToTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(1))
                    };
                    context.Set<Turn>().Add(turn);
                    var area = new Area{
                        Name = "Admin area",
                        Description = "Area for admin",
                        CreatedAt = DateTime.Now,
                        UpdatedAt = null
                    };
                    context.Set<Area>().Add(area);
                    var profile = new Profile{
                        User = user,
                        Enterprice = enterprise,
                        SalaryHour = 0,
                        LeaderId = null,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = null,
                        TurnId = turn.Id,
                        AreaId = area.Id
                    };
                    context.Set<Profile>().Add(profile);
                    var permision = new Permission{
                        Role = rol,
                        Profile = profile,
                        CreateUser = true,
                        ReadUser = true,
                        UpdateUser = true,
                        DeleteUser = true,
                        CreateRoles = true,
                        ReadRoles = true,
                        UpdateRoles = true,
                        DeleteRoles = true,
                        CreateEnterprises = true,
                        ReadEnterprises = true,
                        UpdateEnterprises = true,
                        DeleteEnterprises = true,
                        CreateTurn = true,
                        ReadTurn = true,
                        UpdateTurn = true,
                        DeleteTurn = true,
                        CreateAreas = true,
                        ReadAreas = true,
                        UpdateAreas = true,
                        DeleteAreas = true,
                        CreateMachines = true,
                        ReadMachines = true,
                        UpdateMachines = true,
                        DeleteMachines = true,
                        CreateProducts = true,
                        ReadProducts = true,
                        UpdateProducts = true,
                        DeleteProducts = true,
                        CreateProcesses = true,
                        ReadProcesses = true,
                        UpdateProcesses = true,
                        DeleteProcesses = true,
                        CreateBom = true,
                        ReadBom = true,
                        UpdateBom = true,
                        DeleteBom = true,
                        CreateProviders = true,
                        ReadProviders = true,
                        UpdateProviders = true,
                        DeleteProviders = true,
                        CreateContacts = true,
                        ReadContacts = true,
                        UpdateContacts = true,
                        DeleteContacts = true,
                        CreateServices = true,
                        ReadServices = true,
                        UpdateServices = true,
                        DeleteServices = true,
                        CreateOdp = true,
                        ReadOdp = true,
                        UpdateOdp = true,
                        DeleteOdp = true,
                        CreateReportOdp = true,
                        ReadReportOdp = true,
                        UpdateReportOdp = true,
                        DeleteReportOdp = true,
                        CreateDpnc = true,
                        ReadDpnc = true,
                        UpdateDpnc = true,
                        DeleteDpnc = true,
                        CreateSolutionDpnc = true,
                        ReadSolutionDpnc = true,
                        UpdateSolutionDpnc = true,
                        DeleteSolutionDpnc = true,
                        CreateSchedule = true,
                        ReadSchedule = true,
                        UpdateSchedule = true,
                        DeleteSchedule = true,
                        CreateOc = true,
                        ReadOc = true,
                        UpdateOc = true,
                        DeleteOc = true,
                        CreateOs = true,
                        ReadOs = true,
                        UpdateOs = true,
                        DeleteOs = true,
                        CreatePayments = true,
                        ReadPayments = true,
                        UpdatePayments = true,
                        DeletePayments = true,
                        ReadReports = true,
                        GeneratedReports = true,
                        ReadReception = true,
                        UpdateReception = true,
                        DeleteReception = true,
                        CreateReception = true,
                    };
                    context.Set<Permission>().Add(permision);
                    await context.SaveChangesAsync(cancellationToken);
                }
        });
});
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    // Add OpenAPI 3.0 document serving middleware
    // Available at: http://localhost:<port>/swagger/v1/swagger.json
    app.UseOpenApi();

    // Add web UIs to interact with the document
    // Available at: http://localhost:<port>/swagger
    app.UseSwaggerUi(); // UseSwaggerUI Protected by if (env.IsDevelopment())
}
app.UseHttpsRedirection();
app.UseCors("reforgedPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
