using Command.Main;
using Command.Actions;

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
    }
}