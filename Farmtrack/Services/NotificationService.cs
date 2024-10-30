namespace Farmtrack.Services
{
    public class NotificationService
    {
        public string Message { get; private set; }
        public string Type { get; private set; }

        
        public void SetNotification(string message, string type)
        {
            Message = message;
            Type = type;
        }

        
        public string GetNotificationScript()
        {
            return $@"
            <script>
                document.addEventListener('DOMContentLoaded', function () {{
                    const notyf = new Notyf({{
                        duration: 5000,
                        dismissible: true,
                        position: {{ x: 'center', y: 'top' }} // Lägg till komma efter 'dismissible: true'
                    }});
                    notyf.{Type}('{Message}');
                }});
            </script>";
        }
    }
}
