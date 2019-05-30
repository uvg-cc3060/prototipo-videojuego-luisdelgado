using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongAttack : MonoBehaviour
{
	public float damageToDo = 30f;
    // Start is called before the first frame update
    void Start()
	{
		Destroy(gameObject, 0.5f);

	}

    // Update is called once per frame
    void Update()
	{
		transform.Translate(Vector3.forward * (2f / 0.5f) * Time.deltaTime);

	}
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "BasicEnemy")
		{
			Debug.Log("Hit Basic Enemy");
			col.gameObject.SendMessage("RecievedDamage", damageToDo);
		}
	}
}
