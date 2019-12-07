<%@ Page Language="C#" ValidateRequest=false Trace="false" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<script runat="server">

protected void Page_Load(Object Src, EventArgs E) {

	if (!IsPostBack) {
		FreeTextBox1.StylesMenuNames = new string[] {"style 1", "style 2"};
		FreeTextBox1.StylesMenuList = new string[] {"style1", "style2"};
		FreeTextBox1.Text = "<p>some <b>Bold</b> and <u>underlined</u> and <font color=\"#008000\">colored</font> text<p><ul><li>bulleted list 1</li></ul>";
	}

}

protected void SaveButton_Click(Object Src, EventArgs E) {

	Output.Text = FreeTextBox1.Text;
}


</script>
<html>
<head>
	<title>Example 2 - external files</title>
<script>

</script>
</head>
<body>

    <form runat="server">
    	
    	<h2><a href="javascript:document.location.href=document.location.href"><span style="color:green;">Free</span>TextBox</a></h2>

		<div>
    	    	    		
		<FTB:FreeTextBox id="FreeTextBox1" OnSaveClick="SaveButton_Click" 
			JavaScriptLocation="ExternalFile" 
			ButtonImagesLocation="ExternalFile"
			ToolbarImagesLocation="ExternalFile"
			SupportFolder="~/aspnet_client/FreeTextBox/" 
			Focus=true
			runat="Server" />
		
		<asp:Button id="SaveButton" Text="Save" onclick="SaveButton_Click" runat="server" />		
		</div>
		
		<div style="display:none;">
			<textarea id="debug" name="debug" style="width:500px; height: 250px;">Debug text area
			</textarea>			
		</div>
		
		<div>		
			<asp:Literal id="Output" runat="server" />			
		</div>
		
		<a href="javascript:FTB_API['FreeTextBox1'].Focus();void(0);">test focus</a>
		
	</form>
</body>
</html>
