using Data;
using Data.RequestStruct;
using UnityEngine;

namespace WebCore {
   public class ESPProcees : HTTPRequest {
      
      public override void ProcessRequest(string text) {
         ESPResponse response = JsonUtility.FromJson<ESPResponse>(text);
         Hub.OnESPRequest.Fire(response);
      }
   }
}