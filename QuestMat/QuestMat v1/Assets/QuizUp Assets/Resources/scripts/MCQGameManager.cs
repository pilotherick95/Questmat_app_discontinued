using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MCQGameManager : MonoBehaviour {


	public mcqquestion[] questions;   // creates an array which has a fixed size
	private static List<mcqquestion> unansweredQuestions; //creates list which changes its size during gameplay 
	private mcqquestion currentQuestion;

	public static int newhighscore;

	public Animator answers, GameOver;


	public static int totalquestionstoask = 5;     //Change this value to set how many questions you have to ask in the game.


	[SerializeField]
	private Text factText;

	[SerializeField]
	private Text option1;

	[SerializeField]
	private Text option2;

	[SerializeField]
	private Text option3;

	[SerializeField]
	private Text option4;

	[SerializeField]
	private Text answerdialogbox;

	[SerializeField]
	public float timebetweenquestions;

	[SerializeField]
	private Text counter;

	[SerializeField]
	public float timeforeachquestion;

	[SerializeField]
	private Text correctanswerstext;

	[SerializeField]
	private Text wronganswerstext;


	private static int correctanswers = 0;
	private static int wronganswers = 0;

	float end=0;


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


	/*section 1. This section selects a random question from mcqquestion.cs script along with associated 4 options
    and displays it */
	
	void Start (){



		if (unansweredQuestions == null || unansweredQuestions.Count == 0) 
		{

			unansweredQuestions = questions.ToList<mcqquestion>();
		}

		if (totalquestionstoask > 0) {
			SetCurrentQuestion ();
		} 

		if (totalquestionstoask == 0) {
		
			stopgame ();
		
		}
	}

	void SetCurrentQuestion(){

		int randomQuestionIndex = Random.Range (0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions [randomQuestionIndex];

		factText.text = currentQuestion.mcq;
		option1.text = currentQuestion.option1;
		option2.text = currentQuestion.option2;
		option3.text = currentQuestion.option3;
		option4.text = currentQuestion.option4;

	}

	//Section 1.1 
	// In this section we set the timer clock and logic behind it

	void Update(){


		if (end == 1 ) {
		
			return;
		} 

		if (end == 0)
		{
			timeforeachquestion = timeforeachquestion - Time.deltaTime;
			counter.text = timeforeachquestion.ToString ("F1");
		}

			
		if (timeforeachquestion < 0.0f)
		{
			unansweredQuestions.Remove(currentQuestion);
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			totalquestionstoask = totalquestionstoask - 1;
		}

	
	}

	//end of section1.

	// section 2. this section is to show if the user's selected choice is correct or wrong

	public void option1selected(){

		if (currentQuestion.atrue) {

			answerdialogbox.text = "CORRECT";
			correctanswers = correctanswers + 1;
		} 

		else 
		{
		
			answerdialogbox.text = "WRONG";
			wronganswers = wronganswers + 1;
		}
			
		answers.SetTrigger ("mcqanswershow");
		StartCoroutine (TransitionToNextQuestion ());
	}
		

	public void option2selected(){

		if (currentQuestion.btrue) {

			answerdialogbox.text = "CORRECT";
			correctanswers = correctanswers + 1;
		} 

		else 
		{

			answerdialogbox.text = "WRONG";
			wronganswers = wronganswers + 1;

		}

		answers.SetTrigger ("mcqanswershow");
		StartCoroutine (TransitionToNextQuestion ());
	}

	public void option3selected(){

		if (currentQuestion.ctrue) {

			answerdialogbox.text = "CORRECT";
			correctanswers = correctanswers + 1;
		} 

		else 
		{

			answerdialogbox.text = "WRONG";
			wronganswers = wronganswers + 1;

		}


		answers.SetTrigger ("mcqanswershow");
		StartCoroutine (TransitionToNextQuestion ());
	}

	public void option4selected(){

		if (currentQuestion.dtrue) {

			answerdialogbox.text = "CORRECT";
			correctanswers = correctanswers + 1;
		} 

		else 
		{
			answerdialogbox.text = "WRONG";
			wronganswers = wronganswers + 1;

		}
			
		answers.SetTrigger ("mcqanswershow");
		StartCoroutine (TransitionToNextQuestion ());
	}
		

	//end of section 2.

	//section 3. This section sets the time delay between questions and reloads the scene after that time to show next question.

	IEnumerator TransitionToNextQuestion()
	{

		unansweredQuestions.Remove(currentQuestion);
		totalquestionstoask = totalquestionstoask - 1;
		yield return new WaitForSeconds (timebetweenquestions);
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void skip(){
	
		unansweredQuestions.Remove(currentQuestion);
		totalquestionstoask = totalquestionstoask - 1;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	
	}


	//section 4. Displays results of game

	void stopgame(){

		end = 1;
		factText.text = "END OF QUESTIONS";
		correctanswerstext.text = correctanswers.ToString ();
		wronganswerstext.text = wronganswers.ToString ();


		GameOver.SetTrigger ("mcqover");

		Description = "I just scored " + correctanswers + " in QuizUp Android Game. CAN YOU BEAT ME?";
		sethighscores ();

	}
		

	void sethighscores(){


		//1

		if (PlayerPrefs.GetString ("Category") == "mcqGeneral") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("mcqgkHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("mcqgkHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}

		//2 

		if (PlayerPrefs.GetString ("Category") == "mcqMovies") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("mcqMoviesHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("mcqMoviesHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}

		//3

		if (PlayerPrefs.GetString ("Category") == "mcqCaleb") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("mcqCalebHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("mcqCalebHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}

		//4

		if (PlayerPrefs.GetString ("Category") == "mcqSports") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("mcqSportsHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("mcqSportsHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}

		//5

		if (PlayerPrefs.GetString ("Category") == "mcqGames") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("mcqGamesHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("mcqGamesHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}

		//6

		if (PlayerPrefs.GetString ("Category") == "mcqNature") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("mcqNatureHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("mcqNatureHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}

		//7 

		if (PlayerPrefs.GetString ("Category") == "mcqGeography") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("mcqGeographyHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("mcqGeographyHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}

		//8

		if (PlayerPrefs.GetString ("Category") == "mcqHistory") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("mcqHistoryHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("mcqHistoryHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}

		//9

		if (PlayerPrefs.GetString ("Category") == "mcqLifestyle") {

			int newhighscore = correctanswers;
			int oldhighscore = PlayerPrefs.GetInt ("mcqLifestyleHighScore", 0);

			if (newhighscore > oldhighscore) {

				PlayerPrefs.SetInt ("mcqLifestyleHighScore", newhighscore);
				PlayerPrefs.Save ();

			}
		}


		reset();
	}
	// Reset all variables to initial values

	void reset(){

		totalquestionstoask = 5; //change this value to initial value
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

		totalquestionstoask = 5; //change this value to initial value
		correctanswers = 0;
		wronganswers = 0;
		unansweredQuestions = null;
		questions = null;
		SceneManager.LoadScene ("start");


	}
}
