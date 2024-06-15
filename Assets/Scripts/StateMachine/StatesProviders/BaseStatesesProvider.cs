using System.Collections.Generic;

namespace TTT.States.StatesProviders
{
    public class BaseStatesesProvider : IStatesProvider
    {
        public List<StateTransition> GetStates()
        {
            var initState = new InitState();
            var mainMenuState = new MainMenuState();
            var gamePlayer1MoveState = new GamePlayer1MoveState();
            var gamePlayer2MoveState = new GamePlayer2MoveState();
            var gameFinishState = new GameFinishState();

            return new List<StateTransition>
            {
                new(initState, mainMenuState),
                new(mainMenuState, gamePlayer1MoveState),
                new(gamePlayer1MoveState, gameFinishState),
                new(gamePlayer2MoveState, gameFinishState),
                new(gamePlayer1MoveState, gamePlayer2MoveState),
                new(gamePlayer2MoveState, gamePlayer1MoveState),
                new(gameFinishState, mainMenuState),
            };
        }
    }
}