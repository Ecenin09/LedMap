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
      
      /// <summary>
      ///  Invoke after we got an information from ESP request
      /// </summary>
      public static readonly Signal<ESPResponse> OnESPRequest = new Signal<ESPResponse>();
      
      /// <summary>
      ///  Invoke after start search in local network needed device 
      /// </summary>
      public static readonly Signal FindDevices = new Signal();
      
      /// <summary>
      ///  Invoke when we start transmit date to ESP 
      /// </summary>
      /// TODO need add data for which device send this info ESPTransmit (Create something like Dictionary<key, ESPTransmit>)
      /// where "key" - is IP ESP 
      public static readonly Signal<ESPTransmit> OnTransmitData = new Signal<ESPTransmit>();
      
      /// <summary>
      ///  This data give us which element of map is using
      ///  Image - current element of map 
      /// </summary>
      public static readonly Signal<Image> ElementPick = new Signal<Image>();

      /// <summary>
      ///  We got this signal after parse local network end`s 
      /// </summary>
      public static readonly Signal ParseNetworkEnd = new Signal();

      /// <summary>
      ///  Example how we can transmit data which device was chose for rename in UI 
      /// </summary>
      public static readonly Signal<TMP_Text> DeviceChoose = new Signal<TMP_Text>();
      
      #endregion

      #region [UI Flow]
      /// <summary>
      ///  Invoke if have an error with request
      ///  string - message for show in popap
      /// </summary>
      public static readonly Signal<string> ShowErrorPopap = new Signal<string>();
      
      /// <summary>
      /// Fired when Lobby Screen should be displayed
      /// </summary>
      public static readonly Signal RequestLobbyTransition = new Signal();

      /// <summary>
      /// Fired when Control Panel for map should be displayed 
      /// </summary>
      public static readonly Signal PanelMapTransition = new Signal();

      #endregion

      #region [Profile]

      /// <summary>
      /// Fired when name value changes for choose device
      /// This example signal should invoke(fire) with data
      /// "string" - new name of device
      /// TODO creat subscriber where it needed to change data (if it need) - or just remove this; 
      /// </summary>
      public static readonly Signal<string> NameDeviceChanged = new Signal<string>();

      /// <summary>
      /// Fired when main device changed
      /// should fire if main device changed 
      /// </summary>
      public static readonly Signal<string> MainDeviceChanged = new Signal<string>();
      
      #endregion
      
   }
}