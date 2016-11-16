using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GM : MonoBehaviour {

    public int lives = 3;
    
    public float resetDelay = 1f;
    public Text livesText;
    public GameObject gameOver;
    public GameObject youWOn;
    public GameObject paddle;
    public GameObject deathParticals;
    public GameObject Ball;
    public static GM instance = null;

    //BrickLoader objects
    public GameObject brickPrefab;
    public int rows;
    public int cols;
    private GameObject cube;
    private float colHalf;
    private float rowHalf;
    private int bricks;
    private float brickXsize;
    private float brickYsize;
    private float brickSpaces;
    public float brickSpaceRatio;

    private GameObject clonePaddle;
    private GameObject cloneBall;

	// Use this for initialization
	void Start () {

        
       // Debug.Log(colHalf);
        bricks = cols * rows;
        brickSpaces = brickSpaceRatio / ((rows * rows)/2) ;
        Debug.Log(brickSpaces); 
        brickXsize = (18.5f - (cols + 2) * brickSpaces) / cols;
        brickYsize = (9 - (rows + 2) * brickSpaces) / rows;
        colHalf = (((brickXsize + brickSpaces) * cols) / 2) - ((brickXsize / 2) + brickSpaces / 2 );
        rowHalf = (((brickYsize + brickSpaces) * rows) / 2) - ((brickYsize / 2) + brickSpaces / 2);



        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        Setup();

	}
	
        public void Setup()
    {
        SetupPaddle();

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
        
               //Instantiate(WhiteCube, new Vector3(col * 3, row, 0), Quaternion.identity);
                cube = Instantiate(brickPrefab);
                cube.transform.position = new Vector3(((brickXsize + brickSpaces) * col ) - colHalf, ((brickYsize + brickSpaces) * row) - rowHalf, 0);
                cube.transform.localScale = new Vector3(brickXsize, brickYsize, 1);
                cube.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value);
                //Debug.Log(cube.transform.position);
                // Debug.Log(col);
                // Debug.Log(row);
                //Instantiate(prefab, new Vector3(i * 2.0f, 0, 0), Quaternion.identity);
            }
        }

    }    

    void CheckGamerOver()
    {
        if (bricks < 1)
        {
            youWOn.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);
        }

        if (lives < 1)
        {
            gameOver.SetActive(true);
            Time.timeScale = .25f;
            Invoke("Reset", resetDelay);

        }
    }

    void Reset()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);

    }

    public void LoseLife()
    {

        lives--;
        livesText.text = "Lives: " + lives;
        Instantiate(deathParticals, clonePaddle.transform.position, Quaternion.identity);
        Destroy(clonePaddle);
        Destroy(cloneBall);
        Invoke("SetupPaddle", resetDelay);
        CheckGamerOver();

    }

    void SetupPaddle()
    {

        clonePaddle = Instantiate(paddle, transform.position = new Vector3(0, -13, 0), Quaternion.identity) as GameObject;
        cloneBall = Instantiate(Ball, transform.position = new Vector3(0, -9, 0), Quaternion.identity) as GameObject;

    }

    public void DestroyBrick()
    {

        bricks--;
        CheckGamerOver();

    }

	// Update is called once per frame
	void Update () {
	
	}
}
