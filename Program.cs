using Newtonsoft.Json;
using Spectre.Console;
public class Program
{
    public static void Main()
    {
        Random rng = new Random();
        string path = @"Z:\MP\Punteggio.json";

        string player = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("-----Select player-----")
                .PageSize(3)
                .MoreChoicesText("[grey](Move up and down to select)[/]")
                .AddChoices(new[] {
            "1", "2", "Exit"}));
        
        if (player == "Exit") return;

        Console.Clear();

        dynamic json;
        int launchT = 0;
        do //Finchè un giocatore non vince
        {
            json = Leggo(path);
            if (json.player==player) Console.WriteLine("Waiting for other player...");
            while (json.player == player) 
            {
                
                json = Leggo(path);
                //Console.Clear();
            }
            json.launch = json.launch+1;
            json.player = player;
            Console.WriteLine($"Launch number: {json.launch}"); //Contatore turno

            //launch P1
            Console.WriteLine("Hit a key for launch the dices...");
            Console.ReadKey();
            int launch1 = rng.Next(1, 7);
            int launch2 = rng.Next(1, 7);
            launchT = launch1 + launch2;
            Console.Clear();
            Console.WriteLine($"Yuo have got: {launch1} e {launch2}");
            //

            int launchP2 = json.launchT;
            Console.WriteLine($"Other player last launch: {launchP2}");
            //

            if (launchT < launchP2) //Se vince P2
            {
                Console.WriteLine("Other player won!");
                json.player1 -= launchP2 - launchT; //Aggiorno punteggio
            }
            else if (launchT > launchP2) //Se vince umano
            {
                Console.WriteLine("You won!");
                json.player2 -= launchT - launchP2; //Aggiorno punteggio
            }
            else Console.WriteLine("Even!"); //Se pari

            Genero(path, json);
            int player1=json.player1;
            int player2=json.player2;
            AnsiConsole.Write(new BarChart() //Visualizza barre punteggio parziale
                .Width(60)
                .AddItem("Player1 points:", player1, Color.Yellow)
                .AddItem("Player2 points:", player2, Color.Green));
            Console.WriteLine();
        }while (json.player1 > 0 && json.player2 > 0);

        if (json.player1 < json.player2) //Visualizza punteggio finale
        {
            Console.WriteLine($"Hai perso!\nPlayer 2 vince in {json.launch} lanci con un vantaggio di {json.player2 - json.player1} punti!");
            json.P2=json.P2+1;
        }
        else
        {
            Console.WriteLine($"Hai vinto in {json.launch} tiri con un vantaggio di {json.player1 - json.player2} punti!");
            json.P1=json.P1+1;
        }

        Genero(path, json);
        Console.WriteLine($"Player 1: {json.P1}\tPlayer 2: {json.P2}");


        void Genero(string path, dynamic json)
        {
            try
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(json));
            }
            catch (UnauthorizedAccessException)
            {
                Genero(path, json);
            }
        }

        dynamic Leggo(string path)
        {
            int player1 = 100;
            int player2 = 100;
            int launch = 0;
            int P1 = 0;
            int P2 = 0;
            int launchT = 0;
            try
            {
                return JsonConvert.DeserializeObject(File.ReadAllText(path))!;
            }
            catch (Exception ex) when (ex is FormatException ||
                                        ex is IndexOutOfRangeException ||
                                        ex is OverflowException)
            {
                Console.WriteLine("Formato file errato. Rigenero...");
            }
            catch (Exception ex) when (ex is NotSupportedException ||
                                        ex is DirectoryNotFoundException)
            {
                Console.WriteLine("Problemi di accesso al file. Rigenero...");
            }
            catch (FileNotFoundException) //Creo file inizializzato a zero se non presente
            {
                Console.WriteLine("File non trovato. Rigenero...");
            }
            catch (IOException)
            {
                Leggo(path);
            }
            catch
            {
                Console.WriteLine("Errore non previsto. Rigenero...");
            }
            dynamic json = new { player1, player2, launch, P1, P2, player, launchT };
            Genero(path, json);
            return json;
        }
    }
}