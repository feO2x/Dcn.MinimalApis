using Dcn.MinimalApis.DataAccess.Model;
using LinqToDB.Mapping;
using Synnotech.Migrations.Linq2Db.Int64TimestampVersions;

namespace Dcn.MinimalApis.DataAccess;

public static class Mappings
{
    public static MappingSchema CreateMappings()
    {
        var mappingSchema = new MappingSchema();
        var builder = mappingSchema.GetFluentMappingBuilder();
        builder.MapMigrationInfo();

#nullable disable
        builder.Entity<Contact>()
               .HasTableName("Contacts")
               .Property(c => c.Id).IsPrimaryKey().IsIdentity()
               .Association(c => c.Address, c => c.Id, a => a.ContactId);

        builder.Entity<Address>()
               .HasTableName("Addresses")
               .Property(a => a.Id).IsPrimaryKey().IsIdentity()
               .Association(a => a.Contact, a => a.ContactId, c => c.Id, false);
#nullable restore

        return mappingSchema;
    }
}