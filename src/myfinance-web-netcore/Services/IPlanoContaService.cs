using System.Collections.Generic;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services
{
    public interface IPlanoContaService
    {
        IEnumerable<PlanoContaModel> ListarPlanosConta();
        void Salvar(PlanoContaModel model);
        PlanoContaModel RetornarRegistro(int id);
        void Excluir(int id);
    }
}