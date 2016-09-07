using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float frozenPercent;
    public bool inFreezer;
    public float meltFactor;
    public float freezeFactor;

    public float speed;
    public float jumpHeight;
    float xMovement;

    public Rigidbody2D _rb;



	// Use this for initialization
	void Start ()
    {
        _rb = GetComponent<Rigidbody2D>();
        frozenPercent = 100;
	}
	
	// Update is called once per frame
	void Update ()
    {
        xMovement = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        _rb.velocity = new Vector2(xMovement, 0);
        if(Input.GetKey("Z"))
        {
            if(isTouching().tag == "Ground")
            {

            }
        }
        
        

	    if(!inFreezer)
        {
            frozenPercent -= meltFactor * Time.deltaTime;
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Freezer")
        {
            frozenPercent += freezeFactor * Time.deltaTime;
        }

    }

    public GameObject isTouching()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, -transform.up, out hit, 1))
        {
            return hit.collider.gameObject;
        }
        return null;
    }
}
