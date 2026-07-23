/*using HrSystem.Core.Interfaces.Services;
using HrSystem.Core.Models;
using HrSystem.Core.Interfaces.Repositories;
using HrSystem.Core.Interfaces.Services;
using HrSystem.Core.Managers;
//using CustomerForms.Core.Managers;
using HrSystem.Core.Models;
using HrSystem.Data;
using HrSystem.Data.Repositories;
//using CustomerForms.Data.Repositories;
using HrSystem.Infrastructure.Services;
using HrSystem.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace HrSystem.Infrastructure.Configuration
{
    public static class ServicesConfiguration
    {
        public static void AppServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();
            services.AddHttpClient<IHttpService>("http", c => { })
                .ConfigurePrimaryHttpMessageHandler(h =>
                {

                    var handler = new HttpClientHandler();
                    handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                    handler.ServerCertificateCustomValidationCallback = (httpRequestMessage, cert, cetChain, policyErrors) => { return true; };
                    return handler;
                });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //config
            //services.AddSingleton(configuration.GetSection("SuperAppUser").Get<AppUserDto>());
            services.AddSingleton(configuration.GetSection(nameof(AppUrl)).Get<AppUrl>());
            //services.AddSingleton(configuration.GetSection(nameof(MailConfiguration)).Get<MailConfiguration>());
            services.AddScoped<IDapperContext, DapperContext>();
            services.AddSingleton(configuration.GetSection(nameof(UtilityConfig)).Get<UtilityConfig>());

            //services
            //services.AddScoped(typeof(ILoggerService<>), typeof(LoggerService<>));
            services.AddSingleton<IHttpService, HttpService>();
            services.AddSingleton<IHttpContextService, HttpContextService>();
            services.AddScoped<IUtilityService, UtilityService>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<IJWTService, JWTService>();

            // services.AddScoped<ICsvService, CsvService>();

            //Manager
            //services.AddScoped<IUnitManager, UnitManager>();
            //services.AddScoped<IFunctionManager, FunctionManager>();
            //services.AddScoped<ILocationManager, LocationManager>();
            services.AddScoped<IRoleManager, RoleManager>();
            //services.AddScoped<IPermissionManager, PermissionManager>();
            //services.AddScoped<IRolePermissionManager, RolePermissionManager>();
            services.AddScoped<IUserRoleManager, UserRoleManager>();

            services.AddScoped<IAccountManager, AccountManager>();
            services.AddScoped<IUserManager, UserManager>();

            services.AddScoped<IEmailManager, EmailManager>();
            services.AddScoped<INGInterfaceDataManager, NGInterfaceDataManager>();
            //services.AddScoped<ICustomerInfoManager, CustomerInfoManager>();
            //services.AddScoped<ICompanyRepManager, CompanyRepManager>();
            //services.AddScoped<IBusinessInfoManager, BusinessInfoManager>();
           




            //Repository
            services.AddScoped<IFunctionRepository, FunctionRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IEmailLogRepository, EmailLogRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPasswordHistoryRepository, PasswordHistoryRepository>();
            services.AddScoped<ICustomerIdentificationRepository, CustomerIdentificationRepository>();

            // Address book repository
           // services.AddScoped<IAddressBookRepository, AddressBookRepository>();
            //services.AddScoped<IAddressBookManager, AddressBookManager>();

            services.AddScoped<ILoginAttemptLogRepository, LoginAttemptLogRepository>();
            services.AddScoped<IConfirmationTokenRepository, ConfirmationTokenRepository>();

            services.AddScoped<ILoginTokenRepository, LoginTokenRepository>();
            services.AddScoped<IservicesRepository, ServicesRepository>();
           

            //ProjectTracker




        }
        public static void SchedulerServicesConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddHostedService<VendorsUpdateJob>();

            // services.AddHostedService<PaymentProcessingJob>();

        }

    }
}*/
