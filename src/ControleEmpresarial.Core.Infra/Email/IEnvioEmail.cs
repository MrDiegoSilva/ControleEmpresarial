using System.Threading.Tasks;

namespace ControleEmpresarial.Core.Infra.Email
{
    public interface IEnvioEmail
    {
        Task EnviarAsync(string nome, string email, string assunto, string mensagem);
    }
}