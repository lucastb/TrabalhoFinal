using PL.Model.POCO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace EstacionamentoWebApp.BLL
{
    public class Facade
    {
        InteracaoEstacionamentoComCFG intCfg;
        InteracaoUsuarioEstacionamento intUser;
        CalculadorDePrecos calcP;
        Cancela cancela;
        CancelaSaida cancSaida;
        BarCodeGeneratorTM bcg;
        Guiche guiche;
        GeradorDeDataTM clock;

        public Facade()
        {
            intCfg = new InteracaoEstacionamentoComCFG();
            intUser = new InteracaoUsuarioEstacionamento();
            calcP = new CalculadorDePrecos();
            cancela = new Cancela();
            cancSaida = new CancelaSaida();
            bcg = new BarCodeGeneratorTM();
            clock = new GeradorDeDataTM();
            guiche = new Guiche();
        }

        //1 - Número de vagas disponíveis. Como o estacionamento possui um número máximo de vagas, o sistema
        //deve ser capaz de informar o número atual de vagas livres
        public int nDeVagasDisponiveis()
        {
            return intCfg.getVagasDisponiveis();
        }

        //2 - Consulta do valor a ser pago pelo ticket do estacionamento. Com base no número de identificação, o
        //sistema deve fornecer o valor atual a ser pago para a liberação do ticket de estacionamento.
        public double precoPagar(string cod)
        {
            return calcP.calculaPreco(cod);
            
        }

        //3 - Cancela
        //Emissão de ticket de estacionamento, contendo um código (passível de transformação para código de
        //barras ou qr-code), data e horário de entrada do automóvel.
        public string cancelaEmiteTicket()
        {
          return cancela.emiteTicket();
        }

        //4 - cancela de saida
        //        O sistema deve permitir os seguintes casos de uso por parte da cancela de saída(o sistema permite dois modos de
        //funcionamento):
        // Validação de ticket para liberação da cancela.O sistema deve receber o número do ticket e verificar se o
        //mesmo está liberado a fim da cancela ser aberta.
        //Liberação de todos os tickets. Em casos determinados pela gerência do estabelecimento (emergências ou
        //eventos especiais, por exemplo), a cancela é liberada de forma independente do status do ticket.Neste
        //caso, o sistema deve armazenar a informação do motivo de liberação do ticket(os possíveis motivos são
        //pré-definidos).

        public int validarTicketParaSaida(string cod)
        {
            var resultadoValidacao = cancSaida.liberaSaida(cod);
            return resultadoValidacao;
        }

        //5- O sistema deve permitir os seguintes casos de uso por parte do operador do caixa de cobrança:
        //// Emissão de ticket de estacionamento, contendo um código(passível de transformação para código de
        ////barras ou qr-code), data e horário de emissão.A emissão de ticket diretamente no guichê de pagamento
        ////(caso em que o ticket original foi extraviado, ou outro motivo qualquer considerado relevante pela gerência
        ////do centro comercial) utiliza sempre um código especial como identificador(o valor real do código é pré-
        ////definido no sistema).
        public string guicheEmiteTicket(Boolean extravio)
        {
            //se for extraviado recebe codigo de extravio, se n recebe cod especial por outro motivo relevante ao funcionario
            var res = guiche.emiteTicketCasoExtravio(extravio);
            return res;
        }
       
        public void ativaMotivoFacade(string motivo)
        {
            guiche.ativaMotivo(motivo);   
        }

        public void desativaTodos()
        {
            guiche.desativaMotivos();
        }

//      6 -  Liberação de ticket com pagamento.Após o recebimento do valor devido, o funcionário do guichê solicita ao
//        sistema a liberação do ticket.
        public void pagaTicket(string cod)
        {
            guiche.liberaTicketPorPagamento(cod);

        }

        //7 - Liberação de ticket sem pagamento.Em alguns casos especiais, o funcionário do guichê pode liberar
        //diretamente o ticket, sem o pagamento ter sido efetuado.Neste caso, o sistema deve armazenar a
        //informação do motivo de liberação do ticket.Os possíveis motivos são pré-definidos e contêm pelos menos
        //a opção “outros” para indicar casos não previstos.
        public void liberaSemPagar(string codigo, string motivo)
        {
            guiche.liberaSPagamento(codigo, motivo);
        }


        public string geraCodigoDeBarrasTM(System.Drawing.Image img)
        {
            var byteImagem = bcg.turnImageToByteArray(img);
            var imagemString = bcg.turByteEmString64TM(byteImagem);
            return imagemString;
        }

        public Estacionamento geTicket(string cod)
        {
            var ticket = intUser.getVagaPeloTicket(cod);
            return ticket;
        }

        public Boolean codExiste(string cod)
        {
            return intCfg.codExiste(cod);
        }

        public IEnumerable<Estacionamento> getListaDeTickets()
        {
            return intCfg.getListaDeEstacionamentos();
        }

        public IEnumerable<Estacionamento> getEstatacionamentosCSaida()
        {
            return intCfg.getEstacionamentosQueTemSaida();
        }

        public IEnumerable<Mes> getMeses()
        {
            return clock.meses();
        }

        public int mes(DateTime? ticket)
        {
            return clock.getMes(ticket);
                }

        public int NumeroMesPeloNome(string n)
        {
            return clock.getnMesPorNomeMes(n);
        }

        //public int dia(DateTime dt)
        //{
        //    return clock.getDia(dt);
        //}


    }
}