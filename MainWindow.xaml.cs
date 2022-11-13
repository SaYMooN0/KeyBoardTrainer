using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO.Packaging;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace KeyBoardTrainer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int difficulty = 1;
        string textToEnter = "";
        public MainWindow()
        {
            bColor Red = new bColor(Brushes.Red, Brushes.LightPink, Brushes.Tomato);
            bColor Yellow = new bColor(Brushes.Yellow, Brushes.LemonChiffon, Brushes.Gold);
            bColor Green = new bColor(Brushes.Green, Brushes.LightGreen, Brushes.LimeGreen);
            bColor Blue = new bColor(Brushes.Blue, Brushes.LightCyan, Brushes.DeepSkyBlue);
            bColor Magenta = new bColor(Brushes.Magenta, Brushes.Plum, Brushes.MediumOrchid);
            bColor Gray = new bColor(Brushes.Gray, Brushes.LightGray, Brushes.DarkGray);
            InitializeComponent();
            List<KeyButton> keys = new List<KeyButton>
            {
                new cButton(10, 125, '`', '~', Red),
                new cButton(85, 125, '1', '!', Red),
                new cButton(160, 125, '2', '@', Red),
                new cButton(235, 125, '3', '#', Yellow),
                new cButton(310, 125, '4', '$', Green),
                new cButton(385, 125, '5', '%', Blue),
                new cButton(460, 125, '6', '^', Blue),
                new cButton(535, 125, '7', '&', Magenta),
                new cButton(610, 125, '8', '*', Magenta),
                new cButton(685, 125, '9', '(', Blue),
                new cButton(760, 125, '0', ')', Green),
                new cButton(835, 125, '-', '_', Yellow),
                new cButton(910, 125, '=', '+', Red),
                new uncButton(985, 125, "BackSpace", Gray, 150),
                new uncButton(10, 200, "Tab", Gray, 100),
                new cButton(120, 200, 'q', 'Q', Red),
                new cButton(195, 200, 'w', 'W', Yellow),
                new cButton(270, 200, 'e', 'E', Green),
                new cButton(345, 200, 'r', 'R', Blue),
                new cButton(420, 200, 't', 'T', Blue),
                new cButton(495, 200, 'y', 'Y', Magenta),
                new cButton(570, 200, 'u', 'U', Magenta),
                new cButton(645, 200, 'i', 'I', Blue),
                new cButton(720, 200, 'o', 'O', Green),
                new cButton(795, 200, 'p', 'P', Yellow),
                new cButton(870, 200, '[', '{', Red),
                new cButton(945, 200, ']', '}', Red),
                new uncButton(1020, 200, "\\", Red, 115),
                new uncButton(10, 275, "Caps Lock", Gray, 150),
                new cButton(170, 275, 'a', 'A', Red),
                new cButton(245, 275, 's', 'S', Yellow),
                new cButton(320, 275, 'd', 'D', Green),
                new cButton(395, 275, 'f', 'F', Blue),
                new cButton(470, 275, 'g', 'G', Blue),
                new cButton(545, 275, 'h', 'H', Magenta),
                new cButton(620, 275, 'j', 'J', Magenta),
                new cButton(695, 275, 'k', 'K', Blue),
                new cButton(770, 275, 'l', 'L', Green),
                new cButton(845, 275, ';', ':', Yellow),
                new cButton(920, 275, '\'', '\"', Red),
                new uncButton(995, 275, "Enter", Gray, 140),
                new uncButton(10, 350, "Shift", Gray, 180),
                new cButton(200, 350, 'z', 'Z', Red),
                new cButton(275, 350, 'x', 'X', Yellow),
                new cButton(350, 350, 'c', 'C', Green),
                new cButton(425, 350, 'v', 'V', Blue),
                new cButton(500, 350, 'b', 'B', Blue),
                new cButton(575, 350, 'n', 'N', Magenta),
                new cButton(650, 350, 'm', 'M', Magenta),
                new cButton(725, 350, ',', '<', Blue),
                new cButton(800, 350, '.', '>', Green),
                new cButton(875, 350, '/', '?', Yellow),
                new uncButton(950, 350, "Shift", Gray, 185),
                new uncButton(10, 425, "Ctrl", Gray, 100),
                new uncButton(120, 425, "Win", Gray, 90),
                new uncButton(220, 425, "Alt", Gray, 90),
                new uncButton(1030, 425, "Ctrl", Gray, 105),
                new uncButton(930, 425, "Win", Gray, 90),
                new uncButton(830, 425, "Alt", Gray, 90),
                new uncButton(320, 425, "Space", Red, 500)
            };
            var All = new Canvas();
            All.Children.Add(showAllKeys(keys));
            All.Children.Add(AllInerface());
            Content = All;
        }
        public Canvas AllInerface()
        {
            var sign = new Canvas();
            sign.Margin = new Thickness(10, 20, 0, 0);
            Canvas can = new Canvas();
            can.Margin = new Thickness(0, 100, 0, 0);
            Rectangle r = new Rectangle
            {
                Height = 70,
                Width = 1120,
                StrokeThickness = 6,
                RadiusX = 10,
                RadiusY = 10,
                Fill = new SolidColorBrush(Colors.Bisque),
                Stroke = new SolidColorBrush(Colors.PeachPuff),
            };
            TextBlock str = new TextBlock
            {
                Margin = new Thickness(10, 10, 0, 0),
                Height = 70,
                Width = 1110,
                FontSize = 32,
                Text = "Choose the difficlty level and press start button",
                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Center
            };
            //Style cornerStyle = new Style(typeof(Border));
            //cornerStyle.Setters.Add(new Setter(Border.CornerRadiusProperty, 6));
            //Style sB = new Style(typeof(Button));
            //sB.Resources.Add(typeof(Border), cornerStyle);
            //Спросить у Алексея
            //https://stackoverflow.com/questions/1729368/creating-a-style-in-code-behind
            //https://stackoverflow.com/questions/6745663/how-to-create-make-rounded-corner-buttons-in-wpf
            Button start = new Button()
            {
                Margin = new Thickness(170, 0, 0, 0),
                Height = 60,
                Width = 120,
                Content = "Start",
                Background = new SolidColorBrush(Colors.LightSkyBlue),
                BorderBrush = new SolidColorBrush(Colors.DeepSkyBlue),
                BorderThickness = new Thickness(6),
                //Style=sB
            };
            Slider s = new Slider()
            {
                Value = difficulty,
                TickFrequency = 1,
                TabIndex = 1,
                IsSnapToTickEnabled = true,
                Minimum = 1,
                Maximum = 14,
                Margin = new Thickness(0, 30, 0, 0),
                TickPlacement = TickPlacement.BottomRight,
                Width = 140,
                Height = 36
            };
            TextBlock txt = new TextBlock
            {
                Text = $"Difficulty: {s.Value}",
                FontSize = 22,
                FontWeight = FontWeights.Bold,
                TextAlignment = TextAlignment.Center
            };
            void txtChanging(object sender, RoutedPropertyChangedEventArgs<double> e) => txt.Text = "Difficulty: " + s.Value;
            void diffChangeBlock(object sender, RoutedEventArgs e) => s.IsEnabled = false;
            void newTextShow(object sender, RoutedEventArgs e) => str.Text = textToEnter;
            void startBlock(object sender, RoutedEventArgs e) => start.IsEnabled = false;
            s.ValueChanged += txtChanging;
            s.ValueChanged += diffChanging;
            start.Click += diffChangeBlock;
            start.Click += trainingStart;
            start.Click += newTextShow;
            start.Click += startBlock;
            can.Children.Add(r);
            can.Children.Add(str);
            sign.Children.Add(start);
            sign.Children.Add(txt);
            sign.Children.Add(s);
            sign.Children.Add(can);
            return sign;
        }
        void diffChanging(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            Slider s = sender as Slider;
            difficulty = (int)s.Value;
        }
        void trainingStart(object sender, RoutedEventArgs e)
        {
            textToEnter = generateText();
            var window = Window.GetWindow(this);
            window.KeyDown += KeyPress;
        }
        private void KeyPress(object sender, KeyEventArgs e)
        {
            KeyConverter converter = new KeyConverter();
            if (!String.IsNullOrEmpty(textToEnter) && KeyCheck(e.Key))
            {

                if (corectionChek(e.Key, e.KeyboardDevice.Modifiers))
                    MessageBox.Show(" right ");
                else
                    MessageBox.Show(" not right ");
                textToEnter = textToEnter.Remove(0, 1);
            }
        }
        enum kType { num, numUp, let, letUp, oem, oemUp }
        bool corectionChek(Key k, ModifierKeys m)
        {
            string kValue = k.ToString();
            bool Up = false;
            if (!caps() && m == ModifierKeys.Shift)
                Up = true;
            else if (caps() && m != ModifierKeys.Shift)
                Up = true;
            kType type = kType.let;
            if (kValue.StartsWith("Oem"))
                type = kType.oem;
            else if (kValue.StartsWith("D") && !kValue.EndsWith("D"))
                type = kType.num;
            if (Up == true)
            {
                if (type == kType.let)
                    type = kType.letUp;
                else if (type == kType.num)
                    type = kType.numUp;
                else if (type == kType.oem)
                    type = kType.oemUp;
            }
            if (type == kType.letUp && kValue[0] == textToEnter[0])
                return true;
            if (type == kType.let && kValue.ToLower()[0] == textToEnter[0])
                return true;
            return false;
        }
        bool KeyCheck(Key k)
        {
            if (k != Key.LeftAlt && k != Key.LeftCtrl && k != Key.LeftShift && k != Key.CapsLock && k != Key.Tab && k != Key.Back && k != Key.LWin && k != Key.RWin)
                if (k != Key.RightAlt && k != Key.RightCtrl && k != Key.RightShift)
                    return true;
            return false;
        }
        public static bool caps()
        {
            return Keyboard.IsKeyToggled(Key.CapsLock);
        }
        public static bool ShiftOrCaps()
        {
            if (caps() || Keyboard.IsKeyToggled(Key.LeftShift) || Keyboard.IsKeyToggled(Key.RightShift))
                return true;
            return false;
        }
        private Canvas showAllKeys(List<KeyButton> keys)
        {
            var aK = new Canvas() { Margin = new Thickness(0, 80, 0, 0) };
            foreach (KeyButton k in keys)
            {
                if (!ShiftOrCaps())
                    aK.Children.Add(k.show());
                else
                { 
                    if(k is cButton)
                        aK.Children.Add(k.showUp());
                    else
                        aK.Children.Add(k.show());
                }
            }
            return aK;
        }
        public string generateText()
        {
            string generatedText = "";
            Random rnd = new Random();
            List<char[]> allChars = new List<char[]>()
            {
                new char[4] { 'f', 'g', 'h', 'j' },
                new char[4] { 'w', 'e', 'i', 'o' },
                new char[4] { 'r', 't', 'y', 'u' },
                new char[4] { 'v', 'b', 'n', 'm' },
                new char[4] { 'p', 'l', 'q', 'a' },
                new char[4] { 'k', 's', 'd', 'z' },
                new char[4] { 'x', 'c', ',', '.' },
                new char[4] { ';', '\'', '[', ']' },
                new char[32] { 'F', 'G', 'H', 'J', 'W', 'E', 'I', 'O', 'R', 'T', 'Y', 'U', 'V', 'B', 'N', 'M', 'P', 'L', 'Q', 'A', 'K', 'S', 'D', 'Z', 'X', 'C', '<', '>', ':', '\"', '{', '}' },
                new char[10] { '4', '5', '6', '7', '8', '$', '%', '^', '&', '*' },
                new char[10] { '1', '2', '3', '9', '0', '!', '@', '#', '(', ')' },
                new char[4] { '-', '_', '+', '=' },
                new char[2] { '~', '`' },
                new char[3] { '/', '?', '\\' }
            };
            List<char> possibleChars = new List<char>();
            for (int i = 0; i < difficulty; i++)
                for (int j = 0; j < allChars[i].Length; j++)
                    possibleChars.Add(allChars[i][j]);
            int spaceCount = 0;
            for (int i = 0; i < 100; i++)
            {
                generatedText += possibleChars[rnd.Next(possibleChars.Count)].ToString();
                spaceCount++;
                if (rnd.Next(0, 10) < spaceCount)
                {
                    generatedText += " ";
                    spaceCount = 0;
                    i++;
                }
            }
            return generatedText;
        }
        interface KeyButton
        {
            Canvas show();
            Canvas showUp();
        }
        class cButton:KeyButton
        {
            bColor c;
            int x, y;
            char sym, symUp;
            public cButton(int x, int y, char sym, char symUp, bColor c)
            {
                this.x = x;
                this.y = y;
                this.sym = sym;
                this.symUp = symUp;
                this.c = c;
            }
            public Canvas show()
            {
                Brush dimColor = c.dimColor;
                Brush brightColor = c.brightColor;
                Canvas mCan = new Canvas
                {
                    Margin = new Thickness(x, y, 0, 0)
                };
                Rectangle r = new Rectangle
                {
                    Height = 65,
                    Width = 65,
                    Fill = dimColor,
                    Stroke = brightColor,
                    StrokeThickness = 4,
                    RadiusX = 14,
                    RadiusY = 14
                };
                TextBlock key = new TextBlock
                {
                    Width = 65,
                    Text = sym.ToString(),
                    FontSize = 32,
                    FontWeight = FontWeights.Bold,
                    TextAlignment = TextAlignment.Center,
                    Foreground = brightColor
                };
                mCan.Children.Add(r);
                mCan.Children.Add(key);
                Canvas.SetTop(key, 12);
                return mCan;
            }
            public Canvas showUp()
            {
                Brush dimColor = c.dimColor;
                Brush brightColor = c.brightColor;
                Canvas mCan = new Canvas
                {
                    Margin = new Thickness(x, y, 0, 0)
                };
                Rectangle r = new Rectangle
                {
                    Height = 65,
                    Width = 65,
                    Fill = dimColor,
                    Stroke = brightColor,
                    StrokeThickness = 4,
                    RadiusX = 14,
                    RadiusY = 14
                };
                TextBlock key = new TextBlock
                {
                    Width = 65,
                    Text = symUp.ToString(),
                    FontSize = 32,
                    FontWeight = FontWeights.Bold,
                    TextAlignment = TextAlignment.Center,
                    Foreground = brightColor
                };
                mCan.Children.Add(r);
                mCan.Children.Add(key);
                Canvas.SetTop(key, 12);
                return mCan;
            }
        }
        class uncButton:KeyButton
        {
            int w;
            bColor c;
           int x, y;
            string sym;

            public uncButton (int x, int y, string sym, bColor c, int w)
            {
                this.x = x;
                this.y = y;
                this.sym = sym;
                this.c = c;
                this.w = w;
            }
            public Canvas show()
            {
                Brush dimColor = c.dimColor;
                Brush brightColor = c.brightColor;
                Canvas mCan = new Canvas
                {
                    Margin = new Thickness(x, y, 0, 0)
                };
                Rectangle r = new Rectangle
                {
                    Height = 65,
                    Width = w,
                    Fill = dimColor,
                    Stroke = brightColor,
                    StrokeThickness = 4,
                    RadiusX = 14,
                    RadiusY = 14
                };
                TextBlock key = new TextBlock
                {
                    Width = w,
                    Text = sym.ToString(),
                    FontSize = 28,
                    FontWeight = FontWeights.Bold,
                    TextAlignment = TextAlignment.Center,
                    Foreground = brightColor
                };
                mCan.Children.Add(r);
                mCan.Children.Add(key);
                Canvas.SetTop(key, 12);
                return mCan;
            }
            public Canvas showUp()
            {return new Canvas{Margin = new Thickness(x, y, 0, 0)};}

        }
        public class bColor
        {
            public Brush mainColor;
            public Brush dimColor;
            public Brush brightColor;
            public bColor(Brush mainColor, Brush dimColor, Brush brightColor)
            {
                this.mainColor = mainColor;
                this.dimColor = dimColor;
                this.brightColor = brightColor;
            }
        }
    }
}