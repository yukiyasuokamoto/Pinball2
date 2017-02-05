using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour {
	//HingiJointコンポーネントを入れる
	private HingeJoint myHingeJoynt;
	//初期の傾き
	private float defaultAngle = 20;
	//弾いた時の傾き
	private float flickAngle = -20;

	// Use this for initialization
	void Start () {
		//HinjiJointコンポーネント取得
		this.myHingeJoynt = GetComponent<HingeJoint>();

		//フリッパーの傾きを設定
		SetAngle(this.defaultAngle);
	}

	// Update is called once per frame
	void Update () {

		bool touchLeft = false;
		bool touchRight = false;

		foreach( Touch t in Input.touches ) {
			Debug.Log( t.position );
			if( t.position.x < 340 ) {
				touchLeft = true;
			} else {
				touchRight = true;
			}        
		}
		//左矢印キーを押した時左フリッパーを動かす
		if( tag == "LeftFripperTag" ) {
			if (Input.GetKeyDown(KeyCode.LeftArrow) || touchLeft ){
				SetAngle (this.flickAngle);
			} else {
				SetAngle (this.defaultAngle);
			}
		}
		//右矢印キーを押した時右フリッパーを動かす
		if( tag == "RightFripperTag" ) {
			if (Input.GetKeyDown(KeyCode.RightArrow) || touchRight ){
				SetAngle (this.flickAngle);
			} else {
				SetAngle (this.defaultAngle);
			}
		}
	}

	//フリッパーの傾きを設定
	public void SetAngle (float angle){
		JointSpring jointSpr = this.myHingeJoynt.spring;
		jointSpr.targetPosition = angle;
		this.myHingeJoynt.spring = jointSpr;
	}
}