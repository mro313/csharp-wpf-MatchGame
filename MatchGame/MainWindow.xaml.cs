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
using System.Windows.Threading;

namespace MatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 


    // testing this, pushing to master
    public partial class MainWindow : Window
    {
        //added this for the timer
        DispatcherTimer timer = new DispatcherTimer();
        int tenthsOfSecondsElapsed;
        int matchesFound;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += Timer_Tick;
            SetUpGame(); 
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            tenthsOfSecondsElapsed++;
            timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
            if (matchesFound == 8)
            {
                timer.Stop();
                timeTextBlock.Text = timeTextBlock.Text + " - Play Again?";
            }
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
                if (textBlock.Name != "timeTextBlock")
                {
                    // get random number between 0 and x (x= the count of animal emojis in the list)
                    int index = random.Next(animalEmoji.Count);

                    // creates var and assigns it to an emoji 
                    string nextEmoji = animalEmoji[index];

                    // assigns that specific emoji to that textBlock
                    textBlock.Text = nextEmoji;

                    // removes emoji from list so cannot be used again, for next iteration of loop
                    animalEmoji.RemoveAt(index);

                }
            }

            timer.Start();
            tenthsOfSecondsElapsed = 0;
            matchesFound = 0;

        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock; if (findingMatch == false)
            {
                //this is for first click aka findingMatch == false.
                //first, hide textBlock after you click it
                textBlock.Visibility = Visibility.Hidden;

                // then, set textBlock aka the first emoji you clicked, equal to 
                // lastTextBlockClicked (since you'll be checking next)
                lastTextBlockClicked = textBlock;

                // sets this = true since you're checking next click!
                findingMatch = true;
            }

            // if textBlock (the one you just clicked) == lastText emoji, then execute code block
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                matchesFound++;
                textBlock.Visibility = Visibility.Hidden;
                findingMatch = false;
            }

            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible;
                findingMatch = false;
            }

        }

        private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (matchesFound == 8)
            {
                SetUpGame();
            }
        }
    }
}
