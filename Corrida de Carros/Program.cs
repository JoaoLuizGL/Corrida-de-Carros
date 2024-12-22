char reiniciar;
do
{
    string[] nomes = new string[2];
    do
    {
        Console.Clear();
        Console.Write("Digite o nome do 1° carro: ");
        nomes[0] = Console.ReadLine();
        Console.Write("Digite o nome do 2° carro: ");
        nomes[1] = Console.ReadLine();
    } while (nomes[0].Length > 14 || nomes[1].Length > 14 || string.IsNullOrEmpty(nomes[0]) || string.IsNullOrEmpty(nomes[1]));

    string[] CriaCarro(int index)
    {
        string[] carro = { "_____________", "|__|__|__|__|__", "|", "|~~@~~~~~~~@~~~|" };
        carro[2] += nomes[index];
        for (int i = carro[2].Length + 1; i < 16; i++)
        {
            carro[2] += " ";
        }
        carro[2] += "|";
        return carro;
    }

    string[] Carro1 = CriaCarro(0);
    int LinhaDeChegada = 30, Distancia1 = 0, Distancia2 = 0;
    int[,] PassoCarro1 = new int[4, LinhaDeChegada];



    string[] Carro2 = CriaCarro(1);
    int[,] PassoCarro2 = new int[4, LinhaDeChegada];




    string rua = "";
    for (int i = 0; i < LinhaDeChegada + Carro1[3].Length - 1; i++)
    {
        rua += "-";
    }

    Random random = new Random();

    Console.Clear();
    Console.WriteLine("PRESSIONE ENTER PARA INICIAR A CORRIDA!");

    for (int i = 0; i < Carro1.Length; i++)
    {
        Console.WriteLine(Carro1[i]);
    }
    Console.WriteLine(rua);


    for (int i = 0; i < Carro2.Length; i++)
    {
        Console.WriteLine(Carro2[i]);
    }
    Console.WriteLine(rua);


    Console.ReadKey();
    while (Distancia1 < LinhaDeChegada && Distancia2 < LinhaDeChegada)
    {
        Console.Clear();

        Distancia1 += random.Next(1, 3);
        Distancia2 += random.Next(1, 3);

        Console.WriteLine();

        for (int i = 0; i < PassoCarro1.GetLength(0); i++)
        {
            for (int j = 0; j < Distancia1; j++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(Carro1[i]);
        }

        Console.WriteLine(rua);


        for (int i = 0; i < PassoCarro2.GetLength(0); i++)
        {
            for (int j = 0; j < Distancia2; j++)
            {
                Console.Write(" ");
            }
            Console.WriteLine(Carro2[i]);
        }

        Console.WriteLine(rua);


        Thread.Sleep(350);
    }

    if (Distancia1 > Distancia2)
        Console.WriteLine($"{nomes[0]} venceu a corrida!!!");
    if (Distancia1 < Distancia2)
        Console.WriteLine($"{nomes[1]} venceu a corrida!!!");
    if (Distancia1 == Distancia2)
        Console.WriteLine("A corrida acabou empatada!");


    Console.Write("Deseja começar outra corrida? (S/N)  ");
    reiniciar = char.Parse(Console.ReadLine());
}
while (reiniciar == 'S');

Console.ReadKey();