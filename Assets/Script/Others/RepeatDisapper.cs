using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
/// <summary>
///自动创建敌人用的一个类
/// </summary>
public class RepeatDisapper : MonoBehaviour {
	public bool IsCreateEnemy=true;
	public Transform newEnemy;
	public static RepeatDisapper Instance;
	void Awake(){
		// Register the singleton
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of RepeatDisapper!");
		}
		Instance = this;
	}
	/// <summary>
	///自动创建敌人,位置随机
	/// positon 位置 num 数量
	/// </summary>
	public void createEnemy(Vector3 positon, int num){
		for(int i=0;i<num;i++){
			float dx=Random.Range(-3,17);
			float dy=Random.Range(-3,4);
			positon.z=this.transform.position.z; positon.x+=dx; positon.y+=dy;
			var enemyTransform = Instantiate(newEnemy) as Transform;
			MoveScript move = enemyTransform.gameObject.GetComponent<MoveScript>();
			enemyTransform.position=positon;
			move.speed=new Vector2(5,5);
			move.direction=new Vector2(-1,0);
		}//for
	}
}
