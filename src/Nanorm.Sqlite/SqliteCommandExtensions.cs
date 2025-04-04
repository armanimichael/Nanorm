﻿using System.Data;
using System.Data.Common;
using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;

namespace Nanorm;

/// <summary>
/// Extension methods for <see cref="SqliteCommand"/> from the <c>Nanorm.Sqlite</c> package.
/// </summary>
public static class SqliteCommandExtensions
{
    /// <summary>
    /// Executes a command with the <see cref="CommandBehavior.SingleResult"/> and <see cref="CommandBehavior.SingleRow"/> behaviors
    /// and returns the <see cref="SqliteDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="SqliteDataReader"/>.</returns>
    public static Task<SqliteDataReader> QuerySingleAsync(this SqliteCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        return QueryAsync(command, CommandBehavior.SingleResult | CommandBehavior.SingleRow);
    }

    /// <summary>
    /// Executes a command with the <see cref="CommandBehavior.SingleResult"/> and <see cref="CommandBehavior.SingleRow"/> behaviors
    /// and returns the <see cref="SqliteDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="SqliteDataReader"/>.</returns>
    public static Task<SqliteDataReader> QuerySingleAsync(this SqliteCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);
        return QueryAsync(command, CommandBehavior.SingleResult | CommandBehavior.SingleRow, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="SqliteDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="SqliteDataReader"/>.</returns>
    public static Task<SqliteDataReader> QueryAsync(this SqliteCommand command)
    {
        ArgumentNullException.ThrowIfNull(command);

        return QueryAsync(command, CommandBehavior.Default);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="SqliteDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="SqliteDataReader"/>.</returns>
    public static Task<SqliteDataReader> QueryAsync(this SqliteCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        return QueryAsync(command, CommandBehavior.Default, cancellationToken);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="SqliteDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="commandBehavior">The command behavior to use when executing the command.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="SqliteDataReader"/>.</returns>
    public static Task<SqliteDataReader> QueryAsync(this SqliteCommand command, CommandBehavior commandBehavior)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command.ExecuteReaderAsync(commandBehavior);
    }

    /// <summary>
    /// Executes a command and returns the <see cref="SqliteDataReader"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="commandBehavior">The command behavior to use when executing the command.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>A task representing the asynchronous operation with the <see cref="SqliteDataReader"/>.</returns>
    public static Task<SqliteDataReader> QueryAsync(this SqliteCommand command, CommandBehavior commandBehavior, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command.ExecuteReaderAsync(commandBehavior, cancellationToken);
    }

    /// <summary>
    /// Adds the specified parameters to the command's <see cref="SqliteParameterCollection"/>.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="parameters">
    /// Parameters to use when executing the command. Use the <see cref="SqliteParameterExtensions.AsDbParameter(object?, string?)"/>
    /// method to convert values into <see cref="SqliteParameter"/> instances, e.g. <c>myValue.AsDbParameter()</c>.
    /// </param>
    /// <returns>The command.</returns>
    public static SqliteCommand AddParameters(this SqliteCommand command, SqliteParameter[] parameters)
    {
        ArgumentNullException.ThrowIfNull(command);

        return command.AddParametersImpl(parameters);
    }

    /// <summary>
    /// Configures the command using the specified delegate.
    /// </summary>
    /// <param name="command">The command.</param>
    /// <param name="configureParameters">A delegate to configure the parameters.</param>
    /// <returns>The command.</returns>
    public static SqliteCommand Configure(this SqliteCommand command, Action<SqliteParameterCollection>? configureParameters = null)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (configureParameters is not null)
        {
            configureParameters(command.Parameters);
        }

        return command;
    }

    internal static SqliteCommand AddParametersImpl(this SqliteCommand command, SqliteParameter[] parameters)
    {
        if (parameters is null || parameters.Length == 0)
        {
            return command;
        }

        for (var i = 0; i < parameters.Length; i++)
        {
            command.Parameters.Add(parameters[i]);
        }

        return command;
    }

    internal static async Task<int> ExecuteNonQueryAsyncImpl(this SqliteCommand command, SqliteConnection connection, CancellationToken cancellationToken)
    {
        await connection.OpenAsync(cancellationToken);
        await using (command)
        {
            return await command.ExecuteNonQueryAsync(cancellationToken);
        }
    }

    internal static async Task<object?> ExecuteScalarAsync(this SqliteCommand command, SqliteConnection connection, CancellationToken cancellationToken)
    {
        await connection.OpenAsync(cancellationToken);
        await using (command)
        {
            return await command.ExecuteScalarAsync(cancellationToken);
        }
    }

    internal static async Task<SqliteDataReader> ExecuteReaderAsyncImpl(this SqliteCommand command, SqliteConnection connection, CommandBehavior commandBehavior, CancellationToken cancellationToken)
    {
        await connection.OpenAsync(cancellationToken);
        await using (command)
        {
            return await command.ExecuteReaderAsync(commandBehavior, cancellationToken);
        }
    }

#if NET8_0_OR_GREATER
    internal static async Task<T?> QuerySingleAsyncImpl<T>(this SqliteCommand command, SqliteConnection connection, CancellationToken cancellationToken)
        where T : IDataRecordMapper<T>
    {
        await connection.OpenAsync(cancellationToken);
        await using (command)
        {
            await using var reader = await command.ExecuteReaderAsync(CommandBehavior.SingleResult | CommandBehavior.SingleRow, cancellationToken);

            return await reader.MapSingleAsyncImpl<T>(cancellationToken);
        }
    }

    internal static async IAsyncEnumerable<T> QueryAsyncImpl<T>(this SqliteCommand command, SqliteConnection connection, [EnumeratorCancellation] CancellationToken cancellationToken)
        where T : IDataRecordMapper<T>
    {
        await connection.OpenAsync(cancellationToken);
        await using (command)
        {
            await using var reader = await command.ExecuteReaderAsync(cancellationToken);

            await foreach (var item in reader.MapAsyncImpl<T>(cancellationToken))
            {
                yield return item;
            }
        }
    }
#endif
}
