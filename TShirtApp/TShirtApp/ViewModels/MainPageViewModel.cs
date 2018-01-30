using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using XLabs.Forms.Behaviors;

namespace TShirtApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "T-Shirt Designer";

            Left = new RelayGesture((g, x) =>
            {
                Console.WriteLine("Left ....");
                IsBlackVisible = !IsBlackVisible;
                IsOrangeVisible = !IsOrangeVisible;
            }
            );

            Right = new RelayGesture((g, x) =>
                        {
                            Console.WriteLine("Right ....");
                            IsBlackVisible = !IsBlackVisible;
                            IsOrangeVisible = !IsOrangeVisible;
                        }
            );


            DoubleTap = new RelayGesture((g, x) => { 
                Console.WriteLine("End of MOVEMENT .....");
                IsSunVisible = false;
                IsTreeVisible = false;
                IsDragStarted = false;
            });
            LongPress = new RelayGesture((g, x) =>
            {
                Console.WriteLine("Long Press ....... {0}", x);
                IsDragStarted = true;

                if (x.ToString() == "SUN") { IsSunVisible = true; IsTreeVisible = false; }
                if (x.ToString() == "TREE") { IsTreeVisible = true; IsSunVisible = false; }


            });

            Movement = new RelayGesture((g, x) => {
                if (!isDragStarted) return;
                Console.WriteLine("Movement .... ");
            switch (g.GestureType)
            {
                case XLabs.Forms.Controls.GestureType.Move:
                        var newP = g.Origin2;
                        var p = g.Origin;

                        //Type t = g.GetType();
                        //PropertyInfo[] props = t.GetProperties();
                        //double verticalDistance = (double)props.First((prop) => prop.Name == "VerticalDistance").GetValue(g);
                        //double horizontalDistance = (double)props.First((prop) => prop.Name == "HorizontalDistance").GetValue(g);


                        var xDelta = /* g.UbkHorizontalDistance(); */   p.X - newP.X;
                        var yDelta = /* g.UbkVerticalDistance(); */ p.Y - newP.Y;
                        Console.WriteLine("  old POINT -> {0}   new POINT -> {1}", p.ToString(), newP.ToString());

                        MarginTopLeft = new Thickness(MarginTopLeft.Left + (xDelta / 8), MarginTopLeft.Top + (yDelta / 8), 0, 0);
                    
                    Console.WriteLine(MarginTopLeft.Top.ToString());

                    break;
                }
            });

            MarginTopLeft = new Thickness(300, 100, 0, 0);

            IsBlackVisible = true;
            IsOrangeVisible = false;
            IsDragStarted = false;

            IsSunVisible = false;
            isTreeVisible = false;
        }

        private bool isDragStarted;
        public bool IsDragStarted {  get { return isDragStarted; } set { SetProperty(ref isDragStarted, value);  } }

        private bool isSunVisible = false;
        public bool IsSunVisible { get { return isSunVisible; } set { SetProperty(ref isSunVisible, value); } }

        private bool isTreeVisible = false;
        public bool IsTreeVisible { get { return isTreeVisible; } set { SetProperty(ref isTreeVisible, value); } }

        private bool isBlackVisible = false;
        public bool IsBlackVisible { get { return isBlackVisible; } set { SetProperty(ref isBlackVisible, value); } }

        private bool isOrangeVisible = false;
        public bool IsOrangeVisible { get { return isOrangeVisible; } set { SetProperty(ref isOrangeVisible, value); } }

        public RelayGesture Left { get; private set; }
        public RelayGesture Right { get; private set; }

        public RelayGesture LongPress { get; private set; }

        public RelayGesture Movement { get; private set; }

        public RelayGesture DoubleTap { get; private set; }


        private Thickness marginTopLeft;
        public Thickness MarginTopLeft { get { return marginTopLeft; } set { SetProperty(ref marginTopLeft, value); } } 

    }
}
