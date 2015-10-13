using UnityEngine;
using System.Collections;

public class MazeController : MonoBehaviour {

    public Rigidbody rb;
    public int Speed;
    private Question qst;
    public TextMesh text;
    private Collider currentEnemy;
    private bool questionAsked;
    // Use this for initialization
    void Start()
    {

    }
    void Update()
    {
        if (questionAsked)
        {
            int answer = 0;
            if (int.TryParse(Input.inputString, out answer))
            {
                if (qst.isRight(answer))
                {
                    questionAsked = false; 
                    text.text = "";
                    currentEnemy.gameObject.SetActive(false);
                    currentEnemy = null;
                    Time.timeScale = 1.0F;
                }
            }
        }
    }

    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * Speed);
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Enemy")
        {
            Time.timeScale = 0.0F;
            qst = new Question(1, 9);
            text.text = qst.getQuestion();
            questionAsked = true;
            currentEnemy = other.collider;
        }
        

    }
}
