using UnityEngine;

namespace Profile {
   /// <summary>
   /// Domain defined logic should be here.
   /// 
   /// Define properties, modify data loaded with postprocessing and apply versioning changes when needed.
   /// Or change existing ones to fit your needs.
   /// </summary>
   public static partial class PlayerProfile {
      //
      // Define logic related properties here
      //
      #region [Properties]
         
      #endregion


      /// <summary>
      /// Modify save file based on the version it was used on previously
      /// </summary>
      /// <remarks>Called after PostProcessLoadedData</remarks>
      private static void HandleVersioning() {
         int dataVersion = _data.Version;
         if (dataVersion == CurrentVersion) return;

         // Version changes can be implemented here //

         _data.Version = CurrentVersion;
      }
      
   }
}