using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

using Newtonsoft.Json;
using XQH.EasyUi.Entity;

/// <summary>
/// �Ѷ���ת����JSON����
/// </summary>
public class JsonConvert<T>
{   

    //------jquery ui tree json data------
    //------���ڵ�ֻ֧�� id,text,children,attributes,checked,state,iconCls������
    //[
    //    {
    //        "id":"01",
    //        "text":"ϵͳ����",
    //        "parentid":"0",
    //        "attributes":"",
    //        "children":
    //        [
    //            {
    //                "id":"0101",
    //                "text":"ģ�����",
    //                "parentid":"01",
    //                "attributes":"web/modulemanage.aspx"
    //            }
    //        ]
    //    }
    //]

    //------jquery ui datagrid json data------
    //{                                                      
    //    "total":5,                                                      
    //    "rows":[                                                          
    //        {"RoleId":"001","RoleName":"Name 1","RoleDes":"Address 11"},
    //        {"RoleId":"002","RoleName":"Name 1","RoleDes":"Address 11"},
    //        {"RoleId":"003","RoleName":"Name 1","RoleDes":"Address 11"},
    //        {"RoleId":"004","RoleName":"Name 1","RoleDes":"Address 11"},
    //        {"RoleId":"005","RoleName":"Name 1","RoleDes":"Address 11"}     
    //    ]                                                          
    //}
 
    //------jquery ui flag json data------
    //{
    //    "Flag":[{"Status":"1"}]
    //}

    /// <summary>
    ///ϵͳ���ڵ�����
    /// </summary>
    /// <param name="lsC">����Ϣ</param>
    /// <param name="lsP">����Ϣ</param>
    /// <returns></returns>
    public StringBuilder ToTreeNode(List<T> lsC,List<T> lsP)
    {
        StringBuilder jsonData = new StringBuilder();

        jsonData.Append("[");
        jsonData.Append(JavaScriptConvert.SerializeObject(lsP[0]).ToLower());
        jsonData.Replace("}", ",");
        jsonData.Append("\"children\":[");

        foreach (T item in lsC)
        {
            string jsonGroup = JavaScriptConvert.SerializeObject(item);
            jsonData.Append(jsonGroup.ToLower());
            jsonData.Append(",");
        }

        //ȥ��ĩβ��,����
        if (lsC.Count > 0)
            jsonData = jsonData.Remove(jsonData.Length - 1, 1);

        jsonData.Append("]}]");
        jsonData.Replace("functionname", "text");
        jsonData.Replace("url", "attributes");

        return jsonData;
    }

    public StringBuilder ToCheckedTreeNode(List<T> lsC, List<string> lsP)
    {
        StringBuilder jsonData = new StringBuilder();

        jsonData.Append("[{");

        foreach (string str in lsP)
        {
            jsonData.Append("\"id\":");
            jsonData.Append("0");
            jsonData.Append(",");
            jsonData.Append("\"text\":");
            jsonData.Append(str);
            jsonData.Append(",");
            jsonData.Append("\"children\":[");
        }

        return jsonData;
    }

    /// <summary>
    /// ת����datagrid��ʽ������
    /// </summary>
    /// <param name="ls">���ݼ���</param>
    /// <param name="total">����</param>
    /// <returns></returns>
    public StringBuilder ToDataGrid(List<T> ls,int total)
    {
        StringBuilder jsonData = new StringBuilder();

        jsonData.Append("{");
        jsonData.Append("\"total\":");
        jsonData.Append(total);
        jsonData.Append(",");
        jsonData.Append("\"rows\":");
        jsonData.Append("[");

        foreach (T item in ls)
        {
            string jsonGroup = JavaScriptConvert.SerializeObject(item);
            jsonData.Append(jsonGroup);
            jsonData.Append(",");
        }

        if (ls.Count > 0)
            jsonData = jsonData.Remove(jsonData.Length - 1, 1);

        jsonData.Append("]}");

        return jsonData;
    }

    /// <summary>
    /// ת����״̬��ʽ��JSON����
    /// </summary>
    /// <param name="status"></param>
    /// <returns></returns>
    public StringBuilder ToStatus(int status)
    {
        StringBuilder jsonData = new StringBuilder();

        jsonData.Append("{");
        jsonData.Append("\"Flag\":");
        jsonData.Append("[{");
        jsonData.Append("\"Status\":");
        jsonData.Append(status);
        jsonData.Append("}]");
        jsonData.Append("}");
        return jsonData;
    }

}


