using UnityEngine;

public class Cutscene1Behavior : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneEndingManager.Instance.EndScene("Home");
    }
}
