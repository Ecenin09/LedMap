using System;
using Data;
using UnityEngine;
using UnityEngine.UI;

namespace Map {
[RequireComponent(typeof(Button))]
    public class MapElement : MonoBehaviour {
        [SerializeField]
        private Button _button = default;

        [SerializeField]
        private Image _image = default;
        private void Start() {
            
            _button.onClick.AddListener(OnClick);
        }

        private void OnClick() {
            Hub.ElementPick.Fire(_image);
        }
#if UNITY_EDITOR
        private void OnValidate() {
            if (_button == null) TryGetComponent(out _button);
            if (_image == null) TryGetComponent(out _image);
        }
#endif
    }
}
