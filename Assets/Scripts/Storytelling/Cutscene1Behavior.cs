using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene1Behavior : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneEndingManager.Instance.sceneNameToLoad = "Cutscene1";
        SceneEndingManager.Instance.EndScene();
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
