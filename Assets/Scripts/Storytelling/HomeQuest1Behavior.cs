using UnityEngine;

public class HomeQuest1Behavior : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneEndingManager.Instance.EndScene("Home");
    }
}