using UnityEngine;

public class PrologueBehavior : StateMachineBehaviour
{
    public ChapterScriptableObject prologueScriptableObject;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneEndingManager.Instance.EndScene("ChapterScene");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (ChapterSceneManager.Instance != null && ChapterSceneManager.Instance.chapter != prologueScriptableObject)
        {
            ChapterSceneManager.Instance.UpdateChapter(prologueScriptableObject);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
