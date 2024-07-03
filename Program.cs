int playerUmano = 100;
int playerPC = 100;
Random rng = new Random();
int lanci = 0;

Console.Clear();
while (playerUmano > 0 && playerPC > 0)
{
    Console.WriteLine($"Lancio numero: {++lanci}"); //Contatore turno

     //Lancio umano
    Console.WriteLine("Lancia i dadi");
    Console.ReadKey();
    int lancio1Umano = rng.Next(1,7);
    int lancio2Umano = rng.Next(1,7);
    int lancioUmano =  + lancio2Umano;
    Console.Clear();
    Console.WriteLine($"Hai fatto: {lancio1Umano} e {lancio2Umano}");
    //

    //Lancio PC
    int lancio1PC = rng.Next(1,7); 
    int lancio2PC = rng.Next(1,7);
    int lancioPC = lancio1PC + lancio2PC;
    Console.WriteLine($"Il PC ha fatto: {lancio1PC} e {lancio2PC}");
    //

    if (lancioUmano < lancioPC) //Se vince PC
    {
        Console.WriteLine("Il PC vince!");
        playerUmano -= lancioPC - lancioUmano; //Aggiorno punteggio
    } 
    else if (lancioUmano > lancioPC) //Se vince umano
    {
        Console.WriteLine("Hai vinto!");
        playerPC -= lancioUmano - lancioPC; //Aggiorno punteggio
    }
    else Console.WriteLine("Pari!"); //Se pari

    Console.WriteLine($"Punteggio giocatore: {playerUmano}\nPunteggio PC: {playerPC}\n"); //Visualizza punteggio parziale
    Thread.Sleep(500);
}
if (playerUmano < playerPC ) //Visualizza punteggio finale
    Console.WriteLine($"Hai perso!\nIl PC ha vinto in {lanci} tiri con un vantaggio di {playerPC-playerUmano} punti!");
    else Console.WriteLine($"Hai vinto in {lanci} tiri con un vantaggio di {playerUmano-playerPC} punti!");