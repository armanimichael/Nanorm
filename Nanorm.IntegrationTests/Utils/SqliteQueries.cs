﻿// <auto-generated/> DO NOT MANUALLY EDIT
#nullable enable
using Nanorm;
using Nanorm.IntegrationTests.Models;
using Microsoft.Data.Sqlite;

namespace Nanorm.IntegrationTests.Utils;

public static class SqliteQueries
{
    public static async Task<ByteOnlyModel?> CreateByteAsync(SqliteConnection conn, byte val) => 
        await conn.QuerySingleAsync<ByteOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_byte(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<ShortOnlyModel?> CreateShortAsync(SqliteConnection conn, short val) => 
        await conn.QuerySingleAsync<ShortOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_short(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<IntOnlyModel?> CreateIntAsync(SqliteConnection conn, int val) => 
        await conn.QuerySingleAsync<IntOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_int(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<LongOnlyModel?> CreateLongAsync(SqliteConnection conn, long val) => 
        await conn.QuerySingleAsync<LongOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_long(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<FloatOnlyModel?> CreateFloatAsync(SqliteConnection conn, float val) => 
        await conn.QuerySingleAsync<FloatOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_float(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<DoubleOnlyModel?> CreateDoubleAsync(SqliteConnection conn, double val) => 
        await conn.QuerySingleAsync<DoubleOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_double(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<DecimalOnlyModel?> CreateDecimalAsync(SqliteConnection conn, decimal val) => 
        await conn.QuerySingleAsync<DecimalOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_decimal(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<StringOnlyModel?> CreateStringAsync(SqliteConnection conn, string val) => 
        await conn.QuerySingleAsync<StringOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_string(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<BoolOnlyModel?> CreateBoolAsync(SqliteConnection conn, bool val) => 
        await conn.QuerySingleAsync<BoolOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_bool(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<GuidOnlyModel?> CreateGuidAsync(SqliteConnection conn, Guid val) => 
        await conn.QuerySingleAsync<GuidOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_Guid(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<CharOnlyModel?> CreateCharAsync(SqliteConnection conn, char val) => 
        await conn.QuerySingleAsync<CharOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_char(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<DateTimeOnlyModel?> CreateDateTimeAsync(SqliteConnection conn, DateTime val) => 
        await conn.QuerySingleAsync<DateTimeOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_DateTime(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<NullableByteOnlyModel?> CreateNullableByteAsync(SqliteConnection conn, byte? val) => 
        await conn.QuerySingleAsync<NullableByteOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_nullable_byte(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<NullableShortOnlyModel?> CreateNullableShortAsync(SqliteConnection conn, short? val) => 
        await conn.QuerySingleAsync<NullableShortOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_nullable_short(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<NullableIntOnlyModel?> CreateNullableIntAsync(SqliteConnection conn, int? val) => 
        await conn.QuerySingleAsync<NullableIntOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_nullable_int(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<NullableLongOnlyModel?> CreateNullableLongAsync(SqliteConnection conn, long? val) => 
        await conn.QuerySingleAsync<NullableLongOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_nullable_long(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<NullableFloatOnlyModel?> CreateNullableFloatAsync(SqliteConnection conn, float? val) => 
        await conn.QuerySingleAsync<NullableFloatOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_nullable_float(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<NullableDoubleOnlyModel?> CreateNullableDoubleAsync(SqliteConnection conn, double? val) => 
        await conn.QuerySingleAsync<NullableDoubleOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_nullable_double(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<NullableDecimalOnlyModel?> CreateNullableDecimalAsync(SqliteConnection conn, decimal? val) => 
        await conn.QuerySingleAsync<NullableDecimalOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_nullable_decimal(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<NullableStringOnlyModel?> CreateNullableStringAsync(SqliteConnection conn, string? val) => 
        await conn.QuerySingleAsync<NullableStringOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_nullable_string(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<NullableBoolOnlyModel?> CreateNullableBoolAsync(SqliteConnection conn, bool? val) => 
        await conn.QuerySingleAsync<NullableBoolOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_nullable_bool(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<NullableGuidOnlyModel?> CreateNullableGuidAsync(SqliteConnection conn, Guid? val) => 
        await conn.QuerySingleAsync<NullableGuidOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_nullable_Guid(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<NullableCharOnlyModel?> CreateNullableCharAsync(SqliteConnection conn, char? val) => 
        await conn.QuerySingleAsync<NullableCharOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_nullable_char(val)
             Values({val})
             RETURNING *
             """
    );
    public static async Task<NullableDateTimeOnlyModel?> CreateNullableDateTimeAsync(SqliteConnection conn, DateTime? val) => 
        await conn.QuerySingleAsync<NullableDateTimeOnlyModel>(
            //lang=text - Ignore
            $"""
             INSERT INTO validate_nullable_DateTime(val)
             Values({val})
             RETURNING *
             """
    );
}
