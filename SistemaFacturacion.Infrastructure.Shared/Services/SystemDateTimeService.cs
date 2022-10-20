using SistemaFacturacion.Application.Interfaces.Shared;
using System;

namespace SistemaFacturacion.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}