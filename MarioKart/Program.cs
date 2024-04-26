using MarioKart;

string nomepersonagem = "";
int velocidade = 0;
int manobrabilidade = 0;
int poder = 0;
int pontos=0;
int rollDice()
{
 Random randNum = new Random();
 return randNum.Next(1, 7);
};

string getRandomBlock()
{
    Random randNum = new Random();
    int numBlock=  randNum.Next(1, 4);
    string result="";
    switch (numBlock)
    {
        case 1 :
          result = "RETA";
        break;
        
        case 2 :
         result = "CURVA";
        break;
         
        case 3 :
        result = "CONFRONTO";
        break;
      }
    return result;
}
void logRollResult(string characterName, string block,int diceResult, int attribute )
{
    Console.WriteLine($"{characterName} rolou um dado de {block} {diceResult} + {attribute} = {diceResult + attribute}");
}

void choiceCharacter(int numPersonagem)
{
    switch (numPersonagem)
    {
        case 1:
            nomepersonagem = "Mário";
            velocidade = 4;
            manobrabilidade = 3;
            poder = 3;
            pontos = 0;
            break;
        case 2:
            nomepersonagem = "Peach";
            velocidade = 3;
            manobrabilidade = 4;
            poder = 2;
            pontos = 0;
            break;
        case 3:
            nomepersonagem = "Yoshi";
            velocidade = 2;
            manobrabilidade = 4;
            poder = 3;
            pontos = 0;
            break;
        case 4:
            nomepersonagem = "Bowser";
            velocidade = 5;
            manobrabilidade = 2;
            poder = 5;
            pontos = 0;
            break;
        case 5:
            nomepersonagem = "Luigi";
            velocidade = 3;
            manobrabilidade = 4;
            poder = 4;
            pontos = 0;
            break;
        case 6:
            nomepersonagem = "Donkey Kong";
            velocidade = 2;
            manobrabilidade = 2;
            poder = 5;
            pontos = 0;
            break;
        default:
            Console.WriteLine("Personagem não identificado");
            break;

    }
}

void playRaceEngine(Personagem p1, Personagem p2)
{
    for(int round =1; round<=5; round++)
    {
        Console.WriteLine($"Rodada {round}");
         //sortear bloco
         string block = getRandomBlock();
         Console.WriteLine($"Bloco: {block}");
        //rolar dados
        int diceResult1= rollDice();
        int diceResult2= rollDice();
        //teste de habilidade
        int totalTestSkill1 = 0;
        int totalTestSkill2 = 0;

        if(block == "RETA")
        {
            totalTestSkill1 = diceResult1+p1.Velocidade;
            totalTestSkill2 = diceResult2+p2.Velocidade;
            logRollResult(p1.Nome, block, diceResult1, p1.Velocidade);
            logRollResult(p2.Nome, block, diceResult2, p2.Velocidade);
        }
        if(block == "CURVA")
        {
            totalTestSkill1 = diceResult1 + p1.Manobrabilidade;
            totalTestSkill2 = diceResult2 + p2.Manobrabilidade;
            logRollResult(p1.Nome, block, diceResult1, p1.Manobrabilidade);
            logRollResult(p2.Nome, block, diceResult2, p2.Manobrabilidade);
        }
        if (block == "CONFRONTO")
        {
          int powerResult1 = diceResult1 + p1.Poder;
          int powerResult2  = diceResult2 + p2.Poder;
            Console.WriteLine($"{p1.Nome} Confrontou com {p2.Nome} !");
            logRollResult(p1.Nome, block, diceResult1, p1.Poder);
            logRollResult(p2.Nome, block, diceResult2, p2.Poder);

            if( powerResult1 > powerResult2 && p2.Pontos>0 ) 
            { 
             Console.WriteLine($"{p1.Nome} venceu o confronto! {p2.Nome} perdeu um ponto");
            p2.Pontos--;
            }
            if (powerResult2 > powerResult1 && p1.Pontos > 0)
            {
                Console.WriteLine($"{p2.Nome} venceu o confronto! {p1.Nome} perdeu um ponto");
                p1.Pontos--;
            }
            else if(powerResult2==powerResult1)
            {
                Console.WriteLine("Confronto empatado! Nenhum ponto foi perdido.");
            }
        }
       
        //verificando vencedor
        if (totalTestSkill2 > totalTestSkill1)
        {
            Console.WriteLine($"{p2.Nome} Marcou um ponto !");
            p2.Pontos++;
        }
        else if(totalTestSkill1 > totalTestSkill2)
        {
            Console.WriteLine($"{p1.Nome} Marcou um ponto !");
            p1.Pontos++;
        }
        Console.WriteLine("_____________________");
    }
}

void declareWinner(Personagem p1, Personagem p2)
{
    Console.WriteLine("Resultado Final:");
    Console.WriteLine($"{p1.Nome}: {p1.Pontos} pontos");
    Console.WriteLine($"{p2.Nome}: {p2.Pontos} pontos");
    if (p1.Pontos > p2.Pontos)
    {
        Console.WriteLine("_____________________");
        Console.WriteLine($"{p1.Nome} venceu a corrida! Parabéns.");
    }
    else if(p2.Pontos > p1.Pontos)  
    {
        Console.WriteLine("_____________________");
        Console.WriteLine($"{p2.Nome} venceu a corrida! Parabéns."); 
    }
    else {
        Console.WriteLine("_____________________");
        Console.WriteLine("A corrida terminou em empate"); }
}


//Jogo
Console.WriteLine("Escolha o primeiro Personagem para a disputa");
Console.WriteLine("1-Mário");
Console.WriteLine("2-Peach");
Console.WriteLine("3-Yoshi");
Console.WriteLine("4-Bowser");
Console.WriteLine("5-Luigi");
Console.WriteLine("6-Donkey kong");
int personagem1 = Convert.ToInt32(Console.ReadLine());
choiceCharacter(personagem1);
Personagem player1 = new Personagem(nomepersonagem,velocidade, manobrabilidade, poder, pontos); 
Console.Clear();

Console.WriteLine("Escolha o segundo Personagem para a disputa");
Console.WriteLine("1-Mário");
Console.WriteLine("2-Peach");
Console.WriteLine("3-Yoshi");
Console.WriteLine("4-Bowser");
Console.WriteLine("5-Luigi");
Console.WriteLine("6-Donkey kong");
int personagem2 = Convert.ToInt32(Console.ReadLine());
choiceCharacter(personagem2);
Personagem player2 = new Personagem(nomepersonagem, velocidade, manobrabilidade, poder, pontos);
Console.Clear();

Console.WriteLine($"Corrida entre {player1.Nome} e {player2.Nome} começando...\n");
playRaceEngine(player1, player2);
declareWinner(player1, player2);