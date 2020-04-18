using System;
using System.Threading.Tasks;
using ExpensesApp.Interfaces;
using ExpensesApp.iOS.Dependencies;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly:Dependency(typeof(Share))] //#20
namespace ExpensesApp.iOS.Dependencies
{
    public class Share : IShare //#20 share file from iOS
    {
        public async Task Show(string title, string message, string filePath)
        {
            //#22
            var viewController = GetVisibleViewController();

            var items = new NSObject[] { NSObject.FromObject(title), NSUrl.FromFilename(filePath) };
            var activityController = new UIActivityViewController(items, null);

            if (activityController.PopoverPresentationController != null)
                activityController.PopoverPresentationController.SourceView = viewController.View;

            await viewController.PresentViewControllerAsync(activityController, true);
        }

        private UIViewController GetVisibleViewController() //#22 this will get page that currently is visible
        {
            var rootViewController = UIApplication.SharedApplication.KeyWindow.RootViewController;

            //we dont need null, navigationBar or tab
            if (rootViewController.PresentedViewController == null)
                return rootViewController;
            if (rootViewController.PresentedViewController is UINavigationController)
                return ((UINavigationController)rootViewController.PresentedViewController).TopViewController;
            if(rootViewController.PresentedViewController is UITabBarController)
                return ((UITabBarController)rootViewController.PresentedViewController).SelectedViewController;

            return rootViewController;
        }
    }
}
