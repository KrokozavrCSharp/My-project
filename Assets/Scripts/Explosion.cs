using System;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _force;
    [SerializeField] private Cube _cube;
    
    public event Action <Cube> Destroyed;

    private void OnMouseUpAsButton()
    {
        Destroyed?.Invoke(_cube);
        Destroy(gameObject);
        Explode();
    }

    private void Explode()
    {
        foreach(Rigidbody explodableObject in GetExplodableObject())
            explodableObject.AddExplosionForce(_force, transform.position, _radius);
    }

    private List<Rigidbody> GetExplodableObject()
    {
        Collider [] hits=Physics.OverlapSphere(transform.position, _radius);

        List<Rigidbody> boxes=new List<Rigidbody>();

        foreach (Collider hit in hits)
        {
            if(hit.attachedRigidbody!=null)
                boxes.Add(hit.attachedRigidbody);
        }

        return boxes;
    }
}
