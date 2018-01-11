using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UserNotifications;

using Foundation;
using UIKit;

namespace FoodStock01.iOS
{
    public class LocalNotificationCenterDelegate : UNUserNotificationCenterDelegate
    {
        #region Constructors
        public LocalNotificationCenterDelegate()
        {
        }
        #endregion

        #region Override Methods
        public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
        {
            // Do something with the notification
            Console.WriteLine("Active Notification: {0}", notification);

            // Tell system to display the notification anyway or use
            // `None` to say we have handled the display locally.
            completionHandler(UNNotificationPresentationOptions.Alert);
        }
        #endregion
    }
}