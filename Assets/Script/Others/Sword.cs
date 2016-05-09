using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour {
	// 1 - Designer variables
	
	/// <summary>
	/// Damage inflicted
	/// </summary>
	public int damage = 1;
	/// <summary>
	/// Projectile damage player or enemies?
	/// </summary>
	public bool isEnemySword = false;
	/// <summary>
	/// 剑的攻击状态
	/// </summary>
	public bool attack=false;
	// Use this for initialization
	void Start()
	{
		// 2 - Limited time to live to avoid any leak
		//Destroy(gameObject, 20); // 20sec
	}


	
	// Update is called once per frame
	void Update () {
	
	}
}
