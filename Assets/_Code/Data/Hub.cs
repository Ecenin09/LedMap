using Data.RequestStruct;
using SignalsFramework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Data {
   public static class Hub {
      #region [Program Flow]

      /// <summary>
      /// Example how manage data from response 
      /// </summary>
      public static readonly Signal<string> OnExampleRequest = new Signal<string>();
      
      public static readonly Signal<ESPResponse> OnESPRequest = new Signal<ESPResponse>();
      
      public static readonly Signal FindDevices = new Signal();

      public static readonly Signal<ESPTransmit> OnTransmitData = new Signal<ESPTransmit>();

      public static readonly Signal<Image> ElementPick = new Signal<Image>();

      public static readonly Signal ParseNetworkEnd = new Signal();

      public static readonly Signal<TMP_Text> DeviceChoose = new Signal<TMP_Text>();
      
      #endregion

      #region [UI Flow]

      public static readonly Signal<string> ShowErrorPopap = new Signal<string>();
      
      /// <summary>
      /// Fired when Lobby Screen should be displayed
      /// </summary>
      public static readonly Signal RequestLobbyTransition = new Signal();

      /// <summary>
      /// Fired when Control Panel for map shoud be displayed 
      /// </summary>
      public static readonly Signal PanelMapTransition = new Signal();

      #endregion

      #region [Profile]

      /// <summary>
      /// Fired when name value changes for choose device 
      /// </summary>
      public static readonly Signal<string> NameDeviceChanged = new Signal<string>();

      /// <summary>
      /// Fired when main device changed 
      /// </summary>
      public static readonly Signal<string> MainDeviceChanged = new Signal<string>();
      
      #endregion
      
   }
}