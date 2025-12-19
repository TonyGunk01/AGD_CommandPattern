using Command.Main;
using Command.Actions;

namespace Command.Commands
{
    public class MeditateCommand : UnitCommand
    {
        private bool willHitTarget;
        private int previousMaxHealth;

        public MeditateCommand(CommandData commandData)
        {
            this.commandData = commandData;
            willHitTarget = WillHitTarget();
        }

        public override void Execute()
        {
            previousMaxHealth = targetUnit.CurrentMaxHealth;
            GameService.Instance.ActionService.GetActionByType(Command.Actions.CommandType.Meditate).PerformAction(actorUnit, targetUnit, willHitTarget);
        }

        public override void Undo()
        {
            if (willHitTarget)
            {
                var healthToReduce = targetUnit.CurrentMaxHealth - previousMaxHealth;
                targetUnit.CurrentMaxHealth = previousMaxHealth;
                targetUnit.TakeDamage(healthToReduce);
            }
            actorUnit.Owner.ResetCurrentActiveUnit();
        }

        public override bool WillHitTarget() => true;
    }
}
