using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Moneda : IDinero
    {
        private float valor;

        public Moneda(float valor)
        {
            this.valor = valor;
        }

        public float GetValor()
        {
            return valor;
        }

        public void SetValor(float nuevoValor)
        {
            valor = nuevoValor;
        }

        public void Imprime()
        {
            Console.WriteLine($"Moneda de {valor} euros");
        }
    }
