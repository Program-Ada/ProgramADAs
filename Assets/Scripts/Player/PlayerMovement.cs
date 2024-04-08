using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour, IDataPersistence
{

    public float moveSpeed = 3f;
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    // Update is called once per frame
    void Update(){

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        rb.velocity = Vector2.zero;
    }

    void FixedUpdate(){

        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    public void LoadData(GameData data){
        this.transform.position = data.playerPosition;
    }
    public void SaveData(ref GameData data){
        data.playerPosition = this.transform.position;
        data.scene = SceneManager.GetActiveScene().name;
    }
}
