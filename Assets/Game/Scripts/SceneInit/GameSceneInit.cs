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
        public InputMain inputMain;
        public Level level;
        public GameConfig gameConfig;
        public GameManager gameManager;
        protected override void Awake()
        {
            base.Awake();
            ServiceLocator.Register<GameConfig>(gameConfig);
            ServiceLocator.Register<IGameField>(gameField);
            ServiceLocator.Register<PlayerInput>(playerInput);
            ServiceLocator.Register<PlayerController>(playerController);
            ServiceLocator.Register<CameraMain>(cameraMain);
            ServiceLocator.Register<IInputManager>(inputMain);
            ServiceLocator.Register<ILevel>(level);
            ServiceLocator.Register<IGameManager>(gameManager);
        }
        protected override void SetRefs()
        {
            base.SetRefs();
            gameField = FindAnyObjectByType<GameField>();
            playerInput = FindAnyObjectByType<PlayerInput>();
            playerController = FindAnyObjectByType<PlayerController>();
            cameraMain = FindAnyObjectByType<CameraMain>();
            inputMain = FindAnyObjectByType<InputMain>();
            level = FindAnyObjectByType<Level>();
            gameManager = FindAnyObjectByType<GameManager>();
        }
    }
}