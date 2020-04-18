using System;
using System.Threading.Tasks;
using Android.Content;
using Android.Support.V4.Content;
using ExpensesApp.Droid.Dependencies;
using ExpensesApp.Interfaces;
using Xamarin.Forms;

[assembly:Dependency(typeof(Share))] //#20
namespace ExpensesApp.Droid.Dependencies
{
    public class Share : IShare //#20
    {
        public Task Show(string title, string message, string filePath)
        {
            //#23 in AndroidManifest ReadExternal, WriteExternal permissions
            var intent = new Intent(Intent.ActionSend); //Intent.ActionSend = we want to send
            intent.SetType("text/plain"); //ex: application/pdf

            //create xml folder in Resources & file_provider_paths.xml
            //in AndroidManifest (need to see video #23)
            var documentsUri = FileProvider.GetUriForFile(Forms.Context.ApplicationContext, "net.durasoft.expensesapp.provider", new Java.IO.File(filePath));

            //send document
            intent.PutExtra(Intent.ExtraStream, documentsUri);
            intent.PutExtra(Intent.ExtraText, title);
            intent.PutExtra(Intent.ExtraSubject, message);

            //create the view
            var chooserIntent = Intent.CreateChooser(intent, title);
            chooserIntent.AddFlags(ActivityFlags.NewTask);//fix
            //hooserIntent.AddFlags(ActivityFlags.MultipleTask);
            //chooserIntent.SetFlags(ActivityFlags.GrantReadUriPermission);

            //start activity
            Android.App.Application.Context.StartActivity(chooserIntent);

            return Task.FromResult(true);
        }
    }
}
