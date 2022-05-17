using UnityEngine;

public class Quest4Behavior : StateMachineBehaviour
{
    public QuestScriptableObject quest;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (QuestManager.Instance != null && QuestManager.Instance.currentActiveQuest == null)
        {
            QuestManager.Instance.currentActiveQuest = quest;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneEndingManager.Instance.EndScene("ChapterScene");
    }
}