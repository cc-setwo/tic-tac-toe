using TTT.Commands;
using TTT.Events;
using TTT.GameConfig;
using TTT.States;
using TTT.States.StatesProviders;
using TTT.Ui;
using TTT.Utils;

public class TTTCore : Singleton<TTTCore>
{
    public GameConfig GameConfig { get; private set; }
    public EventManager EventManager { get; private set; }
    public CommandExecutor CommandExecutor { get; private set; }
    public UiManager UiManager { get; private set; }
    public StateMachine StateMachine { get; private set; }

    public void Init()
    {
        GameConfig = new GameConfig();
        EventManager = new EventManager();
        CommandExecutor = new CommandExecutor();
        UiManager = new UiManager();
        StateMachine = new StateMachine(new BaseStatesesProvider());
    }

    private void Update()
    {
        StateMachine.OnUpdate();
    }
}
