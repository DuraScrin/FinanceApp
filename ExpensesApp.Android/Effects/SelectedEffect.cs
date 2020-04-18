using System;
using System.ComponentModel;
using Android.Graphics.Drawables;
using ExpensesApp.Droid.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ResolutionGroupName("DuraSoft")] //DuraSoft.SelectedEffect comes from shared SelectedEffect.cs
[assembly:ExportEffect(typeof(SelectedEffect), "SelectedEffect")] //comes from shared SelectedEffect.cs
namespace ExpensesApp.Droid.Effects //#27
{
    public class SelectedEffect : PlatformEffect 
    {
        Android.Graphics.Color selectedColor; //#28

        protected override void OnAttached()
        {
            selectedColor = new Android.Graphics.Color(176, 152, 164); //#28
        }

        //#28
        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            try
            {
                if (args.PropertyName == "IsFocused")
                {
                    if (((ColorDrawable)Control.Background).Color != selectedColor)
                        Control.SetBackgroundColor(selectedColor);
                    else
                        Control.SetBackgroundColor(Android.Graphics.Color.White);
                }
            }
            catch (InvalidCastException)
            {
                Control.SetBackgroundColor(selectedColor);
            }
            
        }

        protected override void OnDetached()
        {
            
        }
    }
}
