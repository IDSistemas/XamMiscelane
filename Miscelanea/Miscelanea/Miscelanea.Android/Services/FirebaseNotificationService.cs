using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Support.V4.App;
using Android.Util;
using Firebase.Messaging;


namespace Miscelanea.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class FirebaseNotificationService : FirebaseMessagingService
    {
        const string TAG = "FirebaseNotificationService";
        int NOTIFICATION_ID = 234;
        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug(TAG, "From: " + message.From);
            if (message.Data["message"] != null)
            {
                //These is how most messages will be received
                
                SendNotification(message.Data["message"]);
            }
            else
            {
                //Only used for debugging payloads sent from the Azure portal
                SendNotification("No llego");

            }
        }

        void SendNotification(string messageBody)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);
            
            var notificationBuilder = new NotificationCompat.Builder(this, "push_notifications")
                .SetSmallIcon(Resource.Drawable.users)
                .SetContentTitle("New Push")
                .SetContentText(messageBody)
                .SetContentIntent(pendingIntent)
                .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Notification))
                .SetAutoCancel(true);

            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                /* Create or update. */
                NotificationChannel channel = new NotificationChannel("push_notifications",
                    "Push Notifications",
                    NotificationImportance.Default)
                {
                    Description = "Push Notifications"
                };
                notificationManager.CreateNotificationChannel(channel);
            }
            notificationManager.Notify(1, notificationBuilder.Build());

        }
    }
}