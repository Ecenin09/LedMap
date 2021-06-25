using Data;
using Profile;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
   [RequireComponent(typeof(Button))]
   public class RenameButton : MonoBehaviour {
      [SerializeField]
      private Button _button = default;

      [SerializeField]
      private TMP_InputField _inputField = default;
      

      private TMP_Text _placeHolderInformationAboutMap = default;
      
      private void Start() {
         _button.onClick.AddListener(Rename);
         Hub.DeviceChoose.Subscribe(x => {
            //TODO implement get data choosen device 
            Debug.Log(x);
            _placeHolderInformationAboutMap = x;
            //or some key for find needed map
            name = "ChekName";
         }).AddTo(this);
      }

      private void Rename() {
         if (_placeHolderInformationAboutMap != null) {
            _placeHolderInformationAboutMap.text = _inputField.text;
         }
         if (PlayerProfile.ListDevice != null) {
            var espResponse = PlayerProfile.ListDevice[name];
            espResponse.name = _inputField.text;
            PlayerProfile.ListDevice[name] = espResponse;
         }
      }


#if UNITY_EDITOR
      private void OnValidate() {
         if (_button == null) TryGetComponent(out _button);
      }
#endif
   }
}