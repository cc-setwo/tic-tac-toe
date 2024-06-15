using TTT.Commands;
using TTT.Utils;

namespace TTT.States
{
    public class GamePlayer2MoveState : GamePlayerMoveState
    {
        protected override string _playerPrefab => Constants.PLAYER2_PREFAB;

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            var occupiedCells = TTTCore.Instance.GameConfig.OccupiedCells;
            var isAiEnabled = TTTCore.Instance.GameConfig.IsAiEnabled;
            var aiMoveCommand = new AiMoveCommand(occupiedCells, isAiEnabled);

            TTTCore.Instance.CommandExecutor.ExecuteCommand(aiMoveCommand, true);
        }
    }
}