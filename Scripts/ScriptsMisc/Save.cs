[System.Serializable]

public class Save 
{
    public float[] position = new float[3];
    public int score;

    public Save (FPS_Player player)
    {
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
    public Save (GameManager gameManager)
    {
        score = gameManager.score;
    }
}
