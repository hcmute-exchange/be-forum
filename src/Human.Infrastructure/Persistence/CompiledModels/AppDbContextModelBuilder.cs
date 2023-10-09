﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Human.Infrastructure.Persistence.CompiledModels
{
    public partial class AppDbContextModel
    {
        partial void Initialize()
        {
            var user = UserEntityType.Create(this);
            var userPasswordResetToken = UserPasswordResetTokenEntityType.Create(this);
            var userPermission = UserPermissionEntityType.Create(this);

            UserPasswordResetTokenEntityType.CreateForeignKey1(userPasswordResetToken, user);
            UserPermissionEntityType.CreateForeignKey1(userPermission, user);

            UserEntityType.CreateAnnotations(user);
            UserPasswordResetTokenEntityType.CreateAnnotations(userPasswordResetToken);
            UserPermissionEntityType.CreateAnnotations(userPermission);

            AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
            AddAnnotation("ProductVersion", "7.0.11");
            AddAnnotation("Relational:MaxIdentifierLength", 63);
        }
    }
}