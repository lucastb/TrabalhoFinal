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

        public Facade()
        {
            intCfg = new InteracaoEstacionamentoComCFG();
            intUser = new InteracaoUsuarioEstacionamento();
            calcP = new CalculadorDePrecos();
            cancela = new Cancela();
            cancSaida = new CancelaSaida();
            bcg = new BarCodeGeneratorTM();
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
        public string validarTicketParaSaida(string cod)
        {
            var resultadoValidacao = cancSaida.liberaSaida(cod);

            switch (resultadoValidacao)
            {
                case 0:
                    return "Código inexistente";
                    
                case 1:
                    return "Cancela Aberta";

                case 2:
                    return "Cortesia!" + "\nCancela Aberta";

                case 3:
                    return "Ticket não pago... valor a pagar: " + calcP.calculaPreco(cod);

                case 4:
                    return "Erro!";
                    
            }
            return "Erro!";
        }

        //Liberação de todos os tickets. Em casos determinados pela gerência do estabelecimento (emergências ou
        //eventos especiais, por exemplo), a cancela é liberada de forma independente do status do ticket.Neste
        //caso, o sistema deve armazenar a informação do motivo de liberação do ticket(os possíveis motivos são
        //pré-definidos).

            //FAZER MELHOR KK
        public void liberacaoEmergencial(string cod, string motivo)
        {
            cancSaida.liberacaoEmergencial(motivo, cod);
        }
        
            public Boolean codExiste(string cod)
        {
            return intCfg.codExiste(cod);
        }

        //5- O sistema deve permitir os seguintes casos de uso por parte do operador do caixa de cobrança:
    //// Emissão de ticket de estacionamento, contendo um código(passível de transformação para código de
    ////barras ou qr-code), data e horário de emissão.A emissão de ticket diretamente no guichê de pagamento
    ////(caso em que o ticket original foi extraviado, ou outro motivo qualquer considerado relevante pela gerência
    ////do centro comercial) utiliza sempre um código especial como identificador(o valor real do código é pré-
    ////definido no sistema).

        //    public string guicheEmiteTicket()
        //{
        //   var res =  guiche.emitirTicket();

        //    if (res.Equals("lotado"))
        //    {

        //    }
        //}


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

    }
}