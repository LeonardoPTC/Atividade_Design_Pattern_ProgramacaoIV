using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umfgcloud.loja.dominio.service.Entidades;
using umfgcloud.loja.dominio.service.Interfaces.Builders;

namespace umfgcloud.loja.aplicacao.service.Builders
{
    public sealed class NovoProdutoBuilder : IProdutoBuilder
    {
        private readonly string _userId;
        private readonly string _userEmail;

        private string _descricao = string.Empty;
        private string _ean = string.Empty;
        private decimal _valorCompra = decimal.Zero;
        private decimal _valorVenda = decimal.Zero;

        public NovoProdutoBuilder(string userId, string userEmail)
        {
            _userId = userId ?? throw new ArgumentNullException(nameof(userId));
            _userEmail = userEmail ?? throw new ArgumentNullException(nameof(userEmail));
        }

        public IProdutoBuilder SetDescricao(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("Descrição é obrigatória");

            _descricao = descricao;
            return this;
        }

        public IProdutoBuilder SetEAN(string ean)
        {
            if (string.IsNullOrWhiteSpace(ean))
                throw new ArgumentException("EAN é obrigatório");

            _ean = ean;
            return this;
        }

        public IProdutoBuilder SetValorCompra(decimal valorCompra)
        {
            if (valorCompra <= 0)
                throw new ArgumentException("Valor de compra deve ser maior que zero");

            _valorCompra = valorCompra;
            return this;
        }

        public IProdutoBuilder SetValorVenda(decimal valorVenda)
        {
            if (valorVenda <= 0)
                throw new ArgumentException("Valor de venda deve ser maior que zero");

            _valorVenda = valorVenda;
            return this;
        }

        public ProdutoEntity Build()
        {
            if (_valorVenda < _valorCompra)
                throw new InvalidOperationException("Valor de venda não pode ser menor que valor de compra");

            var produto = new ProdutoEntity(_userId, _userEmail);

            produto.SetDescricao(_descricao);
            produto.SetEAN(_ean);
            produto.SetValorCompra(_valorCompra);
            produto.SetValorVenda(_valorVenda);

            return produto;
        }
    }
}
