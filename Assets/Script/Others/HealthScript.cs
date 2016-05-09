using UnityEngine;
using System.Collections;
public delegate void HealthZeroEventHandler();
public class HealthScript : MonoBehaviour {
	/// <summary>
	/// Total hitpoints
	/// </summary>
	public int hp = 10;
	/// <summary>
	/// Enemy or player?
	/// </summary>
	public bool isEnemy = false;
	public bool hasdown = false;
	public static event HealthZeroEventHandler healthBecomeZero;
	Animator anim;
	
	/// <summary>
	/// Inflicts damage and check if the object should be destroyed
	/// </summary>
	/// <param name="damageCount"></param>
	/// 
	void Start () {
		anim=GetComponent<Animator>();
	}
	void Update(){

	}

	public void Damage(int damageCount)
	{
		hp -= damageCount;
		
		if (hp <= 0 && !hasdown)
		{
			hasdown=!hasdown;
			anim.SetTrigger("Die");

			GameOverScript gos= transform.parent.gameObject.AddComponent<GameOverScript>();
			if(isEnemy)
				gos.winnerName="AI";
			else
				gos.winnerName="Player";
			healthBecomeZero();//触发事件
			//Destroy(gameObject,5);
//			// 'Splosion!
//			SpecialEffectsHelper.Instance.Explosion(transform.position);
//			//sound
//			SoundEffectsHelper.Instance.MakeExplosionSound();
			// Dead!
		//	Destroy(gameObject);
		}
	}
	
}
