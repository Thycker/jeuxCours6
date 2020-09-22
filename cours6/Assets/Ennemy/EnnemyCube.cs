using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyCube : Ennemie
{
    private GameObject player;
    private Rigidbody myRigidBody;
    public audioMusic audioMusic;
    public GameObject deathParticle;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        myRigidBody.MovePosition(Vector3.MoveTowards(transform.position, player.transform.position, 7 * Time.deltaTime));
    }

    public override void EnnemiStart()
    {
        myRigidBody = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Die()
    {
        soundPlayer.PlayMusic(audioMusic);
        Instantiate(deathParticle, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
