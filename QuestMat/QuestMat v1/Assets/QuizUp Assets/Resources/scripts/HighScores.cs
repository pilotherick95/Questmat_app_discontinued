using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Linq;

public class HighScores : MonoBehaviour {

	//tf display text fields
	[SerializeField]
	private Text tfgkHighscore;

	[SerializeField]
	private Text tfmoviesHighscore;

	[SerializeField]
	private Text tfcalebHighscore;

	[SerializeField]
	private Text tfsportssHighscore;

	[SerializeField]
	private Text tfgamesHighscore;

	[SerializeField]
	private Text tfnatureHighscore;

	[SerializeField]
	private Text tfgeographyHighscore;

	[SerializeField]
	private Text tfhistoryHighscore;


	[SerializeField]
	private Text tflifestyleHighscore;


	//mcqs diSplay text fields
	[SerializeField]
	private Text mcqgkHighscore;

	[SerializeField]
	private Text mcqmoviesHighscore;

	[SerializeField]
	private Text mcqcalebHighscore;

	[SerializeField]
	private Text mcqsportssHighscore;

	[SerializeField]
	private Text mcqgamesHighscore;

	[SerializeField]
	private Text mcqnatureHighscore;

	[SerializeField]
	private Text mcqgeographyHighscore;

	[SerializeField]
	private Text mcqhistoryHighscore;

	[SerializeField]
	private Text mcqlifestyleHighscore;

	void Start(){

		tfgkHighscore.text = PlayerPrefs.GetInt ("TFgkHighScore").ToString ();
		tfmoviesHighscore.text = PlayerPrefs.GetInt ("TFMoviesHighScore").ToString ();
		tfcalebHighscore.text = PlayerPrefs.GetInt ("TFCalebHighScore").ToString ();
		tfsportssHighscore.text = PlayerPrefs.GetInt ("TFSportsHighScore").ToString ();
		tfgamesHighscore.text = PlayerPrefs.GetInt ("TFGamesHighScore").ToString ();
		tfnatureHighscore.text = PlayerPrefs.GetInt ("TFNatureHighScore").ToString ();
		tfgeographyHighscore.text = PlayerPrefs.GetInt ("TFGeographyHighScore").ToString ();
		tfhistoryHighscore.text = PlayerPrefs.GetInt ("TFHistoryHighScore").ToString ();
		tflifestyleHighscore.text = PlayerPrefs.GetInt ("TFLifestyleHighScore").ToString ();

		mcqgkHighscore.text = PlayerPrefs.GetInt ("mcqgkHighScore").ToString ();
		mcqmoviesHighscore.text = PlayerPrefs.GetInt ("mcqMoviesHighScore").ToString ();
		mcqcalebHighscore.text = PlayerPrefs.GetInt ("mcqCalebHighScore").ToString ();
		mcqsportssHighscore.text = PlayerPrefs.GetInt ("mcqSportsHighScore").ToString ();
		mcqgamesHighscore.text = PlayerPrefs.GetInt ("mcqGamesHighScore").ToString ();
		mcqnatureHighscore.text = PlayerPrefs.GetInt ("mcqNatureHighScore").ToString ();
		mcqgeographyHighscore.text = PlayerPrefs.GetInt ("mcqGeographyHighScore").ToString ();
		mcqhistoryHighscore.text = PlayerPrefs.GetInt ("mcqHistoryHighScore").ToString ();
		mcqlifestyleHighscore.text = PlayerPrefs.GetInt ("mcqLifestyleHighScore").ToString ();
	

	}
}