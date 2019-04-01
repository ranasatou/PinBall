using UnityEngine;
using System.Collections;

public class FripperController : MonoBehaviour{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    // 右半分をタッチした指のID
    private int rightFingerId = 0;
    // 左半分をタッチした指のID
    private int leftFingerId = 0;

    // Use this for initialization
    void Start(){
        //HingeJointコンポーネント取得
        this.myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(this.defaultAngle);
    }

    // Update is called once per frame
    void Update()
    {

        //左矢印キーを押した時左フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
                SetAngle(this.flickAngle);
        }
        //右矢印キーを押した時右フリッパーを動かす
        if (Input.GetKeyDown(KeyCode.RightArrow) && tag == "RightFripperTag"){
                SetAngle(this.flickAngle);
        }

        // 触れている指の本数分繰り返す。Input.touchCountは現在触れている指の本数
        for (int i = 0; i < Input.touchCount; i++) {
            Touch touch = Input.GetTouch(i);
            if (touch.phase == TouchPhase.Began) {
                if (touch.position.x < Screen.width * 0.5f && tag == "LeftFripperTag") {
                    leftFingerId = touch.fingerId;
                    SetAngle(this.flickAngle);
                }else if (touch.position.x > Screen.width * 0.5f && tag == "RightFripperTag") {
                    rightFingerId = touch.fingerId;
                    SetAngle(this.flickAngle);
                }
            }else if (touch.phase == TouchPhase.Ended) {
                if (touch.fingerId == leftFingerId && tag == "LeftFripperTag") {
                    SetAngle(this.defaultAngle);
                }
                else if (touch.fingerId == rightFingerId && tag == "RightFripperTag") {
                    SetAngle(this.defaultAngle);
                }
            }
        }

        //矢印キー離された時フリッパーを元に戻す
        if (Input.GetKeyUp(KeyCode.LeftArrow) && tag == "LeftFripperTag"){
            SetAngle(this.defaultAngle);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && tag == "RightFripperTag"){
            SetAngle(this.defaultAngle);
        }

    }

    //フリッパーの傾きを設定
    public void SetAngle(float angle){
        JointSpring jointSpr = this.myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        this.myHingeJoint.spring = jointSpr;
    }

}



