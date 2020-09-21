using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyControl : MonoBehaviour, Dommageable
{
    private GameObject player;
    private Rigidbody myRigidBody;
    public void TakeDamage(int damage)
    {
        Die();
    }

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position, 7 * Time.deltaTime));
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
