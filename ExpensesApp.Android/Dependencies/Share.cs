using System;
using System.Threading.Tasks;
using ExpensesApp.Droid.Dependencies;
using ExpensesApp.Interfaces;
using Xamarin.Forms;

[assembly:Dependency(typeof(Share))] //#20
namespace ExpensesApp.Droid.Dependencies
{
    public class Share : IShare //#20
    {
        public async Task Show(string title, string message, string filePath)
        {
            
        }
    }
}
