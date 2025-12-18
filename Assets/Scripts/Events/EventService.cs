using Command.Actions;

namespace Command.Events
{
    public class EventService
    {
        public GameEventController<int> OnBattleSelected 
        { 
            get; 
            private set; 
        }

        public GameEventController<ActionType> OnActionSelected 
        { 
            get; 
            private set; 
        }

        public EventService()
        {
            OnBattleSelected = new GameEventController<int>();
            OnActionSelected = new GameEventController<ActionType>();
        }
    }
}