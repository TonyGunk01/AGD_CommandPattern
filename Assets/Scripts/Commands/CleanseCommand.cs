using Command.Main;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    public class CleanseCommand : MonoBehaviour
    {
        private bool willHitTarget;

        public CleanseCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Cleanse).PerformAction(actorUnit, targetUnit, willHitTarget);
    }
}