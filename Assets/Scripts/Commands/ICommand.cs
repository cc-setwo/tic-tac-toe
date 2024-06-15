namespace TTT.Commands
{
    public interface ICommand
    {
        public bool CheckConditions();
        public void Execute();
    }
}