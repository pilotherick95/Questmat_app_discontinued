using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tfGameManager : MonoBehaviour {


	public tfQuestion[] questions;                       // creates an array which has a fixed size
	private static List<tfQuestion> unansweredQuestions; //creates list which changes its size during gameplay 
	private tfQuestion currentQuestion;

	public Animator gameover;

	public static int totalquestionstoask = 15;     //Change this value to set how many questions you have to ask in the game.
	private static int correctanswers = 0;
	private static int wronganswers = 0;

	[SerializeField]
	private Text factText;

	[SerializeField]
	private Text trueAnswerText;

	[SerializeField]
	private Text falseAnswerText;

	[SerializeField]
	public float timeBetweenQuestions;

	[SerializeField]
	private Text timer;

	[SerializeField]
	private Text totalcorrectanswers;

	[SerializeField]
	private Text totalwronganswers;

	[SerializeField]
	public float timeforeachquestion;

	float end = 0;


	/// ///////////////////////////////////THIS SECTION IS TO SHARE SCORE ON FB ///////////////////////////////

	// Your app’s unique identifier.
	string AppID = "1469549399961687";
	// The link attached to this post.
	private string Link = "www.google.com";

	// The URL of a picture attached to this post. The picture must be at least 200px by 200px.
	private string Picture = "https://cdn3.iconfinder.com/data/icons/brain-games/1042/Quiz-Games.png";

	// The name of the link attachment.
	private string Name = "MY HISHCORE";

	// The caption of the link (appears beneath the link name).
	private string Caption = "CLICK TO DOWNLOAD AWESOME QUIZ GAME!";

	// The description of the link (appears beneath the link caption).
	private string Description;


	/// ///////////////////// END OF FB SHARE SECTION ///////////////////////////////////


	void Start ()
	{
		

		if (unansweredQuestions == null || unansweredQuestions.Count == 0) {

				unansweredQuestions = questions.ToList<tfQuestion> ();
			}

		if (totalquestionstoask > 0) {

			SetCurrentQuestion ();
		
		} 

		if(totalquestionstoask == 0){
		
			endgame ();
		}
		}

	void Update()
	{
		if (end == 1) {
		
			return;
		}

		else
		{
			timeforeachquestion = timeforeachquestion - Time.deltaTime;
			timer.text = timeforeachquestion.ToString ("F1");        
		}

		if (timeforeachquestion < 0.0f)
		{
			unansweredQuestions.Remove(currentQuestion);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			totalquestionstoask = totalquestionstoask - 1;
		}



	}

	public Animator trueslected;
	public Animator falseselected;

	void SetCurrentQuestion(){



		int randomQuestionIndex = Random.Range (0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions [randomQuestionIndex];
		factText.text = currentQuestion.fact;


		if (currentQuestion.iSTrue) {
			trueAnswerText.text = "CORRECT";
			falseAnswerText.text = "WRONG";
		} 
		else {
		
			trueAnswerText.text = "WRONG";
			falseAnswerText.text = "CORRECT";
		}
	}



	IEnumerator TransitionToNextQuestion()
	{
	
		unansweredQuestions.Remove(currentQuestion);
		totalquestionstoask = totalquestionstoask - 1;
		yield return new WaitForSeconds (timeBetweenQuestions);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}



	public void userSelectTrue(){
	
		trueslected.SetTrigger ("trueselect");

		if (currentQuestion.iSTrue) 
		{
			Debug.Log ("Correct");
			correctanswers = correctanswers + 1;


		} 

		else {
			Debug.Log ("Wrong");
			wronganswers = wronganswers + 1;



		}
		StartCoroutine (TransitionToNextQuestion ());
	
	}

	public void userSelectFalse(){

		falseselected.SetTrigger ("falsesel");

		if (currentQuestion.iSTrue) 
		{
			Debug.Log ("Wrong");
			wronganswers = wronganswers + 1;
		} 

		else {
			Debug.Log ("Correct");
			correctanswers = correctanswers + 1;
		}

		StartCoroutine (TransitionToNextQuestion ());
	}
		

	public void skip(){

		unansweredQuestions.Remove(currentQuestion);
		totalquestionstoask = totalquestionstoask - 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
		

	void endgame(){
		end = 1;
		factText.text = "GAME OVER";
		timer.text = "5";
		totalcorrectanswers.text = correctanswers.ToString ();
		totalwronganswers.text = wronganswers.ToString ();



		gameover.SetTrigger ("over");
		Description = "I just scored " + correctanswers + " in QuizUp Android Game. CAN YOU BEAT ME?";
		sethighscores ();

	}
		

	void sethighscores(){
	
		//1

		if (PlayerPrefs.GetString ("Category") == "tfGeneral") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("TFgkHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("TFgkHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}

		//2 

		if (PlayerPrefs.GetString ("Category") == "tfMovies") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("TFMoviesHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("TFMoviesHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}

		//3

		if (PlayerPrefs.GetString ("Category") == "tfCaleb") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("TFCalebHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("TFCalebHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}

		//4

		if (PlayerPrefs.GetString ("Category") == "tfSports") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("TFSportsHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("TFSportsHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}

		//5

		if (PlayerPrefs.GetString ("Category") == "tfGames") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("TFGamesHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("TFGamesHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}

		//6

		if (PlayerPrefs.GetString ("Category") == "tfNature") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("TFNatureHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("TFNatureHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}

		//7 

		if (PlayerPrefs.GetString ("Category") == "tfGeography") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("TFGeographyHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("TFGeographyHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}

		//8

		if (PlayerPrefs.GetString ("Category") == "tfHistory") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("TFHistoryHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("TFHistoryHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}

		//9

		if (PlayerPrefs.GetString ("Category") == "tfLifestyle") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("TFLifestyleHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("TFLifestyleHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}
			

		resetvariables ();
	
	}
	void resetvariables(){

		totalquestionstoask = 15; //change this to initial value
		correctanswers = 0;
		wronganswers = 0;
		unansweredQuestions = null;
		questions = null;
	}

	public void sharescoreonfb(){

		Application.OpenURL("https://www.facebook.com/dialog/feed?"+ "app_id="+AppID+ "&link="+
			Link+ "&picture="+Picture+ "&name="+ReplaceSpace(Name)+ "&caption="+
			ReplaceSpace(Caption)+ "&description="+ReplaceSpace(Description)+
			"&redirect_uri=https://facebook.com/");
	}

	string ReplaceSpace (string val) {
		return val.Replace(" ", "%20");
	}


	public void cancelquiz(){

		totalquestionstoask = 15; //change this to initial value
		correctanswers = 0;
		wronganswers = 0;
		unansweredQuestions = null;
		questions = null;
		SceneManager.LoadScene ("start");

	}
		
}
