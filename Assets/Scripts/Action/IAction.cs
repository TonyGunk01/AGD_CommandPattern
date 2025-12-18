using Command.Input;
using Command.Player;
using UnityEngine;

namespace Command.Actions
{
    public interface IAction
    {
        public TargetType TargetType 
        { 
            get; 
        }

        public void PerformAction(UnitController actorUnit, UnitController targetUnit);

        public bool IsSuccessful();

        public Vector3 CalculateMovePosition(UnitController targetUnit);
    } 
}