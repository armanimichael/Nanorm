﻿using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;

namespace Nanorm;

/// <summary>
/// Extension methods for <see cref="SqliteDataReader"/> from the <c>Nanorm.Sqlite</c> package.
/// </summary>
public static class SqliteDataReaderExtensions
{
#if NET8_0_OR_GREATER
    /// <summary>
    /// Maps a single row from the reader to a new instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create an instance of.</typeparam>
    /// <param name="reader">The <see cref="SqliteDataReader"/>.</param>
    /// <returns>An instance of <typeparamref name="T"/> if the reader contains rows, otherwise <c>default(<typeparamref name="T"/>)</c>.</returns>
    public static Task<T?> MapSingleAsync<T>(this SqliteDataReader reader)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(reader);

        return reader.MapSingleAsyncImpl<T>(default);
    }

    /// <summary>
    /// Maps a single row from the reader to a new instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create an instance of.</typeparam>
    /// <param name="reader">The <see cref="SqliteDataReader"/>.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>An instance of <typeparamref name="T"/> if the reader contains rows, otherwise <c>default(<typeparamref name="T"/>)</c>.</returns>
    public static Task<T?> MapSingleAsync<T>(this SqliteDataReader reader, CancellationToken cancellationToken)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(reader);

        return reader.MapSingleAsyncImpl<T>(cancellationToken);
    }
#endif

    /// <summary>
    /// Maps a single row from the reader to a new instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create an instance of.</typeparam>
    /// <param name="reader">The <see cref="SqliteDataReader"/>.</param>
    /// <param name="mapper">The mapping function.</param>
    /// <returns>An instance of <typeparamref name="T"/> if the reader contains rows, otherwise <c>default(<typeparamref name="T"/>)</c>.</returns>
    public static Task<T?> MapSingleAsync<T>(this SqliteDataReader reader, Func<SqliteDataReader, T> mapper)
    {
        ArgumentNullException.ThrowIfNull(reader);
        ArgumentNullException.ThrowIfNull(mapper);

        return reader.MapSingleAsyncImpl(mapper, default);
    }

    /// <summary>
    /// Maps a single row from the reader to a new instance of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create an instance of.</typeparam>
    /// <param name="reader">The <see cref="SqliteDataReader"/>.</param>
    /// <param name="mapper">The mapping function.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>An instance of <typeparamref name="T"/> if the reader contains rows, otherwise <c>default(<typeparamref name="T"/>)</c>.</returns>
    public static Task<T?> MapSingleAsync<T>(this SqliteDataReader reader, Func<SqliteDataReader, T> mapper, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(reader);
        ArgumentNullException.ThrowIfNull(mapper);

        return reader.MapSingleAsyncImpl(mapper, cancellationToken);
    }

#if NET8_0_OR_GREATER
    internal static async Task<T?> MapSingleAsyncImpl<T>(this SqliteDataReader reader, CancellationToken cancellationToken)
        where T : IDataRecordMapper<T>
    {
        if (!reader.HasRows)
        {
            return default;
        }

        await reader.ReadAsync(cancellationToken);

        return T.Map(reader);
    }
#endif

    internal static async Task<T?> MapSingleAsyncImpl<T>(this SqliteDataReader reader, Func<SqliteDataReader, T> mapper, CancellationToken cancellationToken)
    {
        if (!reader.HasRows)
        {
            return default;
        }

        await reader.ReadAsync(cancellationToken);

        return mapper(reader);
    }

#if NET8_0_OR_GREATER
    /// <summary>
    /// Maps all rows from the reader to new instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create instances of.</typeparam>
    /// <param name="reader">The <see cref="SqliteDataReader"/>.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/>.</returns>
    public static IAsyncEnumerable<T> MapAsync<T>(this SqliteDataReader reader)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(reader);

        return reader.MapAsyncImpl<T>(default);
    }

    /// <summary>
    /// Maps all rows from the reader to new instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create instances of.</typeparam>
    /// <param name="reader">The <see cref="SqliteDataReader"/>.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/>.</returns>
    public static IAsyncEnumerable<T> MapAsync<T>(this SqliteDataReader reader, CancellationToken cancellationToken)
        where T : IDataRecordMapper<T>
    {
        ArgumentNullException.ThrowIfNull(reader);

        return reader.MapAsyncImpl<T>(cancellationToken);
    }
#endif

    /// <summary>
    /// Maps all rows from the reader to new instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create instances of.</typeparam>
    /// <param name="reader">The <see cref="SqliteDataReader"/>.</param>
    /// <param name="mapper">The mapping function.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/>.</returns>
    public static IAsyncEnumerable<T> MapAsync<T>(this SqliteDataReader reader, Func<SqliteDataReader, T> mapper)
    {
        ArgumentNullException.ThrowIfNull(reader);
        ArgumentNullException.ThrowIfNull(mapper);

        return reader.MapAsyncImpl(mapper, default);
    }

    /// <summary>
    /// Maps all rows from the reader to new instances of <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to create instances of.</typeparam>
    /// <param name="reader">The <see cref="SqliteDataReader"/>.</param>
    /// <param name="mapper">The mapping function.</param>
    /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
    /// <returns>An <see cref="IAsyncEnumerable{T}"/>.</returns>
    public static IAsyncEnumerable<T> MapAsync<T>(this SqliteDataReader reader, Func<SqliteDataReader, T> mapper, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(reader);
        ArgumentNullException.ThrowIfNull(mapper);

        return reader.MapAsyncImpl(mapper, cancellationToken);
    }

#if NET8_0_OR_GREATER
    internal static async IAsyncEnumerable<T> MapAsyncImpl<T>(this SqliteDataReader reader, [EnumeratorCancellation] CancellationToken cancellationToken)
        where T : IDataRecordMapper<T>
    {
        if (!reader.HasRows)
        {
            yield break;
        }

        while (await reader.ReadAsync(cancellationToken))
        {
            yield return T.Map(reader);
        }
    }
#endif

    internal static async IAsyncEnumerable<T> MapAsyncImpl<T>(this SqliteDataReader reader, Func<SqliteDataReader, T> mapper, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (!reader.HasRows)
        {
            yield break;
        }

        while (await reader.ReadAsync(cancellationToken))
        {
            yield return mapper(reader);
        }
    }
}
