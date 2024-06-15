using System.Collections.Generic;
using TTT.Commands;
using TTT.Events;
using TTT.Utils;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;

namespace TTT.States
{
    public abstract class GamePlayerMoveState : State, IEventSubscriber<OnCellClickedEvent>
    {
        protected abstract string _playerPrefab { get; }

        private Object _loadedPlayerPrefab;
        private bool _isMoveFinished;

        public override void OnStateEnter()
        {
            TTTCore.Instance.EventManager.Subscribe(this);
            _isMoveFinished = false;

            if (_loadedPlayerPrefab != null)
            {
                return;
            }

            var playerPrefabOp = Addressables.LoadAssetAsync<Object>(_playerPrefab);
            playerPrefabOp.WaitForCompletion();
            _loadedPlayerPrefab = playerPrefabOp.Result;
        }

        public override void OnStateExit()
        {
            TTTCore.Instance.EventManager.UnSubscribe(this);
            _isMoveFinished = false;
        }

        public override bool IsStateActive()
        {
            var occupiedCells = TTTCore.Instance.GameConfig.OccupiedCells;
            var finishGameCommand = new FinishGameCommand(occupiedCells,
                new List<string> { Constants.PLAYER1_PREFAB, Constants.PLAYER2_PREFAB });

            return SceneManager.GetSceneByName(Constants.SCENE_GAME_NAME).isLoaded &&
                   !finishGameCommand.CheckConditions() &&
                   !_isMoveFinished;
        }

        public void OnEvent(OnCellClickedEvent eventData)
        {
            var occupiedCells = TTTCore.Instance.GameConfig.OccupiedCells;
            
            var finishGameCommand = new FinishGameCommand(occupiedCells, _playerPrefab);

            if (finishGameCommand.CheckConditions())
            {
                return;
            }
            
            var occupyCellCommand =
                new GameConfigOccupyCellCommand(occupiedCells, _playerPrefab, eventData.IndexOnBoard);

            if (!occupyCellCommand.CheckConditions())
            {
                return;
            }

            TTTCore.Instance.CommandExecutor.ExecuteCommand(occupyCellCommand);
            Object.Instantiate(_loadedPlayerPrefab, eventData.ClickPos, Quaternion.identity);

            finishGameCommand = new FinishGameCommand(occupiedCells, _playerPrefab);

            TTTCore.Instance.CommandExecutor.ExecuteCommand(finishGameCommand, true);
            _isMoveFinished = true;
        }
    }
}