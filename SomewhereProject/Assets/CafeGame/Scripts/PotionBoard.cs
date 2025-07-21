using UnityEngine;

public class PotionBoard : MonoBehaviour
{
    // define the size of the board
    public int width = 6;
    public int height = 8;

    // define some spacing for the board
    public float spacingX;
    public float spacingY;

    // get a referemce to our potion prefabs
    public GameObject[] potionPrefabs;

    // get a reference to the collection nodes potionBoard + Go
    public Node[,] potionBoard;
    public GameObject potionBoardGo;

    // layoutArray
    public ArrayLayout arrayLayout;

    // public static of potionboard
    public static PotionBoard Instance;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        InitializeBoard();
    }

    void InitializeBoard()
    {
        potionBoard = new Node[width, height];

        spacingX = (float)(width - 1) / 2;
        spacingY = (float)((height - 1) / 2) + 1;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                Vector2 position = new Vector2(x - spacingX, y - spacingY);
                if (arrayLayout.rows[y].row[x])
                {
                    potionBoard[x, y] = new Node(false, null);
                }
                else
                {
                    int randomIndex = Random.Range(0, potionPrefabs.Length);

                    GameObject potion = Instantiate(potionPrefabs[randomIndex], position, Quaternion.identity);
                    potion.GetComponent<Potion>().SetIndicies(x, y);
                    potionBoard[x, y] = new Node(true, potion);
                }

                    
            }
        }
    }


}
