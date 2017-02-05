using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	//ボールが見える可能性があるz軸の最大値
	private float visiblePosZ=-6.5f;

	//ゲームオーバを表示するテキスト
	private GameObject gameoverText;
    //得点を表示するテキスト
	private GameObject ScoreText;
	//得点
	private int score=0;

	// Use this for initialization
	void Start () {
		//シーン中のGameOverTextオブジェクトを取得
		this.gameoverText = GameObject.Find("GameOverText");
		//シーン中のScoreTxtオブジェクトを取得
		this.ScoreText=GameObject.Find("ScoreText");
	}
	//コリジョンモードで他のオブジェクトと接触した場合の処理
	void OnCollisionEnter(Collision other){
		//小さい星に衝突した時
		if (other.gameObject.tag == "SmallStarTag") {
			Debug.Log ("小さい星に衝突した時");
			//スコアを加算
			this.score += 10;
			//スコアをScore Textに表示
			this.ScoreText.GetComponent<Text> ().text = "Score" + this.score + "pt";
			Debug.Log ("スコアをScore Textに表示");
		}
		//大きい星に衝突した時
		if (other.gameObject.tag == "LargeStarTag") {
			//スコアを加算
			this.score += 20;
			//スコアをScore Textに表示
			this.ScoreText.GetComponent<Text> ().text = "Score" + this.score + "pt";

		}
		//小さい雲に衝突した時
		if (other.gameObject.tag == "SmallCloudTag") {
			//スコアを加算
			this.score += 40;
			//スコアをScore Textに表示
			this.ScoreText.GetComponent<Text> ().text = "Score" + this.score + "pt";

		}
		//大さい雲に衝突した時
		if (other.gameObject.tag == "LargeCloudTag") {
			//スコアを加算
			this.score += 80;
			//スコアをScore Textに表示
			this.ScoreText.GetComponent<Text> ().text = "Score" + this.score + "pt";

		}

	}
	// Update is called once per frame
	void Update () {
		//ボールが画面外に出た場合
		if(this.transform.position.z<this.visiblePosZ){
			//GameoverTextにゲームオーバーを表示
			this.gameoverText.GetComponent<Text>().text="Game Over";
		}
	}



}	