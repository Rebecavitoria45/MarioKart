using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioKart
{
    public class Personagem
    {
        public string Nome {  get; set; }
        public int Velocidade { get; set; }
        public int Manobrabilidade { get; set; }
        public int Poder {  get; set; }
        public int Pontos { get; set; }

        public  Personagem(string nome, int velocidade, int manobrabilidade, int poder, int pontos)
        {
            Nome = nome;
            Velocidade = velocidade;
            Manobrabilidade = manobrabilidade;
            Poder = poder;
            Pontos = pontos;    
        }
    }
}
