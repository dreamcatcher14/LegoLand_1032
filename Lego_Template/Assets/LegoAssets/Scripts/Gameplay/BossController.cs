using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossController : MonoBehaviour
{
   public float normalSpeed = 3.5f;
   public float enrageSpeed = 6f;
   public Transform introTargetPoint;
   public float introEndDelay = 3f;
   public float chaseDuration = 5f; 
   public NavMeshAgent nav;
   public Animator animator;
   public Transform player;
   public BossStateMachine stateMachine { get; private set; }
   void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        stateMachine = new BossStateMachine();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Start()
    {
        stateMachine.initialize(new BossIntroState(this));
    }

    private void Update(){ stateMachine.Tick(); }
    
	void OnCollisionEnter (Collision col){
		if (col.gameObject.tag == "Player") {

			GameObject gameController = GameObject.Find("GameController");
			if (gameController != null)
            {
				gameController.GetComponent<ScoreController>().Die();
			}

			GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
			
			foreach (GameObject enemy in enemys) {
				enemy.SendMessage("PlayerDie");
			}

			col.gameObject.SetActive(false);
		}
	}

}
