using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

public static class DatabaseHandler {

    public const string URL = "https://bitnaughts.azurewebsites.net/api/";

    public static async Task<string> Post (string endpoint, Dictionary<string, string> parameters) {
        string responseInString = "";
        HttpClient client = new HttpClient ();
        HttpResponseMessage response = await client.PostAsync (
            URL + endpoint,
            new StringContent (
                JSONHandler.ToJSON (parameters)
            )
        );
        return await response.Content.ReadAsStringAsync ();

        // response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        // response.EnsureSuccessStatusCode();

        // using (var wb = new WebClient ()) {
        //     string full_endpoint = URL + endpoint;
        //     var data = new NameValueCollection ();
        //     data["values"] = new string[];

        //     foreach (KeyValuePair<string, string> pair in parameters) {
        //         data["values"] += pair.Value;
        //     }

        //     var response = wb.UploadValues (full_endpoint, "post", data);
        //     responseInString = Encoding.UTF8.GetString (response);
        // }
        // return responseInString;
    }

    public static string Get (string endpoint, Dictionary<string, string> parameters) {

        string full_endpoint = URL + endpoint + "?";
        List<string> parameter_pairs = new List<string> ();

        foreach (KeyValuePair<string, string> pair in parameters) {
            parameter_pairs.Add (pair.Key + "=" + pair.Value);
        }

        full_endpoint += String.Join (
            "&",
            parameter_pairs.ToArray ()
        );

        return Get (full_endpoint);
    }

    public static string Get (string endpoint) {
        string response = "";
        using (var client = new WebClient ()) {
            response = client.DownloadString (endpoint);
        }
        return response;
    }

    public static string Create (GalaxyObject galaxy) {
        Task<string> call = Post (
            "create?table=Galaxies",
            new Dictionary<string, string> { { "id", galaxy.id.ToString () },
                { "seed", galaxy.seed.ToString () }
            }
        );
        call.Wait ();
        return call.Result;
    }
    public static string Create (SystemObject system) {
        Task<string> call = Post (
            "create?table=Systems",
            new Dictionary<string, string> { { "id", system.id.ToString () },
                { "seed", system.seed.ToString () }
            }
        );
        call.Wait ();
        return call.Result;
    }
    public static string Create (PlanetObject planet) {
        Task<string> call = Post (
            "create?table=Planets",
            new Dictionary<string, string> { { "id", planet.id.ToString () },
                { "seed", planet.seed.ToString () }
            }
        );
        call.Wait ();
        return call.Result;
    }
    public static string Create (CelestialObject asteroid) {
        Task<string> call = Post (
            "create?table=Asteroids",
            new Dictionary<string, string> { { "id", asteroid.id.ToString () },
                { "seed", asteroid.seed.ToString () },
                { "size", asteroid.hitpoints.ToString () }
            }
        );
        call.Wait ();
        return call.Result;
    }
    public static string Create (ShipObject ship) {
        Task<string> call = Post (
            "create?table=Ships",
            new Dictionary<string, string> { { "id", ship.id.ToString () },
                { "seed", ship.seed.ToString () },
                { "position_x", ship.motion_handler.position.X.ToString () },
                { "position_y", ship.motion_handler.position.Y.ToString () }
            }
        );
        call.Wait ();
        return call.Result;
    }
}