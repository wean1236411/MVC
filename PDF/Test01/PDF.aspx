<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PDF.aspx.cs" Inherits="Test01.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <script>
    function printScreen(printlist) 
{
  var value = printlist.innerHTML;
  var printPage = window.open("", "Printing...", "");
  printPage.document.open();
  printPage.document.write("<HTML><head></head><BODY onload='window.print();window.close()'>");
  printPage.document.write("<PRE>");
  printPage.document.write(value);
  printPage.document.write("</PRE>");
  printPage.document.close("</BODY></HTML>");
  var txt = $("#sfs :selected").text();

}
    </script>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <div>
        <button id="btn" onclick="printScreen(print_parts)">66</button>
    </div>

        <select id="sfs" name="sfsname">
  <option value="1">第一項</option>
  <option value="2">第二項</option>
  <option value="3">第三項</option>
</select>
    </form>
</body>
</html>
