﻿
namespace SmartBin.Infrastructure.MqttClients
{
    public class MqttBuffer
    {
        public List<TagChangedNotification> TagChanged { get; set; } = new();
        private readonly ManagedMqttClient _mqttClient;

        public MqttBuffer(ManagedMqttClient mqttClient)
        {
            _mqttClient = mqttClient;
        }

        public void Update(TagChangedNotification tagChangedNotification)
        {
            var isExist = TagChanged.FirstOrDefault(x => x.Name == tagChangedNotification.Name);
            if (isExist is null)
            {
                TagChanged.Add(tagChangedNotification);
            }
            else
            {
                isExist.Value = tagChangedNotification.Value;
            }
        }
        public string GetAllTags() => System.Text.Json.JsonSerializer.Serialize(TagChanged);
    }
}
