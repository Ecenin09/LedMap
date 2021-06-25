using System;
using Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
   [RequireComponent(typeof(Button))]
   public class DeviceButton : MonoBehaviour {
      [SerializeField]
      private Button _button = default;
      
      
      private void Start() {
         
         // for open control panel for current device need invoke with some MetaData
         // something like that Hub.PanelMapTransition.Fire(MetaData)
         _button.onClick.AddListener(OnButtonClick);
      }

      private void OnButtonClick() {
         Hub.DeviceChoose.Fire(gameObject.GetComponentInChildren<TMP_Text>());
         Hub.PanelMapTransition.Fire();
      }
      
#if UNITY_EDITOR
      private void OnValidate() {
         if (_button == null) TryGetComponent(out _button);
      }
#endif
   }
}