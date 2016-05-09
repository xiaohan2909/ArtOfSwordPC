using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
//语言切换类全局唯一
public class LanguageScript  {

	public static LanguageScript Instance= new LanguageScript();
	public XmlDocument doc;
	private Dictionary<string, string> textDictionary;
	public bool isChinese=true;
	//构造函数
	public LanguageScript(){
		iniRead();
	}
	public void changLanguage(){
		isChinese = !isChinese;
		iniRead();
	}
	private void iniRead(){
		string filePath;
		if(isChinese)
			//filePath= Application.dataPath+"/Resources/zh-cn.xml";
			filePath= "zh-cn";
		else
			filePath="en";

		doc = new XmlDocument();
		doc.LoadXml(Resources.Load(filePath).ToString());
		textDictionary= new Dictionary<string, string >();
		//textDictionary = new Dictionary<string, string >();
		//获取根节点
		XmlElement rootElem = doc.DocumentElement;
		//获取ui子节点集合
		XmlNodeList uiKeyPairs = rootElem.GetElementsByTagName("ui");
		//装载键值对
		foreach(XmlNode node in uiKeyPairs){
			textDictionary.Add( ((XmlElement)node).GetAttribute("name"),( (XmlElement)node).InnerText);
		}
	}
	public string getKeyValue(string key){
		if(!textDictionary.ContainsKey(key)){
			return "null";
		}
		return textDictionary[key];
	}


}
