using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack1 : MonoBehaviour
{
	public float speed=8.0f;
	public float damageToDo = 15f;
    void Start()
    {
		Destroy(gameObject, 0.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Translate(Vector3.right * (2f/0.5f) * Time.deltaTime);
    }

	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "BasicEnemy"){
			Debug.Log("Hit Basic Enemy");
			col.gameObject.SendMessage("RecievedDamage", damageToDo);
		}
	}
}
