﻿using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xunit;
using SistemaAgendamento.Core.Commands;
using SistemaAgendamento.Infrastructure;
using SistemaDeAgendamento;
using SistemaAgendamento.Core.Models;


namespace SistemaAgendamento.Test
{
    public class InclusaoDeAgendamento
    {
        public void DataAgendamentoIncluirNoBD()
        {
            [Fact]
            public void DadaTarefaComInfoValida()
            {
                
                //arrange
                var comando = new CadastrarAgendamento("Estudar Xunit", new Categoria(100, "Estudo", "joana"), new DateTime(31, 12, 2019));

                var mock = new Mock<ILogger<CadastraTarefaHandler>>();

                var options = new DbContextOptionsBuilder<DbTarefasContext>()
                    .UseInMemoryDatabase("DbTarefasContext")
                    .Options;
                var contexto = new DbContext(options);
                var repo = new RepositorioAgendamento(contexto);

                var handler = new CadastraAgendamentoHandler(repo, mock.Object);

                //act
                handler.Execute(comando); //SUT >> CadastraTarefaHandlerExecute

                //assert
                var tarefa = repo.ObtemTarefas(t => t.Titulo == "Estudar Xunit").FirstOrDefault();
                Assert.NotNull(tarefa);
            }

            delegate void CapturaMensagemLog(LogLevel level, EventId eventId, object state, Exception exception, Func<object, Exception, string> function);

            [Fact]
            public void DadaTarefaComInfoValidasDeveLogar()
            {
                //arrange
                var tituloTarefaEsperado = "Usar Moq para aprofundar conhecimento de API";
                var comando = new CadastraTarefa(tituloTarefaEsperado, new Categoria(100, "Estudo"), new DateTime(2019, 12, 31));

                var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

                LogLevel levelCapturado = LogLevel.Error;
                string mensagemCapturada = string.Empty;

                CapturaMensagemLog captura = (level, eventId, state, exception, func) =>
                {
                    levelCapturado = level;
                    mensagemCapturada = func(state, exception);
                };

                mockLogger.Setup(l =>
                    l.Log(
                        It.IsAny<LogLevel>(), //nível de log => LogError
                        It.IsAny<EventId>(), //identificador do evento
                        It.IsAny<object>(), //objeto que será logado
                        It.IsAny<Exception>(),    //exceção que será logada
                        It.IsAny<Func<object, Exception, string>>() //função que converte objeto+exceção >> string)
                    )).Callback(captura);

                var mock = new Mock<IRepositorioTarefas>();

                var handler = new CadastraTarefaHandler(mock.Object, mockLogger.Object);

                //act
                handler.Execute(comando); //SUT >> CadastraTarefaHandlerExecute

                //assert
                Assert.Equal(LogLevel.Debug, levelCapturado);
                Assert.Contains(tituloTarefaEsperado, mensagemCapturada);
            }

            [Fact]
            public void QuandoExceptionForLancadaResultadoIsSuccessDeveSerFalse()
            {
                //arrange
                var comando = new CadastraTarefa("Estudar Xunit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

                var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

                var mock = new Mock<IRepositorioTarefas>();

                mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                    .Throws(new Exception("Houve um erro na inclusão de tarefas"));

                var repo = mock.Object;

                var handler = new CadastraTarefaHandler(repo, mockLogger.Object);

                //act
                CommandResult resultado = handler.Execute(comando);

                //assert
                Assert.False(resultado.IsSuccess);
            }

            [Fact]
            public void QuandoExceptionForLancadaMensagemDaExcecao()
            {
                //arrange
                var mensagemDeErroEsperada = "Houve um erro na inclusão de tarefas";
                var excecaoEsperada = new Exception(mensagemDeErroEsperada);

                var comando = new CadastraTarefa("Estudar Xunit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

                var mockLogger = new Mock<ILogger<CadastraTarefaHandler>>();

                var mock = new Mock<IRepositorioTarefas>();

                mock.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                    .Throws(excecaoEsperada);

                var repo = mock.Object;

                var handler = new CadastraAgendamentoHandler(repo, mockLogger.Object);

                //act
                CommandResult resultado = handler.Execute(comando);

                //assert
                mockLogger.Verify(l =>
                    l.Log(
                        LogLevel.Error, 
                        It.IsAny<EventId>(), 
                        It.IsAny<object>(), 
                        excecaoEsperada,    
                        It.IsAny<Func<object, Exception, string>>()
                    ), //função que converte objeto+exceção >> string
                    Times.Once());
            }
        }
    }
}
