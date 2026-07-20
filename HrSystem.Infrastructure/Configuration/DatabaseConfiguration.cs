/*using HrSystem.Core.Enums;
using HrSystem.Core.Enums;
using CustomerForms.Core.Enums;
using HrSystem.Core.Interfaces.Repositories;
using HrSystem.Core.Interfaces.Repositories;
using HrSystem.Core.Interfaces.Services;
using HrSystem.Core.Interfaces.Services;
using HrSystem.Data;
using HrSystem.Data;
using HrSystem.Data.Entities;
using HrSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Data;
using System.Linq;
using System.Security;

namespace HrSystem.Infrastructure.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddEntityFrameworkSqlServer()
           .AddDbContextPool<APPContext>((serviceProvider, optionsBuilder) =>
           {
               optionsBuilder.UseSqlServer(connectionString);
               optionsBuilder.UseInternalServiceProvider(serviceProvider);
           });

        }
        public static IHost DbMigration(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var logger = scope.ServiceProvider.GetService<ILoggerService<IHost>>();
                try
                {
                    APPContext dbContext = scope.ServiceProvider.GetRequiredService<APPContext>();
                    dbContext.Database.Migrate();
                    SyncRoles(dbContext, logger);
                    SyncPermission(dbContext, logger);
                    //SyncFunctions(dbContext, logger);
                    //SyncLocations(dbContext, logger);
                    //InitializeSupperUser(scope);

                }
                catch (Exception ex)
                {
                    logger.LogError(ex);
                }
            }
            return host;
        }
        public static void InitializeSupperUser(IServiceScope scope)
        {
            var logger = scope.ServiceProvider.GetService<ILoggerService<IHost>>();
            try
            {
                IUserRepository userService = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                var p = userService.CreateDefaultUser().Result;

                if (p != null)
                    logger.LogInformation($"Super user registration failed");
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
            }
        }
        public static void SyncFunctions(APPContext dbContext, ILoggerService<IHost> loggerService)
        {
            try
            {
                string[] theFunctions = { "INDUSTRIAL", "PROCUREMENT", "FINANCE & IT", "SAFETY, HEALTH & ENVIRONMENT", "SECURITY", "AGGREGATES & CONCRETE", "LOGISTICS", "COMMUNICATIONS, PUBLIC AFFAIRS & SUSTAINABILITY DEVELOPMENT", "ORGANIZATION & HUMAN RESOURCES", "MORTAR, INNOVATION & NEW PRODUCTS DEVELOPMENT", "GEOCYCLE", "COMMERCIAL", "LEGAL", "CEO", "Order Fulfillment Team (OFT)", "LOGISTIC" };
                string[] functions = dbContext.Functions.Select(x => x.Name).ToArray();

                string[] result = theFunctions.Except(functions).ToArray();

                if (result.Length > 0)
                {
                    Function[] entities = result.Select(x => new Function
                    {
                        CreatedBy = "Application",
                        CreatedDate = DateTimeOffset.Now,
                        IsActive = true,
                        Name = x,
                        Description = x,
                        IsDeleted = false
                    }).ToArray();

                    dbContext.Functions.AddRange(entities);
                    dbContext.SaveChanges();


                }

            }
            catch (Exception ex)
            {
                loggerService.LogError(ex);
            }
        }
        public static void SyncLocations(APPContext dbContext, ILoggerService<IHost> loggerService)
        {
            try
            {
                string[] theLocations = { "IKOYI", "EWEKORO PLANT", "MFAMOSING PLANT", "Nkb Rmx Plant", "SAGAMU PLANT", "ASHAKA PLANT", "Ilorin Depot", "OGBA", "OPEBI", "AKURE", "Osogbo Depot", "Ijebu Ode Depot", "Abeokuta Depot", "VICTORIA ISLAND", "IBADAN", "IKORODU", "OWERRI", "GOMBE", "MUBI", "BAYELSA", "SIMAWA", "PORT HARCOURT", "LEKKI/AJAH", "ENUGU", "ABEOKUTA", "OREGUN", "ABAKALIKI", "GRAVITAS PLANT", "NKB PLANT", "Ewekoro Rmx Plant", "Idu Rmx Plant", "TRANS AMADI PLANT", "Maiduguri Depot", "Mubi Depot", "Kaduna Depot", "Gombe Depot", "Kano Depot", "Owerri 1 Depot", "Enugu Depot", "Abuja 2 Depot", "Aba Depot", "Ajah Depot", "Iseyin Oyo Depot", "Onitsha Depot", "MFAMOSING", "EWEKORO" };
                string[] locations = dbContext.Locations.Select(x => x.Name).ToArray();

                string[] result = theLocations.Except(locations).ToArray();

                if (result.Length > 0)
                {
                    Location[] entities = result.Select(x => new Location
                    {
                        CreatedBy = "Application",
                        CreatedDate = DateTimeOffset.Now,
                        IsActive = true,
                        Name = x,
                        Description = x,
                        IsDeleted = false
                    }).ToArray();

                    dbContext.Locations.AddRange(entities);
                    dbContext.SaveChanges();


                }

            }
            catch (Exception ex)
            {
                loggerService.LogError(ex);
            }
        }
        public static void SyncPermission(APPContext dbContext, ILoggerService<IHost> loggerService)
        {
            try
            {
                string[] perms = Enum.GetNames<PermissionEnum>();
                string[] permissions = dbContext.Permissions.Select(x => x.PermissionName).ToArray();

                string[] result = perms.Except(permissions).ToArray();

                if (result.Length > 0)
                {
                    Permission[] entities = result.Select(x => new Permission
                    {
                        CreatedBy = "Application",
                        CreatedDate = DateTimeOffset.Now,
                        IsActive = true,
                        PermissionDescription = x,
                        PermissionDisplayName = x,
                        PermissionName = x
                    }).ToArray();

                    dbContext.Permissions.AddRange(entities);
                    dbContext.SaveChanges();


                }

            }
            catch (Exception ex)
            {
                loggerService.LogError(ex);
            }
        }
        public static void SyncRoles(APPContext dbContext, ILoggerService<IHost> loggerService)
        {
            try
            {
                string[] theRoles = { "System Admin", "User" };
                string[] functions = dbContext.Roles.Select(x => x.RoleName).ToArray();

                string[] result = theRoles.Except(functions).ToArray();

                if (result.Length > 0)
                {
                    Role[] entities = result.Select(x => new Role
                    {
                        CreatedBy = "Application",
                        CreatedDate = DateTimeOffset.Now,
                        IsActive = true,
                        RoleName = x,
                        RoleDescription = x,
                        RoleNameHash = x,
                        IsDeleted = false
                    }).ToArray();

                    dbContext.Roles.AddRange(entities);
                    dbContext.SaveChanges();


                }

            }
            catch (Exception ex)
            {
                loggerService.LogError(ex);
            }
        }

    }
}*/