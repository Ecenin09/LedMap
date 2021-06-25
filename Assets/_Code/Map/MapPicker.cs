using System;
using Data;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Map {
   public class MapPicker : MonoBehaviour {

      [SerializeField]
      private FlexibleColorPicker _flexibleColorPicker = default;

      private Image _elementPick = default;
      private void Start() {
         Hub.ElementPick.Subscribe(data => { _elementPick = data; }).AddTo(this);
      }

      private void Update() {
         if(_elementPick==null) return;
         _elementPick.color = _flexibleColorPicker.color;
      }
   }
}
