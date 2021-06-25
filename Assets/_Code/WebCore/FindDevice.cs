using System;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using UnityEngine.Networking;
using UnityEngine.PlayerLoop;
using Data;
using Data.RequestStruct;
using Profile;
using UniRx;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace WebCore {
   public class FindDevice : MonoBehaviour {

      private bool _isDone = false;
      
      
      private void Start() {
         Hub.FindDevices.Subscribe(x=>ParseESP()).AddTo(this);
      }

      

      private void ParseESP() { 
         string myIp = GetLocalIPAddress();
         if (myIp == null) {
            Hub.ShowErrorPopap.Fire("No network adapters with an IPv4 address in the system!");
            return;
         }
         string SplitIP = myIp;
         
         string[] SplitedIp = SplitIP.Split('.');
         
         for (int lowerIP = 0; lowerIP <= 255; lowerIP++) {
            if(lowerIP.Equals(SplitedIp[3])) return;
            
            string urlREquest = SplitedIp[0] + '.' + SplitedIp[1] + '.' + SplitedIp[2] + '.' + lowerIP + "/health";


            StartCoroutine(TryRequest(urlREquest));
            Debug.Log($"URL For Request to ESP: {urlREquest}");
         }
         
         Hub.ParseNetworkEnd.Fire();
      }

      private IEnumerator TryRequest(string ulrRequest) {
         using (UnityWebRequest request = UnityWebRequest.Get(ulrRequest)) {
            // Request and wait for the desired page.
            yield return request.SendWebRequest();

            _isDone = request.isDone;
            try {
               ESPResponse response = JsonUtility.FromJson<ESPResponse>(request.downloadHandler.text);
               PlayerProfile.ListDevice.Add(response.name, response);
            } catch (Exception e) {
               Debug.Log(e);
            } 
            switch (request.result) {
               case UnityWebRequest.Result.ConnectionError:
               case UnityWebRequest.Result.DataProcessingError:
                  Debug.LogError(ulrRequest + ": Error: " + request.error);
                  Hub.ShowErrorPopap.Fire(ulrRequest + ": Error: " + request.error);
                  break;
               case UnityWebRequest.Result.ProtocolError:
                  Debug.LogError(ulrRequest + ": HTTP Error: " + request.error);
                  Hub.ShowErrorPopap.Fire(ulrRequest + ": Error: " + request.error);
                  break;
               case UnityWebRequest.Result.Success:
                  Debug.Log(ulrRequest + ":\nReceived: " + request.downloadHandler.text);
                  break;
            }
         }
      }
      
      public string GetLocalIPAddress()
      {
         var host = Dns.GetHostEntry(Dns.GetHostName());
         foreach (var ip in host.AddressList)
         {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
               return ip.ToString();
            }
         }
         throw new System.Exception("No network adapters with an IPv4 address in the system!");
      }
      // private void SendRequest(string ulrRequest) {
      //    if (ulrRequest == null) return;
      //    UnityWebRequest request = UnityWebRequest.Get(ulrRequest);
      //    request.timeout = 2;
      //    request.SendWebRequest();
      //    while (!request.isDone||request.result!=UnityWebRequest.Result.Success) {
      //       Debug.Log($"Whait for response");
      //    }
      //    _isDone = request.isDone;
      //    if (request.result == UnityWebRequest.Result.ConnectionError) {
      //       Hub.ShowErrorPopap.Fire(request.error);
      //       return;
      //    }
      //
      // }
   }
}