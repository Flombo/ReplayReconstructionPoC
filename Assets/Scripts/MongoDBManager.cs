using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace DefaultNamespace
{
    public static class MongoDBManager
    {

        private static HttpClient _httpClient;

        public static void Init()
        {
            if (_httpClient == null)
            {
                _httpClient = new HttpClient();
            }
        }
        
        #region Download
        public static IEnumerator Download(string name, Action<List<ActionReplayRecord>> callback = null)
        {
            using var request = UnityWebRequest.Get("http://ee99945e-8c16-4dab-abfd-b04ec2178aac.fr.bw-cloud-instance.org/replays?name=" + name);
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
            {
                Debug.Log(request.error);
                callback?.Invoke(null);
            }
            else
            {
                callback?.Invoke(JsonConvert.DeserializeObject<List<ActionReplayRecord>>(request.downloadHandler.text));
            }
        }
        #endregion

        // #region RetrieveReplay
        //
        // public static async Task<List<ActionReplayRecord>> RetrieveReplay(string name)
        // {
        //     try
        //     {
        //         Init();
        //         var response = await _httpClient.GetAsync(new Uri("http://ee99945e-8c16-4dab-abfd-b04ec2178aac.fr.bw-cloud-instance.org/replays?name=" + name));
        //
        //         if (response.IsSuccessStatusCode)
        //         {
        //             var body = await response.Content.ReadAsStringAsync();
        //             var actionReplayRecords = JsonConvert.DeserializeObject<List<ActionReplayRecord>>(body);
        //             return actionReplayRecords;
        //         }
        //         else
        //         {
        //             throw new Exception(response.Content.ToString());
        //         }
        //     }
        //     catch (Exception exception)
        //     {
        //         Debug.Log(exception);
        //         return null;
        //     }
        // }
        // #endregion

    }
}