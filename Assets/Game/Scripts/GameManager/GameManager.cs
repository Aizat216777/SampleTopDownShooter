using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MKSDK;

namespace MK.Game
{
    public class GameManager : MonoBehaviourBase, IGameManager
    {
        public event GameManagerEvents.SimpleEvent OnGameOver = delegate { };
        private void OnEnable()
        {
            PlayerController playerController = ServiceLocator.Resolve<PlayerController>();
            if (playerController != null)
            {
                playerController.Character.OnDied += PlayerDiedCallback;
            }
        }
        private void OnDisable()
        {
            PlayerController playerController = ServiceLocator.Resolve<PlayerController>();
            if (playerController != null)
            {
                playerController.Character.OnDied -= PlayerDiedCallback;
            }
        }
        private void PlayerDiedCallback(CharacterBase i_Character)
        {
            OnGameOver();
        }
    }
}