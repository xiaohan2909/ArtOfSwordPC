using UnityEngine;
using System.Collections;

public class PrimarySwordmanScript : MonoBehaviour {
	private bool hasSpawn;
	private MoveScript moveScript;
	private Sword sword;
	private Animator anim;
	// Enemy pattern (not really an AI)
	public float minAttackCooldown = 1f;
	public float maxAttackCooldown = 4f;
	
	private float aiCooldown;
	private float attackTime;
	private bool isAttacking;
	//private Vector2 positionTarget;
	//角色生命
	private HealthScript health;
	
	
	void Awake()
	{
		// Retrieve the weapon only once
		sword = GetComponentInChildren<Sword>();
		anim = GetComponent<Animator>();
		// Retrieve scripts to disable when not spawn
		moveScript = GetComponent<MoveScript>();
		health=GetComponent<HealthScript>();
	}
	
	// 1 - Disable everything
	void Start()
	{
		hasSpawn = false;		
		// Disable everything
		// -- collider
		collider.enabled = false;
		// -- Moving
		moveScript.enabled = false;
		// -- Shooting
		sword.enabled = false;
		attackTime=2.0f;
		isAttacking = false;
		GameController.gameIsEnding+=onHealthZero;
	}
	
	void Update()
	{
		// 2 - Check if the enemy has spawned.
		if (hasSpawn == false){Spawn();}
		else
		{
			// AI
			//------------------------------------
			// Move or attack. permute. Repeat.
			aiCooldown -= Time.deltaTime;
			// Auto-attack 冷却时间到了进入攻击状态
			if (aiCooldown <= 0f && !isAttacking)
			{
				isAttacking=true;
				sword.attack = true;
				attackTime=1.0f;
				//		positionTarget = Vector2.zero;
				moveScript.speed.x=0.0f;//攻击时不能走动
				anim.SetTrigger("Attack");
			}else{//对手的移动策略 Move
				Transform playerTransform = GameObject.Find("firstRole").transform.parent.transform;
				float delta = this.transform.parent.position.x-playerTransform.position.x;
				//	Debug.Log("delta_postion:"+delta.ToString());
				if(delta<3.5){
					moveScript.speed.x=-2.0f;
					anim.SetFloat("Speed",Mathf.Abs(moveScript.speed.x));
				}
				else if(delta>6.2){
					moveScript.speed.x=2.0f;
					anim.SetFloat("Speed",Mathf.Abs(moveScript.speed.x));
				}					
			}
			// Attack
			//----------
			if(attackTime<=0f && isAttacking){
				aiCooldown = Random.Range(minAttackCooldown, maxAttackCooldown);
				isAttacking = false;
				sword.attack = false;
				isAttacking=false;
				moveScript.speed.x=Random.Range(-2f, 2f);
				anim.SetFloat("Speed",Mathf.Abs(moveScript.speed.x));
			}else{
				attackTime -=Time.deltaTime;
			}
			//初级剑士不懂防御
			
		}
		//确保不会出屏幕
		var dist = (transform.position - Camera.main.transform.position).z;
		var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
		var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
		var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
		transform.parent.position = new Vector3(//防止出框
		                                        Mathf.Clamp(transform.parent.position.x, leftBorder, rightBorder),
		                                        Mathf.Clamp(transform.parent.position.y, topBorder, bottomBorder),
		                                        transform.position.z
		                                        );
		
	}
	//中剑了
	void OnTriggerEnter(Collider collider){
		Sword enemySword=collider.gameObject.GetComponent<Sword>();
		if(enemySword.isEnemySword==false){//如果不是player的剑那么就是敌人自己的剑了
			//if(!anim.GetCurrentAnimatorStateInfo(0).IsName("defend") && enemySword.attack){
			anim.SetTrigger("BeHit");
			health.Damage(enemySword.damage);
			//Debug.Log("beHit");
			//	}
		}
	}
	//
	public void onHealthZero(){
		Debug.Log("AI Destroying...");
		moveScript.speed.x=0.0f;
	//	anim.SetFloat("Speed",Mathf.Abs(moveScript.speed.x));
//		Destroy(GetComponent<MoveScript>());
//		Destroy(GetComponent<Animator>(),2.0f);
		Destroy(this);
	}
	void OnDestroy(){
	//	Destroy(transform.parent.gameObject.rigidbody);
	}
	// 3 - Activate itself.唤醒自我
	private void Spawn()
	{
		hasSpawn = true;
		
		// Enable everything
		// -- Collider
		collider.enabled = true;
		// -- Moving
		moveScript.enabled = true;
		// -- Shooting
		sword.enabled = true;
	}
}
