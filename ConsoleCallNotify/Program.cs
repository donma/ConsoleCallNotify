



using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace ConsoleCallNotify
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            new Microsoft.Toolkit.Uwp.Notifications.ToastContentBuilder()
                     .AddArgument("action", "viewConversation")
                     .AddArgument("conversationId", new Random().Next(1, 1000))
                     .AddText("Andrew sent you a picture")
                     .AddText("Check this out, The Enchantments in Washington!")
             .Show(); // Not seeing the Show() method? Make sure you have version 7.0, and if you're using .NET 6 (or later), then your TFM must be net6.0-windows10.0.17763.0 or greater

            GenerateToast("Console呼叫呼叫", AppDomain.CurrentDomain.BaseDirectory + "thumb.jpg", "這是主標題", "副標題", "內文內文內文內文內文內文內文內文內文");

            Console.ReadLine();
     
        }

        public static void GenerateToast(string appid, string imageFullPath, string h1, string h2, string p1)
        {

            var template = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText04);

            var textNodes = template.GetElementsByTagName("text");

            textNodes[0].AppendChild(template.CreateTextNode(h1));
            textNodes[1].AppendChild(template.CreateTextNode(h2));
            textNodes[2].AppendChild(template.CreateTextNode(p1));

            if (File.Exists(imageFullPath))
            {
                var toastImageElements = template.GetElementsByTagName("image");
                ((XmlElement)toastImageElements[0]).SetAttribute("src", imageFullPath);
            }
            IXmlNode toastNode = template.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "long");

            var notifier = ToastNotificationManager.CreateToastNotifier(appid);
            var notification = new ToastNotification(template);

            notifier.Show(notification);
        }
    }
}