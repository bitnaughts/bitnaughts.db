using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

public static class DatabaseHandler {

    /* 
        Handles all local and cloud data fetching
    */

    private static readonly HttpClient client = new HttpClient ();

    public const string URL = "https://bitnaughts.azurewebsites.net/api/";

    public static void InitializeClient () {
        // if (client == null) client ;
    }

    public static async Task<string> Post (string endpoint, Dictionary<string, string> parameters) {
        
        InitializeClient ();

        var content = new FormUrlEncodedContent (parameters);
        var response = await client.PostAsync (URL + endpoint, content);
        return await response.Content.ReadAsStringAsync();
    }

    public static bool AddGalaxy (GalaxyObject galaxy) {
        Post (
            "add/galaxy",
            new Dictionary<string, string> { 
                { "id", galaxy.seed.ToString() },
                { "seed", galaxy.seed.ToString() }
            }
        );
        return true;
    }
    
}