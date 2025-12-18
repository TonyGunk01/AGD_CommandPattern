using Command.Main;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Commands.Concrete_Commands
{
    public class BerserkAttackCommand : MonoBehaviour
    {
        private bool willHitTarget;

        public BerserkAttackCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override bool WillHitTarget() => true;

        public override void Execute() => GameService.Instance.ActionService.GetActionByType(CommandType.BerserkAttack).PerformAction(actorUnit, targetUnit, willHitTarget);
    }
}