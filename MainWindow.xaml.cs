using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace SolarSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly double[] rotationSpeed = { 0.5, 0.4, 0.09, 0.08, 0.03, 0.02, 0.01, 0.01 };

        private const int SunRadius = 130;
        private const int PlanetRadiusIncrement = 160;

        private int planetCount = 7;
        private double angle = 0;
        private readonly DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CreatePlanet();
            PlacePlanets();
            StartTimer();

            this.PreviewMouseWheel += MainWindow_PreviewMouseWheel;            
        }

        private void button_Start(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
        private void button_Stop(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void StartTimer()
        {
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            angle += 0.05;

            for (int i = 0; i < planetCount; i++)
            {
                double radius = SunRadius + (i + 1) * PlanetRadiusIncrement;
                double x = SunCanvas.ActualWidth / 2 + radius * Math.Cos(angle * (i + 1) * rotationSpeed[i]);
                double y = SunCanvas.ActualHeight / 2 + radius * Math.Sin(angle * (i + 1) * rotationSpeed[i]);
               
                Button planet = (Button)SunCanvas.Children[i];
                Canvas.SetLeft(planet, x - planet.Width / 2);
                Canvas.SetTop(planet, y - planet.Height / 2);
            }
        }

        private void CreatePlanet()
        {
            Button planet = new Button
            {
                Width = 20,
                Height = 20,                
            };
            planet.BorderThickness = new Thickness(0);            
            planet.Click += Planet_Click;
            Button planet1 = new Button
            {
                Width = 35,
                Height = 35,
            };
            planet1.BorderThickness = new Thickness(0);
            planet1.Click += Planet1_Click;
            Button planet2 = new Button
            {
                Width = 35,
                Height = 35,
            };
            planet2.BorderThickness = new Thickness(0);
            planet2.Click += Planet2_Click;
            Button planet3 = new Button
            {
                Width = 30,
                Height = 30,
            };
            planet3.BorderThickness = new Thickness(0);
            planet3.Click += Planet3_Click; ;
            Button planet4 = new Button
            {
                Width = 70,
                Height = 70,
            };
            planet4.BorderThickness = new Thickness(0);
            planet4.Click += Planet4_Click;
            Button planet5 = new Button
            {
                Width = 60,
                Height = 60,
            };
            planet5.BorderThickness = new Thickness(0);
            planet5.Click += Planet5_Click;
            Button planet6 = new Button
            {
                Width = 40,
                Height = 40,
            };
            planet6.BorderThickness = new Thickness(0);
            planet6.Click += Planet6_Click;
            Button planet7 = new Button
            {
                Width = 37,
                Height = 37,
            };
            planet7.BorderThickness = new Thickness(0);
            planet7.Click += Planet7_Click;

            {
                planet.Background = new ImageBrush(new BitmapImage(new Uri("D:\\c#-projects\\wpfapp\\SolarSystem\\SolarSystem\\Images\\mercury.png")));
                planet1.Background = new ImageBrush(new BitmapImage(new Uri("D:\\c#-projects\\wpfapp\\SolarSystem\\SolarSystem\\Images\\venus.png")));
                planet2.Background = new ImageBrush(new BitmapImage(new Uri("D:\\c#-projects\\wpfapp\\SolarSystem\\SolarSystem\\Images\\earth.png")));
                planet3.Background = new ImageBrush(new BitmapImage(new Uri("D:\\c#-projects\\wpfapp\\SolarSystem\\SolarSystem\\Images\\mars.png")));
                planet4.Background = new ImageBrush(new BitmapImage(new Uri("D:\\c#-projects\\wpfapp\\SolarSystem\\SolarSystem\\Images\\jupiter.png")));
                planet5.Background = new ImageBrush(new BitmapImage(new Uri("D:\\c#-projects\\wpfapp\\SolarSystem\\SolarSystem\\Images\\saturn.png")));
                planet6.Background = new ImageBrush(new BitmapImage(new Uri("D:\\c#-projects\\wpfapp\\SolarSystem\\SolarSystem\\Images\\uranus.png")));
                planet7.Background = new ImageBrush(new BitmapImage(new Uri("D:\\c#-projects\\wpfapp\\SolarSystem\\SolarSystem\\Images\\neptune.png")));
            }

            planetCount++;

            {
                SunCanvas.Children.Add(planet);
                SunCanvas.Children.Add(planet1);
                SunCanvas.Children.Add(planet2);
                SunCanvas.Children.Add(planet3);
                SunCanvas.Children.Add(planet4);
                SunCanvas.Children.Add(planet5);
                SunCanvas.Children.Add(planet6);
                SunCanvas.Children.Add(planet7);
            }
        }

        private void Sun_Star(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"Со́лнце — одна из звёзд нашей Галактики (Млечный Путь) и единственная звезда Солнечной системы. Вокруг Солнца обращаются другие объекты этой системы: планеты и их спутники, карликовые планеты и их спутники, астероиды, метеороиды, кометы и космическая пыль.
По спектральной классификации Солнце относится к типу G2V (жёлтый карлик). Средняя плотность Солнца составляет 1,4 г/см³ (в 1,4 раза больше, чем у воды). Эффективная температура поверхности Солнца — 5780 кельвин. Поэтому Солнце светит почти белым светом, но прямой свет Солнца у поверхности нашей планеты приобретает некоторый жёлтый оттенок из-за более сильного рассеяния и поглощения коротковолновой части спектра атмосферой Земли (при ясном небе, вместе с голубым рассеянным светом от неба, солнечный свет вновь даёт белое освещение).");
        }

        private void Planet7_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"Непту́н — восьмая и самая дальняя от Солнца планета Солнечной системы. Его масса превышает массу Земли в 17,2 раза и является третьей среди планет Солнечной системы, а по экваториальному диаметру Нептун занимает четвёртое место, превосходя Землю в 3,9 раза. Планета названа в честь Нептуна — римского бога морей.");
        }

        private void Planet6_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"Ура́н — планета Солнечной системы, седьмая по удалённости от Солнца, третья по диаметру и четвёртая по массе. Была открыта в 1781 году английским астрономом Уильямом Гершелем и названа в честь греческого бога неба Урана.
Уран стал первой планетой, обнаруженной в Новое время и при помощи телескопа. Его открыл Уильям Гершель 13 марта 1781 года, тем самым впервые со времён античности расширив границы Солнечной системы в глазах человека. Несмотря на то, что порой Уран различим невооружённым глазом, более ранние наблюдатели принимали его за тусклую звезду.");
        }

        private void Planet5_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"Сату́рн — шестая планета по удалённости от Солнца и вторая по размерам планета в Солнечной системе после Юпитера. Сатурн классифицируется как газовая планета-гигант. Сатурн назван в честь римского бога земледелия.Перейти к разделу «#Сатурн в культуре» Символ Сатурна — ♄.
В основном Сатурн состоит из водорода, с примесями гелия и следами воды, метана, аммиака и тяжёлых элементов. Внутренняя область представляет собой относительно небольшое ядро из железа, никеля и льда, покрытое тонким слоем металлического водорода и газообразным внешним слоем.Перейти к разделу «#Внутреннее строение» Внешняя атмосфера планеты кажется из космоса спокойной и однородной, хотя иногда на ней появляются долговременные образования.");
        }

        private void Planet4_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"Юпи́тер — крупнейшая планета Солнечной системы, пятая по удалённости от Солнца. Наряду с Сатурном Юпитер классифицируется как газовый гигант.Перейти к разделу «#Юпитер среди планет Солнечной системы»
Планета была известна людям с глубокой древности, что нашло своё отражение в мифологии и религиозных верованиях различных культур: месопотамской, вавилонской, греческой и других. Современное название Юпитера происходит от имени древнеримского верховного бога-громовержца.Перейти к разделу «#Название и история изучения»
Ряд атмосферных явлений на Юпитере — штормы,Перейти к разделу «#Движение атмосферы» молнии,Перейти к разделу «#Молнии» полярные сияния,Перейти к разделу «#Полярные сияния на Юпитере» — имеет масштабы, на порядки превосходящие земные. Примечательным образованием в атмосфере является Большое красное пятно — гигантский шторм, известный с XVII века.");
        }

        private void Planet3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"Марс — четвёртая по удалённости от Солнца и седьмая по размеру планета Солнечной системы; масса планеты составляет 10,7 % массы Земли.Перейти к разделу «#Основные сведения» Названа в честь Марса — древнеримского бога войны, соответствующего древнегреческому Аресу.Перейти к разделу «#В античной мифологии» Также Марс называют красной планетой из-за красноватого оттенка поверхности, придаваемого ей минералом маггемитом — γ-оксидом железа(III).");
        }

        private void Planet2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"Земля́ — третья по удалённости от Солнца планета Солнечной системы. Самая плотная, пятая по диаметру и массе среди всех планет Солнечной системы и крупнейшая среди планет земной группы, в которую входят также Меркурий, Венера и Марс. Единственное известное человеку в настоящее время тело во Вселенной, населённое живыми организмами.");
        }

        private void Planet1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"Венера — вторая планета Солнечной системы , названная в честь богини Венеры из римской мифологии . Это планета земной группы , очень близкая по размеру и общим качествам к Земле ; его иногда называют «планетой-сестрой Земли». Из всех планет Солнечной системы наименьший эксцентриситет орбиты имеет Венера , равный 0,7% (её орбита почти идеально круглая). Он делает один оборот вокруг Солнца за 224,7 земных дня.");            
        }

        private void Planet_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($@"Меркурий — самая маленькая планета Солнечной системы и самая близкая к Солнцу, вокруг которой он совершает один оборот каждые 87 969 земных суток. Орбита Меркурия имеет больший эксцентриситет , чем орбиты всех других планет Солнечной системы, а также планета имеет наименьший наклон оси.Через каждые два оборота вокруг Солнца он делает три оборота вокруг своей оси.Перигелий орбиты Меркурия прецессирует вокруг Солнца на дополнительные 43 угловых секунды за столетие, явление, объясненное только в 20 - м веке общей теорией относительности.");
        }

        private void PlacePlanets()
        {
            double radius = SunRadius;

            for (int i = 0; i < planetCount; i++)
            {
                double x = SunCanvas.ActualWidth / 2 + radius;
                double y = SunCanvas.ActualHeight / 2;

                Button planet = (Button)SunCanvas.Children[i];
                Canvas.SetLeft(planet, x - planet.Width / 2);
                Canvas.SetTop(planet, y - planet.Height / 2);

                radius += PlanetRadiusIncrement;
            }
        }

        private void MainWindow_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                var transform = MainGrid.LayoutTransform as ScaleTransform;
                if (transform == null)
                {
                    transform = new ScaleTransform(1, 1);
                    MainGrid.LayoutTransform = transform;
                }

                double scale = e.Delta > 0 ? 1.1 : 0.9;
                transform.ScaleX *= scale;
                transform.ScaleY *= scale;

                e.Handled = true;
            }
        }
    }
}
