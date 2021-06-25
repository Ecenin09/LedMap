using System;
using Data;
using Data.RequestStruct;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
   [RequireComponent(typeof(Button))]
   public class SendData : MonoBehaviour {
      [SerializeField]
      private Button _button = default;

      private void Start() {
         _button.onClick.AddListener(StartTransmitData);
      }

      private void StartTransmitData() {
         //TODO collect data for transmit in this scope; 
         ESPTransmit data = new ESPTransmit(new ESPMetaData("data"), 1, 2, "hello");
         Hub.OnTransmitData.Fire(data);
      }
      
#if UNITY_EDITOR
      private void OnValidate() {
         if (_button == null) TryGetComponent(out _button);
      }
#endif
   }
}