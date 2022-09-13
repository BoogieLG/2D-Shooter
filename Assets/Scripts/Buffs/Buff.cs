using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    private float timeToDisappear =10f;

    private void FixedUpdate()
    {
        timeToDisappear -= Time.fixedDeltaTime;
        if (timeToDisappear <= 0f) Destroy(gameObject);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            doAction();
            Destroy(gameObject);
        }
    }
    protected virtual void doAction()
    {

    }
}
