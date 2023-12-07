using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services
{
    public class PlanoContaService : IPlanoContaService
    {
        private readonly MyFinanceDbContext _myFinanceDbContext;
        private readonly IMapper _mapper;

        public PlanoContaService(MyFinanceDbContext myFinanceDbContext, IMapper mapper)
        {
            _myFinanceDbContext = myFinanceDbContext;
            _mapper = mapper;
        }

        public IEnumerable<PlanoContaModel> ListarPlanosConta()
        {
            var lista = _myFinanceDbContext.PlanoConta.ToList();
            return _mapper.Map<IEnumerable<PlanoContaModel>>(lista);
        }

        public void Salvar(PlanoContaModel model)
        {
            var entidade = new PlanoConta()
            {
                Id = model.Id,
                Descricao = model.Descricao,
                Tipo = model.Tipo
            };

            if (entidade.Id == null)
                _myFinanceDbContext.PlanoConta.Add(entidade);
            else
            {
                _myFinanceDbContext.PlanoConta.Attach(entidade);
                _myFinanceDbContext.Entry(entidade).State = EntityState.Modified;
            }

            _myFinanceDbContext.SaveChanges();
        }

        public PlanoContaModel RetornarRegistro(int id)
        {
            var registro = _myFinanceDbContext.PlanoConta.Where(x => x.Id == id).FirstOrDefault();
            return _mapper.Map<PlanoContaModel>(registro);
        }

        public void Excluir(int id)
        {
            var registro = _myFinanceDbContext.PlanoConta.Where(x => x.Id == id).FirstOrDefault();

            _myFinanceDbContext.PlanoConta.Attach(registro);
            _myFinanceDbContext.PlanoConta.Remove(registro);
            _myFinanceDbContext.SaveChanges();
        }
    }
}