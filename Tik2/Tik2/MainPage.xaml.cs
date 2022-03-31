using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MediaManager;

namespace Tik2
{
    public partial class MainPage : ContentPage
    {
        Button uus_btn, kes_btn, tee_btn;
        ImageButton play_btn;
        Grid grid4X1, grid3X3;
        Image a;
        bool esi = false;
        int[,] T = new int[3, 3];
        public MainPage()
        {
            grid4X1 = new Grid
            {
                BackgroundColor = Color.LightBlue,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition{Height=new GridLength(3,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)},
                    new RowDefinition{Height=new GridLength(1,GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width=new GridLength(1,GridUnitType.Star)}
                }
            };
            uus_btn = new Button
            {
                Text = "Uss Mang"
            };
            uus_btn.Clicked += Uus_btn_Clicked;
            kes_btn = new Button
            {
                Text = "Kes on esimene"
            };
            kes_btn.Clicked += Kes_btn_Clicked;
            tee_btn = new Button
            {
                Text = "Teema"
            };
            play_btn = new ImageButton
            {
                Source = "play.png"
            };
            play_btn.Clicked += Play_btn_Clicked;
            grid4X1.Children.Add(uus_btn, 0, 1);
            grid4X1.Children.Add(kes_btn, 0, 2);
            grid4X1.Children.Add(play_btn, 0, 3);
            Content = grid4X1;
        }


        int o = 0;
        //00 10 20
        //01 11 21
        //02 12 22

        //00 01 02
        //10 11 12
        //20 21 22

        //00 11 22
        //02 11 20
        public int Kontroll()
        {
            if (T[0, 0] == 1 && T[1, 0] == 1 && T[2, 0] == 1 || T[0, 1] == 1 && T[1, 1] == 1 && T[2, 1] == 1 || T[0, 2] == 1 && T[1, 2] == 1 && T[2, 2] == 1)
            {
                o = 1;
            }
            else if (T[0, 0] == 1 && T[0, 1] == 1 && T[0, 2] == 1 || T[1, 0] == 1 && T[1, 1] == 1 && T[1, 2] == 1 || T[2, 0] == 1 && T[2, 1] == 1 && T[2, 2] == 1)
            {
                o = 1;
            }
            else if (T[0, 0] == 1 && T[1, 1] == 1 && T[2, 2] == 1 || T[0, 2] == 1 && T[1, 1] == 1 && T[2, 0] == 1)
            {
                o = 1;
            }
            else if (T[0, 0] == 2 && T[1, 0] == 2 && T[2, 0] == 2 || T[0, 1] == 2 && T[1, 1] == 2 && T[2, 1] == 2 || T[0, 2] == 2 && T[1, 2] == 2 && T[2, 2] == 2)
            {
                o = 2;
            }
            else if (T[0, 0] == 2 && T[0, 1] == 2 && T[0, 2] == 2 || T[1, 0] == 2 && T[1, 1] == 2 && T[1, 2] == 2 || T[2, 0] == 2 && T[2, 1] == 2 && T[2, 2] == 2)
            {
                o = 2;
            }
            else if (T[0, 0] == 2 && T[1, 1] == 2 && T[2, 2] == 2 || T[0, 2] == 2 && T[1, 1] == 2 && T[2, 0] == 2)
            {
                o = 2;
            }
            else if (T[0, 0] != 0 && T[0, 1] != 0 && T[0, 2] != 0 && T[1, 0] != 0 && T[1, 1] != 0 && T[1, 2] != 0 && T[2, 0] != 0 && T[2, 1] != 0 && T[2, 2] != 0)
            {
                o = 3;
            }
            return o;
        }

        public void Lopp()
        {
            o = Kontroll();
            if (o == 1)
            {
                DisplayAlert("Võit", "Esimine on voitja", "Ok");
            }
            else if (o == 2)
            {
                DisplayAlert("Võit", "Teine on voitja", "Ok");
            }
            else if (o == 3)
            {
                DisplayAlert("Võit", "Viik", "Ok");
            }
        }

        private async void Kes_btn_Clicked(object sender, EventArgs e)
        {
            string e_valik = await DisplayPromptAsync("Kes on esimene", "Tee oma valik 1-cross,2-round", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (e_valik == "1")
            {
                esi = true;
            }
            else
            {
                esi = false;
            }
        }

        public async void Kes_esm()
        {
            string e_valik = await DisplayPromptAsync("Kes on esimene", "Tee oma valik 1-cross,2-round", initialValue: "1", maxLength: 1, keyboard: Keyboard.Numeric);
            if (e_valik == "1")
            {
                esi = true;
            }
            else
            {
                esi = false;
            }
        }

        public IList<string> Mp3List => new[]
        {
            "https://retrowave.ru/"
        };

        //public Media_Page()
        //{
        //    InitializeComponent();
        //
        //}
        private async void Play_btn_Clicked(object sender, EventArgs e)
        {
            await CrossMediaManager.Current.Play(Mp3List);
        }


        private void Uus_btn_Clicked(object sender, EventArgs e)
        {
            Kes_esm();
            Uss_mang();
        }

        public void Uss_mang()
        {
            grid3X3 = new Grid
            {
                BackgroundColor = Color.Violet,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                    new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },
            };
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    a = new Image { Source = "white.png" };
                    grid3X3.Children.Add(a, j, i);
                    TapGestureRecognizer tap = new TapGestureRecognizer();
                    tap.Tapped += Tap_Tapped;
                    a.GestureRecognizers.Add(tap);
                    T[j, i] = 0;
                    o = 0;
                }
            }
            grid4X1.Children.Add(grid3X3, 0, 0);
        }

        private void Tap_Tapped(object sender, EventArgs e)
        {
            var a = (Image)sender;
            var r = Grid.GetRow(a);
            var c = Grid.GetColumn(a);
            if (esi)
            {
                a.Source = "cross.png";
                esi = false;
                T[r, c] = 1;
            }
            else
            {
                a.Source = "round.png";
                esi = true;
                T[r, c] = 2;
            }
            Lopp();

        }
    }
}
