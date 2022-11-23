﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace B_U1_W1_D3_Esercizio
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool controlAperturaConto = false;
            int numeroAccessoConto = 0;
            List<int> listaScelta = new List<int>();
            ContoCorrente contoCorrente = new ContoCorrente();
            DettagliConto dettagliConto = new DettagliConto();
            dettagliConto.Cliente = new IntestatarioConto();

            int scelta = AzioniSportelloCC();

            if(scelta == 1)
            {
                numeroAccessoConto += 1;
            
                contoCorrente.CheckAperturaConto(controlAperturaConto);

          

                dettagliConto.NumeroConto = 22571152;
                dettagliConto.SaldoCorrente = 0;

              

                Console.WriteLine("\nInserisci il nome");
                dettagliConto.Cliente.Nome = Console.ReadLine();

                Console.WriteLine("\nInserisci il cognome");
                dettagliConto.Cliente.Cognome = Console.ReadLine();

                controlAperturaConto = true;
                
                Console.WriteLine($"Conto corrente nr. {dettagliConto.NumeroConto} intestato a: {dettagliConto.Cliente.Cognome} {dettagliConto.Cliente.Nome} aperto correttamente");


                dettagliConto.SaldoCorrente = contoCorrente.Versamento(controlAperturaConto);

                Console.WriteLine($"Nuovo saldo del CC odienro: {dettagliConto.SaldoCorrente} euro");

                scelta = AzioniSportelloCC();
            }
        
            if(scelta == 2)
            {
                dettagliConto.SaldoCorrente = contoCorrente.Versamento(numeroAccessoConto);
                Console.WriteLine($"Conto corrente nr. {dettagliConto.NumeroConto} intestato a: {dettagliConto.Cliente.Cognome} {dettagliConto.Cliente.Nome} aperto correttamente");
                Console.WriteLine($"Nuovo saldo del CC odienro: {dettagliConto.SaldoCorrente} euro");

                scelta = AzioniSportelloCC();
            }

            if(scelta == 3)
            {
                dettagliConto.SaldoCorrente -= contoCorrente.Prelevamento();
                Console.WriteLine($"Conto corrente nr. {dettagliConto.NumeroConto} intestato a: {dettagliConto.Cliente.Cognome} {dettagliConto.Cliente.Nome} aperto correttamente");
                Console.WriteLine($"Nuovo saldo del CC odienro: {dettagliConto.SaldoCorrente} euro");
                scelta = AzioniSportelloCC();
            }

            if (scelta == 4)
            {
                Console.WriteLine("Fine Operazioni Sportello Bank");
                Console.ReadLine(); 
            }

            if(scelta > 4)
            {
                Console.WriteLine("Operazione sbagliata, riprovare.");
                scelta = AzioniSportelloCC();
            }
        }

        static int AzioniSportelloCC()
        {
                Console.WriteLine("==========================");
                Console.WriteLine(" INTESA SAN STEFANO BANK");
                Console.WriteLine("==========================");
                Console.WriteLine("Scegli l'operazione da effettuare:");
                Console.WriteLine("1. APRI IL NUOVO CONTO CORRENTE");
                Console.WriteLine("2. EFFETTUA UN VERSAMENTO");
                Console.WriteLine("3. EFFETTUA UN PRELEVAMENTO");
                Console.WriteLine("4. ESCI");

               return int.Parse(Console.ReadLine());
    }

    public class ContoCorrente
        {
            public DettagliConto Conto { get; set; }
            public double Versamento(bool controlAperturaConto) {
                int versamento = 0;
                if (controlAperturaConto)
                {
                    Console.WriteLine("Devi necessariamente versare un tot di almeno 1000 euro");
                    Console.WriteLine("Scrivere in seguito l'importo indicato");
                    versamento = int.Parse(Console.ReadLine());

                    while (versamento < 1000)
                    {
                        Console.WriteLine("Importo del versamento non consentito o basso, riprovare:");
                        versamento = int.Parse(Console.ReadLine());
                    }
              
                    return versamento;

                } else
                {
                    Console.WriteLine("Inserisci l'importo del versamento da effettuare");
                    versamento = int.Parse(Console.ReadLine());
                    return versamento;
                }
            }

            public double Prelevamento(bool controlAperturaConto) {
                if (controlAperturaConto)
                {
                    double prelievo = 0;

                    Console.WriteLine("Inserisci l'importo del prelievo da effettuare");
                    prelievo = int.Parse(Console.ReadLine());
                    return prelievo;
                } else
                {
                    Console.WriteLine("Operazione di prelevamento non consentito, poiché non é stato apperto alcun conto corrente");
                    return 0;
                }
               
            }

            public void CheckAperturaConto(bool controlAperturaConto) {
                if (controlAperturaConto)
                {
                    Console.WriteLine("Non é possibile aprire piú di un conto corrente");
                }
            }

            public void MostraSaldoCorrente() { }
        }

        public class DettagliConto
        {
            public double NumeroConto { get; set; }
            public IntestatarioConto Cliente { get; set; }

            public double SaldoCorrente { get; set; }

        }

        public class IntestatarioConto
        {
            public string Nome { get; set; }
            public string Cognome { get; set; }
        }
    }
}