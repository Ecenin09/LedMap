using System;
using System.Collections;
using Data;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


namespace WebCore {
    [RequireComponent(typeof(Button))]
    public abstract class HTTPRequest : MonoBehaviour{
        [SerializeField]
        public string ulrRequest = default;

        [SerializeField]
        private Button _button = default;

        private void Start() {
            _button.onClick.AddListener(SendRequest);
        }

        protected void SendRequest() {
            UnityWebRequest request = UnityWebRequest.Get(ulrRequest);

            request.SendWebRequest();
            while (!request.isDone) {
                Debug.Log($"Whait for response");
            }

            if (request.result == UnityWebRequest.Result.ConnectionError) {
                Hub.ShowErrorPopap.Fire(request.error);
            }
            
            Debug.Log($"Repsonse from {ulrRequest} : {request.downloadHandler.text}");
            ProcessRequest(request.downloadHandler.text);
        }
        /// <summary>
        /// Method for process request 
        /// </summary>
        public abstract void ProcessRequest(string text);
#if UNITY_EDITOR
        private void OnValidate() {
            if (_button == null) TryGetComponent(out _button);
        }
#endif
    }
}
