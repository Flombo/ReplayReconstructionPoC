using UnityEngine;

public class HandPresencePhysics : MonoBehaviour
{

    public Transform target;
    private Rigidbody m_Rb;
    public Renderer nonPhysicalHand;
    public float showNonPhysicalHandDistance = 0.05f;
    private Collider[] m_HandColliders;
    
    // Start is called before the first frame update
    private void Start()
    {
        m_Rb = GetComponent<Rigidbody>();
        m_HandColliders = GetComponentsInChildren<Collider>();
    }

    public void EnableHandCollider()
    {
        foreach (var handCollider in m_HandColliders)
        {
            handCollider.enabled = true;
        }
    }

    public void EnableHandColliderDelay(float delay)
    {
        Invoke("EnableHandCollider", delay);
    }
    
    public void DisableHandCollider()
    {
        foreach (var handCollider in m_HandColliders)
        {
            handCollider.enabled = false;
        }
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, target.position);
        
        nonPhysicalHand.enabled = distance > showNonPhysicalHandDistance;
    }

    // Update is called once per frame
    public void FixedUpdate()
    {
        m_Rb.velocity = (target.position - transform.position) / Time.fixedDeltaTime;

        var rotationDifference = target.rotation * Quaternion.Inverse(transform.rotation);
        rotationDifference.ToAngleAxis(out float angleInDegree, out Vector3 rotationAxis);

        var rotationDifferenceInDegree = angleInDegree * rotationAxis;

        m_Rb.angularVelocity = (rotationDifferenceInDegree * Mathf.Deg2Rad / Time.fixedDeltaTime);
    }
}
