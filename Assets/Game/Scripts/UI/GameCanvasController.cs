using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public class GameCanvasController : MonoBehaviourBase
    {
        [SerializeField]
        private GameObject m_MainMenu;
        [SerializeField]
        private GameObject m_GameOverMenu;
        // Start is called before the first frame update
        void Start()
        {

        }
        private void OnEnable()
        {
            IGameManager gameManager = ServiceLocator.Resolve<IGameManager>();
            if (gameManager != null)
            {
                gameManager.OnGameOver += GameOverCallback;
            }
        }
        private void OnDisable()
        {
            IGameManager gameManager = ServiceLocator.Resolve<IGameManager>();
            if (gameManager != null)
            {
                gameManager.OnGameOver -= GameOverCallback;
            }
        }
        private void GameOverCallback()
        {
            m_MainMenu.SetActive(false);
            m_GameOverMenu.SetActive(true);
        }
    }
}