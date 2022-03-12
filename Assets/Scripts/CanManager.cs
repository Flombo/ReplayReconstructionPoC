using UnityEngine;

public class CanManager : MonoBehaviour
{

    public int canAmount;
    // Start is called before the first frame update
    private void Start()
    {
        canAmount = canAmount > 0 ? canAmount : 10;
    }
    
}
