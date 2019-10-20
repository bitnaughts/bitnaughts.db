using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

public static class JSONHandler {
    public static string ToJSON (Dictionary<string, string> dict) {
        return String.Format (
            "{{0}}",
            String.Join (
                ",\n",
                dict.Select (x => "\"" + x.Key + "\"=\"" + x.Value + "\"")
            )
        );
    }
}