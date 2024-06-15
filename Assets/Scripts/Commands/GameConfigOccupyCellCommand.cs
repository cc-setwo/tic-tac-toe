using System.Collections.Generic;

namespace TTT.Commands
{
    public class GameConfigOccupyCellCommand : ICommand
    {
        private readonly List<string> _occupiedCells;
        private readonly string _player;
        private readonly int _indexOnBoard;

        public GameConfigOccupyCellCommand(List<string> occupiedCells, string player, int indexOnBoard)
        {
            _occupiedCells = occupiedCells;
            _player = player;
            _indexOnBoard = indexOnBoard;
        }

        public bool CheckConditions()
        {
            return _occupiedCells == null || string.IsNullOrEmpty(_occupiedCells[_indexOnBoard]);
        }

        public void Execute()
        {
            _occupiedCells[_indexOnBoard] = _player;
        }
    }
}