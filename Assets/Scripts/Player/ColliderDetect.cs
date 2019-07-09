using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDetect : MonoBehaviour
{
    [SerializeField] string enemyName;
    [SerializeField] string enemyTag;
    [SerializeField] GameObject explodeEffect;
    private void OnTriggerEnter(Collider other)
    {
        GameObject collidedGameObject = other.gameObject;
        if (collidedGameObject.tag == enemyTag)
        {
            Destroy();
        }
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
        GM.Instance.stats[enemyName] += 1;
        Instantiate(explodeEffect, transform.position, Quaternion.identity);
        //StopAllCoroutines();
        StartCoroutine(wait());
        
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        GM.ReloadScene();
    }
}
