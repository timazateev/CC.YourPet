using Npgsql;
using System.Data;
using YourPet.Data.Postgres.Extensions;

namespace YourPet.Data.Postgres.DataAdapters
{
	public abstract class DataAdapterBase
	{
		private readonly string? _connectionString;
		private NpgsqlConnection? _connection;
        private CommandBehavior _commandBehavior = CommandBehavior.Default;

        protected DataAdapterBase(string connectionString)
		{
			_connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
		}

        protected DataAdapterBase(NpgsqlConnection connection)
        {
			_connection = connection;
        }
		
        protected NpgsqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
					_connection = new NpgsqlConnection(_connectionString);
					_commandBehavior = CommandBehavior.CloseConnection;
                }
				return _connection;
            }
        }

        protected async Task<NpgsqlCommand> CreateCommandAsync(string sqlCommand)
        {
			if (Connection.State != ConnectionState.Open)
				await Connection.OpenAsync();

			return new NpgsqlCommand(sqlCommand, Connection);
        }

        protected async Task<T> ExecuteReaderAsync<T>(
			string sqlCommand,
			Func<NpgsqlDataReader, T> entityReader,
			Action<NpgsqlParameterCollection>? addParametersAction)
		{
			await using var command = await CreateCommandAsync(sqlCommand);
            addParametersAction?.Invoke(command.Parameters);
            await using var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleRow | _commandBehavior);

            if (await reader.ReadAsync())
			{
				var result = entityReader(reader);
				return result;
			}

            throw new InvalidOperationException("Expected data not returned.");
        }

		protected async Task<IEnumerable<T>> GetEntitiesAsync<T>(
			string sqlCommand,
			Func<NpgsqlDataReader, T> entityReader,
			Action<NpgsqlParameterCollection>? addParametersAction = null)
		{
			var entities = new List<T>();

			await using var command = await CreateCommandAsync(sqlCommand);
            addParametersAction?.Invoke(command.Parameters);
            await using var reader = await command.ExecuteReaderAsync(_commandBehavior);

            while (await reader.ReadAsync())
			{
				var entity = entityReader(reader);
				entities.Add(entity);
			}
			
			return entities;
		}

        protected async Task DeleteAsync(string storedProcedureName, int id)
        {
            NpgsqlCommand? command = null;
            try
            {
                command = await CreateCommandAsync(storedProcedureName);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddTyped("_id", id);
                command.ExecuteNonQuery();
            }
            finally
            {
                if (_commandBehavior == CommandBehavior.CloseConnection)
                {
                    command?.Connection?.Close();
                }
            }
        }
	}
}