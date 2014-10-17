using System;
using System.Collections.Generic;
using System.Text;


using System.IO;


namespace Ltm.Config
{
	public class BaseCfg
	{
		protected string fileName;
		protected Dictionary<string, int> dictHead;
		protected int _count;
		protected string[][] arrCfg;
		public virtual bool Init(string _fileName)
		{
			fileName = _fileName;

            StreamReader sr = new StreamReader(_fileName, Encoding.Default);
            string text = "";
            try
            {
                text = sr.ReadToEnd();
            }
            catch(Exception e)
            {

                return false;
            }
            finally
            {
                sr.Close();
            }
            
//			TextAsset t = (TextAsset)Resources.Load("Config/" + fileName, typeof(TextAsset));
			return Parse(text);
		}
		protected virtual bool Parse(string str)
		{
			//UnityEngine.Debug.Log(str);
			string[] arrLine = str.Split(new string[] { "\r\n" }, StringSplitOptions.None);
			_count = arrLine.Length;
			//UnityEngine.Debug.Log(arrLine[_count - 1]);
			if (string.IsNullOrEmpty(arrLine[_count - 1]))
			{
				_count--;//去掉配置最后一行空白
			}
			arrCfg = new string[_count][];
			for (int i = 0; i < _count; i++)
			{
				arrCfg[i] = arrLine[i].Split("\t"[0]);
			}

			dictHead = new Dictionary<string, int>();
			for (int j = 0; j < arrCfg[0].Length; j++)
			{
				dictHead.Add(arrCfg[1][j], j);
				//UnityEngine.Debug.Log(arrCfg[1][j]);
			}

            return true;
		}
		public virtual int count
		{
			get { return _count - 2; }
		}
		public virtual DataAdapter GetById(int id)
		{
			string strId = id.ToString();
			return GetSingleBy("id", strId);
		}
		public virtual List<DataAdapter> GetByIds(string ids)
		{
			List<DataAdapter> list = new List<DataAdapter>();
			int keyIndex = dictHead["id"];
			for (int i = 0; i < _count; i++)
			{
				if (ids.Contains(arrCfg[i][keyIndex]))
				{
					DataAdapter da = new DataAdapter();
					da.arrStrData = arrCfg[i];
					da.dictHead = dictHead;
					list.Add(da);
				}
			}
			return list;
		}
		public virtual DataAdapter GetSingleBy(string key, string value)
		{
			if (!dictHead.ContainsKey(key))
			{
				throw new Exception("配置【" + fileName + "】不包含键等于【" + key + "】的列");
			}
			int keyIndex = dictHead[key];
			for (int i = 0; i < _count; i++)
			{
				if (arrCfg[i][keyIndex] == value)
				{
					DataAdapter da = new DataAdapter();
					da.arrStrData = arrCfg[i];
					da.dictHead = dictHead;
					return da;
				}
			}
			return null;
		}
		public virtual List<DataAdapter> GetMultiBy(string key, string value)
		{
			if (!dictHead.ContainsKey(key))
			{
				throw new Exception("配置【" + fileName + "】不包含键等于【" + key + "】的列");
			}
			int keyIndex = dictHead[key];
			List<DataAdapter> list = new List<DataAdapter>();
			for (int i = 0; i < _count; i++)
			{
				if (arrCfg[i][keyIndex] == value)
				{
					DataAdapter da = new DataAdapter();
					da.arrStrData = arrCfg[i];
					da.dictHead = dictHead;
					list.Add(da);
				}
			}
			return list;
		}
		public virtual List<DataAdapter> GetMultiBy(string key1, string value1, string key2, string value2)
		{
			if (!dictHead.ContainsKey(key1))
			{
				throw new Exception("配置【" + fileName + "】不包含键等于【" + key1 + "】的列");
			}
			int keyIndex1 = dictHead[key1];
			int keyIndex2 = dictHead[key2];
			List<DataAdapter> list = new List<DataAdapter>();
			for (int i = 0; i < _count; i++)
			{
				if (arrCfg[i][keyIndex1] == value1 && arrCfg[i][keyIndex2] == value2)
				{
					DataAdapter da = new DataAdapter();
					da.arrStrData = arrCfg[i];
					da.dictHead = dictHead;
					list.Add(da);
				}
			}
			return list;
		}
		public virtual List<DataAdapter> GetAll()
		{
			List<DataAdapter> list = new List<DataAdapter>();
			for (int i = 2; i < _count; i++)
			{
				DataAdapter da = new DataAdapter();
				da.arrStrData = arrCfg[i];
				da.dictHead = dictHead;
				list.Add(da);
			}
			return list;
		}
	}
}
