using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using BoxBack.Domain.Models;
using Dapper;

namespace BoxBack.Infra.Data.Context
{
    public static class DapperDbContext
    {
        public static async Task<IEnumerable<T>> QueryAsync<T>(
            this BoxAppDbContext context,
            CancellationToken ct,
            string text,
            object parameters = null,
            int? timeout = null,
            CommandType? type = null
        )
        {
            using var command = new DapperEFCoreCommand(
                context,
                text,
                parameters,
                timeout,
                type,
                ct
            );

            var connection = context.Database.GetDbConnection();
            return await connection.QueryAsync<T>(command.Definition);
        }

        public static T QueryFirst<T>(
            this BoxAppDbContext context,
            CancellationToken ct,
            string text,
            object parameters = null,
            int? timeout = null,
            CommandType? type = null
        )
        {
            using var command = new DapperEFCoreCommand(
                context,
                text,
                parameters,
                timeout,
                type,
                ct
            );

            var connection = context.Database.GetDbConnection();
            return connection.QueryFirstOrDefault<T>(command.Definition);
        }

        public static async Task<int> ExecuteAsync(
            this BoxAppDbContext context,
            CancellationToken ct,
            string text,
            object parameters = null,
            int? timeout = null,
            CommandType? type = null
        )
        {
            using var command = new DapperEFCoreCommand(
                context,
                text,
                parameters,
                timeout,
                type,
                ct
            );

            var connection = context.Database.GetDbConnection();
            return await connection.ExecuteAsync(command.Definition);
        }

        public static int Execute(
            this BoxAppDbContext context,
            CancellationToken ct,
            string text,
            object parameters = null,
            int? timeout = null,
            CommandType? type = null
        )
        {
            using var command = new DapperEFCoreCommand(
                context,
                text,
                parameters,
                timeout,
                type,
                ct
            );

            var connection = context.Database.GetDbConnection();
            return connection.Execute(command.Definition);
        }
    }

    public readonly struct DapperEFCoreCommand : IDisposable
    {
        private readonly ILogger<DapperEFCoreCommand> _logger;

        public DapperEFCoreCommand(
            BoxAppDbContext context,
            string text,
            object parameters,
            int? timeout,
            CommandType? type,
            CancellationToken ct
        )
        {
            _logger = context.GetService<ILogger<DapperEFCoreCommand>>();

            var transaction = context.Database.CurrentTransaction?.GetDbTransaction();
            var commandType = type ?? CommandType.Text;
            var commandTimeout = timeout ?? context.Database.GetCommandTimeout() ?? 30;

            Definition = new CommandDefinition(
                text,
                parameters,
                transaction,
                commandTimeout,
                commandType,
                cancellationToken: ct
            );

            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug(
                    @"Executing DbCommand [CommandType='{commandType}', CommandTimeout='{commandTimeout}']
                            {commandText}", Definition.CommandType, Definition.CommandTimeout, Definition.CommandText);
            }
        }

        public CommandDefinition Definition { get; }

        public void Dispose()
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(
                    @"Executed DbCommand [CommandType='{commandType}', CommandTimeout='{commandTimeout}']
                            {commandText}", Definition.CommandType, Definition.CommandTimeout, Definition.CommandText);
            }
        }
    }
}