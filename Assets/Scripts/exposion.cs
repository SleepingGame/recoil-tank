using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exposion : MonoBehaviour
{
    public int explosionTimer;

    private void Start()
    {
        StartCoroutine(ExplosionTimer());
    }
    public IEnumerator ExplosionTimer()
    {
        yield return new WaitForSeconds(explosionTimer);
        Destroy(this.gameObject);
    }

}
