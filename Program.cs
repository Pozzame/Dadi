int playerUmano = 100;
int playerPC = 100;
Random rng = new Random();
int lanci = 0;

Console.Clear();
while (playerUmano >= 0 && playerPC >=0)
{
    Console.WriteLine($"Lancio numero: {++lanci}"); //Contatore turno

     //Lancio umano
    Console.WriteLine("Lancia i dadi");
    Console.ReadKey();
    int lancio1PUmano = rng.Next(1,7);
    int lancio2PUmano = rng.Next(1,7);
    int lancioPUmano = lancio1PUmano + lancio2PUmano;
    Console.Clear();
    Console.WriteLine($"Hai fatto: {lancio1PUmano} e {lancio2PUmano}");
    //

    //Lancio PC
    int lancio1PPC = rng.Next(1,7); 
    int lancio2PPC = rng.Next(1,7);
    int lancioPPC = lancio1PPC + lancio2PPC;
    Console.WriteLine($"Il PC ha fatto: {lancio1PPC} e {lancio2PPC}");
    //

    if (lancioPUmano < lancioPPC) //Se vince PC
    {
        Console.WriteLine("Il PC vince!");
        playerUmano -= lancioPPC - lancioPUmano; //Aggiorno punteggio
    } 
    else if (lancioPUmano > lancioPPC) //Se vince umano
    {
        Console.WriteLine("Hai vinto!");
        playerPC -= lancioPUmano - lancioPPC; //Aggiorno punteggio
    }
    else Console.WriteLine("Pari!"); //Se pari

    Console.WriteLine($"Punteggio giocatore: {playerUmano}\nPunteggio PC: {playerPC}\n"); //Visualizza punteggio parziale
    Thread.Sleep(500);
}
if (playerUmano < playerPC ) //Visualizza punteggio finale
    Console.WriteLine($"Hai perso!\nIl PC ha vinto in {lanci} tiri con un vantaggio di {playerPC-playerUmano} punti!");
    else Console.WriteLine($"Hai vinto in {lanci} tiri con un vantaggio di {playerUmano-playerPC} punti!");