using UnityEngine;
using System.Collections;
using System.Text;
using TMPro;

public class ScoreController : MonoBehaviour {

	public TMP_Text ScoreText;
	public GameObject resetButton;
	public TMP_Text winText;
	public static int score;
	public static int totalGold;
	public static int currentGold;

	// Use this for initialization

	private void OnEnable() => EventManager.OnCoinCollected += AddScore;
	private void OnDisable() => EventManager.OnCoinCollected -= AddScore;

	private void AddScore(int coinValue)
	{
		score += coinValue;
		currentGold += 1;
		ScoreText.text = "Score : " + score.ToString();
		if (currentGold >= 4) WinGame();
	}


	void WinGame()
	{
		EventManager.RaisePlayerWin();
		// GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

		// foreach (GameObject enemy in enemys)
		// {
		// 	enemy.SendMessage("PlayerDie");
		// }
		winText.text = "YOU WIN !!!";
		winText.gameObject.SetActive(true);
		resetButton.SetActive(true);
	}

	// Update is called once per frame 
	// void Update () {
		
	// }

	public void Die (){
		winText.text = "YOU DIE !!!";
		winText.gameObject.SetActive(true);
		resetButton.SetActive(true);
	}


	public void Restart(){
		UnityEngine.SceneManagement.SceneManager.LoadScene(0); 
	}
}
