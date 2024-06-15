namespace TTT.Commands
{
    public class GameConfigSetAiCommand : ICommand
    {
        private readonly bool _isAiEnabled;

        public GameConfigSetAiCommand(bool isAiEnabled)
        {
            _isAiEnabled = isAiEnabled;
        }

        public bool CheckConditions()
        {
            return true;
        }

        public void Execute()
        {
            TTTCore.Instance.GameConfig.IsAiEnabled = _isAiEnabled;
        }
    }
}