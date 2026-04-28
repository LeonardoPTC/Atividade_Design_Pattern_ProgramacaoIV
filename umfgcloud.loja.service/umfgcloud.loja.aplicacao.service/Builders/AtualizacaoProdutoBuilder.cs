using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umfgcloud.loja.dominio.service.Entidades;
using umfgcloud.loja.dominio.service.Interfaces.Builders;

namespace umfgcloud.loja.aplicacao.service.Builders
{
    public sealed class AtualizacaoProdutoBuilder : IProdutoBuilder
    {
        private readonly ProdutoEntity _produto;
        private readonly string _userId;
        private readonly string _userEmail;

        private string _descricao = string.Empty;
        private string _ean = string.Empty;
        private decimal _valorCompra = decimal.Zero;
        private decimal _valorVenda = decimal.Zero;

        public AtualizacaoProdutoBuilder(ProdutoEntity produto, string userId, string userEmail)
        {
            _produto = produto ?? throw new ArgumentNullException(nameof(produto));
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

            _produto.SetDescricao(_descricao);
            _produto.SetEAN(_ean);
            _produto.SetValorCompra(_valorCompra);
            _produto.SetValorVenda(_valorVenda);
            _produto.Update(_userId, _userEmail);

            return _produto;
        }
    }
}
