using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	UnityEngine.AI.NavMeshAgent navigationAgent;
	Animator animator;
	float baseSpeed, baseAcceleration, baseAngularSpeed;

	// Use this for initialization
	void Start()
	{
		navigationAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		animator = GetComponent<Animator>();
		baseSpeed = navigationAgent.speed;
		baseAcceleration = navigationAgent.acceleration;
		baseAngularSpeed = navigationAgent.angularSpeed;
	}
	public void CancelPowerUp(PowerupType type)
    {
        switch (type)
		{
				case PowerupType.SpeedBoost:
                navigationAgent.speed = baseSpeed;
				break;
				case PowerupType.AccelerationBoost:
				navigationAgent.acceleration = baseAcceleration;
				break;
				case PowerupType.TurnBoost:
				navigationAgent.angularSpeed = baseAngularSpeed;
				break;
			
        }
    }
	public void ApplyPowerUp(PowerupType type, float duration)
    {
        switch (type)
		{
				case PowerupType.SpeedBoost:
                StartCoroutine(SpeedBoost(duration, 3.5f));
				break;
				case PowerupType.AccelerationBoost:
				StartCoroutine(AccerelationBoost(duration, 2f));
				break;
				case PowerupType.TurnBoost:
				StartCoroutine(TurnBoost(duration, 2f));
				break;
			
        }
    }
	IEnumerator SpeedBoost(float duration, float multiplier)
	{
		navigationAgent.speed = baseSpeed * multiplier;
		yield return new WaitForSeconds(duration);
		navigationAgent.speed = baseSpeed;
	}
	IEnumerator AccerelationBoost(float duration, float multiplier)
	{
		navigationAgent.acceleration = baseAcceleration * multiplier;
		yield return new WaitForSeconds(duration);
		navigationAgent.acceleration = baseAcceleration;
	}

	IEnumerator TurnBoost(float duration, float multiplier)
	{
		navigationAgent.angularSpeed = baseAngularSpeed * multiplier;
		yield return new WaitForSeconds(duration);
		navigationAgent.angularSpeed = baseAngularSpeed;
	}

	// Update is called once per frame
	void Update () {
		PlayerMove ();

		if (animator) {
			float v = navigationAgent.velocity.x;
			if (v != 0){
				animator.SetBool("Moving",true);
			}else{
				animator.SetBool("Moving",false);
			}
		}
	}

	void PlayerMove (){
		if (Input.GetMouseButtonUp (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//Debug.Log(ray);

			if(Physics.Raycast(ray, out hit, 500)){
				//Debug.DrawLine(ray.origin,hit.point,Color.red,1.0f);
				//Debug.Log(hit.point);
				navigationAgent.SetDestination(hit.point);
			}
		}
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "Gold") {
			GetComponent<AudioSource>().Play();
		}
	}
}
