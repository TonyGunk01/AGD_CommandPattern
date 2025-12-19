using Command.Actions;
using Command.Main;
using Command.Player;

namespace Command.Commands
{
    public class HealCommand : UnitCommand
    {
        private bool willHitTarget;

        public HealCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType((Actions.CommandType)CommandType.Heal).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override bool WillHitTarget() => true;

        public override void Undo()
        {
            if (willHitTarget)
            {
                targetUnit.TakeDamage(actorUnit.CurrentPower);
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