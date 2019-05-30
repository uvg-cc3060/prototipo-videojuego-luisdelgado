using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
	public float maxLife = 100f;
	public float curLife = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (curLife <= 0f)
		{
			Destroy(gameObject);
		}
        
    }

	void RecievedDamage(float damage)
	{
		curLife -= damage;
		if (curLife <= 0f){
			curLife = 0f;
		}
	}
}
