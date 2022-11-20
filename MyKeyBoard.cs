using Microsoft.VisualBasic;
using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;


namespace keyboard_v7
{
    internal class MyKeyBoard
    {
        string textToEnter = "";
        Window w;
        bColor Red = new bColor(Brushes.Red, Brushes.LightPink, Brushes.Tomato);
        bColor Yellow = new bColor(Brushes.Yellow, Brushes.LemonChiffon, Brushes.Gold);
        bColor Green = new bColor(Brushes.Green, Brushes.LightGreen, Brushes.LimeGreen);
        bColor Blue = new bColor(Brushes.Blue, Brushes.LightCyan, Brushes.DeepSkyBlue);
        bColor Magenta = new bColor(Brushes.Magenta, Brushes.Plum, Brushes.MediumOrchid);
        bColor Gray = new bColor(Brushes.Gray, Brushes.LightGray, Brushes.DarkGray);
        ProgrammInterface myInterface;
        static List<KeyButton> keys;
        public MyKeyBoard(Window w)
        {
            this.w = w;
            keys = new List<KeyButton>
            {
                new SymButton(10, 125, '`', '~', Red),
                new SymButton(85, 125, '1', '!', Red),
                new SymButton(160, 125, '2', '@', Red),
                new SymButton(235, 125, '3', '#', Yellow),
                new SymButton(310, 125, '4', '$', Green),
                new SymButton(385, 125, '5', '%', Blue),
                new SymButton(460, 125, '6', '^', Blue),
                new SymButton(535, 125, '7', '&', Magenta),
                new SymButton(610, 125, '8', '*', Magenta),
                new SymButton(685, 125, '9', '(', Blue),
                new SymButton(760, 125, '0', ')', Green),
                new SymButton(835, 125, '-', '_', Yellow),
                new SymButton(910, 125, '=', '+', Red),
                new uncButton(985, 125, "BackSpace", Gray, 150),
                new uncButton(10, 200, "Tab", Gray, 100),
                new LetButton(120, 200, 'q', 'Q', Red),
                new LetButton(195, 200, 'w', 'W', Yellow),
                new LetButton(270, 200, 'e', 'E', Green),
                new LetButton(345, 200, 'r', 'R', Blue),
                new LetButton(420, 200, 't', 'T', Blue),
                new LetButton(495, 200, 'y', 'Y', Magenta),
                new LetButton(570, 200, 'u', 'U', Magenta),
                new LetButton(645, 200, 'i', 'I', Blue),
                new LetButton(720, 200, 'o', 'O', Green),
                new LetButton(795, 200, 'p', 'P', Yellow),
                new SymButton(870, 200, '[', '{', Red),
                new SymButton(945, 200, ']', '}', Red),
                new SymButton(1020, 200, '\\', '|', Red, 115),
                new uncButton(10, 275, "Caps Lock", Gray, 150),
                new LetButton(170, 275, 'a', 'A', Red),
                new LetButton(245, 275, 's', 'S', Yellow),
                new LetButton(320, 275, 'd', 'D', Green),
                new LetButton(395, 275, 'f', 'F', Blue),
                new LetButton(470, 275, 'g', 'G', Blue),
                new LetButton(545, 275, 'h', 'H', Magenta),
                new LetButton(620, 275, 'j', 'J', Magenta),
                new LetButton(695, 275, 'k', 'K', Blue),
                new LetButton(770, 275, 'l', 'L', Green),
                new SymButton(845, 275, ';', ':', Yellow),
                new SymButton(920, 275, '\'', '\"', Red),
                new uncButton(995, 275, "Enter", Gray, 140),
                new uncButton(10, 350, "Shift", Gray, 180),
                new LetButton(200, 350, 'z', 'Z', Red),
                new LetButton(275, 350, 'x', 'X', Yellow),
                new LetButton(350, 350, 'c', 'C', Green),
                new LetButton(425, 350, 'v', 'V', Blue),
                new LetButton(500, 350, 'b', 'B', Blue),
                new LetButton(575, 350, 'n', 'N', Magenta),
                new LetButton(650, 350, 'm', 'M', Magenta),
                new SymButton(725, 350, ',', '<', Blue),
                new SymButton(800, 350, '.', '>', Green),
                new SymButton(875, 350, '/', '?', Yellow),
                new uncButton(950, 350, "Shift", Gray, 185),
                new uncButton(10, 425, "Ctrl", Gray, 100),
                new uncButton(120, 425, "Win", Gray, 90),
                new uncButton(220, 425, "Alt", Gray, 90),
                new uncButton(1030, 425, "Ctrl", Gray, 105),
                new uncButton(930, 425, "Win", Gray, 90),
                new uncButton(830, 425, "Alt", Gray, 90),
                new uncButton(320, 425, "Space", Red, 500,' ',' ')
            };
            this.myInterface = new ProgrammInterface(true, false, textToEnter, this);


        }
        public void ShowTrainer()
        {
            w.KeyDown += UpdateKeysToDelegate;
            w.KeyUp += UpdateKeysToDelegate;
            var All = new Canvas();
            All.Children.Add(showAllKeys());
            All.Children.Add(myInterface.Show());
            w.Content = All;
        }
        private Canvas showAllKeys()
        {
            var aK = new Canvas() { Margin = new Thickness(0, 80, 0, 0) };
            foreach (KeyButton k in keys)
            {
                if (k.isPressed)
                    aK.Children.Add(k.showPressed());
                else
                {
                    if (isUp() == 0)
                        aK.Children.Add(k.show());
                    else if (isUp() == 2)
                    {
                        if (k is LetButton)
                            aK.Children.Add(k.showUp());
                        else if (k is SymButton)
                            aK.Children.Add(k.showUp());
                        else
                            aK.Children.Add(k.show());
                    }
                    else if (isUp() == 1)
                    {
                        if (k is LetButton)
                            aK.Children.Add(k.showUp());
                        else if (k is SymButton)
                            aK.Children.Add(k.show());
                        else
                            aK.Children.Add(k.show());
                    }
                    else if (isUp() == 3)
                    {
                        if (k is LetButton)
                            aK.Children.Add(k.show());
                        else if (k is SymButton)
                            aK.Children.Add(k.showUp());
                        else
                            aK.Children.Add(k.show());
                    }
                }
            }
            return aK;
        }
        public static bool caps()
        {
            return Keyboard.IsKeyToggled(Key.CapsLock);
        }
        public static int isUp()
        {
            if (!caps() && !Keyboard.IsKeyDown(Key.LeftShift) && !Keyboard.IsKeyDown(Key.RightShift))
                return 0;
            else if (caps() && !Keyboard.IsKeyDown(Key.LeftShift) && !Keyboard.IsKeyDown(Key.RightShift))
                return 1;
            else if (!caps() && (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift)))
                return 2;
            else return 3;
        }
        delegate void Del(object sender, KeyEventArgs e);
        void UpdateKeys()
        {
            var All = new Canvas();
            Canvas keys = showAllKeys();
            Canvas myInreface = myInterface.Show();
            if (myInreface.Parent != null)
            {
                var parent = (Panel)myInreface.Parent;
                parent.Children.Remove(myInreface);
            }
            All.Children.Add(keys);
            All.Children.Add(myInreface);
            w.Content = All;
        }
        void UpdateKeysToDelegate(object sender, KeyEventArgs e)
        {
            UpdateKeys();
        }
        static public string generateText(int d, int c)
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
            for (int i = 0; i < d; i++)
                for (int j = 0; j < allChars[i].Length; j++)
                    possibleChars.Add(allChars[i][j]);
            int spaceCount = 0;
            for (int i = 0; i < c; i++)
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
            Rectangle showPressed();
            char sym { get; }
            char symUp { get; }
            bool isPressed { get; set; }
        }
        class SymButton : KeyButton
        {
            bColor c;
            int x, y, w;
            public bool isPressed { get; set; }
            public char sym { get; }
            public char symUp { get; }
            public SymButton(int x, int y, char sym, char symUp, bColor c)
            {
                this.x = x;
                this.y = y;
                this.sym = sym;
                this.symUp = symUp;
                this.c = c;
                w = 65;
            }
            public SymButton(int x, int y, char sym, char symUp, bColor c, int w)
            {
                this.x = x;
                this.y = y;
                this.sym = sym;
                this.symUp = symUp;
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
            public Rectangle showPressed()
            {
                Brush b = c.dimColor;
                Rectangle r = new Rectangle
                {
                    Margin = new Thickness(x, y, 0, 0),
                    Height = 65 * 0.95,
                    Width = w * 0.95,
                    Fill = b,
                    Stroke = b,
                    StrokeThickness = 4,
                    RadiusX = 14,
                    RadiusY = 14,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                return r;
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
        class LetButton : KeyButton
        {
            bColor c;
            int x, y;
            public bool isPressed { get; set; }
            public char sym { get; }
            public char symUp { get; }
            public LetButton(int x, int y, char sym, char symUp, bColor c)
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
            public Rectangle showPressed()
            {
                Brush b = c.dimColor;
                Rectangle r = new Rectangle
                {
                    Margin = new Thickness(x, y, 0, 0),
                    Height = 65 * 0.95,
                    Width = 65 * 0.95,
                    Fill = b,
                    Stroke = b,
                    StrokeThickness = 4,
                    RadiusX = 14,
                    RadiusY = 14,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                return r;
            }
        }
        class uncButton : KeyButton
        {
            int w;
            bColor c;
            int x, y;
            string content;
            public bool isPressed { get; set; }
            public char sym { get; }
            public char symUp { get; }

            public uncButton(int x, int y, string sym, bColor c, int w)
            {
                this.x = x;
                this.y = y;
                this.content = sym;
                this.c = c;
                this.w = w;
            }
            public uncButton(int x, int y, string s, bColor c, int w, char sym, char symUp)
            {
                this.x = x;
                this.y = y;
                this.content = s;
                this.c = c;
                this.w = w;
                this.sym = sym;
                this.symUp = symUp;
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
                    Text = content.ToString(),
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

            public Rectangle showPressed()
            {
                Brush b = c.dimColor;
                Rectangle r = new Rectangle
                {
                    Margin = new Thickness(x, y, 0, 0),
                    Height = 65 * 0.95,
                    Width = w * 0.95,
                    Fill = b,
                    Stroke = b,
                    StrokeThickness = 4,
                    RadiusX = 14,
                    RadiusY = 14,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center
                };
                return r;
            }
            public Canvas showUp()
            { return new Canvas { Margin = new Thickness(x, y, 0, 0) }; }

        }
        class ProgrammInterface
        {
            bool isSrartEnabled, isStopEnabled;
            public string textToEnter;
            int difficulty, count;
            Rectangle r;
            TextBlock str;
            TextBlock txtDiff, txtCount, txtFails, txtcharInsec;
            Button start, stop;
            Slider diffSlider, countSlider;
            TextBox tB;
            Canvas canvasToShow = new Canvas();
            MyKeyBoard myKb;
            DateTime startTime;
            int fails;
            bool isStarted;
            public ProgrammInterface(bool isSrartEnabled, bool isStopEnabled, string textToEnter, MyKeyBoard myKb)
            {
                this.textToEnter = textToEnter;
                this.isSrartEnabled = isSrartEnabled;
                this.isStopEnabled = isStopEnabled;
                this.difficulty = 1;
                this.count = 30;
                this.myKb = myKb;
                isStarted = false;
                tB = new TextBox
                {
                    Margin = new Thickness(48, 90, 0, 0),
                    Opacity = 0.00,
                    Height = 100,
                    Width = 1020,
                    FontSize = 22,
                    BorderThickness = new Thickness(6),
                    TextAlignment = TextAlignment.Left
                };
                tB.TextChanged += textChangedEventHandler;
                r = new Rectangle
                {
                    Margin = new Thickness(50, 100, 0, 0),
                    Height = 70,
                    Width = 1020,
                    StrokeThickness = 6,
                    RadiusX = 10,
                    RadiusY = 10,
                    Fill = new SolidColorBrush(Colors.Bisque),
                    Stroke = new SolidColorBrush(Colors.PeachPuff),
                };
                str = new TextBlock
                {
                    Margin = new Thickness(62, 113, 0, 0),
                    Height = 70,
                    Width = 996,
                    FontSize = 29,
                    Text = "Choose the difficulty level, number of characters and press start button",
                    FontWeight = FontWeights.Bold,
                    TextAlignment = TextAlignment.Left
                };
                //Style cornerStyle = new Style(typeof(Border));
                //cornerStyle.Setters.Add(new Setter(Border.CornerRadiusProperty, 6));
                //Style sB = new Style(typeof(Button));
                //sB.Resources.Add(typeof(Border), cornerStyle);
                //Спросить у Алексея
                //https://stackoverflow.com/questions/1729368/creating-a-style-in-code-behind
                //https://stackoverflow.com/questions/6745663/how-to-create-make-rounded-corner-buttons-in-wpf
                start = new Button()
                {
                    Margin = new Thickness(310, 0, 0, 0),
                    Height = 60,
                    Width = 120,
                    Content = "Start",
                    Background = new SolidColorBrush(Colors.LightSkyBlue),
                    BorderBrush = new SolidColorBrush(Colors.DeepSkyBlue),
                    BorderThickness = new Thickness(6),
                    //Style=sB
                };
                stop = new Button()
                {
                    Margin = new Thickness(440, 0, 0, 0),
                    Height = 60,
                    Width = 120,
                    Content = "Stop",
                    Background = new SolidColorBrush(Colors.LightSkyBlue),
                    BorderBrush = new SolidColorBrush(Colors.DeepSkyBlue),
                    BorderThickness = new Thickness(6),
                    IsEnabled = false,
                    //Style=sB
                };
                diffSlider = new Slider()
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
                txtDiff = new TextBlock
                {
                    Text = $"Difficulty: {diffSlider.Value}",
                    FontSize = 22,
                    FontWeight = FontWeights.Bold,
                    TextAlignment = TextAlignment.Center
                };
                countSlider = new Slider()
                {
                    Value = count,
                    TickFrequency = 10,
                    TabIndex = 1,
                    IsSnapToTickEnabled = true,
                    Minimum = 30,
                    Maximum = 170,
                    Margin = new Thickness(140, 30, 0, 0),
                    TickPlacement = TickPlacement.BottomRight,
                    Width = 140,
                    Height = 36
                };
                txtCount = new TextBlock
                {
                    Margin = new Thickness(150, 0, 0, 0),
                    Text = $"Count: {countSlider.Value}",
                    FontSize = 22,
                    FontWeight = FontWeights.Bold,
                    TextAlignment = TextAlignment.Center
                };
                txtcharInsec = new TextBlock
                {
                    Margin = new Thickness(790, 000, 0, 0),
                    Text = $"Characters in sec: ",
                    FontSize = 22,
                    FontWeight = FontWeights.Bold,
                    TextAlignment = TextAlignment.Center
                };
                txtFails = new TextBlock
                {
                    Margin = new Thickness(640, 000, 0, 0),
                    Text = $"Fails: ",
                    FontSize = 22,
                    FontWeight = FontWeights.Bold,
                    TextAlignment = TextAlignment.Center
                };
                void txtDiffChangingTxt(object sender, RoutedPropertyChangedEventArgs<double> e) => txtDiff.Text = "Difficulty: " + diffSlider.Value;
                void txtDiffChangingValue(object sender, RoutedPropertyChangedEventArgs<double> e) => difficulty = (int)diffSlider.Value;
                void txtCountChangingTxt(object sender, RoutedPropertyChangedEventArgs<double> e) => txtCount.Text = "Count: " + countSlider.Value;
                void txtCountChangingValue(object sender, RoutedPropertyChangedEventArgs<double> e) => count = (int)countSlider.Value;
                diffSlider.ValueChanged += txtDiffChangingTxt;
                diffSlider.ValueChanged += txtDiffChangingValue;
                countSlider.ValueChanged += txtCountChangingTxt;
                countSlider.ValueChanged += txtCountChangingValue;
                start.Click += startTraining;
                stop.Click += stopTraining;
                InputLanguageManager.SetInputLanguage(tB, new CultureInfo("en-US"));

            }
            void startTraining(object sender, RoutedEventArgs e)
            {
                MessageBox.Show("Train has been started");
                stop.IsEnabled = true;
                countSlider.IsEnabled = false;
                diffSlider.IsEnabled = false;
                start.IsEnabled = false;

                this.textToEnter = generateText(difficulty, count);
                str.Text = this.textToEnter;
                startTime = DateTime.Now;
                fails = 0;
                tB.Text = "";
                isStarted = true;
            }
            void stopTraining(object sender, RoutedEventArgs e)
            {
                diffSlider.IsEnabled = true;
                countSlider.IsEnabled = true;
                stop.IsEnabled = false;
                start.IsEnabled = true;
                str.Text = "Choose the difficulty level, number of characters and press start button";
                TimeSpan required = DateTime.Now - startTime;
                txtcharInsec.Text = $"Characters in sec: {Math.Round(count / required.TotalSeconds, 2, MidpointRounding.ToEven)}";
                txtFails.Text = $"Fails: {fails}";
                MessageBox.Show($"It required u " + Math.Round(required.TotalSeconds, 3, MidpointRounding.ToEven) + " secs to enter the text\nTotal fails:" + fails);
                isStarted = false;
            }
            public Canvas Show()
            {
                canvasToShow.Margin = new Thickness(10, 20, 0, 0);
                canvasToShow.Children.Clear();
                canvasToShow.Children.Add(start);
                canvasToShow.Children.Add(stop);
                canvasToShow.Children.Add(txtDiff);
                canvasToShow.Children.Add(txtCount);
                canvasToShow.Children.Add(diffSlider);
                canvasToShow.Children.Add(countSlider);
                canvasToShow.Children.Add(r);
                canvasToShow.Children.Add(str);
                canvasToShow.Children.Add(tB);
                canvasToShow.Children.Add(txtFails);
                canvasToShow.Children.Add(txtcharInsec);
                DependencyObject focusScope = FocusManager.GetFocusScope(tB);
                FocusManager.SetFocusedElement(focusScope, tB);
                return canvasToShow;
            }
            private void textChangedEventHandler(object sender, TextChangedEventArgs args)
            {
                var txt = (TextBox)sender;
                string textBoxText = txt.Text;
                if (!String.IsNullOrEmpty(textToEnter) && isStarted)
                {
                    if (textBoxText[textBoxText.Length - 1] != textToEnter[0])
                        fails++;
                    str.Text = textToEnter.Remove(0, 1);
                    textToEnter = textToEnter.Remove(0, 1);
                }
                else if (String.IsNullOrEmpty(textToEnter) && isStarted)
                {
                    stop.RaiseEvent(new RoutedEventArgs(ButtonBase.ClickEvent));
                    return;
                }
                if (!String.IsNullOrEmpty(textBoxText))
                {
                    foreach (KeyButton k in keys)
                        if (k.sym == textBoxText[textBoxText.Length - 1] || k.symUp == textBoxText[textBoxText.Length - 1])
                            k.isPressed = true;
                        else
                            k.isPressed = false;
                    myKb.UpdateKeys();
                }
            }
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
