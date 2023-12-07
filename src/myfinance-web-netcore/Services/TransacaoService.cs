using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using myfinance_web_netcore.Domain;
using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Services
{
    public class TransacaoService : ITransacaoService
    {
        private readonly MyFinanceDbContext _myFinanceDbContext;
        private readonly IMapper _mapper;

        public TransacaoService(MyFinanceDbContext myFinanceDbContext, IMapper mapper)
        {
            _myFinanceDbContext = myFinanceDbContext;
            _mapper = mapper;
        }

        public IEnumerable<TransacaoModel> ListarTransacoes()
        {
            var lista = _myFinanceDbContext.Transacao.ToList();
            return _mapper.Map<IEnumerable<TransacaoModel>>(lista);
        }

        public void Salvar(TransacaoModel model)
        {
            var entidade = new Transacao()
            {
                Id = model.Id,
                Historico = model.Historico,
                Tipo = model.Tipo,
                Valor = model.Valor,
                PlanoContaId = model.PlanoContaId,
                Data = model.Data
            };

            if (entidade.Id == null)
                _myFinanceDbContext.Transacao.Add(entidade);
            else
            {
                _myFinanceDbContext.Transacao.Attach(entidade);
                _myFinanceDbContext.Entry(entidade).State = EntityState.Modified;
            }

            _myFinanceDbContext.SaveChanges();
        }

        public TransacaoModel RetornarRegistro(int id)
        {
            var registro = _myFinanceDbContext.Transacao.Where(x => x.Id == id).FirstOrDefault();
            return _mapper.Map<TransacaoModel>(registro);
        }

        public void Excluir(int id)
        {
            var registro = _myFinanceDbContext.Transacao.Where(x => x.Id == id).FirstOrDefault();

            _myFinanceDbContext.Transacao.Attach(registro);
            _myFinanceDbContext.Transacao.Remove(registro);
            _myFinanceDbContext.SaveChanges();
        }
    }
}