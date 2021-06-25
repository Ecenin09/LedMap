using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using TMPro;
using UniRx;
using UnityEngine;

public class ShowRequestText : MonoBehaviour {
    [SerializeField]
    private TMP_Text _tmpText;
    void Start() {
        Hub.OnExampleRequest.Subscribe(data=>SetText(data)).AddTo(this);
    }

    private void SetText(string data) {
        _tmpText.text = data;
    }

#if UNITY_EDITOR
    private void OnValidate() {
        if (_tmpText == null) TryGetComponent(out _tmpText);
    }
#endif
}
