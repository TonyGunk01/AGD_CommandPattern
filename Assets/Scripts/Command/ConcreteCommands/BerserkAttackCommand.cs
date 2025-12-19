using Command.Actions;
using Command.Main;
using Command.Player;
using UnityEngine;

namespace Command.Commands
{
    public class BerserkAttackCommand : UnitCommand
    {
        private bool willHitTarget;
        private const float hitChance = 0.66f;

        public BerserkAttackCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType((Actions.CommandType)CommandType.BerserkAttack).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override bool WillHitTarget() => Random.Range(0f, 1f) < hitChance;

        public override void Undo()
        {
            if (willHitTarget)
            {
                if (!targetUnit.IsAlive())
                    targetUnit.Revive();

                targetUnit.RestoreHealth(actorUnit.CurrentPower);
                actorUnit.Owner.ResetCurrentActiveUnit();
            }
        }

        public override void Revive()
        {
            SetAliveState(UnitAliveState.ALIVE);
            unitView.PlayAnimation(UnitAnimations.IDLE);
        }
    }
}
