using Command.Main;
using Command.Player;
using Command.Commands;
using Command.Actions;

namespace Command.Input
{
    public class InputService
    {
        private MouseInputHandler mouseInputHandler;

        private InputState currentState;
        private Commands.CommandType selectedCommandType;
        private TargetType targetType;

        public InputService()
        {
            mouseInputHandler = new MouseInputHandler(this);
            SetInputState(InputState.INACTIVE);
            SubscribeToEvents();
        }

        public void SetInputState(InputState inputStateToSet) => currentState = inputStateToSet;

        private void SubscribeToEvents() => GameService.Instance.EventService.OnActionSelected.AddListener(OnActionSelected);

        public void UpdateInputService()
        {
            if(currentState == InputState.SELECTING_TARGET)
                mouseInputHandler.HandleTargetSelection(targetType);
        }

        public void OnActionSelected(Commands.CommandType selectedActionType)
        {
            this.selectedCommandType = selectedActionType;
            SetInputState(InputState.SELECTING_TARGET);
            TargetType targetType = SetTargetType((Actions.CommandType)selectedActionType);
            ShowTargetSelectionUI(targetType);
        }

        private void ShowTargetSelectionUI(TargetType selectedTargetType)
        {
            int playerID = GameService.Instance.PlayerService.ActivePlayerID;
            GameService.Instance.UIService.ShowTargetOverlay(playerID, selectedTargetType);
        }

        private TargetType SetTargetType(Actions.CommandType selectedCommandType) => targetType = GameService.Instance.ActionService.GetTargetTypeForAction(selectedCommandType);

        public void OnTargetSelected(UnitController targetUnit)
        {
            SetInputState(InputState.EXECUTING_INPUT);
            UnitCommand commandToProcess = CreateUnitCommand(targetUnit);
            GameService.Instance.ProcessUnitCommand(commandToProcess);
        }

        private UnitCommand CreateUnitCommand(UnitController targetUnit)
        {

            CommandData commandData = CreateCommandData(targetUnit);

            switch (selectedCommandType)
            {
                case Commands.CommandType.Attack:
                    return new AttackCommand(commandData);
                case Commands.CommandType.Heal:
                    return new HealCommand(commandData);
                case Commands.CommandType.AttackStance:
                    return new AttackStanceCommand(commandData);
                case Commands.CommandType.Cleanse:
                    return new CleanseCommand(commandData);
                case Commands.CommandType.BerserkAttack:
                    return new BerserkAttackCommand(commandData);
                case Commands.CommandType.Meditate:
                    return new MeditateCommand(commandData);
                case Commands.CommandType.ThirdEye:
                    return new ThirdEyeCommand(commandData);
                default:
                    throw new System.Exception($"No Command found of type: {selectedCommandType}");
            }
        }

        private CommandData CreateCommandData(UnitController targetUnit)
        {
            return new CommandData(GameService.Instance.PlayerService.ActiveUnitID,
                                   targetUnit.UnitID,
                                   GameService.Instance.PlayerService.ActivePlayerID,
                                   targetUnit.Owner.PlayerID);
        }
    }
}