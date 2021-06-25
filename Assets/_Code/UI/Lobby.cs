using System.Collections;
using System.Collections.Generic;
using Data;
using UniRx;
using UnityEngine;

public class Lobby : MonoBehaviour
{
   [SerializeField]
   private GameObject _root = default;

   private void Start() {
      _root.SetActive(true);
      Hub.PanelMapTransition.Subscribe(x => { _root.SetActive(false); }).AddTo(this);
      Hub.RequestLobbyTransition.Subscribe(x => _root.SetActive(true)).AddTo(this);
   }
}
