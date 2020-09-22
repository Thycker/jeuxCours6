using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody myRigidBody;
    public int lifeSpan = 5;
    public int bulletVelocity = 4;
    public int bulletDamage = 1;
    private float timeLeftToLive;
    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        timeLeftToLive = lifeSpan;
        Destroy(gameObject, lifeSpan);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position += transform.forward * Time.deltaTime * bulletVelocity;
        myRigidBody.MovePosition(position);
    }

    private void OnTriggerEnter(Collider other)
    {
        Dommageable damageableObject = other.GetComponent<Dommageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDamage(1);
            Destroy(gameObject);
        }
    }
}
