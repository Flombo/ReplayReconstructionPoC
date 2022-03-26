using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference showReplayUIReference;
    private bool m_IsReplayMenuVisible;
    public GameObject replayMenu;
    // Start is called before the first frame update
    void Start()
    {
        showReplayUIReference.action.performed += OnShowReplayUI;
    }

    private void OnShowReplayUI(InputAction.CallbackContext obj)
    {
        replayMenu.SetActive(!m_IsReplayMenuVisible);
        m_IsReplayMenuVisible = !m_IsReplayMenuVisible;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
