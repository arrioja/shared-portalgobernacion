<%@ Page Language="c#" %>
<script runat="server">

    private void Page_Load(object sender, System.EventArgs e) {
            int onrow=1;
            int oncol=1;
            int count=1;
            string s ="";
            string set1 = "";
            string set2 = "";
            for (int r=5; r>=0; r--) {
                for (int g=5; g>=0; g--) {
                    for (int b=5; b>=0; b--) {
                        if (oncol==1) s += "<tr>\n";
                        s += "\t<td onmouseover=\"colorOver(this);\" onclick=\"colorClick(this);\" style=\"background-color:"+ReturnHex(r)+ReturnHex(g)+ReturnHex(b)+";\" class=cc></td>\n";
                        oncol++;
                        if (oncol >= 19) {
                            s+="</tr>\n";
                            oncol = 1;
    
                            if (onrow % 2 == 0) {
                                set2 += s;
                            } else {
                                set1 += s;
                            }
                            s = "";
                            onrow++;
                        }
                        count++;
                    }
                }
            }
            Colors.Text = "<table cellpadding=0 cellspacing=1 style=\"background-color:ffffff;\" border=0 >" + set1 + set2 + "</table>";
    }
    
    string ReturnHex(int i) {
            switch (i) {
                default:
                case 0:
                    return "00";
                case 1:
                    return "33";
                case 2:
                    return "66";
                case 3:
                    return "99";
                case 4:
                    return "CC";
                case 5:
                    return "FF";
            }
    }

</script>
<html>
<head>
    <title>Seleccione el Color</title> <style>.cc {
	WIDTH: 10px; HEIGHT: 8px
}
</style>
    <script launguage="JavaScript">
function colorOver(theTD) {
	previewColor(theTD.style.backgroundColor);
	setTextField(theTD.style.backgroundColor);
}
function colorClick(theTD) {
	setTextField(theTD.style.backgroundColor);
	returnColor(theTD.style.backgroundColor);
}
function setTextField(ColorString) {
	document.getElementById("ColorText").value = ColorString.toUpperCase();
}
function returnColor(ColorString) {
	window.returnValue = ColorString;
	window.close();
}
function userInput(theinput) {
	previewColor(theinput.value);
}
function previewColor(theColor) {
	try {
		PreviewDiv.style.backgroundColor = theColor;
	} catch (e) {
	}
}
</script>
</head>
<body style="MARGIN: 2px; BACKGROUND-COLOR: #d4d0c8">
    <form runat="server">
        <table cellspacing="0" cellpadding="0" border="0">
            <tbody>
                <tr>
                    <td colspan="3">
                        <asp:Literal id="Colors" runat="server" EnableViewState="false"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        <input id="ColorText" onkeyup="userInput(this);" style="WIDTH: 60px; HEIGHT: 22px" type="text" name="ColorText" /></td>
                    <td align="middle">
                        <div id="PreviewDiv" style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; BORDER-LEFT: black 1px solid; WIDTH: 50px; BORDER-BOTTOM: black 1px solid; HEIGHT: 20px; BACKGROUND-COLOR: #ffffff">
                        </div>
                    </td>
                    <td align="right">
                        <input id="ColorButton" style="WIDTH: 80px" onclick="returnColor(ColorText.value);" type="button" value="Usar Color" /></td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>
