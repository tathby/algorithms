namespace AlgoPortfolio.Implements;

using System;
public class Map
{
    private readonly string[,] tiles;
    private readonly int rows;
    private readonly int cols;

    public Map(int rows, int cols)
    {
        this.rows = rows;
        this.cols = cols;
        tiles = new string[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                tiles[i, j] = $"Tile({i},{j})";
            }
        }
    }

    public string GetTile(int row, int col)
    {
        if (row < 0 || row >= rows || col < 0 || col >= cols)
            throw new ArgumentOutOfRangeException("Invalid tile coordinates.");

        return tiles[row, col];
    }
    public void SetTile(int row, int col, string value)
    {
        if (row < 0 || row >= rows || col < 0 || col >= cols)
            throw new ArgumentOutOfRangeException("Invalid tile coordinates.");

        tiles[row, col] = value;
    }


    public int Rows => rows;
    public int Cols => cols;
}