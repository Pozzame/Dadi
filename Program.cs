using Spectre.Console;
public class Program
{
    public static void Main()
    {
        //Inizializzo variabili
        Random rng = new Random();
        string path = @"Punteggio.txt";
        int playerHuman = 100;
        int playerPC = 100;
        int launch = 0;
        int human = 0;
        int PC = 0;
        //

        Console.Clear();
        try
        {
            string[] punteggio = File.ReadAllLines(path);
            playerHuman = Convert.ToInt32(punteggio[0]);
            playerPC = Convert.ToInt32(punteggio[1]);
            launch = Convert.ToInt32(punteggio[2]);
            human = Convert.ToInt32(punteggio[3]);
            PC = Convert.ToInt32(punteggio[4]);
        }
        catch (Exception ex) when (ex is FormatException ||
                                    ex is IndexOutOfRangeException ||
                                    ex is OverflowException)
        {
            Console.WriteLine("Formato file errato. Rigenero...");
            File.Delete(path);
            File.WriteAllLines(path, [playerHuman.ToString(), playerPC.ToString(), launch.ToString(), human.ToString(), PC.ToString()]);
        }
        catch (Exception ex) when (ex is IOException ||
                                    ex is NotSupportedException ||
                                    ex is DirectoryNotFoundException)
        {
            Console.WriteLine("Problemi di accesso al file. Rigenero...");
            File.Delete(path);
            File.WriteAllLines(path, [playerHuman.ToString(), playerPC.ToString(), launch.ToString(), human.ToString(), PC.ToString()]);
        }
        catch (FileNotFoundException) //Creo file inizializzato a zero se non presente
        {
            File.WriteAllLines(path, [playerHuman.ToString(), playerPC.ToString(), launch.ToString(), human.ToString(), PC.ToString()]);
        }
        catch
        {
            Console.WriteLine("Errore non previsto. Rigenero...");
            File.Delete(path);
            File.WriteAllLines(path, [playerHuman.ToString(), playerPC.ToString(), launch.ToString(), human.ToString(), PC.ToString()]);
        }

        // Inizio gioco

        while (playerHuman > 0 && playerPC > 0) //Finchè un giocatore non vince
        {
            Console.WriteLine($"Launch number: {++launch}"); //Contatore turno

            //launch Human
            Console.WriteLine("Hit a key for launch the dices...");
            Console.ReadKey();
            int launch1Human = rng.Next(1, 7);
            int launch2Human = rng.Next(1, 7);
            int launchHuman = launch1Human + launch2Human;
            Console.Clear();
            Console.WriteLine($"Yuo have got: {launch1Human} e {launch2Human}");
            //

            //launch PC
            int launch1PC = rng.Next(1, 7);
            int launch2PC = rng.Next(1, 7);
            int launchPC = launch1PC + launch2PC;
            Console.WriteLine($"PC have got: {launch1PC} e {launch2PC}");
            //

            if (launchHuman < launchPC) //Se vince PC
            {
                Console.WriteLine("PC won!");
                playerHuman -= launchPC - launchHuman; //Aggiorno punteggio
            }
            else if (launchHuman > launchPC) //Se vince umano
            {
                Console.WriteLine("You won!");
                playerPC -= launchHuman - launchPC; //Aggiorno punteggio
            }
            else Console.WriteLine("Even!"); //Se pari

            File.WriteAllLines(path, [playerHuman.ToString(), playerPC.ToString(), launch.ToString(), human.ToString(), PC.ToString()]); // Salvo stato su file dopo ogni lancio

            AnsiConsole.Write(new BarChart() //Visualizza barre punteggio parziale
                .Width(60)
                .AddItem("Player points:", playerHuman, Color.Yellow)
                .AddItem("PC points:", playerPC, Color.Green));
            Console.WriteLine();
        }

        if (playerHuman < playerPC) //Visualizza punteggio finale
        {
            Console.WriteLine($"Hai perso!\nPC vince in {launch} lanci con un vantaggio di {playerPC - playerHuman} punti!");
            PC++;
        }
        else
        {
            Console.WriteLine($"Hai vinto in {launch} tiri con un vantaggio di {playerHuman - playerPC} punti!");
            human++;
        }

        File.WriteAllLines(path, ["100", "100", "0", human.ToString(), PC.ToString()]); //Resetto partita e salvo complessivo
        Console.WriteLine($"PC: {PC}\tUmano: {human}");
    }
}