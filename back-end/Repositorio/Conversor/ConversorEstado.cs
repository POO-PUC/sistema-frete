using Dominio.Objeto;
using DTO.DTOs;
using Repositorio.Validacoes;
using System;

namespace Repositorio.Conversor
{
    public static class ConversorEstado
    {
        public static DTOEstado ConverterParaDTO(Estado estado)
        {
            if (estado == null) return null;

            var dtoEstado = new DTOEstado();

            dtoEstado.Codigo = estado.Codigo;
            dtoEstado.ICMSExterno = estado.ICMSExterno;
            dtoEstado.ICMSLocal = estado.ICMSLocal;
            dtoEstado.Nome = estado.Nome;
            dtoEstado.Uf = estado.Uf;

            return dtoEstado;   
        }

        public static Estado ConverterParaDominio(DTOEstado dtoEstado)
        {
            if (dtoEstado == null) return null;

            var estado = new Estado();

            var validacaoEstado = new ValidacaoEstado();

            
                estado.Codigo = dtoEstado.Codigo;
                estado.ICMSExterno = dtoEstado.ICMSExterno;
                estado.ICMSLocal = dtoEstado.ICMSLocal;
                estado.Nome = dtoEstado.Nome;
                estado.Uf = dtoEstado.Uf;
            

            return estado;
        }
    }
}
