
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var connectionString =
    builder.Configuration.GetConnectionString("Postgres")
    ?? throw new InvalidOperationException(
        "Chua cau hinh ket noi PostgreSQL"
    );

builder.Services.AddSingleton(
    NpgsqlDataSource.Create(connectionString)
);

var app = builder.Build();

// API xem số vé hiện tại
app.MapGet("/stock", async (NpgsqlDataSource db) =>
{
    await using var conn = await db.OpenConnectionAsync();

    await using var cmd = new NpgsqlCommand(
        "SELECT total, sold FROM ticket_inventory WHERE id = 1",
        conn
    );

    await using var reader = await cmd.ExecuteReaderAsync();

    if (!await reader.ReadAsync())
        return Results.NotFound();

    int total = reader.GetInt32(0);
    int sold = reader.GetInt32(1);

    return Results.Ok(new
    {
        total,
        sold,
        remaining = total - sold
    });
});

// API đặt vé - CỐ Ý CÓ RACE CONDITION
app.MapPost("/bookings", async (NpgsqlDataSource db) =>
{
    int total;
    int sold;

    // BƯỚC 1: Đọc số vé từ database
    await using (var conn = await db.OpenConnectionAsync())
    {
        await using var cmd = new NpgsqlCommand(
            "SELECT total, sold FROM ticket_inventory WHERE id = 1",
            conn
        );

        await using var reader = await cmd.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return Results.NotFound();

        total = reader.GetInt32(0);
        sold = reader.GetInt32(1);
    }

    // BƯỚC 2: Kiểm tra số vé còn lại
    if (sold >= total)
    {
        return Results.Conflict(new
        {
            status = "SOLD_OUT",
            message = "Da het ve"
        });
    }

    // CỐ Ý tạo độ trễ để dễ quan sát lỗi
    await Task.Delay(2000);

    // BƯỚC 3: Cập nhật số vé bằng câu lệnh riêng
    // Không kiểm tra lại điều kiện sold < total
    await using (var conn = await db.OpenConnectionAsync())
    {
        await using var cmd = new NpgsqlCommand(
            "UPDATE ticket_inventory SET sold = sold + 1 WHERE id = 1",
            conn
        );

        await cmd.ExecuteNonQueryAsync();
    }

    return Results.Created("/bookings", new
    {
        status = "SUCCESS",
        message = "Dat ve thanh cong"
    });
});

app.Run();
