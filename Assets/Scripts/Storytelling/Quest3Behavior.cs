using UnityEngine;

public class Quest3Behavior : StateMachineBehaviour
{
    public QuestScriptableObject quest;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (QuestManager.Instance != null && QuestManager.Instance.currentActiveQuest != quest)
        {
            QuestManager.Instance.currentActiveQuest = quest;
            QuestManager.QuestChangedEvent.Invoke();
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        SceneEndingManager.Instance.EndScene("Home");
    }
}