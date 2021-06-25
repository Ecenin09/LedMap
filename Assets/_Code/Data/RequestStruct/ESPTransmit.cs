namespace Data.RequestStruct {
   [System.Serializable]
   public struct ESPTransmit {
      public ESPMetaData metaData;
      public int numberPakage;
      public int timeZone;
      public string SomeData;

      public ESPTransmit(ESPMetaData metaData, int numberPakage, int timeZone, string SomeData) {
         this.metaData = metaData;
         this.numberPakage = numberPakage;
         this.timeZone = 0;
         this.SomeData = null;
      }
   }
}