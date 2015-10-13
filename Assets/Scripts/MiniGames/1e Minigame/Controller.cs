using UnityEngine;
using System;

public class Controller : MonoBehaviour {
    public Rigidbody rb;
    public int Speed;
    public int jumpSpeed;
    private bool ground;
    private bool questionAsked = false;
    public TextMesh text;
    private Question question;
    private Collider currentEnemy;
    private System.Random rnd = new System.Random();
	// Use this for initialization
	void Start () {
        text.text = "";
    }
    void Update()
    {
        if (questionAsked)
        {
            int answer = 0;
            if(int.TryParse(Input.inputString, out answer))
            {
                if (question.isRight(answer)){
                    questionAsked = true;
                    unPauseGame();
                    text.text = "";
                    currentEnemy.enabled = false;
                    currentEnemy = null;
                }
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        //float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical);
        rb.AddForce(movement * Speed);
        bool jump = Input.GetKey(KeyCode.Space);
        if (jump)
        {
            Debug.Log("Ground");
            if (jump && ground)
            {
                Debug.Log("JUMP = " + jump + " And Ground = " + ground);
                rb.AddForce((new Vector3(0.0f, 1.0f, 0.0f)) * jumpSpeed);
                ground = false;
            }
        }
        
    }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.collider.name);
        if (other.collider.name == "Unpassable Wall")
        {
            Application.LoadLevel(3);
        }    
        if(other.collider.tag == "Enemy")
        {
            currentEnemy = other.collider;
            askQuestion(5);
        }    
        if(other.collider.tag == "Ground" || other.collider.tag == "Collision")
        {
            ground = true;
        }
    }
    void waitForAnswer(int answer)
    {
        while (true)
        {
            if (Input.GetKeyDown((KeyCode)(48 + answer)))
            {
                Debug.Log(48 + answer);
            }
        }
    }
    void askQuestion(int maxNum)
    {
        int first = rnd.Next(0, maxNum);
        int second = rnd.Next(0, maxNum);
        //bool rightAnswer = false;
        question = new Question(first, second, Question.operators.PLUS);
        text.text = "Wat is " + first + " + " + second + "?";
        pauseGame();        
    }

    void pauseGame() {
        Time.timeScale = 0.0F;
        questionAsked = true;
        
    }
    void unPauseGame()
    {
        Time.timeScale = 1.0F;
    }
}
