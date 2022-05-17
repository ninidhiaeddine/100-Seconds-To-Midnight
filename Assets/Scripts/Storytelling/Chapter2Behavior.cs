using UnityEngine;

public class Chapter2Behavior : StateMachineBehaviour
{
    public ChapterScriptableObject chapterScriptableObject;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (ChapterSceneManager.Instance != null && ChapterSceneManager.Instance.chapter != chapterScriptableObject)
        {
            ChapterSceneManager.Instance.UpdateChapter(chapterScriptableObject);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneEndingManager.Instance.EndScene("Cutscene4");
    }
}
