using System;
using System.Collections.Generic;
using Data.RequestStruct;


namespace Profile {
   /// <summary>
   /// Data that will be saved for the current player progress
   /// </summary>
   [Serializable]
   public class UserData {
      /// <summary>
      /// Should be used for versioning checks and changes only
      /// </summary>
      public int Version;

      public string CurrentDevice; 
      public Dictionary<string,ESPResponse> ListDevice;

   }
}