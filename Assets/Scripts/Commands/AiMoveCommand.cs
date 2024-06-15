using System.Collections.Generic;
using TTT.Events;
using UnityEngine;

namespace TTT.Commands
{
    public class AiMoveCommand : ICommand
    {
        private readonly List<string> _occupiedCells;
        private readonly bool _isAiEnabled;
        
        public AiMoveCommand(List<string> occupiedCells, bool isAiEnabled)
        {
            _occupiedCells = occupiedCells;
            _isAiEnabled = isAiEnabled;
        }

        public bool CheckConditions()
        {
            return _isAiEnabled && _occupiedCells.Exists(string.IsNullOrEmpty);
        }

        public void Execute()
        {
            var freeIndexes = new List<int>();

            for (var i = 0; i < _occupiedCells.Count; i++)
            {
                if (string.IsNullOrEmpty(_occupiedCells[i]))
                {
                    freeIndexes.Add(i);
                }
            }
            
            var randomIndex = freeIndexes[Random.Range(0, freeIndexes.Count)];
            TTTCore.Instance.EventManager.Broadcast(new AiMoveEvent(randomIndex));
        }
    }
}