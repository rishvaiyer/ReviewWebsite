<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="RishIyerProject3.Dashboard" %>

<!DOCTYPE html>
 <link href="https://fonts.googleapis.com/css2?family=Secular+One&display=swap" rel="stylesheet">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
<script src="https://code.jquery.com/jquery-3.2.1.slim.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<link href="https://fonts.googleapis.com/css2?family=IBM+Plex+Sans:wght@300&display=swap" rel="stylesheet">
        <link rel="stylesheet" type="text/css" href="StyleAll.css" />
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <style>
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Panel ID="panelNavRep" runat="server">
            <div class="navRep" runat="server">
                <ul>
                     <li>
  <a href="Dashboard.aspx">
                   All Restaurants
                </a>
                   </li>
                <li><a href="AddRest.aspx">
                    Add Restaraunt
                    </a>
                </li>
                    <li>
                <a href="MyRests.aspx">
                    My Restaraunts
                </a>
                        </li>
                    <li>
                <a href="MakeReservation.aspx">
                    Make Reservation
                </a>
                        </li>
                    <li>
                <a href="ManageReservations.aspx">
                    Manage Reservations
                </a>
                        </li>
                    <li class="float-right">
                        <asp:Label ID="lblLoggedInAs" runat="server" Text=""></asp:Label>
                    </li>
                    <li>
                        <a href="Home.aspx"> Log Off</a>
                    </li>
               </ul>
            </div>
                 </asp:Panel>
           <asp:Panel ID="panelNavReviewer" runat="server">
            <div class="navRep" runat="server">
                <ul>
                     <li>
  <a href="Dashboard.aspx">
                   All Restaurants
                </a>
                   </li>
                <li><a href="AddRest.aspx">
                    Add Restaraunt
                    </a>
                </li>
                    <li>
                <a href="MyReviews.aspx">
                    My Reviews
                </a>
                        </li>
                    <li>
                <a href="MakeReservation.aspx">
                    Make Reservation
                </a>
                        </li>
                    <li>
                <a href="AddReview.aspx">
                  Add Review
                </a>
                        </li>
                    <li class="float-right">
                        <asp:Label ID="lblSignedInAsReviewer" runat="server" Text=""></asp:Label>
                    </li>
                    <li>
                        <a href="Home.aspx"> Log Off</a>
                    </li>
               </ul>
            </div>
               </asp:Panel>
            <asp:Panel ID="panelGuest" runat="server">

     
             <div class="navGuest" runat="server">
               <ul>
                   <li>
  <a href="Dashboard.aspx">
                   All Restaurants
                </a>
                   </li>
                   <li>
  <a href="MakeReservation.aspx">
                    Make Reservation
                </a>
                   </li>
                   <li class="float-right">
<a href="Home.aspx"> Sign Up</a>
                   </li>
               </ul>
               
                
               </div>

                       </asp:Panel>
            </div>



      


        <div class="gvContainer">
            <asp:Label ID="lblTitle" runat="server" Text="All Restaurants" CssClass="lblTitle"></asp:Label>
         <br /><br />
              <asp:Label ID="lblSearch" runat="server" Text="Choose a category to filter restaraunts by type" CssClass="text-primary"> </asp:Label>
           
       
                <asp:DropDownList ID="ddlTypes2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTypes2_SelectedIndexChanged" CssClass="textboxForm">
                     <asp:ListItem Value=""> </asp:ListItem>
            <asp:ListItem Value="American"> American</asp:ListItem>
               <asp:ListItem Value="Steakhouse"> Steakhouse</asp:ListItem>
             <asp:ListItem Value="Chinese"> Chinese</asp:ListItem>
               <asp:ListItem Value="Japanese"> Japanese</asp:ListItem>
             <asp:ListItem Value="Pizza"> Pizza</asp:ListItem>
               <asp:ListItem Value="Mexican"> Mexican</asp:ListItem>
        </asp:DropDownList>
             <asp:DropDownList ID="ddlTypes" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTypes_SelectedIndexChanged" CssClass="textboxForm">
            <asp:ListItem Value="American"> American</asp:ListItem>
               <asp:ListItem Value="Steakhouse"> Steakhouse</asp:ListItem>
             <asp:ListItem Value="Chinese"> Chinese</asp:ListItem>
               <asp:ListItem Value="Japanese"> Japanese</asp:ListItem>
             <asp:ListItem Value="Pizza"> Pizza</asp:ListItem>
               <asp:ListItem Value="Mexican"> Mexican</asp:ListItem>
        </asp:DropDownList>
           <br />
              <asp:Button ID="showMatching" runat="server" OnClick="showMatching_Click" Text="Search" CssClass="btn btn-outline-dark" />
            <asp:GridView ID="gvAllRests" runat="server"  AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" OnSelectedIndexChanged="gvAllRests_SelectedIndexChanged" OnRowCommand="gvAllRests_RowCommand" >
                <Columns>               
                    <asp:BoundField DataField="RestID" HeaderText="ID" Visible="false" />
                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="View Reviews" ShowHeader="True" Text="View Reviews" ControlStyle-CssClass="btn btn-outline-dark" />
                    <asp:ImageField DataImageUrlField="ImgURL" HeaderText="Image" ControlStyle-Width="100" ControlStyle-Height = "100">
<ControlStyle Height="100px" Width="100px"></ControlStyle>
                    </asp:ImageField>
    
                    <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    <asp:BoundField DataField="Type" HeaderText="Category" SortExpression="Type" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                    <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                  
                    <asp:ButtonField ButtonType="Button" CommandName="MakeReservation" HeaderText="Make Reservation" ShowHeader="true" Text="Make Reservation" ControlStyle-CssClass="btn btn-outline-dark" />
                  

                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black"/>
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>


          




            <asp:Button ID="btnSearch" runat="server" Text="Show All Restauraunts" CssClass="btn btn-outline-dark btn-sm btn-block" OnClick="btnSearch_Click" />


        </div>
       
 
    </form>
</body>
</html>

