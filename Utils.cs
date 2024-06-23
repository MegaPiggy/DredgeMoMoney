using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Winch.Core;
using System.Reflection;

namespace Mo_Money
{
    public static class Utils
    {
		public static Dictionary<string, float> GetJSON(string filename, Dictionary<string, string> dictionary)
		{
			var folderpath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Configs");
			if (!Directory.Exists(folderpath)) Directory.CreateDirectory(folderpath);

			string filepath = Path.Combine(folderpath, filename + ".json");
			if (File.Exists(filepath))
			{
				try
				{
					return JsonConvert.DeserializeObject<Dictionary<string, float>>(File.ReadAllText(filepath));
				}
				catch (Exception ex)
				{
					WinchCore.Log.Error(string.Format("Error on 'GetJSON' call. Config at '{0}' cannot be read from: {1}", filepath, ex));
				}
			}
			else if (!File.Exists(filepath)) // Generate file
			{
				JObject jobject = new JObject();
				foreach (KeyValuePair<string, string> keyValuePair in dictionary)
				{
					jobject[keyValuePair.Value] = 1.0;
				}
				try
				{
					File.WriteAllText(filepath, jobject.ToString());
					return JsonConvert.DeserializeObject<Dictionary<string, float>>(File.ReadAllText(filepath));
				}
				catch (Exception ex)
				{
					WinchCore.Log.Error(string.Format("Error on 'GetJSON' call. Config at '{0}' cannot be written to: {1}", filepath, ex));
				}
			}
			return new Dictionary<string, float>(0);
		}
	}
}
