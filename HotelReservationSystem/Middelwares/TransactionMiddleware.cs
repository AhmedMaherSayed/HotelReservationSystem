﻿
using HotelReservationSystem.Data;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Microsoft.EntityFrameworkCore.Storage;

namespace HotelReservationSystem.Middelwares
{
    public class TransactionMiddleware(ApplicationDbContext context, ILogger logger) : IMiddleware
    {
        IDbContextTransaction transaction = null;
        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                if (httpContext.Request.Method != nameof(System.Net.Http.HttpMethod.Get))
                {
                    transaction = await context.Database.BeginTransactionAsync();

                    await next(httpContext);

                    await transaction.CommitAsync();
                }            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                transaction = null;
                logger.LogError($"{ex.InnerException?.Message ?? ex.Message}");
                throw;
            }
        }
    }
}
