using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float frozenPercent;
    public bool inFreezer;
    public float meltFactor;
    public float freezeFactor;

    public float speed;
    public float jumpHeight;



	// Use this for initialization
	void Start ()
    {
        frozenPercent = 100;
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(!inFreezer)
        {
            frozenPercent -= meltFactor * Time.deltaTime;
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Freezer")
        {
            frozenPercent += freezeFactor * Time.deltaTime;
        }
    }
}
