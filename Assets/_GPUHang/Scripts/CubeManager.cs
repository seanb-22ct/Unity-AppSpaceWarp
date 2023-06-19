using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;

// Simple debugging tool that enables our cubes one by one over time
// Once the second cube becomes visible we should get a GPU hang
public class CubeManager : MonoBehaviour
{
    public MeshRenderer m_CubeMeshRenderer1;
    public MeshRenderer m_CubeMeshRenderer2;

    private void Start()
    {
        Assert.IsNotNull(m_CubeMeshRenderer1);
        Assert.IsNotNull(m_CubeMeshRenderer2);

        m_CubeMeshRenderer1.enabled = true;
        m_CubeMeshRenderer2.enabled = false;

        StartCoroutine(StateMachine());
    }

    private IEnumerator StateMachine()
    {
        yield return new WaitForSeconds(3.0f);
        m_CubeMeshRenderer2.enabled = true;
    }
}
