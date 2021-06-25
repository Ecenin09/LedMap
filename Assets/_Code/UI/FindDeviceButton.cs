using Data;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
   
   public class FindDeviceButton : MonoBehaviour {
      [SerializeField]
      private Button _button = default;
      
      
      private void Start() {
         _button.onClick.AddListener(StartFind);
         
      }

      public void StartFind() {
         Hub.FindDevices.Fire();
      }


#if UNITY_EDITOR
      private void OnValidate() {
         if (_button == null) TryGetComponent(out _button);
      }
#endif
   }
}