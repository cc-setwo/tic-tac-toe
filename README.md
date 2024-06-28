# tic-tac-toe
About code:
- Command pattern: used to execute pieces of code with pre execution conditions, example: FinishGameCommand if conditions are satisfied then the game is finished,
- Observer pattern: used to organize and centralize events and event subscribers into 1 place,
- State machine pattern: used to control states of application and separate logic among different states, example: if MainMenuState is active then we located
  in main menu and we should expect execution only of code that is related to main menu,
- Singleton pattern: used to organize and combine all services of application into one place and make them accessible from any place,
- Single responsibility principle: used among all the project, example: each state of the application is responsible only of its logic,
- Magic square: used to check whether the game is finished or not, link: https://mathworld.wolfram.com/MagicSquare.html,
- Addressables: used to load ui popups only when they are needed.

Project structure:
- Assets/Prefabs: used to store prefabs for the project, like: player's circle and cross objects, ui popups,
- Assets/Scenes: used to store scenes for the game,
- Assets/Scripts: used to store scripts.

All other folders are automatically generated due to using TextMeshPro, URP, Addressables, etc!

Activity diagram:

![activity_diagram](https://github.com/cc-setwo/tic-tac-toe/assets/20683443/044b00e3-7dfa-43ee-8eee-b238bcad420f)

## Showcase

____
- #### Player VS AI:
 ![player_vs_ai](https://github.com/cc-setwo/tic-tac-toe/assets/20683443/8de1c4da-a2f8-4aae-99cf-50aa4488e930)
____

- #### Player VS Player:
 ![player_vs_player](https://github.com/cc-setwo/tic-tac-toe/assets/20683443/62b5a34e-d353-4e22-a34e-33dd42e4cc4b)
____

