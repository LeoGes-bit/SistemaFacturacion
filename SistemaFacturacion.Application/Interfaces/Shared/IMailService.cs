using SistemaFacturacion.Application.DTOs.Mail;
using System.Threading.Tasks;

namespace SistemaFacturacion.Application.Interfaces.Shared
{
    public interface IMailService
    {
        Task SendAsync(MailRequest request);
    }
}