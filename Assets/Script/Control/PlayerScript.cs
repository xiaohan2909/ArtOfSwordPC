using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public Vector2 speed = new Vector2(5, 5);
	// 2 - Store the movement
	private Vector2 movement;
	//角色的状态，攻击，防御，其他//没用，改用动画判断了
//	private enum Status{attack,defend,other};
//	private Status status;
	//角色的武器
	//private Sword sword;
	//角色生命
	private HealthScript health;
	bool facingRight = true;
	Animator anim;

	void Awake(){
	//	sword=GetComponentInChildren<Sword>();
		health=GetComponent<HealthScript>();
		anim=GetComponent<Animator>();
	}
	// Use this for initialization
	void Start () {
		//订阅事件
		GameController.gameIsEnding+=onGameEndWork;
		//health.healthBecomeZero+=onHealthZero;
		//Time.timeScale=0.25f;
	}
		// Update is called once per frame
	void Update () {
		// 3 - Retrieve axis information
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
		// 4 - Movement per direction
		movement = new Vector2(
			speed.x * inputX,
			speed.y * inputY);
		var dist = (transform.position - Camera.main.transform.position).z;
		var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
		var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
		var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

		//默认是其他状态
		// 攻击控制
		bool swordAttack= Input.GetButtonDown("Fire1");
//		if(Input.touchCount>0){
//			Touch touch = Input.GetTouch(0);
//			if (touch.phase == TouchPhase.Ended && touch.tapCount == 1){
//				swordAttack=true;
//			}
//		}
		if(swordAttack && !anim.GetCurrentAnimatorStateInfo(0).IsName("attack")){
			anim.SetTrigger("Attack");
			movement=new Vector2(0,0);
		}
		//防御控制
		bool defend = Input.GetButtonDown("Jump");
		if(defend && !anim.GetCurrentAnimatorStateInfo(0).IsName("defend")
		   && !anim.GetCurrentAnimatorStateInfo(0).IsName("beHit")) {
			anim.SetTrigger("Defending");
			movement=new Vector2(0,0);
		}
	
		anim.SetFloat("Speed",Mathf.Abs(inputX));
		transform.parent.position = new Vector3(
			Mathf.Clamp(transform.parent.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.parent.position.y, topBorder, bottomBorder),
			transform.position.z
			);
//		if(inputX > 0 && !facingRight)
//		{
//			FlipFacing();
//		}
//		else if(inputX < 0 && facingRight)
//		{
//			FlipFacing();
//		}

	}
	void FixedUpdate()
	{
		transform.parent.rigidbody.velocity = new Vector3(movement.x, movement.y ,0f);	
		//transform.parent.rigidbody2D.velocity = movement;
		//transform.parent.rigidbody2D.AddForce(movement);
	}
	void OnTriggerEnter(Collider collider){
		Sword enemySword=collider.gameObject.GetComponent<Sword>();
		if(enemySword.isEnemySword){
			//if(!anim.GetCurrentAnimatorStateInfo(0).IsName("defend") && enemySword.attack){
				anim.SetTrigger("BeHit");
				health.Damage(enemySword.damage);
				//Debug.Log("beHit");
		//	}
		}
	}
	public void onGameEndWork(){
		Debug.Log("playerDestroying...");
	    speed.x=0.0f;
		//Destroy(GetComponent<Animator>(),2.0f);
		Destroy(this);
	}
	void OnDestroy()
	{
		//speed.x=0.0f;
		Destroy(transform.parent.gameObject.rigidbody);
	}
	void FlipFacing()
	{
		facingRight = !facingRight;
		Vector3 charScale = transform.localScale;
		charScale.x *= -1;
		transform.localScale = charScale;
	}
}
