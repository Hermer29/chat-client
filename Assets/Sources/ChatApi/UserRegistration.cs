using System;
using ChatClient.ChatApi.Serialization;
using UnityEngine;
using UnityEngine.Networking;

namespace ChatClient.ChatApi
{
    internal class UserRegistration
    {
        public void Register(string userName, string color)
        {
            var deviceId = SystemInfo.deviceUniqueIdentifier;
            var registerJson = $"{{\"deviceId\": \"{deviceId}\", \"color\": \"{color}\", \"name\": \"{userName}\"}}";
            var url = Configurations.HttpServerUrl + "register";
            var request = UnityWebRequest.Get(url);
            var asyncRequest = request.SendWebRequest();
            while(asyncRequest.isDone == false)
            {
                    
            }
            var responseJson = request.downloadHandler.text;
            var deserialized = JsonUtility.FromJson<FaultableResult>(responseJson);
            AssertIsFaulted(deserialized);
        }

        public UserData RequestMyInformation()
        {
            var deviceId = SystemInfo.deviceUniqueIdentifier;
            var selfData = $"{{\"deviceId\": \"{deviceId}\"}}";
            var url = Configurations.HttpServerUrl + "me";
            var request = UnityWebRequest.Get(url);
            var asyncRequest = request.SendWebRequest();
            while(asyncRequest.isDone == false)
            {

            }
            var responseJson = request.downloadHandler.text;
            var deserialized = JsonUtility.FromJson<UserData>(responseJson);
            try
            {
                AssertIsFaulted(deserialized);  
            }
            catch (InvalidOperationException)
            {
                throw;
            }
            return deserialized;
        }

        private void AssertIsFaulted(FaultableResult result)
        {
            if (result.faulted)
                throw new InvalidOperationException($"Execution faulted by reason {result.reason}");
        }
    }
}
