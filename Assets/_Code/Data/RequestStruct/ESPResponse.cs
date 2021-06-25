namespace Data.RequestStruct {
   [System.Serializable]
   public struct ESPResponse {
      
      public int returnValue;
      public int id;
      public string name;
      public string hardware;
      public bool isConnected; 

   }
}