using UnityEngine;

public class Cutscene1Behavior : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneEndingManager.Instance.EndScene("Cutscene1");
    }
}
