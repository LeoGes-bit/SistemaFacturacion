﻿using SistemaFacturacion.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaFacturacion.Application.Interfaces.Repositories
{
    public interface ILogRepository
    {
        Task<List<AuditLogResponse>> GetAuditLogsAsync(string userId);

        Task AddLogAsync(string action, string userId);
    }
}