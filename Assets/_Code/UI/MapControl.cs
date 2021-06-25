using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class MapControl : MonoBehaviour {
   [SerializeField]
   private GameObject _root = default;

   [SerializeField]
   private Button _buttonToLobby = default;

   private void Start() {
      _root.SetActive(false);
      Hub.PanelMapTransition.Subscribe(x=>{_root.SetActive(true);}).AddTo(this);
      Hub.RequestLobbyTransition.Subscribe(x=>_root.SetActive(false)).AddTo(this);
      _buttonToLobby.onClick.AddListener(Hub.RequestLobbyTransition.Fire);
   }
}
