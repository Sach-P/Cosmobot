using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDropDestroy : MonoBehaviour
{
    public int fallBoundry = -15;
    private float destroyTime = 10f;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= fallBoundry)
        {
            Destroy(gameObject);
        }
        Destroy(gameObject, destroyTime);
    }
}
