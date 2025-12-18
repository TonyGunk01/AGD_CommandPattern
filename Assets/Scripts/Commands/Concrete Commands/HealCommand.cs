using Command.Main;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Commands
{
    public class HealCommand : MonoBehaviour
    {
        private bool willHitTarget;

        public HealCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.Heal).PerformAction(actorUnit, targetUnit, willHitTarget);
    }
}