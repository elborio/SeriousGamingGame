using UnityEngine;
using System.Collections;

public class Enemy1 : MonoBehaviour {
    public NavMeshAgent nma;
    public GameObject player;
    private bool asked = false;
    private Question question;
    public TextMesh text;
	// Use this for initialization
	void Start () {
        nma.SetDestination(player.transform.position);
        text.text = "";
	}
	
	// Update is called once per frame
	void Update () {
        nma.SetDestination(player.transform.position);
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
    void OnCollisionEnter(Collision other)
    {

        if (other.collider.tag == "Player")
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
