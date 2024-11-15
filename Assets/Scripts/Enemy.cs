using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent (typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    private Mover _target;

    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _agent.SetDestination(_target.transform.position);
    }

    public void Initialize(Mover target)
    {
        _target = target;
    }
}
