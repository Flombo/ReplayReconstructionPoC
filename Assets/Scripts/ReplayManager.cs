using System.Collections.Generic;
using UnityEngine;
using DefaultNamespace;

public class ReplayManager : MonoBehaviour
{
    private List<ActionReplayRecord> m_ActionReplayRecords;
    private float m_CurrentReplayIndex;
    private bool m_ShouldStartReplay;
    private ReplayMenuController m_ReplayMenuController;

    private void Start()
    {
        m_ReplayMenuController = FindObjectOfType<ReplayMenuController>();
        m_ActionReplayRecords = new List<ActionReplayRecord>();
        StartCoroutine((MongoDBManager.Download(gameObject.name, result => 
        {
            m_ActionReplayRecords.AddRange(result);
            m_ShouldStartReplay = true;
        })));

        var rigidBody = GetComponent<Rigidbody>();
        if (rigidBody == null) return;
        rigidBody.isKinematic = true;
    }

    public void Update()
    {
        if (FindObjectOfType<PlayerController>().replayMenu.activeSelf)
        {
            if (m_ReplayMenuController.GetIsInReplayMode())
            {
                SetTransform(0);
            }
            else
            {
                SetTransform(m_ActionReplayRecords.Count - 1);
            }
        }
    }

    private void FixedUpdate()
    {
        if (!m_ShouldStartReplay && !FindObjectOfType<ReplayMenuController>().GetIsInReplayMode()) return;
        var nextIndex = m_CurrentReplayIndex + m_ReplayMenuController.GetReplayDirection() * m_ReplayMenuController.GetReplaySpeed();
        if (nextIndex < m_ActionReplayRecords.Count && nextIndex >= 0)
        {
            SetTransform(nextIndex);
        }
    }

    private void SetTransform(float index)
    {
        if(!m_ShouldStartReplay) return;
        m_CurrentReplayIndex = index;
        var actionReplayRecord = m_ActionReplayRecords[(int)index];
        var currentGameObject = gameObject;
        var gameObjectTransform = transform;
        gameObjectTransform.position = actionReplayRecord.position;
        gameObjectTransform.rotation = actionReplayRecord.rotation;
        currentGameObject.SetActive(actionReplayRecord.isActive);
    }
}
