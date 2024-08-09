using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;
using UnityEngine.InputSystem;

namespace MK.Game
{
    [ScriptExecutionOrder(-9999)]
    public class GameSceneInit : SceneInitBase
    {
        public GameField gameField;
        public PlayerInput playerInput;
        public PlayerController playerController;
        public CameraMain cameraMain;
        protected override void Awake()
        {
            base.Awake();
            ServiceLocator.Register<IGameField>(gameField);
            ServiceLocator.Register<PlayerInput>(playerInput);
            ServiceLocator.Register<PlayerController>(playerController);
            ServiceLocator.Register<CameraMain>(cameraMain);
        }
        protected override void SetRefs()
        {
            base.SetRefs();
            gameField = FindAnyObjectByType<GameField>();
            playerInput = FindAnyObjectByType<PlayerInput>();
            playerController = FindAnyObjectByType<PlayerController>();
            cameraMain = FindAnyObjectByType<CameraMain>();
        }
    }
}