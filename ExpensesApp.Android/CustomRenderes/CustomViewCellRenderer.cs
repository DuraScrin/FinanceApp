using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using ExpensesApp.Droid.CustomRenderes;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ViewCell), typeof(CustomViewCellRenderer))] //this line can be in one file (all exports in one file)
namespace ExpensesApp.Droid.CustomRenderes
{
    public class CustomViewCellRenderer : ViewCellRenderer //#17
    {
        private Android.Views.View _cell;
        private bool _isSelected;
        //private Drawable _defaultBackground; //when cell is not selected put it back to default

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            _cell = base.GetCellCore(item, convertView, parent, context);
            _isSelected = false;
            //_defaultBackground = _cell.Background;
            _cell.SetBackgroundColor(Android.Graphics.Color.Transparent); //this is fix

            return _cell;
        }

        //if property IsSelected is changed
        protected override void OnCellPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);

            if(e.PropertyName == "IsSelected")
            {
                _isSelected = !_isSelected;

                if (_isSelected)
                    _cell.SetBackgroundColor(Color.FromHex("#E6E6E6").ToAndroid());
                else
                    _cell.SetBackgroundColor(Android.Graphics.Color.Transparent);
            }
                
        }
    }
}
