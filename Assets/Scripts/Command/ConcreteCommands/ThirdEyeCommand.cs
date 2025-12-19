using Command.Actions;
using Command.Main;
using Command.Player;

namespace Command.Commands
{
    public class ThirdEyeCommand : UnitCommand
    {
        private bool willHitTarget;

        public ThirdEyeCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Execute() => GameService.Instance.ActionService.GetActionByType((Actions.CommandType)CommandType.ThirdEye).PerformAction(actorUnit, targetUnit, willHitTarget);

        public override bool WillHitTarget() => true;

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
