using System;
using System.Collections.Generic;
using System.Linq;
using OpenLiveWriter.Api;

namespace Hunabku.VSPasteResurrected
{
	public class OptionsProperties : IProperties
	{
		private readonly Dictionary<string, object> propertiesBag = new Dictionary<string, object>();

		public string GetString(string name, string defaultValue)
		{
			object value;
			return propertiesBag.TryGetValue(name, out value) ? (value?.ToString() ?? defaultValue) : defaultValue;
		}

		public void SetString(string name, string value)
		{
			propertiesBag[name] = value;
		}

		public int GetInt(string name, int defaultValue)
		{
			object value;
			return propertiesBag.TryGetValue(name, out value) ? Convert.ToInt32(value ?? defaultValue) : defaultValue;
		}

		public void SetInt(string name, int value)
		{
			propertiesBag[name] = value;
		}

		public bool GetBoolean(string name, bool defaultValue)
		{
			object value;
			return propertiesBag.TryGetValue(name, out value) ? Convert.ToBoolean(value ?? defaultValue) : defaultValue;
		}

		public void SetBoolean(string name, bool value)
		{
			propertiesBag[name] = value;
		}

		public float GetFloat(string name, float defaultValue)
		{
			object value;
			return propertiesBag.TryGetValue(name, out value) ? Convert.ToSingle(value ?? defaultValue) : defaultValue;
		}

		public void SetFloat(string name, float value)
		{
			propertiesBag[name] = value;
		}

		public decimal GetDecimal(string name, decimal defaultValue)
		{
			object value;
			return propertiesBag.TryGetValue(name, out value) ? Convert.ToDecimal(value ?? defaultValue) : defaultValue;
		}

		public void SetDecimal(string name, decimal value)
		{
			propertiesBag[name] = value;
		}

		public void Remove(string name)
		{
			propertiesBag.Remove(name);
		}

		public bool Contains(string name)
		{
			return propertiesBag.ContainsKey(name);
		}

		public IProperties GetSubProperties(string name)
		{
			return null;
		}

		public void RemoveSubProperties(string name) {}

		public bool ContainsSubProperties(string name)
		{
			return false;
		}

		public void RemoveAll()
		{
			propertiesBag.Clear();
		}

		public string this[string name]
		{
			get
			{
				return GetString(name, "null");
			}
			set { propertiesBag[name] = value; }
		}

		public string[] Names => propertiesBag.Keys.ToArray();
		public string[] SubPropertyNames => new string[0];
	}
}