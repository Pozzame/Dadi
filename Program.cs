int playerUmano = 100;
int playerPC = 100;
Random rng = new Random();
int lanci = 0;

Console.Clear();
while (playerUmano >= 0 && playerPC >=0)
{
    Console.WriteLine($"Lancio numero: {++lanci}");
    int lancio1PUmano = rng.Next(1,7);
    int lancio2PUmano = rng.Next(1,7);
    Console.WriteLine("Premi invio per lanciare i dadi");
    Console.ReadLine();
    Console.Clear();
    Console.WriteLine($"Hai fatto: {lancio1PUmano} e {lancio2PUmano}");
    int lancioPUmano = lancio1PUmano + lancio2PUmano;
    int lancio1PPC = rng.Next(1,7);
    int lancio2PPC = rng.Next(1,7);
    Console.WriteLine($"Il PC ha fatto: {lancio1PPC} e {lancio2PPC}");
    int lancioPPC = lancio1PPC + lancio2PPC;
    if (lancioPUmano < lancioPPC)
    {
        Console.WriteLine("Il PC vince!");
        playerUmano -= lancioPPC - lancioPUmano;
    } 
    else if (lancioPUmano > lancioPPC)
    {
        Console.WriteLine("Hai vinto!");
        playerPC -= lancioPUmano - lancioPPC;
    }
    else Console.WriteLine("Pari!");
    Console.WriteLine($"Punteggio giocatore: {playerUmano}\nPunteggio PC: {playerPC}\n");
    Thread.Sleep(500);
}
if (playerUmano < playerPC )
    Console.WriteLine($"Hai perso!\nIl PC ha vinto in {lanci} tiri con un vantaggio di {playerPC-playerUmano} punti!");
    else Console.WriteLine($"Hai vinto in {lanci} tiri con un vantaggio di {playerUmano-playerPC} punti!");