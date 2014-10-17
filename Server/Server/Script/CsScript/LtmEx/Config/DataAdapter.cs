using System;
using System.Collections.Generic;
using System.Text;
//using Server.Pack;

namespace Ltm.Config
{
	/// <summary>
	/// �����ļ�����������
	/// </summary>
	public class DataAdapter
	{
		public string fileName;
		public Dictionary<string, int> dictHead;
		public string[] arrStrData;

		public string stringOf(string key)
		{
			if (!dictHead.ContainsKey(key))
			{
				throw new Exception(fileName + "δ�ҵ��������ݼ���" + key);
			}
			int index = dictHead[key];
			if (index < 0 || index >= arrStrData.Length)
			{
				throw new Exception(fileName + "���ݼ�����������Χ��" + index);
			}
			return arrStrData[index];
		}
		public int intOf(string key)
		{
			string v = stringOf(key);
			return int.Parse(v);
		}
		public float floatOf(string key)
		{
			string v = stringOf(key);
			return float.Parse(v);
		}
/*		public SVector3 vector3Of(string key)
		{
			string v = stringOf(key);
			string[] arr = v.Split("|"[0]);
			if (arr.Length < 3)
			{
				throw new Exception(fileName + "," + v + " ����С��3�����ܵ�vector3��ת��");
			}
			return new SVector3(float.Parse(arr[0]), float.Parse(arr[1]), float.Parse(arr[2]));
		}
		public SVector3 vector2Of(string key)
		{
			string v = stringOf(key);
			string[] arr = v.Split("|"[0]);
			if (arr.Length < 2)
			{
				throw new Exception(fileName + "," + v + " ����С��3�����ܵ�vector2��ת��");
			}
			return new SVector3(float.Parse(arr[0]), float.Parse(arr[1]), 0);
		}*/

		public string[] stringArrayOf(string key)
		{
			return stringOf(key).Split ("|"[0]);
		}

		public int[] intArrayOf(string key)
		{
			string v = stringOf(key);
			string[] arr = v.Split("|"[0]);
			int[] arrInt = new int[arr.Length];
			int count = 0;
			foreach (string s in arr)
			{
				arrInt[count] = int.Parse(s);
				count++;
			}
			return arrInt;
		}
		public float[] floatArrayOf(string key)
		{
			string v = stringOf(key);
			string[] arr = v.Split("|"[0]);
			float[] arrFloat = new float[arr.Length];
			int count = 0;
			foreach (string s in arr)
			{
				arrFloat[count] = float.Parse(s);
				count++;
			}
			return arrFloat;
		}

	}
}
