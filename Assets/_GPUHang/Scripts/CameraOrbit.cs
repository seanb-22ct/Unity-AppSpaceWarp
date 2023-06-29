using UnityEngine;
using UnityEngine.Assertions;

// Quick and dirty behavior that orbits the main camera around an object
public class CameraOrbit : MonoBehaviour
{
    private const float MaxTime = 5.0f;

    private Camera m_Camera;
    private float m_Radius;
    private float m_SpaceWarpTimer;

    public GameObject m_FocusGameObject;
    public float m_SpeedPerSecond = 10.0f;

    void Start()
    {
        Assert.IsNotNull(m_FocusGameObject);

        m_Camera = GetComponent<Camera>();
        Assert.IsNotNull(m_Camera);

        m_Radius = Vector3.Distance(m_FocusGameObject.transform.position, transform.position);

        OVRManager.SetSpaceWarp(true);
    }

    void LateUpdate()
    {
        float speed = m_SpeedPerSecond * Time.deltaTime;

        // Have the camera look at the focus object
        m_Camera.transform.LookAt(m_FocusGameObject.transform);

        // Move the camera along its local x-axis
        m_Camera.transform.transform.position += m_Camera.transform.right * speed;

        // Have the camera look at the focus object again
        m_Camera.transform.LookAt(m_FocusGameObject.transform);

        // Make sure the camera's orbit radius is reset
        m_Camera.transform.position = m_FocusGameObject.transform.position + m_Radius * -m_Camera.transform.forward;

        /*
        m_SpaceWarpTimer += Time.deltaTime; // for testing
        if (m_SpaceWarpTimer >= MaxTime)
        {
            m_SpaceWarpTimer = 0.0f;
            OVRManager.SetSpaceWarp(!OVRManager.GetSpaceWarp());
        }
        */
    }
}
