<%@ WebService Language="C#" Class="NumericUpDown1" %>
using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
[System.Web.Script.Services.ScriptService]
public class NumericUpDown1 : System.Web.Services.WebService
{
 [WebMethod]
 public int Up(int current, string tag)
 {
 if (current <= 536870912)
 {
 return current * 2;
 }
 else
 {
 return current;
 }
 }
 [WebMethod]
 public int Down(int current, string tag)
 {
 if (current >= 2)
 {
 return (int)(current / 2);
 }
 else
 {
 return current;
 };
 }
}