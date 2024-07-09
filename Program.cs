using Spectre.Console;

int playerHuman = 100;
int playerPC = 100;
Random rng = new Random();
int launch = 0;

Console.Clear();
while (playerHuman > 0 && playerPC > 0)
{
    Console.WriteLine($"Launch number: {++launch}"); //Contatore turno

     //launch Human
    Console.WriteLine("Launch dice");
    Console.ReadKey();
    int launch1Human = rng.Next(1,7);
    int launch2Human = rng.Next(1,7);
    int launchHuman = launch1Human + launch2Human;
    Console.Clear();
    Console.WriteLine($"Yuo have got: {launch1Human} e {launch2Human}");
    //

    //launch PC
    int launch1PC = rng.Next(1,7); 
    int launch2PC = rng.Next(1,7);
    int launchPC = launch1PC + launch2PC;
    Console.WriteLine($"PC have got: {launch1PC} e {launch2PC}");
    //

    if (launchHuman < launchPC) //Se vince PC
    {
        Console.WriteLine("PC won!");
        playerHuman -= launchPC - launchHuman; //Aggiorno punteggio
    } 
    else if (launchHuman > launchPC) //Se vince Human
    {
        Console.WriteLine("You won!");
        playerPC -= launchHuman - launchPC; //Aggiorno punteggio
    }
    else Console.WriteLine("Even!"); //Se pari

/*
    Console.WriteLine($"Player points: {playerHuman}\nPC points: {playerPC}\n"); //Visualizza punteggio parziale
    Thread.Sleep(500);
*/
    AnsiConsole.Write(new BarChart()
    .Width(60)
    .AddItem("Player points:", playerHuman, Color.Yellow)
    .AddItem("PC points:", playerPC, Color.Green));
    Console.WriteLine();
}
if (playerHuman < playerPC ) //Visualizza punteggio finale
    Console.WriteLine($"You lost!\nPC win in {launch} lounches con un vantaggio di {playerPC-playerHuman} punti!");
    else Console.WriteLine($"Hai vinto in {launch} tiri con un vantaggio di {playerHuman-playerPC} punti!");