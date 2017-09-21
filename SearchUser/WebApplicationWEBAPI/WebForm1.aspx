<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplicationWEBAPI.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="CSS/main.css" rel="stylesheet" />
    <title></title>
    <style type="text/css">
        body {
            background-color:mediumaquamarine;
        }
        .auto-style1 {
            width: 61%;
        }
        .auto-style13 {
            width: 299px;
        }
        .auto-style15 {
            width: 299px;
            height: 21px;
        }
        .auto-style16 {
            width: 567px;
        }
        .auto-style18 {
            width: 567px;
            height: 21px;
        }
        .auto-style19 {
            width: 727px;
        }
        .auto-style21 {
            width: 727px;
            height: 21px;
        }
        .auto-style22 {
            width: 567px;
            height: 26px;
        }
        .auto-style23 {
            width: 299px;
            height: 26px;
        }
        .auto-style24 {
            width: 727px;
            height: 26px;
        }       
    </style>
</head>
<body>    
    <img src="220x200_hotshot-jackpot325.jpg" width="250" height="200" alt="Web sites examples"/>
    <h1>This is table for insert and search.</h1>
    <form id="form1" runat="server">
    <div>
    
        <table class="auto-style1">
            <tr>
                <td class="auto-style16">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserName:</td>
                <td class="auto-style13">
                    <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style22">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; FirstName:</td>
                <td class="auto-style23">
                    <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="auto-style24"></td>
            </tr>
            <tr>
                <td class="auto-style22">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; SurName:</td>
                <td class="auto-style23">
                    <asp:TextBox ID="TextBox3" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="auto-style24"></td>
            </tr>
            <tr>
                <td class="auto-style18">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; UserPassword:</td>
                <td class="auto-style15">
                    <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                </td>
                <td class="auto-style21">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Email:</td>
                <td class="auto-style13">
                    <asp:TextBox ID="TextBox5" runat="server" Width="200px"></asp:TextBox>
                </td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style13">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="AdUser" Width="130px" />
                </td>
                <td class="auto-style19">
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Search" Width="130px" />
                </td>
            </tr>
            <tr>
                <td class="auto-style16">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style19">&nbsp;</td>
            </tr>
        </table>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="283px">
            <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
            <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
            <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
            <RowStyle BackColor="White" ForeColor="#003399" />
            <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SortedAscendingCellStyle BackColor="#EDF6F6" />
            <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
            <SortedDescendingCellStyle BackColor="#D6DFDF" />
            <SortedDescendingHeaderStyle BackColor="#002876" />
        </asp:GridView>
    </form>
    <h2>Place your BETs!</h2>
    <p>Why not write a BET of your own, and have it published here, for the benefit of patients everywhere? We're keen to receive Best Evidence Topic reviews from colleagues all over the world. Use the submission form in the database section, for you to register your intention to write a BET. We'll add your topic to the database, and the world will await your completed review!

A more advanced feature is now available on the BestBETs website - appraisal tool checklists are available for use online or downloading as an aid to the critical appraisal process. We strongly encourage BET authors to submit their critical appraisals of papers in the BET table along with their BET. Visitors to the site can now view critical appraisals independently or link directly from the BET table wherever appears. Further details of BestBETs new features can be found on the 'Site & EBM news' page in the News section.

If you have any comments about BETs or the website, please feel free to contact us.</p>
</body>
</html>
