using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class categoriesscenechanger : MonoBehaviour {

	/////////////////////TF Categories ///////////////////////////////////	


	public void tfgeneral(){

		PlayerPrefs.SetString ("Category", "tfGeneral");
		PlayerPrefs.Save ();
		SceneManager.LoadScene ("timerscene");
	
	}

	public void tfmovies(){

		PlayerPrefs.SetString ("Category", "tfMovies");
		PlayerPrefs.Save ();
		SceneManager.LoadScene("timerscene");

	}

	public void tfcaleb(){

		SceneManager.LoadScene("timerscene");
		PlayerPrefs.SetString ("Category", "tfCaleb");
		PlayerPrefs.Save ();

	}

	public void tfsports(){

		SceneManager.LoadScene("timerscene");
		PlayerPrefs.SetString ("Category", "tfSports");
		PlayerPrefs.Save ();

	}

	public void tfgames(){

		SceneManager.LoadScene("timerscene");
		PlayerPrefs.SetString ("Category", "tfGames");
		PlayerPrefs.Save ();

	}

	public void tfnature(){

		SceneManager.LoadScene("timerscene");
		PlayerPrefs.SetString ("Category", "tfNature");
		PlayerPrefs.Save ();

	}

	public void tfgeography(){

		SceneManager.LoadScene("timerscene");
		PlayerPrefs.SetString ("Category", "tfGeography");
		PlayerPrefs.Save ();

	}

	public void tfhistory(){

		SceneManager.LoadScene("timerscene");
		PlayerPrefs.SetString ("Category", "tfHistory");
		PlayerPrefs.Save ();

	}


	public void tflifestlye(){

		SceneManager.LoadScene("timerscene");
		PlayerPrefs.SetString ("Category", "tfLifestyle");
		PlayerPrefs.Save ();

	}


	// MCQ Categories //////////////////////////////////////////////////////////////////////////// 

	public void mcqgeneral(){

		SceneManager.LoadScene("timerscene");
		PlayerPrefs.SetString ("Category", "mcqGeneral");
		PlayerPrefs.Save ();

	}

	public void mcqhollywood(){

		SceneManager.LoadScene("timerscene");
		PlayerPrefs.SetString ("Category", "mcqMovies");
		PlayerPrefs.Save ();

	}

	public void mcqcaleb(){

		SceneManager.LoadScene("timerscene");
		PlayerPrefs.SetString ("Category", "mcqCaleb");
		PlayerPrefs.Save ();

	}

	public void mcqsports(){

		SceneManager.LoadScene("timerscene");
		PlayerPrefs.SetString ("Category", "mcqSports");
		PlayerPrefs.Save ();
	}

	public void mcqgames(){

		SceneManager.LoadScene("timerscene");
		PlayerPrefs.SetString ("Category", "mcqGames");
		PlayerPrefs.Save ();

	}

	public void mcqnature(){

		SceneManager.LoadScene("timerscene");
		PlayerPrefs.SetString ("Category", "mcqNature");
		PlayerPrefs.Save ();

	}

	public void mcqgeography(){

		SceneManager.LoadScene("timerscene");
		PlayerPrefs.SetString ("Category", "mcqGeography");
		PlayerPrefs.Save ();

	}

	public void mcqhistory(){

		SceneManager.LoadScene("timerscene");
		PlayerPrefs.SetString ("Category", "mcqHistory");
		PlayerPrefs.Save ();

	}


	public void mcqlifestlye(){

		SceneManager.LoadScene("timerscene");
		PlayerPrefs.SetString ("Category", "mcqLifestyle");
		PlayerPrefs.Save ();

	}
		
	public void mcqMovies(){

		SceneManager.LoadScene("timerscene");
		PlayerPrefs.SetString ("Category", "mcqMovies");
		PlayerPrefs.Save ();

	}


	public void mcqrandom(){

		int randomindex = Random.Range (1,10);

		if (randomindex == 1)
			mcqgeneral ();
		
		else if (randomindex == 2)
			mcqcaleb ();

		else if (randomindex == 3)
			mcqsports ();

		else if (randomindex == 4)
			mcqgames ();

		else if (randomindex == 5)
			mcqnature ();

		else if (randomindex == 6)
			mcqgeneral ();

		else if (randomindex == 7)
			mcqhistory ();

		else if (randomindex == 8)
			mcqlifestlye ();

		else if (randomindex == 9)
			mcqcaleb ();
	}


	public void tfrandom(){

		int randomindex = Random.Range (1,10);

		if (randomindex == 1)
			tfgeneral ();

		else if (randomindex == 2)
			tfcaleb ();

		else if (randomindex == 3)
			tfsports ();

		else if (randomindex == 4)
			tfgames ();

		else if (randomindex == 5)
			tfnature ();

		else if (randomindex == 6)
			tfgeneral ();

		else if (randomindex == 7)
			tfhistory ();

		else if (randomindex == 8)
			tflifestlye ();

		else if (randomindex == 9)
			tfcaleb ();
	}
}
