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
    public static HttpClient client = new HttpClient ();

    public const bool LOAD_FROM_DATABASE = false;

    public static async Task<string> Post (string endpoint, Dictionary<string, string> parameters_dict, string json) {
        return await Post (
            endpoint + JSONHandler.ToParameters (parameters_dict),
            json
        );
    }
    public static async Task<string> Post (string endpoint, string json) {
        try {
            HttpResponseMessage response = await client.PostAsync (
                URL + endpoint,
                new StringContent (json)
            );
            response.EnsureSuccessStatusCode ();
            return await response.Content.ReadAsStringAsync ();
        } catch (Exception ex) {
            return ex.ToString ();
        }
    }

    public static async Task<string> Get (string endpoint, Dictionary<string, string> parameters_dict) {
        return await Get (
            endpoint + JSONHandler.ToParameters (parameters_dict)
        );
    }

    public static async Task<string> Get (string endpoint) {
        try {
            HttpResponseMessage response = await client.GetAsync (
                URL + endpoint
            );
            response.EnsureSuccessStatusCode ();
            return await response.Content.ReadAsStringAsync ();
        } catch (Exception ex) {
            return ex.ToString ();
        }
    }

    public static async Task<string> Create (GalaxyObject galaxy) {
        return await Post (
            "create",
            new Dictionary<string, string> { { "flag", "reset" } },
            galaxy.ToString ()
        );
    }

    public static async Task<string> Create (SystemObject system) {
        return await Post (
            "create",
            new Dictionary<string, string> { { "table", "Systems" } },
            system.ToString ()
        );
    }

    public static async Task<string> Create (PlanetObject planet) {
        return await Post (
            "create",
            new Dictionary<string, string> { { "table", "Planets" } },
            planet.ToString ()
        );
    }

    public static async Task<string> Create (CelestialObject asteroid) {
        return await Post (
            "create",
            new Dictionary<string, string> { { "table", "Asteroids" } },
            asteroid.ToString ()
        );
    }

    public static async Task<string> Create (ShipObject ship) {
        return await Post (
            "create",
            new Dictionary<string, string> { { "table", "Ships" } },
            ship.ToString ()
        );
    }
}