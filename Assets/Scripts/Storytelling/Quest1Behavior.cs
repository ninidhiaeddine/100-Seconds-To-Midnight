using UnityEngine;

public class Quest1Behavior : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneEndingManager.Instance.EndScene("ChapterScene");
    }
}