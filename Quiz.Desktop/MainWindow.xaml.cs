using Microsoft.Data.Sqlite;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiz.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        string connectionString = "Data Source=Data\\quiz.db";

        int aktuelleFrage = 0;
        int punkte = 0;
        string? username;
        List<int> FrageID = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
            CreateDatenbank();
        }

        public void CreateDatenbank()
        {
            using (SqliteConnection conn = new SqliteConnection(connectionString))
            {
                conn.Open();

                string createTableFragenErgebniss = @"CREATE TABLE IF NOT EXISTS Fragen(
                                                        ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                        Fragen TEXT,
                                                        NR1 TEXT,
                                                        NR2 TEXT,
                                                        NR3 TEXT,
                                                        NR4 TEXT,
                                                        Antwort TEXT
                                            );

                                            CREATE TABLE IF NOT EXISTS Ergebniss (
                                                ID INTEGER PRIMARY KEY AUTOINCREMENT,
                                                Username TEXT,
                                                Punkte INTEGER,
                                                Datum TEXT
                                            );";

                using (SqliteCommand cmd = new SqliteCommand(createTableFragenErgebniss, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void addFrage(SqliteConnection conn)
        {
            var frage = new (string frage, string NR1, string NR2, string NR3, string NR4, string Antwort)[]
            {
                (
                "And if you ask me how I'm feeling, don't tell me you're too blind to see",
                "Love you like a love song",
                "Never gonna give you up",
                "Photoshop",
                "Criminal",
                "B"
                ),
                (
                "I know you know that I made those mistakes maybe once or twice",
                "Sorry",
                "505",
                "Obsessed",
                "Single Ladies",
                "A"
                ),
                (
                "We were too close to the stars, I never knew somebody like you",
                "WAP",
                "Reflections",
                "Cherry Lady",
                "Magic Melody",
                "B"
                ),
                (
                "Just gonna stand there and watch me burn",
                "Rap God",
                "My House",
                "Love the way you lie",
                "7 Rings",
                "C"
                ),
                (
                "Ich steh mit Rücken an der Wand",
                "Jim Beam & Voddi",
                "RADW",
                "Aura",
                "Komet",
                "B"
                ),
                (
                "Geb mir die Hand, ich bau dir ein Schloss aus Sand",
                "99 Luftballons",
                "Griechischer Wein",
                "Side by Side",
                "Irgendwie, Irgendwo, Irgendwann",
                "D"
                ),
            };
        }

    }
}
