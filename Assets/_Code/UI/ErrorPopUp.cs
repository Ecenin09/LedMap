using System;
using Data;
using SignalsFramework;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
   public class ErrorPopUp : MonoBehaviour {
      [SerializeField]
      private Button _closeButton = default;

      [SerializeField]
      private GameObject _root = default;

      [SerializeField]
      private TMP_Text _textField = default;

      #region [Signals]

      private static readonly Signal Close = new Signal();

      #endregion
      
      private void Start() {
         Hub.ShowErrorPopap.Subscribe(dataText => Show(dataText)).AddTo(this);
         _closeButton.onClick.AddListener(ClosePopap);
         Close.Subscribe(x=>{_root.SetActive(false);}).AddTo(this);

      }

      private void ClosePopap() {
         Close.Fire();
      } 
      private void Show(string textError) {
         _textField.text = textError;
         _root.SetActive(true);
      }
   }
}