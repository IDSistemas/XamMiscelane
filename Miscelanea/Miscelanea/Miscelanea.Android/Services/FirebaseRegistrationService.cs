using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Util;
using Firebase.Iid;
using Microsoft.WindowsAzure.MobileServices;
using WindowsAzure.Messaging;

namespace Miscelanea.Droid.Services
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class FirebaseRegistrationService : FirebaseInstanceIdService
    {
        const string TAG = "FirebaseRegistrationService";
        NotificationHub hub;
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "Refreshed token: " + refreshedToken);
            SendRegistrationTokenToAzureNotificationHub(refreshedToken);
        }

        void SendRegistrationTokenToAzureNotificationHub(string token)
        {
            // Update notification hub registration
            //Task.Run(async () =>
            //{
                //await AzureNotificationHubService.RegisterAsync(TodoItemManager.DefaultManager.CurrentClient.GetPush(), token);
                hub = new NotificationHub("MachSoftHub","Endpoint=sb://machsoft.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=Py4+oAL8yxBEuwU+7uKy/wS1c5ExAEBM6vYZKShm/+Y=", this);
                var tags = new List<string>() { };
                var reg = hub.Register(token, tags.ToArray());
            //});
        }
    }
}