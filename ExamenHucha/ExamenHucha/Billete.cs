using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    class Billete : IDinero
    {
        private int valor;

        public Billete(int valor)
        {
            this.valor = valor;
        }

        public float GetValor()
        {
            return valor;
        }

        public void SetValor(float nuevoValor)
        {
            valor = (int)nuevoValor;
        }

        public void Imprime()
        {
            Console.WriteLine($"Billete de {valor} euros");
        }
    }   
