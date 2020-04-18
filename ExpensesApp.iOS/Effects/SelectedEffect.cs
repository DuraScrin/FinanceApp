using System;
using System.ComponentModel;
using ExpensesApp.iOS.Effects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

//#27
[assembly:ResolutionGroupName("DuraSoft")]
[assembly:ExportEffect(typeof(SelectedEffect), "SelectedEffect")]
namespace ExpensesApp.iOS.Effects //#27
{
    public class SelectedEffect : PlatformEffect
    {
        UIColor selectedColor; //#29

        protected override void OnAttached()
        {
            selectedColor = new UIColor(176.0f / 255, 152.0f / 255, 164.0f / 255, 255 / 255); //#29
        }
        //#29
        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if(args.PropertyName == "IsFocused")
            {
                if (Control.BackgroundColor != selectedColor)
                    Control.BackgroundColor = selectedColor;
                else
                    Control.BackgroundColor = UIColor.White;
            }
        }

        protected override void OnDetached()
        {
            
        }
    }
}
