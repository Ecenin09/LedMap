using System;
using System.Collections;
using Data;
using Data.RequestStruct;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

namespace WebCore {
   public class TransmitData : MonoBehaviour {
      [SerializeField]
      private string ulrRequest = "https://vivazzi.pro/test-request/";

      [SerializeField]
      private int _maxTimeRequest = 1000;
      

      private void Start() {
         Hub.OnTransmitData.Subscribe(x => Transmit(x)).AddTo(this);
      }
      
      private void Transmit(ESPTransmit data) {
         string jsonTransmit = JsonUtility.ToJson(data);
         UnityWebRequest request = new UnityWebRequest();
          request.timeout = _maxTimeRequest;
          request = UnityWebRequest.Put(ulrRequest, jsonTransmit);
          request.SetRequestHeader("Content-Type","application/json; charset=UTF-8");
          request.SendWebRequest();
         Hub.OnExampleRequest.Fire(jsonTransmit);
         while (!request.isDone) {
            Debug.Log($"Whait for response");
         }
         
         if (request.result == UnityWebRequest.Result.ConnectionError||request.result==UnityWebRequest.Result.DataProcessingError) {
            Hub.ShowErrorPopap.Fire(request.error);
         }
      }
   }
}