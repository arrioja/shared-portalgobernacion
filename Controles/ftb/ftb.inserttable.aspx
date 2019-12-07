<%@ Page Language="c#" %>
<script runat="server">

    private void Page_Load(object sender, System.EventArgs e) {
    }

</script>
<!doctype html public "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
    <title>Insertar Tabla</title> 
    <meta http-equiv="Expires" content="0" />
    <style>

body {
	margin: 0px 0px 0px 0px;
	padding: 0px 0px 0px 0px;
	background: #ffffff;
	width: 100%;
	overflow:hidden;
	border: 0;
}

body,tr,td {
	color: #000000;
	font-family: Verdana, Arial, Helvetica, sans-serif;
	font-size: 10pt;
}
</style>
    <script language="javascript">
function returnTable() {
	var arr = new Array();

	arr["width"] = document.getElementById('Width').value;
	arr["height"] = document.getElementById('Height').value;
	arr["cellpadding"] = document.getElementById('Cellpadding').value;
	arr["cellspacing"] = document.getElementById('Cellspacing').value;
	arr["border"] = document.getElementById('Border').value;

	arr["cols"] = document.getElementById('Columns').value;
	arr["rows"] = document.getElementById('Rows').value;
	arr["valigncells"] = document.getElementById('VAlignCells')[document.getElementById('VAlignCells').selectedIndex].value;
	arr["haligncells"] = document.getElementById('HAlignCells')[document.getElementById('HAlignCells').selectedIndex].value;
	arr["percentcols"] = document.getElementById('PercentCols').checked;

	window.returnValue = arr;
	window.close();
}
</script>
</head>
<body>
    <table cellspacing="3" cellpadding="1" width="100%" border="0">
        <tbody>
            <tr>
                <td valign="top">
                    <fieldset>
                        <legend>Tabla</legend>
                        <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        Ancho</td>
                                    <td>
                                        <input id="Width" style="WIDTH: 50px" type="text" value="100" name="Width" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Altura</td>
                                    <td>
                                        <input id="Height" style="WIDTH: 50px" type="text" value="100" name="Height" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Cellpadding</td>
                                    <td>
                                        <input id="Cellpadding" style="WIDTH: 50px" type="text" value="0" name="Cellpadding" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Cellspacing</td>
                                    <td>
                                        <input id="Cellspacing" style="WIDTH: 50px" type="text" value="0" name="Cellspacing" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Borde</td>
                                    <td>
                                        <input id="Border" style="WIDTH: 50px" type="text" value="1" name="Border" /></td>
                                </tr>
                            </tbody>
                        </table>
                    </fieldset>
                </td>
                <td>
                    &nbsp;&nbsp;</td>
                <td valign="top">
                    <fieldset>
                        <legend>Celdas</legend>
                        <table height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        Columnas</td>
                                    <td>
                                        <input id="Columns" style="WIDTH: 50px" type="text" value="2" name="Columns" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        Lineas</td>
                                    <td>
                                        <input id="Rows" style="WIDTH: 50px" type="text" value="2" name="Rows" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        VAlign</td>
                                    <td>
                                        <select id="VAlignCells" style="WIDTH: 50px" name="VAlignCells">
                                            <option selected="selected">
                                            </option>
                                            <option value="top">Top</option>
                                            <option value="center">Center</option>
                                            <option value="bottom">Bottom</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        HAlign</td>
                                    <td>
                                        <select id="HAlignCells" style="WIDTH: 50px" name="HAlignCells">
                                            <option selected="selected">
                                            </option>
                                            <option value="left">Left</option>
                                            <option value="center">Center</option>
                                            <option value="right">Right</option>
                                        </select>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Percent Cols</td>
                                    <td>
                                        <input id="PercentCols" type="checkbox" value="1" name="PercentCols" /></td>
                                </tr>
                            </tbody>
                        </table>
                    </fieldset>
                </td>
            </tr>
            <tr>
                <td align="middle" colspan="3">
                    <input onclick="returnTable();return false;" type="button" value="Insertar Tabla" />
                </td>
            </tr>
        </tbody>
    </table>
</body>
</html>
