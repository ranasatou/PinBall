using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class BallController : MonoBehaviour { 

    // ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    // ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    private int score = 0;// スコア用変数
    public Text scoreText; // スコアを表示するテキスト


    // Use this for initialization
    void Start () {

          
        // シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        // シーン中のscoreTextオブジェクトを取得
        //this.gameoverText = GameObject.Find("scoreText");

    }
	
	// Update is called once per frame
	void Update () {

        // ボールが画面外に出た場合
        if(this.transform.position.z < this.visiblePosZ)
        {
             // GameoverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

    }


    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision collision )
    {
        string Tag = collision.gameObject.tag;

        if (Tag == "SmallCloudTag" || Tag == "LargeCloudTag")
        {
            score += 10;
        }
        else if(Tag == "SmallStarTag" || Tag == "LargeStarTag")
        {
            score += 20;
        }

        SetScore();
    }

    void SetScore()
    {
        this.scoreText.text = string.Format("Score:{0}", score);
    }

    
}

