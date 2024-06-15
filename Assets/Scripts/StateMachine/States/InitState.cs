using TTT.Utils;
using UnityEngine.SceneManagement;

namespace TTT.States
{
    public class InitState : State
    {
        public override void OnStateEnter()
        {
            SceneManager.LoadSceneAsync(Constants.SCENE_MENU_NAME);
        }

        public override bool IsStateActive()
        {
            return SceneManager.GetSceneByName(Constants.SCENE_INIT_NAME).isLoaded;
        }
    }
}