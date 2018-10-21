using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godIhopethisworks : MonoBehaviour {
    public int speed;
    public float aliveTime;
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0, speed * Time.deltaTime, 0);
	}
    IEnumerator Start()
    {
        yield return new WaitForSeconds(aliveTime);
        Destroy(gameObject);
    }
}
