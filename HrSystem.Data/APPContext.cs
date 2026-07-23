/*using HrSystem.Core.DTOs;
using HrSystem.Data.Entities;
using HrSystem.Data.Entities;
using HrSystem.Data.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Emit;
using System.Security;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
//using System.Runtime.Remoting.Contexts;

namespace HrSystem.Data
{
    public class APPContext : DbContext
    {
        public APPContext(DbContextOptions<APPContext> options)
       : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<Function> Functions { get; set; }
        //public DbSet<Unit> Units { get; set; }
        public DbSet<EmailLog> EmailLogs { get; set; }
        //public DbSet<Location> Locations { get; set; }
        public DbSet<LoginAttemptLog> LoginAttemptLogs { get; set; }

        //public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        //public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<PasswordHistory> PasswordHistories { get; set; }

        public DbSet<LoginToken> LoginTokens { get; set; }
       
        // public DbSet<Vendors> Vendors { get; set; }
       // public DbSet<VendorsCategory> VendorsCategories { get; set; }*/