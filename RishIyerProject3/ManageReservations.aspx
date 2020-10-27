<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageReservations.aspx.cs" Inherits="RishIyerProject3.ManageReservations"  %>

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

            <asp:Label ID="lblTitle" runat="server" Text="Manage Reservations" CssClass="lblTitle"></asp:Label>
            <div class="gvContainer">

                <asp:label ID="lblError" runat="server" text="" CssClass="errorReservation"></asp:label>
            <asp:GridView ID="gvManageReservations" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black"  OnSelectedIndexChanged="gvManageReservations_SelectedIndexChanged" AutoGenerateColumns="False" style="margin-top: 15px" OnRowCommand="gvManageReservations_RowCommand" GridLines="Horizontal" EnableViewState="False" OnRowEditing="gvManageReservations_RowEditing" OnRowUpdating="gvManageReservations_RowUpdating"  OnRowCancelingEdit="gvManageReservations_RowCancelingEdit" Width="1008px">
                <Columns>
                   <asp:BoundField DataField="ReservationID" HeaderText="ID" Visible="false" ReadOnly="true" />
                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Cancel " ShowHeader="True" Text="Cancel" ControlStyle-CssClass="btn btn-outline-dark"  />
                    <asp:BoundField DataField="Name" HeaderText="Restaraunt Name" SortExpression="Name" ReadOnly="True" />
                    <asp:BoundField DataField="Date" HeaderText="Date" SortExpression="Date" />
                     <asp:BoundField DataField="Time" HeaderText="Time" SortExpression="Time" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" SortExpression="FirstName" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" SortExpression="LastName" />
               
                    <asp:CommandField ButtonType="Button" HeaderText="Edit" ShowEditButton="True" ShowHeader="True" ControlStyle-CssClass="btn btn-outline-dark"  />
               
                </Columns>
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="White" Font-Bold="True" ForeColor="Black" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>
            <asp:label ID="display" runat="server" text="" CssClass="displayNoneText"></asp:label>
                 <asp:label ID="updateSuccess" runat="server" text="" CssClass="displayNoneText"></asp:label>
            </div>
               
        </div>
   
    </form>
</body>
</html>

