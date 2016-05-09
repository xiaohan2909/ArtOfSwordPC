using UnityEngine;
using System.Collections;
/// <summary>
/// 用于把摄像机左边的景物搬运到摄像机右边，并且随机一个位置
/// </summary>
public class ObjectRecycle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
		//如果景物已经在摄像机的左边了而且摄像机也看不到它了
		if(! this.transform.renderer.IsVisibleFrom(Camera.main) && this.transform.position.x<Camera.main.transform.position.x){
			float dx=Random.Range(-3,17);
			float dy=Random.Range(-3,4);
			Vector3 adaptVector=new Vector3(Camera.main.transform.position.x+20,Camera.main.transform.position.y,this.transform.position.z);
			this.transform.position=adaptVector+new Vector3(dx,dy,0);
		}
	}
}
