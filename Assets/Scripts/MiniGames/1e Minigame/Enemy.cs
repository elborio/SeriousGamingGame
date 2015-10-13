using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public Rigidbody rb;
    public int speed;
    private bool right = false;
    private Question question;
    public TextMesh text;
    private bool asked = false;
	// Use this for initialization
	void Start () {
        rb.AddForce(0.0F, 0.0F, (-2.5F * speed));
        text.text = "";
	}
	void Update()
    {
        if (asked)
        {
            if (asked)
            {
                int answer = 0;
                if (int.TryParse(Input.inputString, out answer))
                {
                    if (question.isRight(answer))
                    {
                        asked = false; 
                        unPauseGame();
                        text.text = "";
                        this.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
	// Update is called once per frame
	void OnCollisionEnter(Collision other)
    {
        
        if(other.collider.tag == "Collision")
        {
            Debug.Log("Enemy wall collision");
            if (!right)
            {
                Debug.Log("Force Right Added");
                rb.AddForce(0.0F, 0.0F, (5.0F * speed));
                right = true;
            }
            else 
            {
                Debug.Log(rb.velocity.z);
                rb.AddForce(0.0F, 0.0F, (-5.0F * speed));
                right = false;
                Debug.Log("Force Left Added");
            }
        }
        else if(other.collider.tag == "Player")
        {
            Time.timeScale = 0.0F;
            question = new Question(1, 10);
            text.text = question.getQuestion();
            asked = true;
        }
    }
    void unPauseGame()
    {
        Time.timeScale = 1.0F;
    }
}
