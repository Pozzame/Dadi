using Newtonsoft.Json;
using Spectre.Console;
public class Program
{
    public static void Main()
    {

        string path = @"Z:\MP\Punteggio.json";

        string player = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("-----Select player-----")
                .PageSize(3)
                .MoreChoicesText("[grey](Move up and down to select)[/]")
                .AddChoices(new[] {
            "1", "2", "Exit"}));
        if (player == "Exit") return;

        dynamic json;

        do
        {
            json = Leggo(path);
            if (json.player == player) Console.WriteLine("Waiting for other player...");
            while (json.player == player) json = Leggo(path);
            
            VisualizzaBarra(json);
            (int launch1, int launch2) launchs = Giocata();
            int launchT = launchs.launch1 + launchs.launch2;
            
            Console.WriteLine($"Yuo have got: {launchs.launch1} e {launchs.launch2}");

            if (player == "2")
            {
                Console.WriteLine($"Other player last launch: {json.launchT}");
                if (launchT < Convert.ToInt32(json.launchT)) //Se vince P1
                {
                    Console.WriteLine("Other player won!");
                    json.player2 = Convert.ToInt32(json.player2) - Convert.ToInt32(json.launchT) - launchT; //Aggiorno punteggio
                }
                else if (Convert.ToInt32(json.launchT) < launchT) //Se vince P2
                {
                    Console.WriteLine("You won!");
                    json.player1 = Convert.ToInt32(json.player1) - launchT - Convert.ToInt32(json.launchT); //Aggiorno punteggio
                }
                else Console.WriteLine("Even!"); //Se pari
            }
            json.launchT = launchT;
            json.player = player;
            Genero(path, json);
        } while (json.player1 > 0 && json.player2 > 0);

        if (Convert.ToInt32(json.player1) < Convert.ToInt32(json.player2)) //Visualizza punteggio finale
        {
            Console.WriteLine($"Player 2 vince in {json.launch} lanci con un vantaggio di {json.player2 - json.player1} punti!");
            json.P2 = json.P2 + 1;
        }
        else
        {
            Console.WriteLine($"Player 1 vince in {json.launch} tiri con un vantaggio di {json.player1 - json.player2} punti!");
            json.P1 = json.P1 + 1;
        }

        Console.WriteLine($"Player 1: {json.P1}\tPlayer 2: {json.P2}");
/*
        void SafeWrite(string path, dynamic json)
        {
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                using (StreamWriter writer = new StreamWriter(fileStream))
                {
                    fileStream.Lock(0, long.MaxValue);
                    writer.Write(JsonConvert.SerializeObject(json));
                    writer.Flush();
                    fileStream.Unlock(0, long.MaxValue);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Errore di accesso al file: " + ex.Message);
            }
            finally
            {
                fileStream?.Close();
            }
        }

        dynamic SafeRead(string path)
        {
            FileStream fileStream = null;
            try
            {
                fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                fileStream.Lock(0, long.MaxValue);
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string content = reader.ReadToEnd();
                    fileStream.Unlock(0, long.MaxValue);
                    return JsonConvert.DeserializeObject(content);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Errore di lettura del file: " + ex.Message);
                return null;
            }
            finally
            {
                fileStream?.Close();
            }
        }
*/
        void Genero(string path, dynamic json)
        {
            try
            {
                File.WriteAllText(path, JsonConvert.SerializeObject(json));
            }
            catch (UnauthorizedAccessException)
            {
                Thread.Sleep(500);
                Genero(path, json);
            }
        }

        dynamic Leggo(string path)
        {
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
                Thread.Sleep(500);
                Leggo(path);
            }
            catch
            {
                Console.WriteLine("Errore non previsto. Rigenero...");
            }
            dynamic json = new { player1 = 100, player2 = 100, launch = 0, P1 = 0, P2 = 0, player = "0", launchT = 0 };
            Genero(path, json);
            return json;
        }

        (int, int) Giocata()
        {
            Random rng = new Random();
            Console.WriteLine("Hit a key for launch the dices...");
            Console.ReadKey(true);
            return (rng.Next(1, 7), rng.Next(1, 7));
        }

        void VisualizzaBarra(dynamic json)
        {
            int player1 = json.player1;
            int player2 = json.player2;
            AnsiConsole.Write(new BarChart() //Visualizza barre punteggio parziale
                .Width(60)
                .AddItem("Player1 points:", player1, Color.Yellow)
                .AddItem("Player2 points:", player2, Color.Green));
            Console.WriteLine();
        }
    }
}