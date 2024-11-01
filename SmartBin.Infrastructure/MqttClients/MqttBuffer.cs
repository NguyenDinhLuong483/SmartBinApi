
namespace SmartBin.Infrastructure.MqttClients
{
    public class MqttBuffer
    {
        public List<TagChangedNotification> TagChangedForUser { get; set; } = new();
        public List<TagChangedNotification> TagChangedForAdmin { get; set; } = new();
        public MqttBuffer()
        {
        }

        public void Update(TagChangedNotification tagChangedNotification)
        {
            var isExist = TagChangedForAdmin.FirstOrDefault(x => x.Name == tagChangedNotification.Name);
            if (isExist is null)
            {
                TagChangedForAdmin.Add(tagChangedNotification);
                if(tagChangedNotification.Name == "FullLevel")
                {
                    TagChangedForUser.Add(tagChangedNotification);
                }
            }
            else
            {
                isExist.Value = tagChangedNotification.Value;
            }
        }
        public string GetTagsForUser() => System.Text.Json.JsonSerializer.Serialize(TagChangedForUser);
        public string GetTagsForAdmin() => System.Text.Json.JsonSerializer.Serialize(TagChangedForAdmin);
    }
}
