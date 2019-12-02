﻿using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Rescues
{
    public sealed class GameController : MonoBehaviour
    {
        private GameStateController _activeController;

        #region Unity lifecycle

        private void Awake()
        {
        
        }

        private void Start()
        {
            _activeController = new GameSystemsController();
            _activeController.Initialize();
        }

        private void FixedUpdate()
        {
            _activeController.Execute(UpdateType.Fixed);
//        activeController.Cleanup(UpdateType.Fixed);
        }
          
        private void Update()
        {
            _activeController.Execute(UpdateType.Update);
//        activeController.Cleanup(UpdateType.Update);
        }

        private void LateUpdate()
        {
            _activeController.Execute(UpdateType.Late);
//        activeController.Cleanup(UpdateType.Update);
        }

        #if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            if (!EditorApplication.isPlaying)
            {
                return;
            }
            _activeController.Execute(UpdateType.Gizmos);
//        activeController.Cleanup(UpdateType.Gizmos);
        }

        #endif

        #endregion
    }
}
