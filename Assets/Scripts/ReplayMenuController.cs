using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class ReplayMenuController : MonoBehaviour
{

    private bool m_IsInReplayMode;
    private float m_ReplayDirection;
    private float m_ReplaySpeed;
    public TMPro.TMP_Dropdown replaySpeedDropDown;

    public bool GetIsInReplayMode() => m_IsInReplayMode;
    public float GetReplayDirection() => m_ReplayDirection;
    public float GetReplaySpeed() => m_ReplaySpeed;

    public void OnStartReplayButtonClicked()
    {
        m_IsInReplayMode = true;
    }

    public void OnStopReplayButtonClicked()
    {
        m_IsInReplayMode = false;
    }

    public void OnForwardsReplayButtonClicked()
    {
        m_ReplayDirection = 1;
    }

    public void OnBackwardsReplayButtonClicked()
    {
        m_ReplayDirection = -1;
    }

    public void OnReplaySpeedChanged()
    {
        m_ReplaySpeed = replaySpeedDropDown.value switch
        {
            0 => 0.25f,
            1 => 0.5f,
            2 => 0.75f,
            3 => 1f,
            4 => 1.25f,
            5 => 1.5f,
            6 => 1.75f,
            _ => m_ReplaySpeed
        };
    }
    
}
