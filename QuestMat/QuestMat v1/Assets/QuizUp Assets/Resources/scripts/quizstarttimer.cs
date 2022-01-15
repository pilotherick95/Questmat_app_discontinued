using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class quizstarttimer : MonoBehaviour {

	[SerializeField]
	private Text timer;


	void Start(){
		StartCoroutine (delay ());
	}


	IEnumerator delay(){
        timer.text = "5";

        yield return new WaitForSeconds(1);
        timer.text = "4";

        yield return new WaitForSeconds(1);
        timer.text = "3";

        yield return new WaitForSeconds (1);
		timer.text = "2";

		yield return new WaitForSeconds (1);
		timer.text = "1";

		yield return new WaitForSeconds (1);
		timer.text = "GO !";

		startquiz ();

	}
	void startquiz(){

		if (PlayerPrefs.GetString ("Category") == "tfGeneral") {
		
			SceneManager.LoadScene ("tf gk");
		}

		if (PlayerPrefs.GetString ("Category") == "tfMovies") {

			SceneManager.LoadScene ("tf movies");
		}

		if (PlayerPrefs.GetString ("Category") == "tfCaleb") {

			SceneManager.LoadScene ("tf caleb");
		}

		if (PlayerPrefs.GetString ("Category") == "tfSports") {

			SceneManager.LoadScene ("tf sports");
		}

		if (PlayerPrefs.GetString ("Category") == "tfGames") {

			SceneManager.LoadScene ("tf games");
		}

		if (PlayerPrefs.GetString ("Category") == "tfNature") {

			SceneManager.LoadScene ("tf nature");
		}

		if (PlayerPrefs.GetString ("Category") == "tfGeography") {

			SceneManager.LoadScene ("tf geography");
		}

		if (PlayerPrefs.GetString ("Category") == "tfHistory") {

			SceneManager.LoadScene ("tf history");
		}

		if (PlayerPrefs.GetString ("Category") == "tfLifestyle") {

			SceneManager.LoadScene ("tf lifestyle");
		}


		//MCQS 

		if (PlayerPrefs.GetString ("Category") == "mcqGeneral") {

			SceneManager.LoadScene ("mcq gk");
		}

		if (PlayerPrefs.GetString ("Category") == "mcqMovies") {

			SceneManager.LoadScene ("mcq movies");
		}

		if (PlayerPrefs.GetString ("Category") == "mcqCaleb") {

			SceneManager.LoadScene ("mcq caleb");
		}

		if (PlayerPrefs.GetString ("Category") == "mcqSports") {

			SceneManager.LoadScene ("mcq sports");
		}

		if (PlayerPrefs.GetString ("Category") == "mcqGames") {

			SceneManager.LoadScene ("mcq games");
		}

		if (PlayerPrefs.GetString ("Category") == "mcqNature") {

			SceneManager.LoadScene ("mcq nature");
		}

		if (PlayerPrefs.GetString ("Category") == "mcqGeography") {

			SceneManager.LoadScene ("mcq geography");
		}

		if (PlayerPrefs.GetString ("Category") == "mcqHistory") {

			SceneManager.LoadScene ("mcq history");
		}

		if (PlayerPrefs.GetString ("Category") == "mcqLifestyle") {

			SceneManager.LoadScene ("mcq lifestyle");
		}


	}
}
