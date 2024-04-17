using Microsoft.AspNetCore.Mvc;
using OneSignal.Models;
using OneSignal.NotificationManager;

namespace OneSignal.Controllers {
    public class NotificationController:Controller {
        private readonly IConfiguration _configuration;

        public NotificationController(IConfiguration configuration) {
            _configuration = configuration;
        }

        public IActionResult Index() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(NotificationModel request) {
            Guid appId = Guid.Parse(_configuration.GetSection(AppSettingKey.OneSignalAppId).Value);
            string restKey = _configuration.GetSection(AppSettingKey.OneSignalRestKey).Value;

            string result = await OneSignalPushNotificationManager.OneSignalPushNotification(request,appId,restKey);
            return RedirectToAction("Index","Notification");
        }
    }
}
