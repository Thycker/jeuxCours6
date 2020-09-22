using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ennemie : MonoBehaviour, Dommageable
{
    int lifeTotal = 1;
    protected SoundPlayer soundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = GameObject.FindGameObjectWithTag("SoundPlayer").GetComponent<SoundPlayer>();
        EnnemiStart();
    }

    public abstract void EnnemiStart();

    public abstract void Die();

    // Update is called once per frame

    public void TakeDamage(int damage)
    {
        lifeTotal -= damage;
        if (lifeTotal <= 0)
        {
            Die();
        }
    }
}
