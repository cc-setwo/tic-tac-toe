using System.Collections.Generic;

namespace TTT.Commands
{
    public class GameConfigInitCellsCommand : ICommand
    {
        private readonly int _cellsAmount;

        public GameConfigInitCellsCommand(int cellsAmount)
        {
            _cellsAmount = cellsAmount;
        }

        public bool CheckConditions()
        {
            return _cellsAmount > 0;
        }

        public void Execute()
        {
            TTTCore.Instance.GameConfig.OccupiedCells = new List<string>(new string[_cellsAmount]);
        }
    }
}