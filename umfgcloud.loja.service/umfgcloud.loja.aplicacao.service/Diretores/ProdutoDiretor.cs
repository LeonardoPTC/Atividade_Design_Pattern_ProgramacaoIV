using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using umfgcloud.loja.dominio.service.DTO;
using umfgcloud.loja.dominio.service.Entidades;
using umfgcloud.loja.dominio.service.Interfaces.Builders;

namespace umfgcloud.loja.aplicacao.service.Diretores
{
    public sealed class ProdutoDiretor
    {
        private IProdutoBuilder _builder;

        public ProdutoDiretor(IProdutoBuilder builder)
        {
            _builder = builder ?? throw new ArgumentNullException(nameof(builder));
        }

        public ProdutoEntity BuildProdutoRequest(ProdutoDTO.ProdutoRequest dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return _builder
                .SetDescricao(dto.Descricao)
                .SetEAN(dto.EAN)
                .SetValorCompra(dto.ValorCompra)
                .SetValorVenda(dto.ValorVenda)
                .Build();
        }

        public ProdutoEntity BuildProdutoRequestWithId(ProdutoDTO.AbstractProdutoWithIdDTO dto)
        {
            if (dto == null)
                throw new ArgumentNullException(nameof(dto));

            return _builder
                .SetDescricao(dto.Descricao)
                .SetEAN(dto.EAN)
                .SetValorCompra(dto.ValorCompra)
                .SetValorVenda(dto.ValorVenda)
                .Build();
        }
    }
}
