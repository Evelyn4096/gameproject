using UnityEngine;
using Mono.Data.Sqlite;
using System;
using Unity.VisualScripting.Dependencies.Sqlite;
using System.Data;

public class DatabaseManager : MonoBehaviour
{
    private string dbName = "URI=file:RecipeList.db";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RunNonQuery("CREATE TABLE IF NOT EXISTS recipes (ice INT, sugar INT, complexity INT, tapioka INT, coffeeJelly INT, cookieCrumble INT)");
    }

    void RunNonQuery(string line)
    {
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = line;
                command.ExecuteNonQuery();
            }

            connection.Close();
        }
    }
    
    public Order GetRecipe()
    {
        Order order = null;
        using (var connection = new SqliteConnection(dbName))
        {
            connection.Open();

            using (var command = connection.CreateCommand())
            {
                command.CommandText = "SELECT RANDOM FROM recipes;";
                using (IDataReader reader = command.ExecuteReader())
                {
                    order = new Order();
                    while (reader.Read())
                        order.blended = (bool)reader["blended"];
                        order.coffeeJelly = (int)reader["coffeeJelly"];
                        order.tapioka = (int)reader["tapioka"];
                        order.sugar = (int)reader["sugar"];
                        order.ice = (int)reader["ice"];
                        order.cookieCrumble = (int)reader["cookieCrumble"];
                        order.flavour = (string)reader["flavour"];
                    reader.Close();
                }
            }

            connection.Close();
        }
        return order;
    }
}
