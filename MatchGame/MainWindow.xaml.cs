using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();  SetUpGame(); 
        }

        private void SetUpGame()
        {
            // creates a list of emojis
            List<string> animalEmoji = new List<string>()
            {
                "🐔", "🐔",
                "🐫", "🐫",
                "🐘", "🐘",
                "🐪", "🐪",
                "🦍", "🦍",
                "🦄", "🦄",
                "🐼", "🐼",
                "🐙", "🐙",
            };

            // new method to get a random number!
            Random random = new Random();

            // foreach loop runs for every textBlock in the mainGrid
            foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
            {
                // get random number between 0 and x (x= the count of animal emojis in the list)
                int index = random.Next(animalEmoji.Count);

                // creates var and assigns it to an emoji 
                string nextEmoji = animalEmoji[index];
                
                // assigns that specific emoji to that textBlock
                textBlock.Text = nextEmoji;

                // removes emoji from list so cannot be used again, for next iteration of loop
                animalEmoji.RemoveAt(index);

                //this is new code, but this is just a test.
            }
        }
    }
}
