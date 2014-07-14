<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dcTable.aspx.cs" Inherits="dcTable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
<script runat="server" language="C#">
</script>
    <form id="form1" runat="server">
    <div>
    <h4>How many TextBoxes would you like to create?</h4>(<i>Please choose vaule between 1 and 10</i>)<br />
    <asp:textbox runat="Server" id="txtTBCount" Columns="3" />
    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtTBCount"
             MinimumValue="1" MaximumValue="10" Type="Integer"
             ErrorMessage="Make sure that you choose a value between 1 and 10!" />
    <br />
    <asp:button ID="Button1" runat="server" Text="Create Dynamic TextBoxes"/>
	<p>
	<asp:PlaceHolder runat="server" id="phTextBoxesHere" />
	<br />
	</p>
    </div>
    </form>
</body>
</html>
