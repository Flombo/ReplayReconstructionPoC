using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using DefaultNamespace;
using UnityEngine.InputSystem;

public class ReplayManager : MonoBehaviour
{
    private List<ActionReplayRecord> m_ActionReplayRecords = new List<ActionReplayRecord>();
    private bool m_IsInReplayMode;
    private Rigidbody m_RigidBody;
    private float currentReplayIndex;
    private float indexChangeRate;

    private void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        indexChangeRate = 0;
    }

    public void Update()
    {

        if (Input.GetKey(KeyCode.R))
        {
            m_IsInReplayMode = !m_IsInReplayMode;
            if (m_IsInReplayMode)
            {
                SetTransform(0);
                if (m_RigidBody == null) return;
                m_RigidBody.isKinematic = true;
            }
            else
            {
                SetTransform(m_ActionReplayRecords.Count - 1);
                if (m_RigidBody == null) return;
                m_RigidBody.isKinematic = false;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            indexChangeRate = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            indexChangeRate = -1;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            indexChangeRate *= 0.5f;
        }
    }

    private void FixedUpdate()
    {
        if (m_IsInReplayMode == false)
        {

            var currentGameObjectTransform = transform;

            m_ActionReplayRecords.Add(new ActionReplayRecord
            {
                position = currentGameObjectTransform.position,
                rotation = currentGameObjectTransform.rotation
            });
        }
        else
        {
            var nextIndex = currentReplayIndex + indexChangeRate;
            if (nextIndex < m_ActionReplayRecords.Count && nextIndex >= 0)
            {
                SetTransform(nextIndex);
            }
        }
    }

    private void SetTransform(float index)
    {
        currentReplayIndex = index;
        var actionReplayRecord = m_ActionReplayRecords[(int)index];
        var gameObjectTransform = transform;
        gameObjectTransform.position = actionReplayRecord.position;
        gameObjectTransform.rotation = actionReplayRecord.rotation;
    }
}
