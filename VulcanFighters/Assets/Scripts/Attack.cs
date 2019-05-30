using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
	public GameObject BasicComboAttack;
	public GameObject LightKnockUp;
	public GameObject HeavyBasicAttack;
	public GameObject HeavyEnder;
	public int state=0;
	public Animator anim;
	public bool isAttacking = false;
	public bool duringCombo = false;
	public bool timeToStop = false;
	public bool hasEnded=false;
	public float timeBetweenAttacks = 0.5f;
	public float timeForRecovery = 1f;
	public float timeSinceLastPress = 0.0f;
	public float timeForComboes = 0.8f;
	public bool hasEndedString=false;
	

	// Start is called before the first frame update
	void Start()
    {
		anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
		duringCombo = (timeSinceLastPress >= timeBetweenAttacks && timeSinceLastPress <= timeForComboes);
		timeToStop = (timeSinceLastPress>timeForComboes && timeSinceLastPress<=timeForRecovery);
		if (hasEndedString)
		{
			state = 0;
			hasEndedString = (timeSinceLastPress <= timeForRecovery);
		}
		

        if (Input.GetButtonDown("Fire1"))
		{
			if (state == 0 && !hasEndedString)
			{
				gameObject.SendMessage("StartedAttacking");
				timeSinceLastPress = 0.0f;
				state += 1;
				Instantiate(BasicComboAttack, transform, false);
			}
			else if (state == 1 && duringCombo && !hasEndedString)
			{
				timeSinceLastPress = 0.0f;
				state += 1;
				Instantiate(BasicComboAttack, transform, false);
			}
			else if (state == 2 && duringCombo && !hasEndedString)
			{
				timeSinceLastPress = 0.0f;
				state += 1;
				Instantiate(BasicComboAttack, transform, false);
			}
			else if (state == 3 && duringCombo && !hasEndedString)
			{
				timeSinceLastPress = 0.0f;
				state += 1;
				Instantiate(BasicComboAttack, transform, false);
			}
			else if (state == 4 && duringCombo && !hasEndedString)
			{
				timeSinceLastPress = 0.0f;
				state += 1;
				hasEndedString=false;
				Instantiate(BasicComboAttack, transform, false);
			}
		}
		if (Input.GetButtonDown("Fire2"))
		{
			if (state == 0 && !hasEndedString)
			{
				gameObject.SendMessage("StartedAttacking");
				timeSinceLastPress = 0.0f;
				Instantiate(HeavyEnder, transform, false);
				hasEndedString = true;

			}
			else if (state == 1 && duringCombo && !hasEndedString)
			{
				timeSinceLastPress = 0.0f;
				Instantiate(HeavyEnder, transform, false);
				hasEndedString = true;

			}
			else if (state == 2 && duringCombo && !hasEndedString)
			{
				timeSinceLastPress = 0.0f;
				Instantiate(HeavyEnder, transform, false);
				hasEndedString = true;
			}
			else if (state == 3 && duringCombo && !hasEndedString)
			{
				timeSinceLastPress = 0.0f;
				Instantiate(HeavyEnder, transform, false);
				hasEndedString = true;
			}
			else if (state == 4 && duringCombo && !hasEndedString)
			{
				timeSinceLastPress = 0.0f;
				Instantiate(HeavyEnder, transform, false);
				hasEndedString = true;
			}
		}
		timeSinceLastPress += Time.deltaTime;
		if (timeSinceLastPress >= timeForRecovery)
		{
			gameObject.SendMessage("IsNotAttacking");
			state = 0;
		}
	}
}
