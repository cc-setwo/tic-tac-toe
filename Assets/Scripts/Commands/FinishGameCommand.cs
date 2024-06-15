using System.Collections.Generic;
using TTT.Ui;
using TTT.Utils;

namespace TTT.Commands
{
    public class FinishGameCommand : ICommand
    {
        private readonly List<string> _occupiedPositions;
        private readonly List<string> _players;
        private readonly List<int> _winIndexes = new();

        private string _winner;

        public FinishGameCommand(List<string> occupiedPositions, List<string> players)
        {
            _occupiedPositions = occupiedPositions;
            _players = players;
        }

        public FinishGameCommand(List<string> occupiedPositions, string player) : this(occupiedPositions,
            new List<string> { player })
        {
        }

        public bool CheckConditions()
        {
            var magicSquare = Constants.MAGIC_SQUARE;
            var cellsAmount = Constants.CELLS_AMOUNT;

            for (var i = 0; i < cellsAmount; i++)
            {
                for (var j = 0; j < cellsAmount; j++)
                {
                    for (var k = 0; k < cellsAmount; k++)
                    {
                        if (i == j || i == k || j == k)
                        {
                            continue;
                        }

                        var playerToCheck = _players.Find(a => a == _occupiedPositions[i]);

                        if (string.IsNullOrEmpty(playerToCheck))
                        {
                            continue;
                        }

                        if (_occupiedPositions[i] == playerToCheck && _occupiedPositions[j] == playerToCheck &&
                            _occupiedPositions[k] == playerToCheck)
                        {
                            if (magicSquare[i] + magicSquare[j] + magicSquare[k] == Constants.MAGIC_SQUARE_SUM)
                            {
                                _winIndexes.Add(i);
                                _winIndexes.Add(k);
                                _winner = playerToCheck;
                                return true;
                            }
                        }
                    }
                }
            }

            return !_occupiedPositions.Exists(string.IsNullOrEmpty);
        }

        public void Execute()
        {
            var winHighlightAnimateCommand = new WinHighlightAnimateCommand(_winIndexes, OnWinHighlightAnimated);

            if (!winHighlightAnimateCommand.CheckConditions())
            {
                OnWinHighlightAnimated();
            }
            else
            {
                TTTCore.Instance.CommandExecutor.ExecuteCommand(winHighlightAnimateCommand);
            }
        }

        private async void OnWinHighlightAnimated()
        {
            var finishPopup = await TTTCore.Instance.UiManager.GetOrShowPopup<UiGameFinishPopup>();
            finishPopup.Init(_winner);
        }
    }
}