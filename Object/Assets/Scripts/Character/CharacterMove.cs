using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {
    const float gravity = 20.0f;

    CharacterController controller; // コントローラー
    Vector3 moveDirection;          // 移動方向
    Animator animator;              // アニメーション

    [SerializeField]
    float speed = 6.0f;     // 移動速度
    [SerializeField]
    float jumpSpeed = 8.0f; // ジャンプ速度
    [SerializeField]
    GameObject camera = null;      // カメラオブジェクト


    void Awake ()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animator = gameObject.GetComponent<Animator>();
    }


    // Use this for initialization
    void Start () {
        moveDirection = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		if (controller.isGrounded) {
            animator.SetBool("Walk", false);

            // カメラの角度に応じた移動方向に補正
            if (camera != null) {
                Vector3 cameraForward = Vector3.Scale(camera.transform.forward, new Vector3(1, 0, 1)).normalized;
                moveDirection = cameraForward * Input.GetAxis("Vertical_left") + 
                    camera.transform.transform.right * Input.GetAxis("Horizontal_left");
            }
            else {
                moveDirection = new Vector3(Input.GetAxis("Horizontal_left"), 0, Input.GetAxis("Vertical_left"));
            }

            if (Input.GetAxis("Horizontal_left") > 0.0f || Input.GetAxis("Vertical_left") > 0.0f) {
                animator.SetBool("Walk", true);
            }
            

            // 移動方向をローカルからワールド空間に変換
            //moveDirection = transform.TransformDirection(moveDirection);

            // 移動速度を掛ける
            moveDirection *= speed;

            if (Input.GetButton("Jump")) {
                moveDirection.y = jumpSpeed;
            }
        }

        if (moveDirection != Vector3.zero) {
            // 移動方向にキャラクターを回転
        }
        // y軸方向への移動に重力を加える
        moveDirection.y -= gravity * Time.deltaTime;
        // 移動
        controller.Move(moveDirection * Time.deltaTime);
	}
}
