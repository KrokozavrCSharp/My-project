using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;

    private Cube _cube;

    private void Awake()
    {
        _cube= GetComponent<Cube>();
    }

    private void OnEnable()
    {
        _cube.Destroyed += Explode;
    }

    private void OnDisable()
    {
        _cube.Destroyed -= Explode;
    }

    private void Explode(Cube cube)
    {
        float force = _force / (cube.transform.localScale.x);
        float radius = _radius / (cube.transform.localScale.x);

        foreach (Rigidbody explodableObject in GetExplodableObject())
        {
            float distance = (cube.transform.position - explodableObject.transform.position).magnitude;;

            if(explodableObject!= cube.GetComponent<Rigidbody>())
                explodableObject.AddExplosionForce(force/distance, transform.position, radius);
        }
    }

    private List<Rigidbody> GetExplodableObject()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _radius);

        List<Rigidbody> boxes = new List<Rigidbody>();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
                boxes.Add(hit.attachedRigidbody);
        }

        return boxes;
    }
}
