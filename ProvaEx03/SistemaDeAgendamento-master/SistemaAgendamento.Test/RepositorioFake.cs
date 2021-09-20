using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SistemaAgendamento.Infrastructure;

namespace SistemaAgendamento.Test
{
    class RepositorioFake : IRepositorioSala
    {
        List<InclusaoDeAgendamento> lista = new List<InclusaoDeAgendamento>();

        public void IncluirTarefas(params AgendamentoModel[] agendamento)
        {
            throw new Exception("Houve um erro ao incluir as tarefas.");
            agendamento.ToList().ForEach(t => lista.Add(t));
        }

        public IEnumerable<AgendamentoModel> ObtemAgendamentos(Func<AgendamentoModel, bool> filtro)
        {
            return lista.Where(filtro);
        }

        public void AtualizarTarefas(params AgendamentoModel[] agendamento)
        {
            throw new NotImplementedException();
        }

        public void ExcluirTarefas(params AgendamentoModel[] agendamento)
        {
            throw new NotImplementedException();
        }

        public Categoria ObtemAgendamentoPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
