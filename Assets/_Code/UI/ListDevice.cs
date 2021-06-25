using System;
using System.Collections.Generic;
using Data;
using Data.RequestStruct;
using Profile;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
   public class ListDevice : MonoBehaviour {
      [SerializeField]
      private Button _buttonPrefab = default;

      private List<Button> _buttonDivice = new List<Button>();
      
      
      private void Start() {
         Hub.ParseNetworkEnd.Subscribe(x=>UpdateList()).AddTo(this);
         UpdateList();
      }

      private void UpdateList() {
         if (_buttonDivice.Count > 0) {
            foreach (var button in _buttonDivice) {
               Destroy(button);
               _buttonDivice.Remove(button);
            }
         } 
         if(PlayerProfile.ListDevice != null)
         foreach (var device in PlayerProfile.ListDevice) {
            CreatButton(device.Key);
         }
      }

      private void CreatButton(string name) {
         Button currentButton;
         currentButton = Instantiate(_buttonPrefab, gameObject.transform,false);
         currentButton.name = name;
         _buttonDivice.Add(currentButton);
         //TODO implement logic for assigne map
      }
   }
}