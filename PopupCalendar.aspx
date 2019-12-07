<%@ Page Language="c#" autoeventwireup="false" Inherits="PeterBlum.DateTextBoxWebForms.PopupCalendar" ClientTarget="Uplevel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
    <title>Fecha</title> 
    <meta content="Microsoft Visual Studio 7.0" name="GENERATOR" />
    <meta content="C#" name="CODE_LANGUAGE" />
    <meta content="JavaScript" name="vs_defaultClientScript" />
    <meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
</head>
<body onblur="javascript:self.focus()" leftmargin="0" topmargin="0">
    <form id="Form1" runat="server">
        <table height="100%" cellspacing="0" cellpadding="0" width="100%">
            <tbody>
                <tr>
                    <td valign="center" align="middle">
                        <asp:Calendar id="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged" OnDayRender="Calendar1_DayRender" showtitle="true" SelectionMode="Day" BackColor="#ffffff" FirstDayOfWeek="Monday" BorderColor="#000000" ForeColor="#00000" Height="60" Width="150" Font-Names="Tahoma" Font-Size="8pt" ShowGridLines="True" DayNameFormat="Full">
                            <TodayDayStyle forecolor="White" backcolor="SteelBlue"></TodayDayStyle>
                            <SelectorStyle backcolor="LightSteelBlue"></SelectorStyle>
                            <NextPrevStyle forecolor="White" backcolor="SteelBlue"></NextPrevStyle>
                            <DayHeaderStyle borderwidth="1px" forecolor="Navy" borderstyle="None" bordercolor="Transparent" backcolor="LightSteelBlue"></DayHeaderStyle>
                            <SelectedDayStyle backcolor="LightSteelBlue"></SelectedDayStyle>
                            <TitleStyle forecolor="White" backcolor="SteelBlue"></TitleStyle>
                            <WeekendDayStyle backcolor="AliceBlue"></WeekendDayStyle>
                            <OtherMonthDayStyle forecolor="Silver"></OtherMonthDayStyle>
                        </asp:Calendar>
                    </td>
                </tr>
            </tbody>
        </table>
    </form>
</body>
</html>
