using Npgsql;
using NpgsqlTypes;

namespace YourPet.Data.Postgres.Extensions
{
    public static class Extensions
    {
        public static NpgsqlParameter AddTyped<T>(this NpgsqlParameterCollection parameters, string name, T value, NpgsqlDbType? type = null)
        {
            var p = new NpgsqlParameter<T>(name, value);
            if (type != null)
                p.NpgsqlDbType = type.Value;

            return parameters.Add(p);
        }

        public static T GetSafe<T>(this NpgsqlDataReader reader, string fieldName, T defaultValue = default)
        {
            var fieldPosition = reader.GetOrdinal(fieldName);
            return reader.IsDBNull(fieldPosition) ? defaultValue : reader.GetFieldValue<T>(fieldPosition);
        }
    }
}
