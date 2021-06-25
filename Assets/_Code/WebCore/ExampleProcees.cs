using Data;
using UnityEngine;

namespace WebCore {
   public class ExampleProcees : HTTPRequest {
      public override void ProcessRequest(string text) {
         Hub.OnExampleRequest.Fire(text);
      }
      
   }
}