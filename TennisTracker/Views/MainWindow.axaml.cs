using Avalonia.Controls;
using Avalonia.Interactivity;
using TennisTracker.Models;
using TennisTracker.Controllers;
using System.Collections.ObjectModel;

namespace TennisTracker.Views
{
    public partial class MainWindow : Window
    {
        private MatchController matchController;
        public ObservableCollection<MatchItem> Matches { get; set; } = new ObservableCollection<MatchItem>();

        public MainWindow()
        {
            InitializeComponent();

            matchController = new MatchController();

            // Asignamos la ObservableCollection al ListBox
            MatchListBox.ItemsSource = Matches;

            // Cargar matches existentes del controlador
            var existingMatches = matchController.GetAllMatches();
            foreach (var match in existingMatches)
            {
                Matches.Add(match);
            }
        }

        private void AddMatchButton_Click(object sender, RoutedEventArgs e)
        {
            // Leer datos de los TextBoxes
            string opponent = OpponentTextBox.Text;
            string score = ScoreTextBox.Text;
            string notes = NotesTextBox.Text;

            // Crear nuevo match
            var newMatch = new MatchItem(opponent, score, notes);

            // Guardar en el controlador (opcional, según tu lógica)
            matchController.AddMatch(newMatch);

            // Agregar a la ObservableCollection
            Matches.Add(newMatch);

            // Limpiar los TextBoxes
            OpponentTextBox.Text = "";
            ScoreTextBox.Text = "";
            NotesTextBox.Text = "";
        }

        private void RemoveMatchButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedMatch = MatchListBox.SelectedItem as MatchItem;
            if (selectedMatch != null)
            {
                // Remover del controlador
                matchController.RemoveMatch(selectedMatch);

                // Remover de la ObservableCollection
                Matches.Remove(selectedMatch);
            }
        }
    }
}
