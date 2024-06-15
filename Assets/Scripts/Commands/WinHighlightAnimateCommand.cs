using System;
using System.Collections;
using System.Collections.Generic;
using TTT.Events;
using TTT.Utils;
using UnityEngine;

namespace TTT.Commands
{
    public class WinHighlightAnimateCommand : ICommand
    {
        private readonly List<int> _winIndexes;
        private readonly Action _callback;

        public WinHighlightAnimateCommand(List<int> winIndexes, Action callback)
        {
            _winIndexes = winIndexes;
            _callback = callback;
        }

        public bool CheckConditions()
        {
            return _winIndexes != null && _winIndexes.Count >= Constants.WIN_POSITIONS_REQUIRED;
        }

        public void Execute()
        {
            var winnerHighlight = new GameObject().AddComponent<LineRenderer>();
            var winWorldPositions = new List<Vector3>();

            TTTCore.Instance.EventManager.Broadcast(new WinHighlightEvent(_winIndexes, winWorldPositions));

            var spritesDefaultMaterial = new Material(Shader.Find("Sprites/Default"));

            winnerHighlight.material = spritesDefaultMaterial;
            winnerHighlight.positionCount = _winIndexes.Count;
            winnerHighlight.startColor = Constants.WIN_START_COLOR;
            winnerHighlight.endColor = Constants.WIN_END_COLOR;
            winnerHighlight.sortingOrder = Constants.WIN_LAYER_ORDER;
            winnerHighlight.startWidth = winnerHighlight.endWidth = Constants.WIN_WIDTH;

            TTTCore.Instance.StartCoroutine(AnimateWinHighlight(winnerHighlight, winWorldPositions));
        }

        private IEnumerator AnimateWinHighlight(LineRenderer winnerHighlight, List<Vector3> winWorldPositions)
        {
            winnerHighlight.SetPosition(0, winWorldPositions[0]);
            winnerHighlight.SetPosition(1, winWorldPositions[0]);

            var startPos = winWorldPositions[0];
            var endPos = winWorldPositions[1];
            var timer = 0.0f;

            while (timer <= Constants.WIN_ANIMATION_DURATION)
            {
                var newPos = Vector3.Lerp(startPos, endPos, timer / Constants.WIN_ANIMATION_DURATION);

                winnerHighlight.SetPosition(1, newPos);
                timer += Time.deltaTime;

                yield return null;
            }

            yield return new WaitForSeconds(Constants.WIN_ANIMATION_DURATION);

            winnerHighlight.SetPosition(1, endPos);
            _callback.Invoke();
        }
    }
}