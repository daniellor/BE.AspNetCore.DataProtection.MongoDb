using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;

namespace BE.AspNetCore.DataProtection.MongoDb;

public static class ConfigExtension
{
    public static IDataProtectionBuilder PersistKeysToMongoDb(this IDataProtectionBuilder builder,
        IMongoDatabase db, string collectionName)
    {
        ArgumentNullException.ThrowIfNull(builder);
        ArgumentNullException.ThrowIfNull(db);
        ArgumentNullException.ThrowIfNullOrWhiteSpace(collectionName);

        builder.Services.Configure<KeyManagementOptions>(options =>
        {
            options.XmlRepository = new MongoXmlRepository(db, collectionName);
        });

        return builder;
    }
}