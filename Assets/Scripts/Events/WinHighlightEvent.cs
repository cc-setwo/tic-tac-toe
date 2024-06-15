using System.Collections.Generic;
using UnityEngine;

namespace TTT.Events
{
    public class WinHighlightEvent : IEvent
    {
        public List<int> WinIndexes { get; }
        public List<Vector3> WinWorldPositions { get; }

        public WinHighlightEvent(List<int> winIndexes,List<Vector3> winWorldPositions)
        {
            WinIndexes = winIndexes;
            WinWorldPositions = winWorldPositions;
        }
    }
}